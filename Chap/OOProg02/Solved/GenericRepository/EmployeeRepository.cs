
public class EmployeeRepository
{
    private Dictionary<string, Employee> _employees;

    public EmployeeRepository()
    {
        _employees = new Dictionary<string, Employee>();
    }

    public List<Employee> All
    {
        get { return _employees.Values.ToList(); }
    }

    public void Insert(string name, Employee anEmployee)
    {
        if (!_employees.ContainsKey(name))
        {
            _employees.Add(name, anEmployee);
        }
    }

    public void Delete(string name)
    {
        _employees.Remove(name);
    }
}
