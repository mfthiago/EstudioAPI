using MusicaAPI.Models;

namespace MusicaAPI.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(AppUser user);
    }
}
