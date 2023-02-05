
// This is the class definition for the class Player
public class Player09
{
    // Define an instance field named _sword here

    public string Name { get; }
    public int LifePoints { get; private set; }
    public bool IsDead { get { return LifePoints <= 0; } }

    public Player09(string name, int lifePoints)
    {
        // Initialize the instance field _sword here

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
        // Use the instance field _sword here
        return GetRandomNumber(10, 50);
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
