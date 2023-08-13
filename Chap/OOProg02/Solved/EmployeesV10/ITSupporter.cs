
/// <summary>
/// This class now only contains elements  
/// specific for an IT-Supporter
/// </summary>
public class ITSupporter : Employee
{
    public string PrimaryWorkArea { get; set; }

    public ITSupporter(string name, int hoursPerWeek, string primaryWorkArea)
        : base(name, hoursPerWeek)
    {
        PrimaryWorkArea = primaryWorkArea;
    }

    public string AllInformation
    {
        get
        {
            return $"IT-Supporter {Name} works {HoursPerWeek} hours/week, mostly with {PrimaryWorkArea}";
        }
    }
}
