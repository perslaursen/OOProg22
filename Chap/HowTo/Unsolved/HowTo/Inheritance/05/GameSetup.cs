
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

        // Add some character objects of different types here.
    }

    public void AllTalk()
    {
        // Use a foreacah loop to let all characters Talk
    }
}

