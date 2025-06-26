using api.Data;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("api/OK")]
    public class ClassOk : ControllerBase
    {
        private readonly ApplicationDBContext _dbContext;
        public ClassOk(ApplicationDBContext context)
        {
            _dbContext = context;
        }

        [HttpGet]
        public IActionResult Get() => Ok("API OK");

    }
}
