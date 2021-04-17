using System.Threading.Tasks;
using TheLibrary.Domain.Entities;

namespace TheLibrary.Application.Interfaces
{
    public interface ITokenService
    {
        string GenerateToken(User user);
    }
}
