
public class PiCalc : PiCalcBase
{
    /// <summary>
    /// Executes the calculation of an approximate value of pi.
    /// </summary>
    /// <param name="iterations">Number of iterations to perform</param>
    /// <returns>Approximate value of pi</returns>
    public double Calculate(int iterations)
    {
        int insideUnitCircle = Iterate(iterations);
        return insideUnitCircle * 4.0 / iterations;
    }
}
