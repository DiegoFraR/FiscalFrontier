using FiscalFrontier.API.Models.Domain;

namespace FiscalFrontier.API.Repositories.Interface
{
    public interface ITokenRepository
    {
        string CreateJwtToken(User user, List<string> roles);
    }
}
