
public class Person : IdBase<Person>
{
    public string Name { get; }

    public Person(int id, string name) : base(id)
    {
        Name = name;
    }

    public override string ToString()
    {
        return base.ToString() + Name;
    }
}
