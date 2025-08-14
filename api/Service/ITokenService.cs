using api.AppUserIdentity.Model;

namespace api.Service
{
    public interface ITokenService
    {
        string CriarToken(AppUser user);
    }
}
