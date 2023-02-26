
public class Dog
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
    public override string ToString()
    {
        return $"{Name} is {Height} cm tall, and weighs {Weight} kgs.";
    }
    #endregion
}
