using api_catalogo_personagens.Controllers.Entidades.Compartilhado;
using Dominio.Entidades;
using Interfaces.Dominio;
using Interfaces.Externo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models.Entidades;
using Models.Input;
using Models.Output;

namespace api_catalogo_personagens.Controllers.Entidades;

[ApiController]
[Route("[controller]")]
[AllowAnonymous]
public class PersonagemController : BaseEntidadeController<Personagem>
{
    private readonly IPersonagemServico _personagemServico;

    public PersonagemController(
        IPersonagemServico personagemServico
    ) : base(personagemServico)
    {
        _personagemServico = personagemServico;
    }

    [HttpGet("ObterPagina")]
    public IActionResult ObterTodos([FromQuery] ObterPaginaFiltrada filtros)
    {
        try
        {
            PaginaFiltradaDados<Personagem> paginaDados = _personagemServico.ObterPagina(filtros);

            return Ok(paginaDados);
        }
        catch (Exception ex)
        {
            return Problem(ex.Message);
        }
    }
}
