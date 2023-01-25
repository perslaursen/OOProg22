
/// <summary>
/// An "error ticket" represents a report of an error,
/// submitted by a system stakeholder (user, tester, etc.)
/// </summary>
public class ErrorTicket
{
    #region Properties
    public string Title { get; set; }
    public string Description { get; set; }
    public ErrorLanguage Language { get; set; }
    public ErrorLevel Level { get; set; }
    #endregion


    #region Constructor
    public ErrorTicket(string title, string description, ErrorLanguage language, ErrorLevel level)
    {
        Title = title;
        Description = description;
        Language = language;
        Level = level;
    }
    #endregion

    #region Methods
    public override string ToString()
    {
        return $"{Title} (level: {Level}  lang: {Language})";
    }
    #endregion
}
