
/// <summary>
/// This class contains a general setup of user options 
/// for managing a set of data objects through CRUD+ 
/// (Create, Read, Update, Delete + Print All, Get All and Search For) 
/// operations. The data itself must be available in a repository
/// implementing the interface IRepository<T>.
/// </summary>
/// <typeparam name="T">The type of data objects to manage</typeparam>
public abstract class CRUDUserDialogBase<T> : UserDialogBase where T : class, IId
{
    private IRepository<T> _repo;
    private static string TypeName => typeof(T).Name;

    public CRUDUserDialogBase(IRepository<T> repo)
    {
        _repo = repo;
    }

    public override UserChoice InitUserChoice()
    {
        List<UserOption> initialOptions = new List<UserOption>
        {
            new UserOption("A", $"List all {TypeName}s", PrintAll),
            new UserOption("C", $"Create new {TypeName}", CreateNew),
            new UserOption("R", $"Read a {TypeName}", Read),
            new UserOption("U", $"Update a {TypeName}", Update),
            new UserOption("D", $"Delete a {TypeName}", Delete),
            new UserOption("S", $"Search for {TypeName}s", Search),
            new UserOption("B", $"Back", () => Console.WriteLine(), true),
        };

        return new UserChoice(initialOptions);
    }

    protected virtual void PrintAll()
    {
        PrintCollection(_repo.GetAll(), $"-----   All {TypeName}s in repository -----");
    }

    protected virtual void CreateNew()
    {
        T t = _repo.Create();
        Console.WriteLine($"Initial {TypeName} with Id {t.Id} created");

        CreateNewSpecific(t);
        Console.WriteLine($"Complete {TypeName} with Id {t.Id} created");
    }

    protected virtual void Read()
    {
        int id = UserInputReader.ReadIntFromUser($"Please enter the Id of the {TypeName} to read");
        T? t = _repo.Read(id);

        if (t == null)
            Console.WriteLine($"No {TypeName} with Id {id} was found");
        else
            Console.WriteLine(t);
    }

    protected virtual void Update()
    {
        int id = UserInputReader.ReadIntFromUser($"Please enter the Id of the {TypeName} to update");
        T? t = _repo.Read(id);

        if (t == null)
        {
            Console.WriteLine($"No {TypeName} with Id {id} was found");
        }
        else
        {
            T tUpdated = UpdateSpecific(t);
            _repo.Update(tUpdated);
            Console.WriteLine($"{TypeName} with Id {t.Id} updated");
        }
    }

    protected virtual void Delete()
    {
        int id = UserInputReader.ReadIntFromUser($"Please enter the Id of the {TypeName} to delete");
        bool didDelete = _repo.Delete(id);

        if (!didDelete)
            Console.WriteLine($"No {TypeName} with Id {id} was found");
        else
        {
            Console.WriteLine($"{TypeName} with Id {id} deleted");
        }
    }

    protected virtual void Search()
    {
        string searchTerm = UserInputReader.ReadStringFromUser($"Please enter a search term to search for {TypeName}s");

        List<T> ts = _repo.Search(searchTerm);
        PrintCollection(ts, $"-----   All {TypeName}s matching search term \"{searchTerm}\" -----");
    }


    protected string FormatNewPrompt(string propertyName)
    {
        return $"Please enter the {propertyName} of the {TypeName}";
    }

    protected string FormatUpdatePrompt<V>(string propertyName, V currentValue)
    {
        return $"Please enter the new {propertyName} of the {TypeName} (or blank to keep current value: {currentValue})";
    }

    protected void PrintCollection(List<T> collection, string header)
    {
        Console.WriteLine();
        Console.WriteLine(header);

        foreach (T t in collection)
        {
            Console.WriteLine(t);
        }

        Console.WriteLine();
    }

    /// <summary>
    /// This method must be overrided in a derived class, 
    /// to implement the details of how to create a new 
    /// object of type T.
    /// </summary>
    protected abstract void CreateNewSpecific(T t);

    /// <summary>
    /// This method must be overrided in a derived class, 
    /// to implement the details of how to update an
    /// object of type T.
    /// </summary>
    protected abstract T UpdateSpecific(T t);
}
