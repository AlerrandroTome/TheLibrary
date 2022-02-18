using AutoMapper;
using System;
using System.Linq;
using System.Threading.Tasks;
using TheLibrary.Core.DTOs.Author;
using TheLibrary.Core.DTOs.Response;
using TheLibrary.Core.Entities;
using TheLibrary.Core.Interfaces;
using TheLibrary.Infrastructure.Data.Context;
using TheLibrary.Infrastructure.UnitOfWork;

namespace TheLibrary.Application.Services
{
    public class ManageAuthorService : IManageAuthorService
    {
        private readonly LibraryContext _context;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;

        public ManageAuthorService(LibraryContext context, IMapper mapper, IUnitOfWork uow)
        {
            _context = context;
            _mapper = mapper;
            _uow = uow;
        }

        public async Task<Response<Author>> Create(AuthorCreateDTO dto)
        {
            var entity = _mapper.Map<Author>(dto);
            var response = new Response<Author>();
            response.Data = await _uow.Repository<Author>(_context).Create(entity);
            return response;
        }

        public async Task<Response<Guid>> Delete(Guid id)
        {
            var entity = await _uow.Repository<Author>(_context).Get(w => w.Id == id, new[] { "Books" });
            var response = new Response<Guid>();

            if (entity.Books.Any())
                throw new ApplicationException("There are books saved for this Author, so it cannot be removed.");

            response.Data = id;

            await _uow.Repository<Author>(_context).Delete(entity);

            return response;
        }

        public IQueryable<Author> Get()
        {
            return _uow.Repository<Author>(_context).GetAll();
        }

        public async Task<Response<Author>> Update(AuthorUpdateDTO dto)
        {
            var entity = await _uow.Repository<Author>(_context).Get(w => w.Id == dto.Id);
            var response = new Response<Author>();
            entity = _mapper.Map(dto, entity);
            response.Data = await _uow.Repository<Author>(_context).Update(entity);
            return response;
        }
    }
}
