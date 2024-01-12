using Models.MarvelAPI;

namespace Interfaces.Externo;

public interface IMarvelAPI
{
    Task<CharacterDataWrapper?> ObterPersonagens(int quantidade, int pagina);
}
