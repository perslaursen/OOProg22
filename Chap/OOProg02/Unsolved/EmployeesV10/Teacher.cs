
public class Teacher
{
    #region Properties
    public string Name { get; }
    public int HoursPerWeek { get; set; }
    public int PayGrade { get; set; }

    public string AllInformation
    {
        get
        {
            return $"Teacher {Name} works {HoursPerWeek} hours/week, at paygrade {PayGrade}";
        }
    }
    #endregion

    #region Constructor
    public Teacher(string name, int hoursPerWeek, int payGrade)
    {
        Name = name;
        HoursPerWeek = hoursPerWeek;
        PayGrade = payGrade;
    }
    #endregion
}