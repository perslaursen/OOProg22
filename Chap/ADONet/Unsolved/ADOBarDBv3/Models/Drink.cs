
/// <summary>
/// This class represents a simple drink, which consists of
/// 1) An alcoholic part (name and amount in cl.)
/// 2) A non-alcoholic part (name and amount in cl.)
/// </summary>
public class Drink : IHasId
{
    #region Properties

    public int Id { get; set; }
    public string Name { get; }
    public Ingredient? AlcoholicPart { get; } // NB: Object reference!
    public Ingredient? NonAlcoholicPart { get; } // NB: Object reference!
    public int AlcoholicPartAmount { get; }
    public int NonAlcoholicPartAmount { get; }

    public int Price 
    {
        get { return ((AlcoholicPart is null) ? 0 : AlcoholicPart.PricePerCl * AlcoholicPartAmount) +
                     ((NonAlcoholicPart is null) ? 0 : NonAlcoholicPart.PricePerCl * NonAlcoholicPartAmount); }
    }

    #endregion

    #region Constructor
    public Drink(int id, string name,
        Ingredient? alcoholicPart, int? alcoholicPartAmount,
        Ingredient? nonAlcoholicPart, int? nonAlcoholicPartAmount)
    {
        // Note that we need to do some "sanity checks" of the parameters,
        // to catch some meaningless combinations.

        if (alcoholicPart is not null && alcoholicPartAmount is null)
            throw new ArgumentException();

        if (nonAlcoholicPart is not null && nonAlcoholicPartAmount is null)
            throw new ArgumentException();


        Id = id;
        Name = name;

        AlcoholicPart = alcoholicPart;
        AlcoholicPartAmount = alcoholicPart is null ? 0 : alcoholicPartAmount ?? 0;

        NonAlcoholicPart = nonAlcoholicPart;
        NonAlcoholicPartAmount = nonAlcoholicPart is null ? 0 : nonAlcoholicPartAmount ?? 0;
    }

    #endregion

    public override string ToString()
    {
        // Becomes a bit complicated due to the possibility of 
        // drinks without one of the components...

        string? alcoPart = AlcoholicPart is null ? null : $"{AlcoholicPartAmount} cl. {AlcoholicPart?.Name}";
        string? nonAlcoPart = NonAlcoholicPart is null ? null : $"{NonAlcoholicPartAmount} cl. {NonAlcoholicPart?.Name}";

        string result = $"[{Id,2}]  {Name} ";

        if (alcoPart is not null && nonAlcoPart is null)
            result += $"({alcoPart})";

        if (alcoPart is null && nonAlcoPart is not null)
            result += $"({nonAlcoPart})";

        if (alcoPart is not null && nonAlcoPart is not null)
            result += $"({alcoPart}, {nonAlcoPart})";

        result += $", costs {Price} kr.";

        return result;
    }
}
