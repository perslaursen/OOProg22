
/// <summary>
/// The PersonRepository class should handle any exceptions 
/// that might occur from creating/updating a Person object, 
/// as well as throw exceptions in case of error situations.
/// </summary>
public class PersonRepository
{
    private static int _nextId = 1;

    private Dictionary<int, Person> _persons;

    public PersonRepository()
    {
        _persons = new Dictionary<int, Person>();
    }

    public int Create(string name, double height, double weight)
    {
        int id = _nextId;

        // Creating a new Person object may produce an exception...
        _persons[id] = new Person(name, height, weight);
        _nextId++;

        return id;
    }

    public Person Read(int id)
    {
        // If no Person object is stored with the given id,
        // it is considered an error!
        return _persons[id];
    }

    public void Update(int id, Person person)
    {
        // If no Person object is stored with the given id - i.e.
        // we cannot update any object -  it is considered an error!
        // NB: The updating itself may produce an exception...
        _persons[id].UpdateFromOther(person);
    }

    public void Delete(int id)
    {
        // If no Person object is stored with the given id - i.e.
        // we cannot delete any object -  it is considered an error!
        _persons.Remove(id);
    }
}


