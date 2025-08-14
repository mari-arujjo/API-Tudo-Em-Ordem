/*
using api.Usuario.Dtos;

namespace api.Usuario.Model
{
    public static class UsuarioMapper
    {
        // método de extensão
        // permite adicionar um novo método a uma classe existente sem precisar modificar essa classe diretamente ou criar uma subclasse.
        public static UsuarioDto ConverterParaUsuarioDto(this UsuarioModel usuarioModel) // this indica que ConverterParaUsuarioDto é um método de extensão da classe Usuario
        {
            return new UsuarioDto
            {
                id_usuario = usuarioModel.id_usuario,
                usuario = usuarioModel.usuario,
                nome = usuarioModel.nome,
                nivel_acesso = usuarioModel.nivel_acesso,
                senha = usuarioModel.senha,
                foto = usuarioModel.foto,
            };
        }
        public static UsuarioModel CriarNovoUsuarioDto(this CriarUsuarioDto usuarioDto) //metodo do tipo Model e com parametro DTO
        {
            return new UsuarioModel //para criar com .ADD() ele deve estar no formato Model, e não DTO
            {
                usuario = usuarioDto.usuario,
                nome = usuarioDto.nome,
                nivel_acesso = usuarioDto.nivel_acesso,
                foto = usuarioDto.foto ?? Array.Empty<byte>(),
                senha = usuarioDto.senha

            };
        }


    }
}
*/