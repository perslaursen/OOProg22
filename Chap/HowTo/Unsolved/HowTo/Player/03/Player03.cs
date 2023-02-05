
// This is the class definition for the class Player
public class Player03
{
    public string Name { get; }
    public int LifePoints { get; set; }  // This needs to change...

    public Player03(string name)
    {
        Name = name;
        LifePoints = 100;
    }

    public Player03(string name, int lifePoints)
    {
        Name = name;
        LifePoints = lifePoints;
    }

    // Add RaiseLifePoints method
    // Add LowerLifePoints method
}
