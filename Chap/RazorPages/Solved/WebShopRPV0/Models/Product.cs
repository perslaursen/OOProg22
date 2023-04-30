
using System.ComponentModel.DataAnnotations;
#nullable disable // Shut up about null issues...

public class Product
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Der skal angives et navn")]
    public string Name { get; set; }

    [Range(0, 99999.99, ErrorMessage = "Pris skal være mellem 0 og 100.000")]
    public double Price { get; set; }

    public Product() { }

    public Product(string name, double price)
    {
        Id = 0;
        Name = name;
        Price = price;
    }

    public void Update(Product other)
    {
        Name = other.Name; 
        Price = other.Price;
    }
}
