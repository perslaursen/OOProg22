
public class Dog
{
    public string Name { get; set; }
    public int Weight { get; set; }

    public Dog(string name, int weight)
    {
        Name = name;
        Weight = weight;
    }

    public override string ToString()
    {
        return $"{Name} weighs {Weight} kg.";
    }
}
