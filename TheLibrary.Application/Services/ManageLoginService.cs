using System;
using System.Threading.Tasks;
using TheLibrary.Core.DTOs.Login;
using TheLibrary.Core.DTOs.Response;
using TheLibrary.Core.Entities;
using TheLibrary.Core.Interfaces;
using TheLibrary.Infrastructure.Data.Context;
using TheLibrary.Infrastructure.UnitOfWork;

namespace TheLibrary.Application.Services
{
    public class ManageLoginService : IManageLoginService
    {
        private readonly IUnitOfWork _uow;
        private readonly LibraryContext _contexto;
        private readonly ITokenService _tokenService;

        public ManageLoginService(IUnitOfWork uow, LibraryContext contexto, ITokenService tokenService)
        {
            _uow = uow;
            _contexto = contexto;
            _tokenService = tokenService;
        }

        public async Task<Response<string>> Login(LoginDTO credentials)
        {
            //credentials.Password = credentials.Password.Atob();
            var user = await _uow.Repository<User>(_contexto).Get(w => w.Login.Equals(credentials.Login) && w.Password.Equals(credentials.Password)).ConfigureAwait(false);
            
            if (user != null)
            {
                var response = new Response<string>();
                response.Data = _tokenService.GenerateToken(user);
                return response;
            }
            else
            {
                throw new ApplicationException("Username or password is wrong.");
            }
        }
    }
}
