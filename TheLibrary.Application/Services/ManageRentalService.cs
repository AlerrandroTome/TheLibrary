using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheLibrary.Core.DTOs.Rental;
using TheLibrary.Core.DTOs.Response;
using TheLibrary.Core.Entities;
using TheLibrary.Core.Interfaces;
using TheLibrary.Infrastructure.Data.Context;
using TheLibrary.Infrastructure.UnitOfWork;

namespace TheLibrary.Application.Services
{
    public class ManageRentalService : IManageRentalService
    {
        private readonly LibraryContext _context;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;

        public ManageRentalService(LibraryContext context, IMapper mapper, IUnitOfWork uow)
        {
            _context = context;
            _mapper = mapper;
            _uow = uow;
        }

        public async Task<Response<Rental>> Create(RentalCreateDto dto)
        {
            var entity = _mapper.Map<Rental>(dto);

            foreach (var book in dto.Books)
            {
                var bookRental = new BookRental 
                {
                    BookId = book,
                    RentalId = entity.Id,
                };

                _ = await _context.AddAsync(bookRental).ConfigureAwait(false);
            }

            var response = new Response<Rental>();
            response.Data = await _uow.Repository<Rental>(_context).Create(entity).ConfigureAwait(false);
            return response;
        }

        public async Task<Response<Guid>> Delete(Guid id)
        {
            var entity = await _uow.Repository<Rental>(_context).Get(w => w.Id == id, new[] { "Books" }).ConfigureAwait(false);

            _context.RemoveRange(entity.Books);
            await _uow.Repository<Rental>(_context).Delete(entity).ConfigureAwait(false);
            var response = new Response<Guid>();
            response.Data = id;
            return response;
        }

        public IQueryable<Rental> Get() => _uow.Repository<Rental>(_context).GetAll();

        public async Task<Response<Rental>> Update(RentalUpdateDto dto)
        {

            var entity = await _uow.Repository<Rental>(_context).Get(g => g.Id == dto.Id, new[] { "Books" }).ConfigureAwait(false);
            
            if (entity.Books.Any()) // TODO remove when validator class is created
            {
                _context.BookRentals.RemoveRange(entity.Books);
            }

            entity = _mapper.Map(dto, entity);
            entity.Books = new List<BookRental>();

            foreach (var book in dto.Books)
            {
                var bookRental = new BookRental
                {
                    BookId = book,
                    RentalId = entity.Id,
                };

                _context.BookRentals.Add(bookRental);
            }

            var response = new Response<Rental>();
            response.Data = await _uow.Repository<Rental>(_context).Update(entity).ConfigureAwait(false);
            return response;
        }
    }
}
