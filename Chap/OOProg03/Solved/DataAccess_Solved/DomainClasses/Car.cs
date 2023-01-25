
/// <summary>
/// Domain class representing a car. Note that 
/// this domain class does NOT implement IHasKey.
/// </summary>
public class Car
{
    #region Properties
    public string Plate { get; }
    public int Price { get; }
    #endregion

    #region Constructor
    public Car(string plate, int price)
    {
        Plate = plate;
        Price = price;
    }
    #endregion

    #region Methods
    public override string ToString()
    {
        return $"Car: Plate = {Plate}, Price = {Price}";
    }
    #endregion
}
 