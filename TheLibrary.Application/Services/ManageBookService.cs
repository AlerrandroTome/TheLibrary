using AutoMapper;
using System;
using System.Linq;
using System.Threading.Tasks;
using TheLibrary.Core.DTOs.Book;
using TheLibrary.Core.Entities;
using TheLibrary.Core.Interfaces;
using TheLibrary.Infrastructure.Data.Context;
using TheLibrary.Infrastructure.UnitOfWork;

namespace TheLibrary.Application.Services
{
    public class ManageBookService : IManageBookService
    {
        private readonly LibraryContext _context;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;

        public ManageBookService(LibraryContext context, IMapper mapper, IUnitOfWork uow)
        {
            _context = context;
            _mapper = mapper;
            _uow = uow;
        }

        public async Task Create(BookCreateDTO dto)
        {
            var entity = _mapper.Map<Book>(dto);
            await _uow.Repository<Book>(_context).Create(entity);
        }

        public async Task Delete(Guid id)
        {
            var entity = await _uow.Repository<Book>(_context).Get(w => w.Id == id);
            await _uow.Repository<Book>(_context).Delete(entity);
        }

        public IQueryable<Book> Get()
        {
            return _uow.Repository<Book>(_context).GetAll();
        }

        public async Task<Book> Update(BookUpdateDTO dto)
        {
            var entity = await _uow.Repository<Book>(_context).Get(w => w.Id == dto.Id);
            entity = _mapper.Map(dto, entity);
            await _uow.Repository<Book>(_context).Update(entity);
            return entity;
        }
    }
}
