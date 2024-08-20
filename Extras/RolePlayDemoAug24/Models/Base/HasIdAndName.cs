namespace RolePlayDemoAug24.Models.Base;

/// <summary>
/// Base clas for all entities which 
/// 1) Can be uniquely identified by a numeric id.
/// 2) Have a Name
/// All ids are drawn from a shared static instance field.
/// </summary>
public class HasIdAndName
{
    private static int _nextId = 0;

    public int Id { get; private set; }
    public string Name { get; }

    public HasIdAndName(string name)
    {
        Id = _nextId++;
        Name = name;
    }
}
