
/// <summary>
/// This class represents an item which can be put into e.g. a backpack.
/// An item has a description, a weight (in kg.), and a value.
/// </summary>
public class BackPackItem
{
    #region Properties
    public string Description { get; }
    public double Weight { get; }
    public int Value { get; }
    #endregion

    #region Constructor
    public BackPackItem(string description, double weight, int value)
    {
        Description = description;
        Weight = weight;
        Value = value;
    }
    #endregion

    public override string ToString()
    {
        return $"{Description} : weight {Weight} kg., worth {Value}";
    }
}

