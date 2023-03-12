
public interface ICharacter
{
    string Name { get; }
    int LifePoints { get;  }
    int DamageLimit { get; }
    bool IsDead { get; }

    string Talk();
    void RaiseLifePoints(int points);
    void LowerLifePoints(int points);
    int DealDamage();
}
