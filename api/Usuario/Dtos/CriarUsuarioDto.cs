/*
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace api.Usuario.Dtos
{
    public class CriarUsuarioDto
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
        public byte[]? foto { get; set; } = Array.Empty<byte>();


        [Required]
        [MinLength(5, ErrorMessage = "A senha deve ter no mínimo 5 caracteres")]
        [MaxLength(20, ErrorMessage = "Limite de caracteres: 20")]
        public string senha { get; set; } = string.Empty;
    }
}
*/