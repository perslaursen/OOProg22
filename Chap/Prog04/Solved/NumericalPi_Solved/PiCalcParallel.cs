
public class PiCalcParallel : PiCalcBase
{
    public double Calculate(int iterations, int noOfParallels)
    {
        int iterationsPerParallel = iterations / noOfParallels;
        int[] insideUnitCircle = new int[noOfParallels];

        Parallel.For(0, noOfParallels, (int taskNo) => { insideUnitCircle[taskNo] = Iterate(iterationsPerParallel); });

        return (insideUnitCircle.Sum() * 4.0) / iterations;
    }
}
