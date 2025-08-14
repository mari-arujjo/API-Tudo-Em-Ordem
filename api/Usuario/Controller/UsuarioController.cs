using api.Usuario.Dtos;
using api.Usuario.Helper;
using api.Usuario.Model;
using api.Usuario.Repository;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Usuario.Controller
{
    
    [ApiController] // marca a  classe como uma api controller
    [Route("OrdemDeServico/usuario")]


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

            var users = await _usuarioRep.ObterTodosAsync(query); 
            var usersDto = users.Select(u => u.ConverterParaUsuarioDto()).OrderBy(dto => dto.id_usuario); 

            return Ok(usersDto);
        }


        [HttpGet("{id:int}")]
        public async Task<IActionResult> ObterPorID([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = await _usuarioRep.ObterPorIdAsync(id);
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

        [HttpPut]
        [Route("{id:int}/foto")]
        public async Task<IActionResult> AtualizarFotoUsuario([FromRoute] int id, [FromBody] AtualizarFotoDto updateDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var userModel = await _usuarioRep.UpdateFotoDePerfil(id, updateDto);
            if (userModel == null)
            {
                return NotFound();
            }

            return Ok(userModel.ConverterParaUsuarioDto());
        }

        [HttpPut]
        [Route("{id:int}/senha")]
        public async Task<IActionResult> AtualizarSenhaUsuario([FromRoute] int id, [FromBody] AtualizarSenhaDto updateDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var userModel = await _usuarioRep.UpdateSenha(id, updateDto);
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
