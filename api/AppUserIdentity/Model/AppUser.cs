using Microsoft.AspNetCore.Identity;

namespace api.AppUserIdentity.Model
{
    public class AppUser : IdentityUser
    {
        public string nome { get; set; } = string.Empty;
        public byte[]? foto { get; set; } = Array.Empty<byte>();
    }
}
