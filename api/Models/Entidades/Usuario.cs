using Dapper.Contrib.Extensions;

namespace Models.Entidades;

[Table("Usuario")]
public class Usuario
{
    [Key]
    public int UsuarioId { get; set; }
    public string Login { get; set; } = string.Empty;
    public string Senha { get; set; } = string.Empty;
    public string UsuarioNome { get; set; } = string.Empty;
    public DateTime CriadoEm { get; set; }
}
