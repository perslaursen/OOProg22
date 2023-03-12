
public class PassiveNPC04 : NPC04
{
    public PassiveNPC04(string name, int lifePoints, List<string> lines) 
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
