
// This is the class definition for the class Person
public class Person07
{
    public string Name { get; }
    public double Height { get; set; }
    public double Weight { get; set; }
    public double BMI 
    { 
        get { return Weight / (Height * Height); } 
    }

    // Add Underweight Property here

    public Person07(string name, double height, double weight)
    {
        Name = name;
        Weight = weight;
        Height = height;
    }
}
