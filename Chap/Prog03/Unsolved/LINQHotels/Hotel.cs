
/// <summary>
/// A simple class representing a hotel. A hotel has a
/// unique ID, plus a name and an adresss
/// </summary>
public class Hotel
{
    #region Properties
    public int ID { get; }
    public string Name { get; }
    public string Address { get; }
    #endregion

    #region Constructor
    public Hotel(int id, string name, string address)
    {
        ID = id;
        Name = name;
        Address = address;
    }
    #endregion

    public override string ToString()
    {
        return $"ID: {ID}, Name: {Name}, Address: {Address}";
    }
}
