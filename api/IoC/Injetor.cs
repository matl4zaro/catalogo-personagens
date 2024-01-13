using Dominio.Entidades;
using Dominio.Sincronizacao;
using Externo;
using Interfaces.Dominio;
using Interfaces.Externo;
using Interfaces.Repositorio;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;
using Models.Entidades;
using Repositorio.Compartilhado;
using Repositorio.Contexto;

namespace IoC;

public static class Injetor
{
    public static void RegistrarServicos(this IServiceCollection colecaoServicos)
    {
        colecaoServicos.AddLogging();
        colecaoServicos._CamadaDominio();
        colecaoServicos._CamadaDados();
    }

    private static void _CamadaDominio(this IServiceCollection colecaoServicos)
    {
        colecaoServicos.TryAddScoped<IOperacaoBasicaServico<Personagem>, OperacaoBasicaServico<Personagem>>();
        colecaoServicos.TryAddScoped<IOperacaoBasicaServico<Usuario>, OperacaoBasicaServico<Usuario>>();
        colecaoServicos.TryAddScoped<IOperacaoBasicaServico<PersonagemFavoritoUsuario>, OperacaoBasicaServico<PersonagemFavoritoUsuario>>();

        //---//

        colecaoServicos.TryAddScoped<IAtualizacaoServico, AtualizacaoServico>();
    }
    
    private static void _CamadaDados(this IServiceCollection colecaoServicos)
    {
        colecaoServicos._Externo();
        colecaoServicos._Repositorio();
    }

    private static void _Externo(this IServiceCollection colecaoServicos)
    {
        colecaoServicos.AddHttpClient("marvel-api", (serviceProvider, httpClient) =>
        {
            httpClient.BaseAddress = new Uri("https://gateway.marvel.com/v1/public/");
        });

        colecaoServicos.TryAddScoped<IMarvelAPI, MarvelAPI>();
    }
    
    private static void _Repositorio(this IServiceCollection colecaoServicos)
    {
        colecaoServicos.TryAddScoped<ISqlConnectionFactory, SqlConnectionFactory>();
        colecaoServicos.TryAddScoped<IDapperContexto, DapperContexto>();
    }
}
