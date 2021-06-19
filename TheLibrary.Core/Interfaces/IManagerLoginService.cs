using System.Threading.Tasks;
using TheLibrary.Core.DTOs.Login;

namespace TheLibrary.Core.Interfaces
{
    public interface IManagerLoginService
    {
        Task<string> Login(LoginDTO credentials);
    }
}
