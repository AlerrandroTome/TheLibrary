using AutoMapper;
using Microsoft.EntityFrameworkCore;
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
            if(!dto.Books.Any())
                throw new ApplicationException("It's necessary to inform at least one book.");

            var entity = _mapper.Map<Rental>(dto);

            foreach (var book in dto.Books)
            {
                var bookUnavailable = await _context.BookRentals.AsNoTracking()
                                                                .Select(s => new { s.Book.Title, s.BookId, s.Rental.StartDate, s.Rental.ReturnDate })
                                                                .FirstOrDefaultAsync(b => b.BookId == book && 
                                                                    ((b.StartDate <= dto.StartDate && b.ReturnDate >= dto.StartDate) || 
                                                                    ((b.StartDate <= dto.ReturnDate && b.ReturnDate >= dto.ReturnDate)) ||
                                                                    (dto.StartDate <= b.StartDate && dto.ReturnDate >= b.StartDate) ||
                                                                    ((dto.StartDate <= b.ReturnDate && dto.ReturnDate >= b.ReturnDate)))).ConfigureAwait(false);

                if (bookUnavailable is not null)
                    throw new ApplicationException($"The book '{bookUnavailable.Title}' is unavailable for the requested " +
                        $"date ({dto.StartDate.ToString("MM/dd/yyyy")} - {dto.ReturnDate.ToString("MM/dd/yyyy")}).");

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
            if (!dto.Books.Any())
                throw new ApplicationException("It's necessary to inform at least one book.");

            var entity = await _uow.Repository<Rental>(_context).Get(g => g.Id == dto.Id, new[] { "Books" }).ConfigureAwait(false);

            _context.BookRentals.RemoveRange(entity.Books);
            entity = _mapper.Map(dto, entity);
            entity.Books = new List<BookRental>();

            foreach (var book in dto.Books)
            {
                var bookUnavailable = await _context.BookRentals.AsNoTracking()
                                                          .Select(s => new { s.Book.Title, s.BookId, s.Rental.StartDate, s.Rental.ReturnDate, s.RentalId })
                                                          .FirstOrDefaultAsync(b => (b.BookId == book && b.RentalId != dto.Id) &&
                                                               ((b.StartDate <= dto.StartDate && b.ReturnDate >= dto.StartDate) ||
                                                               ((b.StartDate <= dto.ReturnDate && b.ReturnDate >= dto.ReturnDate)) ||
                                                               (dto.StartDate <= b.StartDate && dto.ReturnDate >= b.StartDate) ||
                                                               ((dto.StartDate <= b.ReturnDate && dto.ReturnDate >= b.ReturnDate)))).ConfigureAwait(false);

                if (bookUnavailable is not null)
                    throw new ApplicationException($"The book '{bookUnavailable.Title}' is unavailable for the requested " +
                        $"date ({dto.StartDate.ToString("MM/dd/yyyy")} - {dto.ReturnDate.ToString("MM/dd/yyyy")}).");

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
