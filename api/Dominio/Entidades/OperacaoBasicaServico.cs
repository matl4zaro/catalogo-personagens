using Interfaces.Dominio;
using Interfaces.Repositorio;

namespace Dominio.Entidades;

public class OperacaoBasicaServico<T> : IOperacaoBasicaServico<T> where T : class
{
    private readonly IDapperContexto _dapperContexto;

    public OperacaoBasicaServico(IDapperContexto dapperContexto)
    {
        _dapperContexto = dapperContexto;
    }

    public virtual T Cadastrar(T entidade) => _dapperContexto.Cadastrar(entidade);
    public virtual List<T> CadastrarListagem(List<T> entidades) => _dapperContexto.CadastrarListagem(entidades);
    public virtual bool Atualizar(T entidade) => _dapperContexto.Atualizar(entidade);
    public virtual bool Excluir(T entidade) => _dapperContexto.Excluir(entidade);
    public virtual bool ExcluirPorId(int entidadeId) => _dapperContexto.ExcluirPorId<T>(entidadeId);
    public virtual T ObterPorId(int entidadeId) => _dapperContexto.ObterPorId<T>(entidadeId);
    public virtual List<T> ObterTodos() => _dapperContexto.ObterTodos<T>();
}
