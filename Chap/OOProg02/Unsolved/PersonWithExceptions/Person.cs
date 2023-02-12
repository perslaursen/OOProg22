
public class Person
{
    private double _height;
    private double _weight;

    /// <summary>
    /// Height in Meters (must be in the interval 0.2 to 3.0)
    /// </summary>
    public double Height 
    {
        get { return _height; }
        set { _height = value; } // Validation needed!
    }

    /// <summary>
    /// Weight in Kilograms (must be in the interval 0.2 to 500.0)
    /// </summary>
    public double Weight 
    {
        get { return _weight; }
        set { _weight = value; } // Validation needed!
    }

    /// <summary>
    /// Must be at least 2 characters long.
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// Must be in the interval 5.0 to 200.0
    /// </summary>
    public double BMI { get { return Weight / (Height * Height); } }

    public Person(string name, double height, double weight)
    {
        // Validation needed!
        Name = name;
        _height = height;
        _weight = weight;
    }

    public void UpdateFromOther(Person other)
    {
        // Validation needed!
        _height = other.Height;
        _weight = other.Weight;
    }
}

