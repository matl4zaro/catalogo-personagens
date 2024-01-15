using Interfaces.Dominio;
using Models.Entidades;
using Models.Input;
using Models.Output;

namespace Dominio.Entidades
{
    public interface IPersonagemServico : IOperacaoBasicaServico<Personagem>
    {
        PaginaFiltradaDados<Personagem> ObterPagina(ObterPaginaFiltrada filtros);
    }
}