using System.ComponentModel.DataAnnotations;

namespace api.Usuario.Dtos
{
    public class AtualizarUsuarioDto
    {
        //public int id_usuario { get; set; }

        [Required]
        [MinLength(5, ErrorMessage = "O username deve ter no mínimo 5 caracteres")]
        [MaxLength(15, ErrorMessage = "Limite de caracteres: 15")]
        public string usuario { get; set; } = string.Empty;


        [Required]
        [MinLength(10, ErrorMessage = "O nome deve ter no mínimo 10 caracteres")]
        [MaxLength(50, ErrorMessage = "Limite de caracteres: 50")]
        public string nome { get; set; } = string.Empty;

        public int nivel_acesso { get; set; }

    }
}
