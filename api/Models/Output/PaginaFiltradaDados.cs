using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Output;

public class PaginaFiltradaDados<T> where T : class
{
    public List<T> Dados { get; set; } = new List<T>();
    public int TotalRegistros { get; set; }
    public int Pagina {  get; set; }
    public int RegistrosPorPagina { get; set; }
}
