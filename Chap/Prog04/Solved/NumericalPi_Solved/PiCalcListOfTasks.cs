
public class PiCalcListOfTasks : PiCalcBase
{
    public double Calculate(int iterations, int noOfTasks)
    {
        int iterationsPerTask = iterations / noOfTasks;
        List<Task> tasks = new List<Task>();
        int[] insideUnitCircle = new int[noOfTasks];

        for (int taskNo = 0; taskNo < noOfTasks; taskNo++)
        {
            int no = taskNo; // NB: Cannot use taskNo directly inside function body (why?).
            tasks.Add(new Task(() => {  insideUnitCircle[no] = Iterate(iterationsPerTask); }));
        }

        for (int taskNo = 0; taskNo < noOfTasks; taskNo++)
        {
            tasks[taskNo].Start();
        }
        Task.WaitAll(tasks.ToArray());

        return (insideUnitCircle.Sum() * 4.0) / iterations;
    }
}
