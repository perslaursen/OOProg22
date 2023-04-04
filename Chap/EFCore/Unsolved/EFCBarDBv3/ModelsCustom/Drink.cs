
public partial class Drink : IHasId
{
    /// <summary>
    /// This constructor should be used when creatng new object to be managed by EF Core, 
    /// since it does NOT set the navigation properties, but rather sets the corresponding identifiers.
    /// </summary>
    public Drink(string name, int? alcoholicPartId, int? alcoholicPartAmount, int? nonAlcoholicPartId, int? nonAlcoholicPartAmount)
    {
        Id = 0;
        Name = name;
        AlcoholicPartId = alcoholicPartId;
        AlcoholicPartAmount = alcoholicPartAmount;
        NonAlcoholicPartId = nonAlcoholicPartId;
        NonAlcoholicPartAmount = nonAlcoholicPartAmount;
    }

    public int Price
    {
        get
        {
            return ((AlcoholicPart is null) ? 0 : AlcoholicPart.PricePerCl * (AlcoholicPartAmount is null ? 0 : AlcoholicPartAmount.Value)) +
                   ((NonAlcoholicPart is null) ? 0 : NonAlcoholicPart.PricePerCl * (NonAlcoholicPartAmount is null ? 0 : NonAlcoholicPartAmount.Value));
        }
    }

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
