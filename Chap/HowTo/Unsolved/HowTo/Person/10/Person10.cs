
// This is the class definition for the class Person
public class Person10
{
    public string Name { get; }
    public double Height { get; set; }
    public double Weight { get; set; }
    public double BMI 
    { 
        get { return Weight / (Height * Height); } 
    }

    public bool Underweight
    {
        get { return BMI < 18.5; }
    }

    public bool IsUnderweight(double bmiLimit)
    {
        return BMI < bmiLimit;
    }

    public void PrintPersonData()
    {
        Console.WriteLine($"Name : {Name}");
        Console.WriteLine($"Height : {Height}");
        Console.WriteLine($"Weight : {Weight}");
        Console.WriteLine($"BMI : {BMI}");
        Console.WriteLine($"Underweight : {Underweight}");
    }

    // Add PersonDataAsString method here

    public Person10(string name, double height, double weight)
    {
        Name = name;
        Weight = weight;
        Height = height;
    }
}
