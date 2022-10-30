
/// <summary>
/// This class is intended to process simple, console-based input
/// from a user, and execute code corresponding to the input.
/// </summary>
public abstract class UserDialogBase
{
    /// <summary>
    /// Starts up the dialog
    /// </summary>
    public void Run()
    {
        UserChoice userChoice = InitUserChoice();

        // Keep getting input from the user, until
        // the user chooses to quit
        while (userChoice.ChosenOption?.IsQuit != true)
        {
            userChoice.PrintOptions();
            string choice = UserChoice.ReadUserChoice().ToUpper();
            userChoice.ExecuteChosenOption(choice);
        }
    }

    /// <summary>
    /// Initializes a UserChoice object (the specific initialization
    /// must be defined in a derived class).
    /// </summary>
    public abstract UserChoice InitUserChoice();
}






