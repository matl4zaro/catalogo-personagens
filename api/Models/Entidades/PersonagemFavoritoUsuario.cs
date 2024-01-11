using Dapper.Contrib.Extensions;

namespace Models.Entidades;

[Table("PersonagemFavoritoUsuario")]
public class PersonagemFavoritoUsuario
{
    public int UsuarioId { get; set; }
    public int PersonagemId { get; set; }
    public DateTime FavoritadoEm { get; set; }

    [Write(false)]
    [Computed]
    public Usuario Usuario { get; set; }

    [Write(false)]
    [Computed]
    public Personagem Personagem { get; set; }
}
