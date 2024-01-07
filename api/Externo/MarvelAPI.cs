using Interfaces.Externo;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Models.MarvelAPI.Credenciais;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Externo;

public class MarvelAPI : IMarvelAPI
{
    private readonly IConfiguration _configuracao;

    public MarvelAPI(
        IConfiguration configuracao
    )
    {
        _configuracao = configuracao;
    }

    public string ChavePublica()
    {
        MarvelCredenciais credenciaisMarvelAPI = new();

        new ConfigureFromConfigurationOptions<MarvelCredenciais>(_configuracao.GetSection("MarvelAPI")).Configure(credenciaisMarvelAPI);

        return credenciaisMarvelAPI.PublicKey;
    }
}
