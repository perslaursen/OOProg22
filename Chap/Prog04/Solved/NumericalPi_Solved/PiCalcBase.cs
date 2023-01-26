
public class PiCalcBase
{
    /// <summary>
    /// Perform a number of "dart-throwing" simulations.
    /// </summary>
    /// <param name="iterations">Number of dart-throws to perform</param>
    /// <returns>Number of throws within the unit circle</returns>
    protected int Iterate(int iterations)
    {
        Random _generator = new Random(Guid.NewGuid().GetHashCode());
        int insideUnitCircle = 0;

        for (int i = 0; i < iterations; i++)
        {
            double x = _generator.NextDouble();
            double y = _generator.NextDouble();

            if (x * x + y * y < 1.0)
            {
                insideUnitCircle++;
            }
        }

        return insideUnitCircle;
    }
}
