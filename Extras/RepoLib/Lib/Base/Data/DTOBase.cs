
/// <summary>
/// Base class for all DTO classes. A DTO (Data Transfer Object) class is a class that reflects
/// a corresponding model class, but with the specific purpose of enabling easier transport and/or
/// storage of the data in a model object. This could be done by replacing object references 
/// in the model object with object identifiers in the DTO object.
/// The DTO class uses a numeric Id for object identification.
/// </summary>
public class DTOBase : IHasId
{
    public int Id { get; set; }

    public DTOBase()
    {
    }
}
