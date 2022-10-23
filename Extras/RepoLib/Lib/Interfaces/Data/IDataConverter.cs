
/// <summary>
/// Interface for converting between a data class (typically a model class), 
/// and a corresponding converted version of data (typically a DTO class)
/// </summary>
/// <typeparam name="TData">Type of data class</typeparam>
/// <typeparam name="TConv">Type of converted class</typeparam>
public interface IDataConverter<TData, TConv>
{
    TConv ConvertData(TData data);
    TData CreateData(TConv dto);
}
