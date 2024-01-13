using Interfaces.Dominio;
using Interfaces.Externo;
using Microsoft.Extensions.Logging;
using Models.Entidades;
using Models.MarvelAPI;

namespace Dominio.Sincronizacao;

public class AtualizacaoServico : IAtualizacaoServico
{
    private readonly IOperacaoBasicaServico<Personagem> _personagemOperacoes;
    private readonly IMarvelAPI _marvelAPI;
    private readonly ILogger<AtualizacaoServico> _logger;

    public AtualizacaoServico(
        IOperacaoBasicaServico<Personagem> personagemOperacoes,
        IMarvelAPI marvelAPI,
        ILogger<AtualizacaoServico> logger
    )
    {
        _personagemOperacoes = personagemOperacoes;
        _marvelAPI = marvelAPI;
        _logger = logger;
    }

    public async Task AdicionaPersonagens()
    {
        for (int i = 1; i < 17; i++)
        {
            _logger.LogInformation($"----/--------/--------/------/----");
            _logger.LogInformation($"Iteração: {i}");
            CharacterDataWrapper? wrapper = await _marvelAPI.ObterPersonagens(100, i);
            if (wrapper is null)
                return;

            List<Character> characters = wrapper.data.results;

            List<Personagem> personagens = characters
                .Select(a => (Personagem)a)
                .ToList();

            _personagemOperacoes.CadastrarListagem(personagens);
            personagens.ForEach(p => _logger.LogInformation(p.ToString()));
        }
        _logger.LogInformation($"----/--------/--------/------/----");


    }


}
