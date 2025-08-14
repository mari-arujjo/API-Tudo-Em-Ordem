using api.AppUserIdentity.Dtos;
using api.AppUserIdentity.Model;
using api.Service;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.AppUserIdentity.Controller
{
    [ApiController]
    [Route("OrdemDeServico/account")]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ITokenService _tokenService;
        private readonly SignInManager<AppUser> _signIn;
        public AccountController(UserManager<AppUser> userManager, ITokenService tokenService, SignInManager<AppUser> signIn)
        {
            _userManager = userManager;
            _tokenService = tokenService;
            _signIn = signIn;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var user = await _userManager.Users.FirstOrDefaultAsync(x => x.UserName == loginDto.username.ToLower());
            if (user == null) return Unauthorized("Usuário inválido!");
            var result = await _signIn.CheckPasswordSignInAsync(user, loginDto.senha, false);
            if (!result.Succeeded) return Unauthorized("Usuário não encontrado e/ou senha incorreta!");

            return Ok(
                new NewUserDto
                {
                    nome = user.nome,
                    username = user.UserName,
                    email = user.Email,
                    token = _tokenService.CriarToken(user)
                }
            );
        }

        [HttpPost("registro")]
        public async Task<IActionResult> RegistrarNovoUsuario([FromBody] RegistroUserDto registroUserDto)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);

                var appUser = new AppUser
                {
                    nome = registroUserDto.nome,
                    UserName = registroUserDto.username,
                    Email = registroUserDto.email,

                };

                var userCriado = await _userManager.CreateAsync(appUser, registroUserDto.senha);
                if (userCriado.Succeeded)
                {
                    var roleAtribuida = await _userManager.AddToRoleAsync(appUser, "Def");
                    if (roleAtribuida.Succeeded) {
                        return Ok(
                            new NewUserDto
                            {
                                nome = appUser.nome,
                                username = appUser.UserName,
                                email = appUser.Email,
                                token = _tokenService.CriarToken(appUser)
                            }
                        );
                    }
                    else
                    {
                        return StatusCode(500, roleAtribuida.Errors);
                    }
                }
                else
                {
                    return StatusCode(500, userCriado.Errors);
                }

            } catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }
    }
}
