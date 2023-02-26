
public class Circle : IComparable<Circle>
{
    #region Properties
    public double Radius { get; }
    public double X { get; }
    public double Y { get; }
    public double Area { get { return Math.PI * Radius * Radius; } }
    #endregion

    #region Constructor
    public Circle(double radius, double x, double y)
    {
        Radius = radius;
        X = x;
        Y = y;
    }
    #endregion

    #region Methods
    public int CompareTo(Circle? other)
    {
        if (other == null) return 1;

        if (Area > other.Area) return 1;

        if (Area < other.Area)  return -1;

        return 0;
    }

    public override string ToString()
    {
        return $"Circle at ({X} , {Y}) has an area of {Area.ToString().Substring(0, 6)}";
    }
    #endregion
}
