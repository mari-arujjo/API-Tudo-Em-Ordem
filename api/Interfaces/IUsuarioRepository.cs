using api.Dtos;
using api.Helper;
using api.Models;

namespace api.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<List<Usuario>> GetAllAsync(UsuarioQueryObject query);
        Task<Usuario?> GetByIdAsync(int id);
        Task<Usuario> CreateAsync(Usuario usuarioModel);
        Task<Usuario?> UpdateAsync(int id, AtualizarUsuarioDto updateDto);
        Task<Usuario?> DeleteIdAsync(int id);
        Task<Usuario?> UpdateProfileImage(int id, AtualizarFotoDto updateDto);
        Task<Usuario?> UpdatePassowrd(int id, AtualizarSenhaDto updateDto);
    }
}
