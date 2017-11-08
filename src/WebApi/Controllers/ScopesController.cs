using Microsoft.AspNetCore.Mvc;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    public class ScopesController : Controller
    {
        [Route("singleton")]
        public IActionResult Get([FromServices] SingletonScope x, [FromServices] SingletonScope y)
        {
            return GetScope(x, y);
        }

        [Route("scoped")]
        public IActionResult Get([FromServices] ScopedScope x, [FromServices] ScopedScope y)
        {
            return GetScope(x, y);
        }

        [Route("transient")]
        public IActionResult Get([FromServices] TransientScope x, [FromServices] TransientScope y)
        {
            return GetScope(x, y);
        }

        [Route("factory")]
        public IActionResult Get([FromServices] ScopeFactory factory)
        {
            return Ok(factory);
        }
        
        private IActionResult GetScope(Scope x, Scope y)
        {
            return Ok(new { X = x, Y = y });
        }
    }
}
