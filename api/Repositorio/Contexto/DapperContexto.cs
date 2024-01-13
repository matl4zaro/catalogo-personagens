using Dapper.Contrib.Extensions;
using Interfaces.Repositorio;
using Microsoft.Extensions.Configuration;
using Repositorio.Compartilhado;

namespace Repositorio.Contexto;

public class DapperContexto : SqlConnectionFactory, IDapperContexto
{
    public DapperContexto(IConfiguration configuration) : base(configuration)
    {
    }

    public T Cadastrar<T>(T entidade) where T : class
    {
        using (var conexaoSql = CreateConnection())
        {
            conexaoSql.Insert<T>(entidade);
            return entidade;
        }
    }

    public List<T> CadastrarListagem<T>(List<T> entidades) where T : class
    {
        using (var conexaoSql = CreateConnection())
        {
            conexaoSql.Insert<List<T>>(entidades);
            return entidades;
        }
    }

    public T ObterPorId<T>(int entidadeId) where T : class
    {
        using (var conexaoSql = CreateConnection())
        {
            T entidade = conexaoSql.Get<T>(entidadeId);
            return entidade;
        }
    }

    public List<T> ObterTodos<T>() where T : class
    {
        using (var conexaoSql = CreateConnection())
        {
            List<T> listagem = conexaoSql.GetAll<T>().ToList();
            return listagem;
        }
    }

    public bool Atualizar<T>(T entidade) where T : class
    {
        using (var conexaoSql = CreateConnection())
        {
            bool operacaoAtualizacao = conexaoSql.Update<T>(entidade);
            return operacaoAtualizacao;
        }
    }

    public bool Excluir<T>(T entidade) where T : class
    {
        using (var conexaoSql = CreateConnection())
        {
            bool operacaoExclusao = conexaoSql.Delete<T>(entidade);
            return operacaoExclusao;
        }
    }

    public bool ExcluirPorId<T>(int entidadeId) where T : class
    {
        using (var conexaoSql = CreateConnection())
        {
            T entidade = conexaoSql.Get<T>(entidadeId);
            bool operacaoExclusao = conexaoSql.Delete<T>(entidade);

            return operacaoExclusao;
        }
    }

}
