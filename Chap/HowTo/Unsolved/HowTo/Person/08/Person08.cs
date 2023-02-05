
// This is the class definition for the class Person
public class Person08
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

    // Add IsUnderweight method here

    public Person08(string name, double height, double weight)
    {
        Name = name;
        Weight = weight;
        Height = height;
    }
}
