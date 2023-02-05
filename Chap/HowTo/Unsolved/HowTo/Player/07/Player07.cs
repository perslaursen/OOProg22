
// This is the class definition for the class Player
public class Player07
{
    public string Name { get; }
    public int LifePoints { get; private set; }
    public bool IsDead { get { return LifePoints <= 0; } }

    public Player07(string name)
    {
        Name = name;
        LifePoints = 100;
    }

    public Player07(string name, int lifePoints)
    {
        Name = name;
        LifePoints = lifePoints;
    }

    public void RaiseLifePoints(int points)
    {
        if (points >= 0)
        {
            LifePoints += points;
        }
    }

    public void LowerLifePoints(int points)
    {
        if (points >= 0)
        {
            LifePoints -= points;
        }
    }

    public int DealDamage()
    {
        // Call GetRandomNumber instead of just returning 15.
        return 15;
    }

    /// <summary>
    /// This method returns a random integer value, 
    /// in the interval from "min to "max".
    /// </summary>
    private int GetRandomNumber(int min, int max)
    { 
        return _random.Next(min, max + 1); 
    }

    private static Random _random = new Random();
}
