
double rect1x1 = 4.5;
double rect1y1 = 2.3;
double rect1x2 = 8.2;
double rect1y2 = 4.9;

double area1 = AreaOfRectangle(rect1x1, rect1y1, rect1x2, rect1y2);
Console.WriteLine($"Area of first rectangle is {area1}");

double rect2x1 = -3.2;
double rect2y1 = 1.1;
double rect2x2 = 3.7;
double rect2y2 = 5.6;

double area2 = AreaOfRectangle(rect2x1, rect2y1, rect2x2, rect2y2);
Console.WriteLine($"Area of second rectangle is {area2}");


double AreaOfRectangle(double x1, double y1, double x2, double y2)
{
    double sideA = x2 - x1;
    double sideB = y2 - y1;
    double area = sideA * sideB;
    return Math.Abs(area);
}

#region NB: This region only contains code related to steps 5 and 6.

double x1 = 3.3;
double y1 = 2.2;

double x2 = 7.5;
double y2 = 2.8;

double x3 = 11.1;
double y3 = 8.0;

double x4 = 6.8;
double y4 = 12.4;

double x5 = 3.5;
double y5 = 7.7;

List<double> xValues = new List<double> { x1, x2, x3, x4, x5 };
List<double> yValues = new List<double> { y1, y2, y3, y4, y5 };

Console.WriteLine($"Perimeter of pentagon (using PentagonPerimeter) is " +
                  $"{PentagonPerimeter(x1, y1, x2, y2, x3, y3, x4, y4, x5, y5):F2}");

Console.WriteLine($"Perimeter of pentagon (using PolygonPerimeter) is " +
                  $"{PolygonPerimeter(xValues, yValues):F2}");

double PentagonPerimeter(double x1, double y1,
                 double x2, double y2,
                 double x3, double y3,
                 double x4, double y4,
                 double x5, double y5)
{
    return SideLength(x1, y1, x2, y2) +
           SideLength(x2, y2, x3, y3) +
           SideLength(x3, y3, x4, y4) +
           SideLength(x4, y4, x5, y5) +
           SideLength(x5, y5, x1, y1);
}

double PolygonPerimeter(List<double> xVals, List<double> yVals)
{
    // Sanity checks
    if ((xVals == null || yVals == null) || (xVals.Count != yVals.Count) || xVals.Count < 3)
        return 0; // What else could we do here? Throw an exception...?

    double perimeter = 0;
    int noOfSides = yVals.Count;

    for (int index = 0; index < noOfSides - 1; index++)
    {
        perimeter += SideLength(xVals[index], yVals[index], xVals[index + 1], yVals[index + 1]);
    }
    perimeter += SideLength(xVals[noOfSides - 1], yVals[noOfSides - 1], xVals[0], yVals[0]);

    return perimeter;
}

double SideLength(double x1, double y1, double x2, double y2)
{
    return Math.Sqrt((Math.Pow(x1 - x2, 2) + Math.Pow(y1 - y2, 2)));
} 

#endregion
