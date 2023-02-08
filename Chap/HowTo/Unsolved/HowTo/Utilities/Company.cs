
/// <summary>
/// This class represents a Danish company.
/// All Danish companies have a CVR number, 
/// which is unique for each company.
/// </summary>
public class Company
{
    public int CVRNo { get; }
    public string Name { get; set; }
    public int NoOfEmployees { get; set; }

    public Company(int cVRNo, string name, int noOfEmployees)
    {
        CVRNo = cVRNo;
        Name = name;
        NoOfEmployees = noOfEmployees;
    }

    public override string ToString()
    {
        return $"{Name} (CVR {CVRNo}), with {NoOfEmployees} employees.";
    }
}

