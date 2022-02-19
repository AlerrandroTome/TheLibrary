using AutoMapper;
using System;
using System.Linq;
using System.Threading.Tasks;
using TheLibrary.Core.DTOs.BookCategory;
using TheLibrary.Core.DTOs.Response;
using TheLibrary.Core.Entities;
using TheLibrary.Core.Interfaces;
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

        public async Task<Response<BookCategory>> Create(BookCategoryCreateDTO dto)
        {
            var entity = _mapper.Map<BookCategory>(dto);
            var response = new Response<BookCategory>();
            response.Data = await _uow.Repository<BookCategory>(_context).Create(entity);
            return response;
        }

        public async Task<Response<Guid>> Delete(Guid id)
        {
            var entity = await _uow.Repository<BookCategory>(_context).Get(w => w.Id == id, new[] { "Books" }).ConfigureAwait(false);

            if(entity.Books.Any()) 
                throw new ApplicationException("There are books saved for this category, so it cannot be removed.");

            await _uow.Repository<BookCategory>(_context).Delete(entity).ConfigureAwait(false);

            var response = new Response<Guid>();
            response.Data = id;
            return response;
        }

        public IQueryable<BookCategory> Get() => _uow.Repository<BookCategory>(_context).GetAll();

        public async Task<Response<BookCategory>> Update(BookCategoryUpdateDTO dto)
        {
            var entity = await _uow.Repository<BookCategory>(_context).Get(w => w.Id == dto.Id).ConfigureAwait(false);
            entity = _mapper.Map(dto, entity);
            var response = new Response<BookCategory>();
            response.Data = await _uow.Repository<BookCategory>(_context).Update(entity).ConfigureAwait(false);
            return response;
        }
    }
}
