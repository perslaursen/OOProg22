
public class PassiveNPC03 : NPC03
{
    public PassiveNPC03(string name, int lifePoints, List<string> lines) 
        : base(name, lifePoints, 0, lines)
    {
    }

    public override string Talk()
    {
        int percent = GetRandomNumber(0, 100);
        if (percent > 50)
            return base.Talk();
        else
            return string.Empty;
    }
}
