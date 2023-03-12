
public class Item : IdBase<Item>
{
    public string Description { get; }

    public Item(int id, string name) : base(id)
    {
        Description = name;
    }

    public override string ToString()
    {
        return base.ToString() + Description;
    }
}
