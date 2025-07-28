using Microsoft.AspNetCore.Identity;

namespace api.AppUser.Model
{
    public class AppUserModel : IdentityUser
    {
        public int nivel_acesso { get; set; }
        public byte[]? foto { get; set; } = Array.Empty<byte>();
    }
}
