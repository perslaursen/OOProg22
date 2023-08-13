
public class Employee
{
    public string Name { get; set; }
    public int YearOfBirth { get; set; }

    public Employee(string name, int yearOfBirth)
    {
        Name = name;
        YearOfBirth = yearOfBirth;
    }

    public override string ToString()
    {
        return $"{Name}, born {YearOfBirth}";
    }
}