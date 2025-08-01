using api.AppUserIdentity.Dtos;
using api.AppUserIdentity.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace api.AppUserIdentity.Controller
{
    [ApiController]
    [Route("api/account")]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        public AccountController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
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
                return (IActionResult)userCriado;
                //var userCriado = await _userManager.CreateAsync(appUser, registroUserDto.senha);
                //if (userCriado.Succeeded)
                //{

                //}

            } catch (Exception e)
            {
                throw;
            }

        }
    }
}
