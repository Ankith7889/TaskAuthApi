using TaskAuthApi.Models;

namespace TaskAuthApi.Services
{
    public interface ITokenService
    {
        string CreateToken(AppUser user);
    }
}
