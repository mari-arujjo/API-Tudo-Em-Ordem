using api.Data;
using api.Dtos;
using api.Helper;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    
    [ApiController] // marca a  classe como uma api controller
    [Route("api/usuario")]


    // herda funcionalidades básicas de um controlador da ASP.NET
    public class UsuarioController : ControllerBase 
    {
        private readonly IUsuarioRepository _usuarioRep;
        public UsuarioController(IUsuarioRepository usuarioRep)
        {
            _usuarioRep = usuarioRep;
        }
          

        [HttpGet]
        public async Task<IActionResult> ObterTodos([FromQuery] UsuarioQueryObject query)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var users = await _usuarioRep.GetAllAsync(query); 
            var usersDto = users.Select(u => u.ConverterParaUsuarioDto()).OrderBy(dto => dto.id_usuario); 

            return Ok(usersDto);
        }


        [HttpGet("{id:int}")]
        public async Task<IActionResult> ObterPorID([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = await _usuarioRep.GetByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user.ConverterParaUsuarioDto());
        }


        [HttpPost]
        public async Task<IActionResult> NovoUsuario([FromBody] CriarUsuarioDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var userModel = dto.CriarNovoUsuarioDto();
            userModel.foto_url ??= "https://fldoyzuifdwwxrtzinsb.supabase.co/storage/v1/object/sign/fotos-de-perfil/sem-foto.png?token=eyJraWQiOiJzdG9yYWdlLXVybC1zaWduaW5nLWtleV82MDEyZDE1Mi1lMDAwLTQ3NDUtYmQ3Zi1iOTI5OTZkMTlkMWYiLCJhbGciOiJIUzI1NiJ9.eyJ1cmwiOiJmb3Rvcy1kZS1wZXJmaWwvc2VtLWZvdG8ucG5nIiwiaWF0IjoxNzUxNjM2NjQyLCJleHAiOjE3ODMxNzI2NDJ9.7TuEkC9FKlqyJBGwrYKYZMobIDV-fm042xpb0JtLv8k";
            await _usuarioRep.CreateAsync(userModel);

            return CreatedAtAction(nameof(ObterPorID), new { id = userModel.id_usuario }, userModel.ConverterParaUsuarioDto());
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> AtualizarUsuario([FromRoute] int id, [FromBody] AtualizarUsuarioDto updateDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var userModel = await _usuarioRep.UpdateAsync(id, updateDto);
            if (userModel == null) 
            {
                return NotFound();
            }

            return Ok(userModel.ConverterParaUsuarioDto());
        }


        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeletarUsuario([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var userModel = await _usuarioRep.DeleteIdAsync(id);
            if (userModel == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
