
/// <summary>
/// This class makes it possible to adapt a domain 
/// class which does not implement IHasKey.
/// </summary>
/// <typeparam name="T">Type of domain class being adapted</typeparam>
public class KeyAdapter<T> : IHasKey
{
    #region Properties
    public int Key { get; set; }
    public T Data { get; }
    #endregion

    #region Constructor
    public KeyAdapter(T obj, int key)
    {
        Data = obj;
        Key = key;
    }
    #endregion
}
