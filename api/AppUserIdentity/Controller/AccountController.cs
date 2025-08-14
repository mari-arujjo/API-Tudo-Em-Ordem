using api.AppUserIdentity.Dtos;
using api.AppUserIdentity.Model;
using api.Service;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace api.AppUserIdentity.Controller
{
    [ApiController]
    [Route("api/account")]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ITokenService _tokenService;
        public AccountController(UserManager<AppUser> userManager, ITokenService tokenService)
        {
            _userManager = userManager;
            _tokenService = tokenService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Registrar([FromBody] RegistroUserDto registroUserDto)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);

                var appUser = new AppUser
                {
                    UserName = registroUserDto.username,
                    Email = registroUserDto.email,

                };

                var userCriado = await _userManager.CreateAsync(appUser, registroUserDto.senha);
                if (userCriado.Succeeded)
                {
                    var funcaoAtribuida = await _userManager.AddToRoleAsync(appUser, "Def");
                    if (funcaoAtribuida.Succeeded) {
                        return Ok(
                            new NewUserDto
                            {
                                username = appUser.UserName,
                                email = appUser.Email,
                                token = _tokenService.CriarToken(appUser)
                            }
                        );
                    }
                    else
                    {
                        return StatusCode(500, funcaoAtribuida.Errors);
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
