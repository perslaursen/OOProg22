
/// <summary>
/// This class is a very simple representation of a Warrior game character.
/// At this point, the Warrior only has a Name and some Hit Points. The
/// Warrior can only receive damage...
/// </summary>
public class Warrior
{
    /// <summary>
    /// Returns the name of the Warrior
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// Returns the current number of Hit Points for the Warrior
    /// </summary>
    public int HitPoints { get; private set; }

    /// <summary>
    /// Returns true if the Warrior is dead (defined as having zero or negative
    /// Hit Points), otherwise false.
    /// </summary>
    public bool IsDead { get { return HitPoints <= 0; } }


    public Warrior(string name, int hitPoints)
    {
        // The name must contain at least two non-blank characters
        if (string.IsNullOrWhiteSpace(name) || name.Length < 2)
        {
            throw new ArgumentException("Name must contain at least two characters");
        }

        // Hit point must initially be positive
        if (hitPoints <= 0)
        {
            throw new ArgumentException("Initial hit points must be positive");
        }

        Name = name;
        HitPoints = hitPoints;
    }


    /// <summary>
    /// Deals the given number of damage points to the Warrior.
    /// The Warrior's Hit Points are reduced with the given number
    /// of damage points.
    /// </summary>
    public void ReceiveDamage(int damagePoints)
    {
        // Damage points must be non-negative
        if (damagePoints < 0)
        {
            throw new ArgumentException("Damage points must be non-negative");
        }

        HitPoints = HitPoints - damagePoints;
    }
}