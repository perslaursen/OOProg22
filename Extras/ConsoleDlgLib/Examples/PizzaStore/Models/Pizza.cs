
public class Pizza : IId
{
    public int Id { get; init;}
    public string Description { get; set; }
    public int Price { get; set; }

    public Pizza(int id, string name, int price)
    {
        Id = id;
        Description = name;    
        Price = price;
    }

    public Pizza() 
    {
        Description = "";
    }

    public override string ToString()
    {
        return $"{Id} - {Description}, {Price} kr.";
    }
}

