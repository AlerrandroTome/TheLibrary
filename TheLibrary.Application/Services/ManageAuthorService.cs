using AutoMapper;
using System;
using System.Linq;
using System.Threading.Tasks;
using TheLibrary.Core.DTOs.Author;
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

        public ManageAuthorService(LibraryContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task Create(AuthorCreateDTO dto)
        {
            var entity = _mapper.Map<Author>(dto);
            await _uow.Repository<Author>(_context).Create(entity);
        }

        public async Task Delete(Guid id)
        {
            var entity = await _uow.Repository<Author>(_context).Get(w => w.Id == id, new[] { "Books" });
            
            if (entity.Books.Any())
                throw new ApplicationException("O autor possuí livros cadastrados e por isso não pode ser excluído.");

            await _uow.Repository<Author>(_context).Delete(entity);
        }

        public IQueryable<Author> Get()
        {
            return _uow.Repository<Author>(_context).GetAll();
        }

        public async Task<Author> Update(AuthorUpdateDTO dto)
        {
            var entity = await _uow.Repository<Author>(_context).Get(w => w.Id == dto.Id);
            entity = _mapper.Map(dto, entity);
            await _uow.Repository<Author>(_context).Update(entity);
            return entity;
        }
    }
}
