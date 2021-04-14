using AutoMapper;
using System;
using System.Linq;
using System.Threading.Tasks;
using TheLibrary.Application.Interfaces;
using TheLibrary.Domain.DTOs.BookCategory;
using TheLibrary.Domain.Entities;
using TheLibrary.Infrastructure.Data.Context;
using TheLibrary.Infrastructure.UnitOfWork;

namespace TheLibrary.Application.Services
{
    public class ManageBookCategoryService : IManageBookCategoryService
    {
        private readonly LibraryContext _context;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;

        public ManageBookCategoryService(LibraryContext context, IMapper mapper, IUnitOfWork uow)
        {
            _context = context;
            _mapper = mapper;
            _uow = uow;
        }

        public async Task Create(BookCategoryCreateDTO dto)
        {
            var entity = _mapper.Map<BookCategory>(dto);
            await _uow.Repository<BookCategory>(_context).Create(entity);
        }

        public async Task Delete(Guid id)
        {
            var entity = await _uow.Repository<BookCategory>(_context).Get(w => w.Id == id);
            await _uow.Repository<BookCategory>(_context).Delete(entity);
        }

        public IQueryable<BookCategory> Get()
        {
            return _uow.Repository<BookCategory>(_context).GetAll();
        }

        public async Task Update(BookCategoryUpdateDTO dto)
        {
            var entity = await _uow.Repository<BookCategory>(_context).Get(w => w.Id == dto.Id);
            entity = _mapper.Map(dto, entity);
            await _uow.Repository<BookCategory>(_context).Update(entity);
        }
    }
}
