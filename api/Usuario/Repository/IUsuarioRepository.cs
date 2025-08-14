/*
using api.Usuario.Dtos;
using api.Usuario.Helper;
using api.Usuario.Model;

namespace api.Usuario.Repository
{
    public interface IUsuarioRepository
    {
        Task<List<UsuarioModel>> ObterTodosAsync(UsuarioQueryObject query);
        Task<UsuarioModel?> ObterPorIdAsync(int id);
        Task<UsuarioModel> CreateAsync(UsuarioModel usuarioModel);
        Task<UsuarioModel?> UpdateAsync(int id, AtualizarUsuarioDto updateDto);
        Task<UsuarioModel?> DeleteIdAsync(int id);
        Task<UsuarioModel?> UpdateFotoDePerfil(int id, AtualizarFotoDto updateDto);
        Task<UsuarioModel?> UpdateSenha(int id, AtualizarSenhaDto updateDto);
    }
}
*/