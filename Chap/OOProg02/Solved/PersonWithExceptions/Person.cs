
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
        set
        {
            ValidateHeight("Height", value);
            ValidateBMI("Height", value, Weight);

            _height = value;
        }
    }

    /// <summary>
    /// Weight in Kilograms (must be in the interval 0.2 to 500.0)
    /// </summary>
    public double Weight
    {
        get { return _weight; }
        set
        {
            ValidateWeight("Weight", value);
            ValidateBMI("Weight", Height, value);

            _weight = value;
        }
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
        ValidateName("ctor", name);
        ValidateHeight("ctor", height);
        ValidateWeight("ctor", weight);
        ValidateBMI("ctor", height, weight);

        Name = name;
        _height = height;
        _weight = weight;
    }

    public void UpdateFromOther(Person other)
    {
        ValidateHeight("UpdateFromOther", other.Height);
        ValidateWeight("UpdateFromOther", other.Weight);
        ValidateBMI("UpdateFromOther", other.Height, other.Weight);

        _height = other.Height;
        _weight = other.Weight;
    }

    private void ValidateName(string from, string name)
    {
        if (name == null || name.Length < 2)
            throw new ArgumentException($"{from}: Name");
    }

    private void ValidateHeight(string from, double height)
    {
        if (height < 0.2 || height > 3.0)
            throw new ArgumentException($"{from}: Height");
    }

    private void ValidateWeight(string from, double weight)
    {
        if (weight < 0.2 || weight > 500.0)
            throw new ArgumentException($"{from}: Weight");
    }

    private void ValidateBMI(string from, double height, double weight)
    {
        double bmi = weight / (height * height);

        if (bmi < 5.0 || bmi > 200.0)
            throw new ArgumentException($"{from}: BMI");
    }
}

