
public class Phone
{
    public int Number { get; set; }
    public string Brand { get; set; }

    public Phone(int number, string brand)
    {
        Number = number;
        Brand = brand;
    }

    public override string ToString()
    {
        return $"{Number} ({Brand})";
    }
}
