
public class Dog : IComparable<Dog>
{
    #region Properties
    public string Name { get; }
    public int Height { get; }
    public double Weight { get; }
    #endregion

    #region Constructor
    public Dog(string name, int height, double weight)
    {
        Name = name;
        Height = height;
        Weight = weight;
    }
    #endregion

    #region Methods
    public int CompareTo(Dog? other)
    {
        if (other == null) return 1;

        if (Weight > other.Weight) return 1;

        if (Weight < other.Weight) return -1;

        return 0;
    }

    public override string ToString()
    {
        return $"{Name} is {Height} cm tall, and weighs {Weight} kgs.";
    }
    #endregion
}
