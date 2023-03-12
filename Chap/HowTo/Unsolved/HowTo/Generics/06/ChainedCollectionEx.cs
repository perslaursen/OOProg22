
using System.Collections;

public class ChainedCollectionEx<T> :
    ChainedCollectionDone<T>, 
    IChainedCollection<T>, 
    IEnumerable<T> where T : IHasId
{
    public IEnumerator<T> GetEnumerator()
    {
        return GetEnumeratorInternal();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumeratorInternal();
    }

    private IEnumerator<T> GetEnumeratorInternal()
    {
        return GetAll().GetEnumerator();
    }
}
