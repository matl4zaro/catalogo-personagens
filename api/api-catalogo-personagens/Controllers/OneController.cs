using Interfaces.Dominio;
using Interfaces.Externo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api_catalogo_personagens.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize]
public class OneController : ControllerBase
{
    private readonly IAtualizacaoServico _atualizacaoServico;

    public OneController(IAtualizacaoServico atualizacaoServico)
    {
        _atualizacaoServico = atualizacaoServico;
    }

    [HttpGet("SincronizarTodos")]
    public async Task<IActionResult> Get()
    {
        try
        {
            await _atualizacaoServico.AdicionaPersonagens();
            return Ok();
        }
        catch (Exception ex)
        {
            return Problem(ex.Message);
        }                
    }
}

