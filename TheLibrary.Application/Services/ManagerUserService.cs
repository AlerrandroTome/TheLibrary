using AutoMapper;
using System;
using System.Linq;
using System.Threading.Tasks;
using TheLibrary.Application.Interfaces;
using TheLibrary.Domain.Entities;
using TheLibrary.Infrastructure.Data.Context;
using TheLibrary.Infrastructure.DTOs.User;
using TheLibrary.Infrastructure.UnitOfWork;

namespace TheLibrary.Application.Services
{
    public class ManagerUserService : IManagerUserService
    {
        private readonly LibraryContext _context;
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public ManagerUserService(LibraryContext context, IUnitOfWork uow, IMapper mapper)
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
            await _uow.Repository<User>(_context).Create(entity);
        }

        public async Task Delete(Guid id)
        {
            var entity = await _uow.Repository<User>(_context).Get(w => w.Id == id);
            await _uow.Repository<User>(_context).Delete(entity);
        }

        public IQueryable<User> Get() => _uow.Repository<User>(_context).GetAll();

        public async Task<User> Update(UserUpdateDTO dto)
        {
            var entity = await _uow.Repository<User>(_context).Get(w => w.Id == dto.Id);
            entity = _mapper.Map(dto, entity);
            await _uow.Repository<User>(_context).Update(entity);
            return entity;
        }
    }
}
