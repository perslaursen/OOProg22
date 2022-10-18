    
public abstract class JsonRepositorySimple<T> : JsonRepositoryBase<T, T> where T : IHasId
{
    public JsonRepositorySimple(bool loadOnCreation = true)
        : base(loadOnCreation)
    {
    }

    protected override T FromDTO(T dto) => dto;
    protected override T ToDTO(T t) => t;
}
