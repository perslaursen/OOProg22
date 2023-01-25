
/// <summary>
/// Domain class representing a customer. 
/// This domain class does implement IHasKey.
/// </summary>
public class Customer : IHasKey
{
    #region Properties
    public int Key { get; set; }
    public string Name { get; }
    public string Phone { get; }
    #endregion

    #region Constructor
    public Customer(string name, string phone, int key)
    {
        Key = key;
        Name = name;
        Phone = phone;
    }
    #endregion

    #region Methods
    public override string ToString()
    {
        return $"Customer: Key = {Key}, Name = {Name}, Phone = {Phone}";
    }
    #endregion
}
