
/// <summary>
/// This class implements a general "repository adapter", with a inner 
/// repository storing data in a converted version (of type TConv). 
/// This will typically be a DTO-like class.
/// A "data converter" (implementing IDataConverter) is used for conversion.
/// In this way, the repository client only interacts with the repository
/// in terms of model data, while being oblivious of how data is stored.
/// </summary>
/// <typeparam name="TData">Type of (model) data</typeparam>
/// <typeparam name="TConv">Type of converted data</typeparam>
public class RepositoryAdapterBase<TData, TConv> : IPersistentRepository<TData>
    where TConv : IHasId
    where TData : IHasId
{
    private IPersistentRepository<TConv> _innerRepo;
    private IDataConverter<TData, TConv> _dataConverter;

    public RepositoryAdapterBase(IPersistentRepository<TConv> innerRepo, IDataConverter<TData, TConv> dataConverter)
    {
        _innerRepo = innerRepo ?? throw new ArgumentNullException();
        _dataConverter = dataConverter ?? throw new ArgumentNullException();
    }

    public void Clear()
    {
        _innerRepo.Clear();
    }

    public int Create(TData t, int? hardId = null)
    {
        return _innerRepo.Create(_dataConverter.ConvertData(t), hardId);
    }

    public bool Delete(int id)
    {
        return _innerRepo.Delete(id);
    }

    public List<TData> GetAll()
    {
        return _innerRepo.GetAll().Select(e => _dataConverter.CreateData(e)).ToList();
    }

    public Dictionary<int, TData> GetAllAsDictionary()
    {
        return _innerRepo.GetAllAsDictionary().ToDictionary(e => e.Key, e => _dataConverter.CreateData(e.Value));
    }

    public void InitFromList(List<TData> elements, bool useIds)
    {
        _innerRepo.InitFromList(elements.Select(e => _dataConverter.ConvertData(e)).ToList(), useIds);
    }

    public TData? Read(int id)
    {
        TConv? conv = _innerRepo.Read(id);
        return conv != null ? _dataConverter.CreateData(conv) : default;
    }

    public virtual List<TData> Search(string searchTerm)
    {
        return _innerRepo.Search(searchTerm).Select(e => _dataConverter.CreateData(e)).ToList();
    }

    public bool Update(int id, TData t)
    {
        return _innerRepo.Update(id, _dataConverter.ConvertData(t));
    }

    public void Load()
    {
        _innerRepo.Load();
    }

    public void Save()
    {
        _innerRepo.Save();
    }

    public override string ToString()
    {
        List<TData> elements = GetAll();

        string result = $"{typeof(TData)} repository, {elements.Count} elements\n";

        foreach (TData t in elements)
        {
            result += t.ToString();
            result += "\n";
        }

        return result;
    }
}

