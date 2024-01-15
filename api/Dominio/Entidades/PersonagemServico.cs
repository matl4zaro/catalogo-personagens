using Interfaces.Repositorio;
using Models.Entidades;
using Models.Input;
using Models.Output;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades;

public class PersonagemServico : OperacaoBasicaServico<Personagem>, IPersonagemServico
{
    private readonly IPersonagemRepositorio _personagemRepositorio;
    public PersonagemServico(IPersonagemRepositorio personagemRepositorio) : base(personagemRepositorio)
    {
        _personagemRepositorio = personagemRepositorio;
    }

    public PaginaFiltradaDados<Personagem> ObterPagina(ObterPaginaFiltrada filtros)
    {
        return _personagemRepositorio.ObterPagina(filtros);
    }
}
