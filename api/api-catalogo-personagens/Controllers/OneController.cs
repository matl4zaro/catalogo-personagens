using Interfaces.Externo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace api_catalogo_personagens.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize]
public class OneController : ControllerBase
{
    private readonly IMarvelAPI _configuracao;
    private readonly ILogger<OneController> _logger;

    public OneController(
        ILogger<OneController> logger,
        IMarvelAPI configuracao
    )
    {
        _configuracao = configuracao;
        _logger = logger;
    }

    [HttpGet(Name = "Teste")]
    public IActionResult Get()
    {

        var a = _configuracao.ObterPersonagens();


        return Ok(new { a.Result });
    }
}

