
/// <summary>
/// This class is the "desolved" version of the Drink class.
/// It has a structure that reflects the way a Drink object 
/// is stored in a relational database.
/// </summary>
public class DrinkDesolved : IHasId
{
    #region Properties

    public int Id { get; set; }
    public string Name { get; }
    public int? AlcoholicPartId { get; }
    public int? NonAlcoholicPartId { get; }
    public int? AlcoholicPartAmount { get; }
    public int? NonAlcoholicPartAmount { get; }

    #endregion

    public DrinkDesolved(int id, string name,
        int? alcoholicPartId, int? alcoholicPartAmount,
        int? nonAlcoholicPartId, int? nonAlcoholicPartAmount)
    {
        Id = id;
        Name = name;

        AlcoholicPartId = alcoholicPartId;
        AlcoholicPartAmount = alcoholicPartAmount;

        NonAlcoholicPartId = nonAlcoholicPartId;
        NonAlcoholicPartAmount = nonAlcoholicPartAmount;
    }
}
