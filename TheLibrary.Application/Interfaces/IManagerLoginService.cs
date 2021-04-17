using System.Threading.Tasks;
using TheLibrary.Infrastructure.DTOs.Login;

namespace TheLibrary.Application.Interfaces
{
    public interface IManagerLoginService
    {
        Task<string> Login(LoginDTO credentials);
    }
}
