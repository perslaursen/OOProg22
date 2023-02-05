
// This is the class definition for the class Person
public class Person09
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

    // Add PrintPersonData method here

    public Person09(string name, double height, double weight)
    {
        Name = name;
        Weight = weight;
        Height = height;
    }
}
