namespace Interfaces.Dominio;
public interface IOperacaoBasicaServico<T> where T : class
{
    bool Atualizar(T entidade);
    T Cadastrar(T entidade);
    List<T> CadastrarListagem(List<T> entidades);
    bool Excluir(T entidade);
    bool ExcluirPorId(int entidadeId);
    T ObterPorId(int entidadeId);
    List<T> ObterTodos();
}
