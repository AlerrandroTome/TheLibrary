using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheLibrary.Core.DTOs.User;
using TheLibrary.Core.Entities;
using TheLibrary.Core.Interfaces;
using TheLibrary.Infrastructure.Data.Context;
using TheLibrary.Infrastructure.Entities;
using TheLibrary.Infrastructure.UnitOfWork;

namespace TheLibrary.Application.Services
{
    public class ManageUserService : IManageUserService
    {
        private readonly LibraryContext _context;
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public ManageUserService(LibraryContext context, IUnitOfWork uow, IMapper mapper)
        {
            _context = context;
            _uow = uow;
            _mapper = mapper;
        }

        public async Task BlockUser(Guid userId, Guid loggedUserId)
        {
            var user = await _uow.Repository<User>(_context).Get(w => w.Id == userId);
            user.Active = false;
            await _uow.Repository<User>(_context).Update(user);
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

            await _uow.Repository<User>(_context).Create(entity);
        }

        public async Task Delete(Guid id)
        {
            var entity = await _uow.Repository<User>(_context).Get(w => w.Id == id, new[] { "Addresses" });

            _context.RemoveRange(entity.Addresses);
            await _uow.Repository<User>(_context).Delete(entity);
        }

        public IQueryable<User> Get() => _uow.Repository<User>(_context).GetAll();

        public async Task<User> Update(UserUpdateDTO dto)
        {
            var entity = await _uow.Repository<User>(_context).Get(w => w.Id == dto.Id, new[] { "Addresses" });

            foreach (var address in entity.Addresses)
            {
                _context.Remove(address);
            }

            entity = _mapper.Map(dto, entity);
            entity.Addresses = new List<UserAddress>();

            foreach(var address in dto.Addresses)
            {
                var newEntity = _mapper.Map<UserAddress>(address);
                newEntity.UserId = entity.Id;
                _context.Add(newEntity);
            }

            await _uow.Repository<User>(_context).Update(entity);

            return entity;
        }
    }
}
