using Dapper;
using Interfaces.Repositorio;
using Microsoft.Extensions.Configuration;
using Models.Entidades;
using Models.Input;
using Models.Output;
using Repositorio.Contexto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.Entidades;

public class PersonagemRepositorio : DapperContexto, IPersonagemRepositorio
{
    public PersonagemRepositorio(IConfiguration configuration) : base(configuration)
    {
    }

    public PaginaFiltradaDados<Personagem> ObterPagina(ObterPaginaFiltrada filtros)
    {
        using(var conexao = CreateConnection())
        {
            PaginaFiltradaDados<Personagem> paginaDados = new();

            string condicaoImagem = filtros.ImagemDisponivel is not null 
                ? (filtros.ImagemDisponivel == true ?
                "AND p.ThumbnailUrl == @linkImagemNaoDisponivel" : //verdadeiro
                "AND p.ThumbnailUrl != @linkImagemNaoDisponivel" // falso
                ) : ""; // null

            string queryTotalRegistros = $@"
                SELECT COUNT(p.PersonagemId) 
                FROM Personagem p
                WHERE (p.Nome LIKE @filtro) {condicaoImagem}
            ";
            string queryPrincipal = @$"
                SELECT p.* 
                FROM Personagem p
                WHERE (p.Nome LIKE @filtro) {condicaoImagem}
                ORDER BY p.Nome
                OFFSET @itensAnteriores ROWS FETCH NEXT @quantidadeItens ROWS ONLY
            ";
            
            var parametros = new {
                filtro = $"%{filtros.TermoFiltro}%",
                itensAnteriores = (filtros.Pagina - 1) * filtros.ItensPorPagina,
                quantidadeItens = filtros.ItensPorPagina,
                linkImagemNaoDisponivel = "http://i.annihil.us/u/prod/marvel/i/mg/b/40/image_not_available.jpg"
            };

            paginaDados.Pagina = filtros.Pagina;
            paginaDados.RegistrosPorPagina = filtros.ItensPorPagina;
            paginaDados.TotalRegistros = conexao
                .QuerySingle<int>(queryTotalRegistros, parametros);

            if (paginaDados.TotalRegistros != 0)
            {
                paginaDados.Dados = conexao
                    .Query<Personagem>(queryPrincipal, parametros)
                    .ToList();
            }

            return paginaDados;
        }
    }
}
