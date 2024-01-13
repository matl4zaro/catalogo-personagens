using Dapper.Contrib.Extensions;

namespace Models.Entidades;

[Table("Personagem")]
public class Personagem
{
    [ExplicitKey]
    public int PersonagemId { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Descricao { get; set; } = string.Empty;
    public string ThumbnailUrl { get; set; } = string.Empty;
    public DateTime SincronizadoEm { get; set; }
}
