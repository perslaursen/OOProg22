
/// <summary>
/// This class now only contains elements  
/// specific for a Teacher
/// </summary>
public class Teacher : Employee
{
    public int PayGrade { get; set; }

    public Teacher(string name, int hoursPerWeek, int payGrade)
        : base(name, hoursPerWeek)
    {
        PayGrade = payGrade;
    }

    public string AllInformation
    {
        get
        {
            return $"Teacher {Name} works {HoursPerWeek} hours/week, at paygrade {PayGrade}";
        }
    }
}
