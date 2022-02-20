using AutoMapper;
using System;
using System.Linq;
using System.Threading.Tasks;
using TheLibrary.Core.DTOs.Book;
using TheLibrary.Core.DTOs.Response;
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

        public async Task<Response<Book>> Create(BookCreateDTO dto)
        {
            var entity = _mapper.Map<Book>(dto);
            var response = new Response<Book>();
            response.Data = await _uow.Repository<Book>(_context).Create(entity).ConfigureAwait(false);
            return response;
        }

        public async Task<Response<Guid>> Delete(Guid id)
        {
            var entity = await _uow.Repository<Book>(_context).Get(w => w.Id == id, new[] { "Rentals", "Rentals.Rental" }).ConfigureAwait(false);
            
            if (entity.Rentals.Any(r => r.Rental.ReturnDate >= DateTime.Now))
            {
                throw new ApplicationException("The book is rented, please try again when the book is not rented.");
            }

            var rentalList = entity.Rentals.Select(s => s.Rental);

            _context.Rentals.RemoveRange(rentalList);
            await _uow.Repository<Book>(_context).Delete(entity).ConfigureAwait(false);
            var response = new Response<Guid>();
            response.Data = id;
            return response;
        }

        public IQueryable<Book> Get()
        {
            return _uow.Repository<Book>(_context).GetAll();
        }

        public async Task<Response<Book>> Update(BookUpdateDTO dto)
        {
            var entity = await _uow.Repository<Book>(_context).Get(w => w.Id == dto.Id).ConfigureAwait(false);
            entity = _mapper.Map(dto, entity);
            var response = new Response<Book>();
            response.Data = await _uow.Repository<Book>(_context).Update(entity).ConfigureAwait(false);
            return response;
        }
    }
}
