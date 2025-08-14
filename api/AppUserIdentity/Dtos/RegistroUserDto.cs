using System.ComponentModel.DataAnnotations;

namespace api.AppUserIdentity.Dtos
{
    public class RegistroUserDto
    {
        [Required]
        public string nome { get; set; }

        [Required]
        public string username { get; set; }

        [Required]
        [EmailAddress]
        public string email { get; set; }

        [Required]
        public string senha { get; set; }
    }
}
