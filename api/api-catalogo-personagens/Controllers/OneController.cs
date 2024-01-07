using Microsoft.AspNetCore.Mvc;

namespace api_catalogo_personagens.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OneController : ControllerBase
    {
        private readonly ILogger<OneController> _logger;

        public OneController(ILogger<OneController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "void")]
        public void Get()
        {
            return;
        }
    }
}