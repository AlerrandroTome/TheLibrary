using System.Threading.Tasks;
using TheLibrary.Core.DTOs.Login;

namespace TheLibrary.Core.Interfaces
{
    public interface IManageLoginService
    {
        Task<string> Login(LoginDTO credentials);
    }
}
