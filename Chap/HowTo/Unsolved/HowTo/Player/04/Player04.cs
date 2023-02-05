
// This is the class definition for the class Player
public class Player04
{
    public string Name { get; }
    public int LifePoints { get; private set; }

    public Player04(string name)
    {
        Name = name;
        LifePoints = 100;
    }

    public Player04(string name, int lifePoints)
    {
        Name = name;
        LifePoints = lifePoints;
    }

    // Update this method
    public void RaiseLifePoints(int points)
    {
        LifePoints += points;
    }

    // Update this method
    public void LowerLifePoints(int points)
    {
        LifePoints -= points;
    }
}
