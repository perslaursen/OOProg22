
public abstract class JsonRepositoryBase<T, TDTO> : RepositoryWithDataSourceBase<T> 
    where T : IHasId 
    where TDTO : IHasId
{
    public JsonRepositoryBase(bool loadOnCreation = true) 
        : base(loadOnCreation)    
    {
    }

    protected abstract string JsonFileName { get; }

    protected override List<T> ReadAllFromDataSource()
    {
        List<TDTO> dtoList = JsonFileReader<TDTO>.ReadJson(JsonFileName);

        List<T> elements = new List<T>();
        foreach (TDTO dto in dtoList)
        {
            elements.Add(FromDTO(dto));
        }

        return elements;
    }

    protected override void SaveAllToDataSource(List<T> elements)
    {
        List<TDTO> dtoList = new List<TDTO>();

        foreach (T t in elements)
        {
            dtoList.Add(ToDTO(t));
        }

        JsonFileWriter<TDTO>.WriteToJson(dtoList, JsonFileName);
    }

    protected abstract T FromDTO(TDTO dto);
    protected abstract TDTO ToDTO(T t);
}
