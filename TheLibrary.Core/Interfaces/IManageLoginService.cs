using System.Threading.Tasks;
using TheLibrary.Core.DTOs.Login;
using TheLibrary.Core.DTOs.Response;

namespace TheLibrary.Core.Interfaces
{
    public interface IManageLoginService
    {
        Task<Response<string>> Login(LoginDTO credentials);
    }
}
