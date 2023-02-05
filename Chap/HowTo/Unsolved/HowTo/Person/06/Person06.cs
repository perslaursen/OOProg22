
// This is the class definition for the class Person
public class Person06
{
    public string Name { get; }
    public double Height { get; set; }
    public double Weight { get; set; }
    // Add BMI Property here

    public Person06(string name, double height, double weight)
    {
        Name = name;
        Weight = weight;
        Height = height;
    }
}
