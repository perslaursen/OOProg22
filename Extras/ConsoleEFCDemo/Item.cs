using System.ComponentModel.DataAnnotations.Schema;

public class Item
{
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int ID { get; set; }

    public string Name { get; set; }
    public double Price { get; set; }

    public Item() { }

    public Item(string name, double price)
    {
        ID = 0;
        Name = name;
        Price = price;
    }

    public override string ToString()
    {
        return $"{ID} -->  {Name},  {Price:F02} kr.";
    }
}
