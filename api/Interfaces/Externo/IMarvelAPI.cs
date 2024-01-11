using Models.MarvelAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Externo;

public interface IMarvelAPI
{
    Task<CharacterDataWrapper?> ObterPersonagens(int quantidade, int pagina);
}
