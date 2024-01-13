using Interfaces.Externo;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Models.MarvelAPI;
using Models.MarvelAPI.Credenciais;
using System.Net.Http.Json;
using System.Security.Cryptography;
using System.Text;

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

    public string ChaveAutenticacao()
    {
        MarvelCredenciais credenciaisMarvelAPI = new();
        new ConfigureFromConfigurationOptions<MarvelCredenciais>(_configuracao.GetSection("MarvelAPI")).Configure(credenciaisMarvelAPI);

        string timeStamp = (DateTime.Now).Ticks.ToString();
        string apiKey = credenciaisMarvelAPI.PublicKey;

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

    public async Task<CharacterDataWrapper?> ObterPersonagens(int quantidadeResultados, int pagina)
    {
        // satinização
        pagina = (pagina < 1) ? 1 : pagina;
        quantidadeResultados = (quantidadeResultados < 1) ? 10 : quantidadeResultados;
        int offset = (pagina - 1) * quantidadeResultados;

        HttpClient client = _httpClientFactory.CreateClient("marvel-api");

        string terms = $"characters?limit={quantidadeResultados}&offset={offset}&{ChaveAutenticacao()}";

        try
        {
            CharacterDataWrapper? content = await client.GetFromJsonAsync<CharacterDataWrapper>(terms);

            return content;
        }
        catch (Exception)
        {
            throw;
        }

        /*
         
            (ok) GERAR MODELS
            (ok) CRIAR O DapperContexto
            (ok) CONFIGURAR O BANCO 

            Testar se banco funciona, inserindo e buscando dados

            CONCLUIR O ENDPOINT DE OBTENÇÃO DE DADOS
            CONCLUIR O ENDPOINT DE OBTENÇÃO DE PERSONAGEM POR ID ESPECÍFICO
         

            GET /v1/public/characters - OK, ENDPOINT PARA SER USADO INTERNO MONTAR FLUXO DE SINCRONIZAÇÃO DE DADOS

            GET /v1/public/characters/{characterId}

            GET /v1/public/characters/{characterId}/comics
            GET /v1/public/characters/{characterId}/events
            GET /v1/public/characters/{characterId}/series
            GET /v1/public/characters/{characterId}/stories
         */
    }
}
