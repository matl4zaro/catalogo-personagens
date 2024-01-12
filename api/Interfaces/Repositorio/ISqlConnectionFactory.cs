using Microsoft.Data.SqlClient;

namespace Interfaces.Repositorio;

public interface ISqlConnectionFactory
{
    SqlConnection CreateConnection();
}
