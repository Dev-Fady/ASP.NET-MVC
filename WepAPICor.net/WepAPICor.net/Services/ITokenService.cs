using System.IdentityModel.Tokens.Jwt;
using WepAPICor.net.Models;

namespace WepAPICor.net.Services
{
    public interface ITokenService
    {
        string CreateToken(ApplicationUser user, IList<string> roles);
    }
}

