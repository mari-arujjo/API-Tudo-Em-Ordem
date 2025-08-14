using api.AppUserIdentity.Model;
using api.Usuario.Dtos;

namespace api.Usuario.Repository
{
    public interface IEditarPerfilRepository
    {
        Task<AppUser?> UpdateFotoDePerfil(int id, AtualizarFotoDto updateDto);
    }
}
