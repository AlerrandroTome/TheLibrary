using TheLibrary.Core.Entities;

namespace TheLibrary.Core.Interfaces
{
    public interface ITokenService
    {
        string GenerateToken(User user);
    }
}
