using Interfaces.Externo;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Models.MarvelAPI;
using Models.MarvelAPI.Credenciais;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Externo;

public class MarvelAPI : IMarvelAPI
{
    private readonly IConfiguration _configuracao;
    private readonly IHttpClientFactory _httpClientFactory;

    public MarvelAPI(
        IConfiguration configuracao,
        IHttpClientFactory httpClientFactory
    )
    {
        _configuracao = configuracao;
        _httpClientFactory = httpClientFactory;
    }

    public string ChavePublica()
    {
        return ChaveAutenticacao();
    }

    public string ChaveAutenticacao()
    {
        MarvelCredenciais credenciaisMarvelAPI = new();
        new ConfigureFromConfigurationOptions<MarvelCredenciais>(_configuracao.GetSection("MarvelAPI")).Configure(credenciaisMarvelAPI);

        string timeStamp = (DateTime.Now).Ticks.ToString();
        string apiKey = credenciaisMarvelAPI.PublicKey ;

        string hash;
        using (MD5 md5 = MD5.Create())
        {
            string toHash = timeStamp + credenciaisMarvelAPI.PrivateKey + apiKey;
            hash = string.Join(string.Empty, md5.ComputeHash(Encoding.UTF8.GetBytes(toHash)).Select(b => b.ToString("x2")));
        }

        //string chaveAutenticacao = $"ts={timeStamp}&apikey={apiKey}&hash={BitConverter.ToString(hashBytes).Replace("-", "").ToLower()}";
        string chaveAutenticacao = $"ts={timeStamp}&apikey={apiKey}&hash={hash}";
        return chaveAutenticacao;
    }

    public async Task<CharacterDataWrapper> ObterPersonagens()
    {
        var client = _httpClientFactory.CreateClient();

        client.BaseAddress = new Uri("https://gateway.marvel.com");
        var terms = $"/v1/public/characters?limit=10&{ChaveAutenticacao()}";
        try
        {
            var content = await client.GetFromJsonAsync<CharacterDataWrapper>(terms);
            return content;

        }
        catch (Exception ex)
        {

            throw ex;
        }

    }
}
