using System;
using System.Threading.Tasks;
using TheLibrary.Application.Interfaces;
using TheLibrary.Domain.Entities;
using TheLibrary.Infrastructure.Data.Context;
using TheLibrary.Infrastructure.DTOs.Login;
using TheLibrary.Infrastructure.UnitOfWork;

namespace TheLibrary.Application.Services
{
    public class ManagerLoginService : IManagerLoginService
    {
        private readonly IUnitOfWork _uow;
        private readonly LibraryContext _contexto;
        private readonly ITokenService _tokenService;

        public ManagerLoginService(IUnitOfWork uow, LibraryContext contexto, ITokenService tokenService)
        {
            _uow = uow;
            _contexto = contexto;
            _tokenService = tokenService;
        }

        public async Task<string> Login(LoginDTO credentials)
        {
            //credentials.Password = credentials.Password.Atob();
            var user = await _uow.Repository<User>(_contexto).Get(w => w.Login == credentials.Login && w.Password == credentials.Password );
            
            if (user != null)
            {
                return _tokenService.GenerateToken(user);
            }
            else
            {
                throw new ApplicationException("Usuário e/ou senha incorreto(s).");
            }
        }
    }
}
