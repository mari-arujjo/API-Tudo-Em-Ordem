using Microsoft.AspNetCore.Identity;

namespace api.AppUserIdentity.Model
{
    public class AppUser : IdentityUser
    {
        public int nivel_acesso { get; set; }
        public byte[]? foto { get; set; } = Array.Empty<byte>();
    }
}
