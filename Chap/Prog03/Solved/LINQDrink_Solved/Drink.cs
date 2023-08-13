
/// <summary>
/// This class represents a simple drink, which consists of
/// 1) An alcoholic part (name and amount in cl.)
/// 2) A non-alcoholic part (name and amount in cl.)
/// </summary>
public class Drink
{
    #region Properties
    public string Name { get; }
    public string AlcoholicPart { get; }
    public string NonAlcoholicPart { get; }
    public int AlcoholicPartAmount { get; }
    public int NonAlcoholicPartAmount { get; }
    #endregion

    #region Constructor
    public Drink(string name,
        string alcoholicPart, int alcoholicPartAmount,
        string nonAlcoholicPart, int nonAlcoholicPartAmount)
    {
        Name = name;

        AlcoholicPart = alcoholicPart;
        AlcoholicPartAmount = alcoholicPartAmount;

        NonAlcoholicPart = nonAlcoholicPart;
        NonAlcoholicPartAmount = nonAlcoholicPartAmount;
    }
    #endregion
}
