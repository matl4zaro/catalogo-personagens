using Externo;
using Interfaces.Externo;
using Microsoft.Extensions.DependencyInjection;

namespace IoC;

public static class Injetor
{
    public static void RegistrarServicos(this IServiceCollection colecaoServicos)
    {
        colecaoServicos._CamadaDados();
    }

    private static void _CamadaDados(this IServiceCollection colecaoServicos)
    {
        colecaoServicos._Externo();
    }

    private static void _Externo(this IServiceCollection colecaoServicos)
    {
        colecaoServicos.AddHttpClient("marvel-api", (serviceProvider, httpClient) =>
        {
            httpClient.BaseAddress = new Uri("https://gateway.marvel.com/v1/public/");
        });

        colecaoServicos.AddScoped<IMarvelAPI, MarvelAPI>();
    }
}
