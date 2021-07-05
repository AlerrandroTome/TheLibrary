using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheLibrary.Core.DTOs.User;
using TheLibrary.Core.Entities;
using TheLibrary.Core.Interfaces;
using TheLibrary.Infrastructure.UnitOfWork;

namespace TheLibrary.Application.Services
{
    public class ManageUserService : IManageUserService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public ManageUserService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task BlockUser(Guid userId, Guid loggedUserId)
        {
            var user = await _uow.Repository<User>().Get(w => w.Id == userId);
            user.Active = false;
            await _uow.Repository<User>().Update(user);
        }

        public async Task Create(UserCreateDTO dto)
        {
            var entity = _mapper.Map<User>(dto);

            foreach (var address in dto.Addresses)
            {
                var entityAddress = _mapper.Map<UserAddress>(address);
                entityAddress.UserId = entity.Id;
                entity.Addresses.Add(entityAddress);
            }

            await _uow.Repository<User>().Create(entity);
        }

        public async Task Delete(Guid id)
        {
            var entity = await _uow.Repository<User>().Get(w => w.Id == id, new[] { "Addresses" });

            await _uow.Repository<UserAddress>().DeleteRange(entity.Addresses.ToList());
            await _uow.Repository<User>().Delete(entity);
        }

        public IQueryable<User> Get() => _uow.Repository<User>().GetAll();

        public async Task<User> Update(UserUpdateDTO dto)
        {
            var entity = await _uow.Repository<User>().Get(w => w.Id == dto.Id, new[] { "Addresses" });

            foreach (var address in entity.Addresses)
            {
                await _uow.Repository<UserAddress>().Delete(address);
            }

            entity = _mapper.Map(dto, entity);
            entity.Addresses = new List<UserAddress>();

            foreach(var address in dto.Addresses)
            {
                var newEntity = _mapper.Map<UserAddress>(address);
                newEntity.UserId = entity.Id;
                await _uow.Repository<UserAddress>().Create(newEntity);
            }

            await _uow.Repository<User>().Update(entity);

            return entity;
        }
    }
}
