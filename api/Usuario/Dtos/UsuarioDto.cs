using System.ComponentModel.DataAnnotations;

namespace api.Usuario.Dtos
{
    public class UsuarioDto
    {
        public int id_usuario { get; set; }
        public string usuario { get; set; } = string.Empty; 
        public string nome { get; set; } = string.Empty;
        public int nivel_acesso { get; set; }
        public byte[]? foto { get; set; } = Array.Empty<byte>();

        public string senha { get; set; } = string.Empty;

    } 
}
