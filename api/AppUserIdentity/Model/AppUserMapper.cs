using api.AppUserIdentity.Dtos;
using System.Runtime.CompilerServices;

namespace api.AppUserIdentity.Model
{
    public static class AppUserMapper
    {
        public static AppUserDto ConverterParaUserDto(this AppUser appUser)
        {
            return new AppUserDto
            {
                nome = appUser.nome,
                username = appUser.UserName,
                email = appUser.Email
            };
        }
    }
}
