
public class Zombie : ICharacter
{
    private bool _dealDamage;

    public string Name { get { return "Nameless Zombie"; } }

    public int LifePoints { get { return 0; } }

    public int DamageLimit { get { return 10; } }

    public bool IsDead { get { return false; } }

    public Zombie()
    {
        _dealDamage = false;
    }

    public int DealDamage()
    {
        _dealDamage = !_dealDamage;

        if (_dealDamage)
            return DamageLimit;
        else
            return 0;
    }

    public void LowerLifePoints(int points)
    {
        // Does nothing...
    }

    public void RaiseLifePoints(int points)
    {
        // Does nothing...
    }

    public string Talk()
    {
        return "Brraaaaiiinnnsss.....";
    }
}
