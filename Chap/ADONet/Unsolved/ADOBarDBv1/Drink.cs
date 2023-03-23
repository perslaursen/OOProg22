
/// <summary>
/// This class represents a simple drink, which consists of
/// 1) An alcoholic part (name and amount in cl.)
/// 2) A non-alcoholic part (name and amount in cl.)
/// </summary>
public class Drink
{
    #region Properties

    public int Id { get; }
    public string Name { get; }
    public string AlcoholicPart { get; }
    public string NonAlcoholicPart { get; }
    public int AlcoholicPartAmount { get; }
    public int NonAlcoholicPartAmount { get; }

    #endregion

    #region Constructor
    
    public Drink(int id, string name,
        string alcoholicPart, int alcoholicPartAmount,
        string nonAlcoholicPart, int nonAlcoholicPartAmount)
    {
        Id = id;
        Name = name;

        AlcoholicPart = alcoholicPart;
        AlcoholicPartAmount = alcoholicPartAmount;

        NonAlcoholicPart = nonAlcoholicPart;
        NonAlcoholicPartAmount = nonAlcoholicPartAmount;
    }

    #endregion

    public override string ToString()
    {
        return $"[{Id,2}]  {Name} ({AlcoholicPartAmount} cl. {AlcoholicPart}, " +
                               $"{NonAlcoholicPartAmount} cl. {NonAlcoholicPart})";
    }
}
