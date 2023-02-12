
/// <summary>
/// A Service that supports CRUD operations for Person objects
/// by calling corresponding repository methods.
/// This class does NOT want to handle any exceptions!
/// </summary>
public class PersonService
{
    private PersonRepository _personRepository;

    public PersonService(PersonRepository personRepository)
    {
        _personRepository = personRepository;
    }

    /// <summary>
    /// Creates a Person object from the given data
    /// </summary>
    /// <param name="name">Name</param>
    /// <param name="height">Height (in meters)</param>
    /// <param name="weight">Weight (in kilograms)</param>
    public int CreatePerson(string name, double height, double weight)
    {
        return _personRepository.Create(name, height, weight);
    }

    /// <summary>
    /// Reads the Person object with the given id.
    /// </summary>
    public Person ReadPerson(int id)
    {
        return _personRepository.Read(id);
    }

    /// <summary>
    /// Updates height and weight for the Person object with the given id.
    /// </summary>
    public Person UpdatePerson(int id, double height, double weight)
    {
        Person person = new Person("Data", height, weight);
        _personRepository.Update(id, person);

        return _personRepository.Read(id);
    }

    /// <summary>
    /// Deletes the Person object with the given id.
    /// </summary>
    public void DeletePerson(int id)
    {
        _personRepository.Delete(id);
    }
}

