
public class GameSetup
{
    private static List<string> _lines = new List<string>
    {
        "Hello",
        "What a fine day!",
        "The Fare will begin tomorrow",
        "I'm lost..."
    };

    private List<ICharacter> _characters;

    public GameSetup()
    {
        _characters = new List<ICharacter>();

        _characters.Add(new NPC04("Player", 100, 10, _lines));
        _characters.Add(new PassiveNPC04("Player", 100, _lines));
        _characters.Add(new Zombie());
    }

    public void AllTalk()
    {
        foreach (var item in _characters)
        {
            Console.WriteLine(item.Talk());
        }
    }
}

