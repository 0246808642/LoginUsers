using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LoginUsers.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AcessController : ControllerBase
    {
        [HttpGet()]
        [Authorize(Policy ="IdadeMinima")]
        public IActionResult Get()
        {
            return Ok("Acesso permitido");
        }
    }
}
