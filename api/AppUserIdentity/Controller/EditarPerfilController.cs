using api.Usuario.Dtos;
using api.Usuario.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace api.Usuario.Controller
{
    
    [ApiController]
    [Route("OrdemPro/account/editarPerfil")]
    [Authorize]
    public class EditarPerfilController : ControllerBase 
    {
        private readonly IEditarPerfilRepository _editRep;
        public EditarPerfilController(IEditarPerfilRepository editRep)
        {
            _editRep = editRep;
        }

        [HttpPatch("foto")]
        public async Task<IActionResult> AtualizarFotoUsuario([FromRoute] int id, [FromBody] AtualizarFotoDto updateDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null)
                return Unauthorized("Usuário não autenticado.");

            var user = await _editRep.UpdateFotoDePerfil(int.Parse(userId), updateDto);
            if (user == null)
            {
                return NotFound("Usuário não encontrado.");
            }

            return Ok(user);
        }

    }
}
