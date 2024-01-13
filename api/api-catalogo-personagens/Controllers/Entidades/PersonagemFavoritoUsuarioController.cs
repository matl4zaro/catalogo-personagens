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
public class PersonagemFavoritoUsuarioController : BaseEntidadeController<PersonagemFavoritoUsuario>
{
    public PersonagemFavoritoUsuarioController(
        IOperacaoBasicaServico<PersonagemFavoritoUsuario> operacaoBasica
    ) : base(operacaoBasica)
    {
    }
}