using Externo;
using Interfaces.Externo;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        colecaoServicos.AddScoped<IMarvelAPI, MarvelAPI>();
    }
}
