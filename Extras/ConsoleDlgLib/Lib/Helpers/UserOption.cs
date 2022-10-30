
/// <summary>
/// This class represents a single "user option".
/// A option ties together a shortcut, a description and an actual action
/// (i.e. code to be executed upon choosing the option).
/// </summary>
public class UserOption
{
    public bool IsQuit { get; set; }
    public string ShortCut { get; set; }
    public string Description { get; set; }
    public Action UserAction { get; set; }

    public UserOption(string shortCut, string description, Action userAction, bool isQuit = false)
    {
        ShortCut = shortCut;
        Description = description;
        IsQuit = isQuit;
        UserAction = userAction;
    }

    public override string ToString()
    {
        return $"{ShortCut} -> {Description}";
    }
}
