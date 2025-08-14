using api.AppUserIdentity.Model;
using api.Controllers;
using api.Usuario.Dtos;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace api.Usuario.Repository
{
    public class EditarPerfilRepository : IEditarPerfilRepository
    {
        public readonly ApplicationDBContext _dbContext;
        private readonly UserManager<AppUser> _userManager;

        public EditarPerfilRepository(ApplicationDBContext context, UserManager<AppUser> userManager)
        {
            _dbContext = context;
            _userManager = userManager;
        }

        public async Task<AppUser?> UpdateFotoDePerfil(int id, AtualizarFotoDto updateDto)
        {
            var userModel = await _userManager.Users.FirstOrDefaultAsync();

            if (userModel == null)
            {
                return null;
            }
            userModel.foto = updateDto.foto;
            await _dbContext.SaveChangesAsync();
            return userModel;
        }

    }
}
