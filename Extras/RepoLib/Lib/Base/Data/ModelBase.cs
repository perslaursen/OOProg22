
/// <summary>
/// Base class for all Model classes. A model class is a class reflecting a conceptual domain class.
/// The model class is not aware of how it is stored and transported.
/// The model class uses a numeric Id for object identification.
/// </summary>
/// <typeparam name="T">Type of actual model class. Needed for implementing ToString</typeparam>
public abstract class ModelBase<T> : IHasId
{
    public int Id { get; set; }

    public ModelBase(int id = 0)
    {
        Id = id;
    }

    public override string ToString()
    {
        return $"{typeof(T)} with Id {Id}";
    }
}
