using System.ComponentModel.DataAnnotations;

namespace api.Dtos
{
    public class AtualizarSenhaDto
    {
        [Required]
        [MinLength(5, ErrorMessage = "A senha deve ter no mínimo 5 carcateres")]
        [MaxLength(20, ErrorMessage = "Limite de carcateres: 20")]
        public string senha { get; set; } = string.Empty;
    }
}
