using System.ComponentModel.DataAnnotations;

namespace api.AppUserIdentity.Dtos
{
    public class NewUserDto
    {
        public string username { get; set; }
        public string email { get; set; }
        public string token { get; set; }
    }
}
