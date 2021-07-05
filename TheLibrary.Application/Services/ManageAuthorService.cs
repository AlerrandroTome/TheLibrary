using AutoMapper;
using System;
using System.Linq;
using System.Threading.Tasks;
using TheLibrary.Core.DTOs.Author;
using TheLibrary.Core.Entities;
using TheLibrary.Core.Interfaces;
using TheLibrary.Infrastructure.UnitOfWork;

namespace TheLibrary.Application.Services
{
    public class ManageAuthorService : IManageAuthorService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;

        public ManageAuthorService(IMapper mapper, IUnitOfWork uow)
        {
            _mapper = mapper;
            _uow = uow;
        }

        public async Task Create(AuthorCreateDTO dto)
        {
            var entity = _mapper.Map<Author>(dto);
            await _uow.Repository<Author>().Create(entity);
        }

        public async Task Delete(Guid id)
        {
            var entity = await _uow.Repository<Author>().Get(w => w.Id == id, new[] { "Books" });
            
            if (entity.Books.Any())
                throw new ApplicationException("O autor possuí livros cadastrados e por isso não pode ser excluído.");

            await _uow.Repository<Author>().Delete(entity);
        }

        public IQueryable<Author> Get()
        {
            return _uow.Repository<Author>().GetAll();
        }

        public async Task<Author> Update(AuthorUpdateDTO dto)
        {
            var entity = await _uow.Repository<Author>().Get(w => w.Id == dto.Id);
            entity = _mapper.Map(dto, entity);
            await _uow.Repository<Author>().Update(entity);
            return entity;
        }
    }
}
