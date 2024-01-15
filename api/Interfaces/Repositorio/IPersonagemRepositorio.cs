using Models.Entidades;
using Models.Input;
using Models.Output;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Repositorio;

public interface IPersonagemRepositorio : IDapperContexto
{
    PaginaFiltradaDados<Personagem> ObterPagina(ObterPaginaFiltrada filtros);
}
