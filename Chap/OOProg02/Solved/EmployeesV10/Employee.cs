
/// <summary>
/// This class now acts as a base class 
/// for all kinds of employees
/// </summary>
public class Employee
{
    #region Properties
    public string Name { get; }
    public int HoursPerWeek { get; set; }
    #endregion

    #region Constructor
    public Employee(string name, int hoursPerWeek)
    {
        Name = name;
        HoursPerWeek = hoursPerWeek;
    }
    #endregion
}
