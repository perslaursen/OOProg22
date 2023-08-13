
public class Circle : Shape
{
    #region Properties
    public double X { get; }
    public double Y { get; }
    public double Radius { get; }
    #endregion

    #region Constructor
    public Circle(double x, double y, double radius)
        : base("Circle")
    {
        X = x;
        Y = y;
        Radius = radius;
    }
    #endregion

    /// <summary>
    /// Override of base class (abstract) property
    /// </summary>
    public override double Area
    {
        // This needs to be changed
        get { return 0; }
    }
}