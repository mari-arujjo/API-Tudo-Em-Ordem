using System.ComponentModel.DataAnnotations;

namespace api.Dtos
{
    public class AtualizarUsuarioDto
    {
        //public int id_usuario { get; set; }

        [Required]
        [MinLength(5, ErrorMessage = "O username deve ter no mínimo 5 carcateres")]
        [MaxLength(15, ErrorMessage = "Limite de carcateres: 15")]
        public string usuario { get; set; } = string.Empty;


        [Required]
        [MinLength(10, ErrorMessage = "O nome deve ter no mínimo 10 carcateres")]
        [MaxLength(50, ErrorMessage = "Limite de carcateres: 50")]
        public string nome { get; set; } = string.Empty;
        public int nivel_acesso { get; set; }
        public string foto_url { get; set; } = string.Empty;

    }
}
