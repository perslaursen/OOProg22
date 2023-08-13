
public class Car
{
    public string LicensePlate { get; set; }
    public int Price { get; set; }

    public Car(string licensePlate, int price)
    {
        LicensePlate = licensePlate;
        Price = price;
    }

    public override string ToString()
    {
        return $"{LicensePlate}, costs {Price} kr.";
    }
}
