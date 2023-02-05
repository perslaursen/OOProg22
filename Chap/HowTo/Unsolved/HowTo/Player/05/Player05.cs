
// This is the class definition for the class Player
public class Player05
{
    public string Name { get; }
    public int LifePoints { get; private set; }
    // Add property IsDead here

    public Player05(string name)
    {
        Name = name;
        LifePoints = 100;
    }

    public Player05(string name, int lifePoints)
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
}
