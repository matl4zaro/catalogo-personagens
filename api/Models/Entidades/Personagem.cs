using Dapper.Contrib.Extensions;
using Models.MarvelAPI;

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

    //public static List<Personagem> Conver(List<Character> listB)
    //{
    //    List<A> listA = new List<A>();

    //    foreach (B itemB in listB)
    //    {
    //        // You may need to implement a conversion logic here
    //        A itemA = ConvertBtoA(itemB);
    //        listA.Add(itemA);
    //    }

    //    return listA;
    //}

    public static explicit operator Personagem(Character c) => new Personagem()
    {
        Descricao = c.description,
        Nome = c.name,
        PersonagemId = c.id??0,
        SincronizadoEm = DateTime.Now,
        ThumbnailUrl = c.thumbnail.path + c.thumbnail.extension
    };

    public override string ToString()
    {
        string propriedade1 = $"PersonagemId: {PersonagemId}";
        string propriedade2 = $"Nome: {Nome}";
        return $"{propriedade1}\t{propriedade2}";
    }
}
