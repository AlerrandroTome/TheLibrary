using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheLibrary.Core.DTOs.Response;
using TheLibrary.Core.DTOs.User;
using TheLibrary.Core.Entities;
using TheLibrary.Core.Interfaces;
using TheLibrary.Infrastructure.Data.Context;
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

        public async Task<Response<Guid>> BlockUser(Guid userId, Guid loggedUserId)
        {
            var user = await _uow.Repository<User>(_context).Get(w => w.Id == userId);
            user.Active = false;
            await _uow.Repository<User>(_context).Update(user);
            var response = new Response<Guid>();
            response.Data = userId;
            return response;
        }

        public async Task<Response<User>> Create(UserCreateDTO dto)
        {
            var entity = _mapper.Map<User>(dto);

            foreach (var address in dto.Addresses)
            {
                var entityAddress = _mapper.Map<UserAddress>(address);
                entityAddress.UserId = entity.Id;
                entity.Addresses.Add(entityAddress);
            }

            var response = new Response<User>();
            response.Data = await _uow.Repository<User>(_context).Create(entity);
            return response;
        }

        public async Task<Response<Guid>> Delete(Guid id)
        {
            var entity = await _uow.Repository<User>(_context).Get(w => w.Id == id, new[] { "Addresses" });

            _context.RemoveRange(entity.Addresses);
            await _uow.Repository<User>(_context).Delete(entity);
            var response = new Response<Guid>();
            response.Data = entity.Id;
            return response;
        }

        public IQueryable<User> Get() => _uow.Repository<User>(_context).GetAll();

        public async Task<Response<User>> Update(UserUpdateDTO dto)
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

            var response = new Response<User>();
            response.Data = await _uow.Repository<User>(_context).Update(entity);

            return response;
        }
    }
}
