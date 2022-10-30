
/// <summary>
/// This class represents the top-level user options for a very simple setup.
/// </summary>
public class SimpleUserDialog : UserDialogBase
{
    public override UserChoice InitUserChoice()
    {
        List<UserOption> initialOptions = new List<UserOption>
        {
            new UserOption("A", "Option A", RunOptionA),
            new UserOption("B", "Option B", RunOptionB),
            new UserOption("C", "Option C", RunOptionC),
            new UserOption("Q", "Quit", RunQuit, true),
        };

        return new UserChoice(initialOptions);
    }

    private void RunOptionA()
    {
        Console.WriteLine("You chose Option A.");
    }

    private void RunOptionB()
    {
        Console.WriteLine("You chose Option B.");
    }

    private void RunOptionC()
    {
        Console.WriteLine("You chose Option C.");
    }

    private void RunQuit()
    {
        Console.WriteLine("You chose to quit... bye...");
    }
}
