
public class NPC : Character
{
    private List<string> _lines = new List<string>();

    public NPC(string name, int lifePoints, int damageLimit, List<string> lines)
        : base(name, lifePoints, damageLimit)
    {
        _lines = lines;
    }


    public virtual string Talk()
    {
        return _lines[GetRandomNumber(0 ,_lines.Count - 1)];
    }
}
