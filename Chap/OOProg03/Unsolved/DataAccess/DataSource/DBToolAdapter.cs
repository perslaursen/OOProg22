
using System.Security.Cryptography;
/// <summary>
/// This class implements an adapter for the DBTool. That is, the class
/// 1) Implements the IDataSource interface (with TKey = int).
/// 2) Adapts a DBTool instance, and thus implements the IDataSource
///    methods by calling methods on the DBTool instance.
/// </summary>
/// <typeparam name="T">Type of domain object (must implement IHasKey)</typeparam>
public class DBToolAdapter<T> : IDataSource<int, T> where T : class, IHasKey
{
    #region Instance fields
    private DBTool<T> _dbTool;
    
    #endregion

    #region Constructor
    public DBToolAdapter()
    {
        _dbTool = new DBTool<T>();
    }
    #endregion

    #region Properties (from IDataSource interface)
    public int Count
    {
        // Implement this property by using _dbTool
        
        get { return _dbTool.NoOfRecords(); }
    }

    public Dictionary<int, T> All
    {
        // Implement this property by using _dbTool
        get 
        { 
            List<int> keys = _dbTool.GetAllKeys();

            Dictionary<int, T> myDictonaty = new Dictionary<int, T>();

            foreach (var key in keys)
            {
                T obj = _dbTool.GetRecord(key);
                myDictonaty.Add(key, obj);
            }
            return myDictonaty;

        }
    }
    #endregion

    #region Methods (from IDataSource interface)
    public void Create(int key, T data)
    {
        // Implement this method by using _dbTool
        data.Key = key;
        _dbTool.InsertRecord(data);
    }

    public T Read(int key)
    {
        // Implement this method by using _dbTool
        return _dbTool.GetRecord(key);
        
    }

    public void Update(int key, T data)
    {
        // Implement this method by using _dbTool
        T oldData = Read(key);
        _dbTool.UpdateRecord(oldData,data);
    }

    public void Delete(int key)
    {
        // Implement this method by using _dbTool
        _dbTool.RemoveRecord(key);
    }

    public void Load()
    {
        // Implement this method by using _dbTool
        _dbTool.ReadFromDB();
    }

    public void Save()
    {
        // Implement this method by using _dbTool
        _dbTool.WriteToDB();
    }
    #endregion
}
