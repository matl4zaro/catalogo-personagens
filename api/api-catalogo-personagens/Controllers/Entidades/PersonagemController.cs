using api_catalogo_personagens.Controllers.Entidades.Compartilhado;
using Interfaces.Dominio;
using Interfaces.Externo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models.Entidades;

namespace api_catalogo_personagens.Controllers.Entidades;

[ApiController]
[Route("[controller]")]
[Authorize]
public class PersonagemController : BaseEntidadeController<Personagem>
{
    public PersonagemController(
        IOperacaoBasicaServico<Personagem> operacaoBasica
    ) : base(operacaoBasica)
    {
    }
}

