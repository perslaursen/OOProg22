
public class NPC03 : Character03
{
    private List<string> _lines = new List<string>();

    public NPC03(string name, int lifePoints, int damageLimit, List<string> lines)
        : base(name, lifePoints, damageLimit)
    {
        _lines = lines;
    }

    public override string Talk()
    {
        return _lines[GetRandomNumber(0, _lines.Count - 1)];
    }
}
