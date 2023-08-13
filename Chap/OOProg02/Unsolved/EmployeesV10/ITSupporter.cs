
public class ITSupporter
{
    #region Properties
    public string Name { get; }
    public int HoursPerWeek { get; set; }
    public string PrimaryWorkArea { get; set; }

    public string AllInformation
    {
        get
        {
            return $"IT-Supporter {Name} works {HoursPerWeek} hours/week, mostly with {PrimaryWorkArea}";
        }
    }
    #endregion

    #region Constructor
    public ITSupporter(string name, int hoursPerWeek, string primaryWorkArea)
    {
        Name = name;
        HoursPerWeek = hoursPerWeek;
        PrimaryWorkArea = primaryWorkArea;
    }
    #endregion
}