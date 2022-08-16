
public interface ICollectionGet<T>
{
    T Get(int index);
    int Count { get; }
}
