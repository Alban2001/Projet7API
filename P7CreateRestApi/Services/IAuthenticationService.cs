using P7CreateRestApi.Domain;
using System.Security.Claims;

namespace P7CreateRestApi.Services
{
    public interface IAuthenticationService
    {
        //User Authenticate(string username, string password);
        string GenerateToken(string secret, List<Claim> claims);
    }
}
