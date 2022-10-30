
/// <summary>
/// This class enables a user to choose between a set of "user options".
/// The code corresponding to the chosen option is executed upon choice.
/// </summary>
public class UserChoice
{
    public UserOption? ChosenOption { get; set; }
    public List<UserOption> Options { get; set; }

    public UserChoice(List<UserOption> options)
    {
        ChosenOption = null;
        Options = options;
    }

    /// <summary>
    /// Prints all available options to the Console.
    /// </summary>
    public void PrintOptions()
    {
        foreach (UserOption option in Options)
        {
            Console.WriteLine(option);
        }
    }

    /// <summary>
    /// Reads user input - which is the shortcut for a chosen option - from the Console.
    /// </summary>
    public static string ReadUserChoice()
    {
        string choice = Console.ReadLine() ?? "";
        return choice;
    }

    /// <summary>
    /// Given a user option shortcut, the corresponding user options is set.
    /// The option is then ready to be executed.
    /// </summary>
    public void SetChosenOption(string shortCut)
    {
        ChosenOption = Options.FirstOrDefault(o => o.ShortCut == shortCut);

        if (ChosenOption == null)
        {
            Console.WriteLine($"Unknown option {shortCut} chosen, please try again...");
        }
    }

    /// <summary>
    /// Executes the user option corresponding to the given shortcut.
    /// </summary>
    public void ExecuteChosenOption(string? shortCut = null)
    {
        if (!string.IsNullOrEmpty(shortCut))
            SetChosenOption(shortCut);

        ChosenOption?.UserAction();
    }
}
