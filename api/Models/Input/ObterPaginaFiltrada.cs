using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Input;
public class ObterPaginaFiltrada
{
    public int Pagina { get; set; }
    public int ItensPorPagina { get; set; }
    public string TermoFiltro { get; set; } = string.Empty;
    public bool? ImagemDisponivel { get; set; }
}
