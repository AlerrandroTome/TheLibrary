using System.Threading.Tasks;
using TheLibrary.Infrastructure.Entities;

namespace TheLibrary.Application.Interfaces
{
    public interface ITokenService
    {
        string GenerateToken(User user);
    }
}
