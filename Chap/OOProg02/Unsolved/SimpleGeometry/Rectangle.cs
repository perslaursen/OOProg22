
public class Rectangle : Shape
{
    #region Properties
    public double XLowerLeft { get; }
    public double YLowerLeft { get; }
    public double XUpperRight { get; }
    public double YUpperRight { get; }
    #endregion

    #region Constructor
    public Rectangle(double xLowerLeft, double yLowerLeft, double xUpperRight, double yUpperRight)
        : base("Rectangle")
    {
        XLowerLeft = xLowerLeft;
        YLowerLeft = yLowerLeft;
        XUpperRight = xUpperRight;
        YUpperRight = yUpperRight;
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