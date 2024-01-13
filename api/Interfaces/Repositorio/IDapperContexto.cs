namespace Interfaces.Repositorio;

public interface IDapperContexto
{
    bool Atualizar<T>(T entidade) where T : class;
    T Cadastrar<T>(T entidade) where T : class;
    List<T> CadastrarListagem<T>(List<T> entidades) where T : class;
    bool Excluir<T>(T entidade) where T : class;
    bool ExcluirPorId<T>(int entidadeId) where T : class;
    T ObterPorId<T>(int entidadeId) where T : class;
    List<T> ObterTodos<T>() where T : class;
}
