
/// <summary>
/// A class representing a hotel room. A hotel room has
/// 1) A number
/// 2) A hotel ID
/// 3) A type ("D": Double, "F": Family, S:"Single")
/// 4) A price
/// </summary>
public class Room
{
    #region Properties
    public int No { get; }
    public int HotelID { get; }
    public string Type { get; }
    public int Price { get; }
    #endregion

    #region Constructor
    public Room(int no, int hotelID, string type, int price)
    {
        No = no;
        HotelID = hotelID;
        Type = type;
        Price = price;
    }
    #endregion

    public override string ToString()
    {
        return $"HotelNo: {HotelID}, No: {No}, Type: {Type}, Price: {Price}";
    }
}
