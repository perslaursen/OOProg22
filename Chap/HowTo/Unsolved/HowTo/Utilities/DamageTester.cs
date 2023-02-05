
public class DamageTester
{
    /// <summary>
    /// Given a Player11 object and a number of runs to perform, 
    /// this method will test the DealDamage method. 
    /// More specifically, the method must call DealDamage noOfRuns times,
    /// and record:
    ///    1) The maximal amount of damage dealt in a single call
    ///    2) The minimal amount of damage dealt in a single call
    ///    3) The average amount of damage dealt
    /// These values, plus the noOfRuns value, can then be used to
    /// call PrintTestResult, which will output the result of the
    /// test to the screen.
    /// </summary>
    public void TestPlayerDamage(IPlayer player, int noOfRuns)
    {
        // Implement the method according to the above definition.
    }

    private void PrintTestResult(int runs, int minDmg, int maxDmg, int aveDmg)
    {
        Console.WriteLine($"Number of runs: {runs}");
        Console.WriteLine($"Minimal damage: {minDmg}");
        Console.WriteLine($"Maximal damage: {maxDmg}");
        Console.WriteLine($"Average damage: {aveDmg}");
    }
}
