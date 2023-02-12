
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

        try
        {
            _persons[id] = new Person(name, height, weight);
            _nextId++;
        }
        catch (Exception)
        {
            string msg = $"Person data: {name}, {height}, {weight}";
            throw new RepositoryException(RepositoryExceptionType.Create, msg);
        }

        return id;
    }

    public Person Read(int id)
    {
        if (_persons.ContainsKey(id))
        {
            return _persons[id];
        }
        else
        {
            string msg = $"Person Id: {id}";
            throw new RepositoryException(RepositoryExceptionType.Read, msg);
        }
    }

    public void Update(int id, Person person)
    {
        if (_persons.ContainsKey(id))
        {
            try
            {
                _persons[id].UpdateFromOther(person);
            }
            catch (Exception)
            {
                string msg = $"Person data: {id}, {person.Name}, {person.Height}, {person.Weight}";
                throw new RepositoryException(RepositoryExceptionType.Update, msg);
            }
        }
        else
        {
            string msg = $"Person Id: {id}";
            throw new RepositoryException(RepositoryExceptionType.Update, msg);
        }
    }

    public void Delete(int id)
    {
        if (_persons.ContainsKey(id))
        {
            _persons.Remove(id);
        }
        else
        {
            string msg = $"Person Id: {id}";
            throw new RepositoryException(RepositoryExceptionType.Delete, msg);
        }
    }
}



