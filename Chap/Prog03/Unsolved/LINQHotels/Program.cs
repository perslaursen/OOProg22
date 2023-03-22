﻿
#region Hotel & Room objects and lists
List<Hotel> hotels = new List<Hotel>
            {
                new Hotel(0, "The Pope", "Vaticanstreet 1  1111 Bishopcity"),
                new Hotel(1, "Lucky Star", "Lucky Road 12  2222 Hometown"),
                new Hotel(2, "Discount", "Inexpensive Road 7 3333 Cheaptown"),
                new Hotel(3, "DeLuxeCapital", "Luxury Road 99  4444 Luxus"),
                new Hotel(4, "Discount", "Inexpensive Road 7 3333 Cheaptown"),
                new Hotel(5, "Prindsen", "Algade 5, 4000 Roskilde"),
                new Hotel(6, "Scandic", "Algade 5, 4000 Roskilde")
            };

List<Room> rooms = new List<Room>
            {
                new Room(1,0,"D",200),
                new Room(2,0,"D",200),
                new Room(3,0,"D",200),
                new Room(4,0,"D",200),
                new Room(11,0,"S",150),
                new Room(12,0,"S",150),
                new Room(13,0,"S",150),
                new Room(21,0,"F",220),
                new Room(22,0,"F",220),
                new Room(23,0,"F",220),

                new Room(1,1,"D",230),
                new Room(2,1,"D",230),
                new Room(3,1,"D",230),
                new Room(4,1,"D",230),
                new Room(11,1,"S",180),
                new Room(12,1,"S",180),
                new Room(21,1,"F",300),
                new Room(22,1,"F",300),

                new Room(1,2,"D",175),
                new Room(2,2,"D",180),
                new Room(11,2,"S",100),
                new Room(21,2,"S",100),
                new Room(31,2,"F",200),
                new Room(32,2,"F",230),

                new Room(1,3,"D",500),
                new Room(2,3,"D",550),
                new Room(3,3,"D",550),
                new Room(11,3,"S",350),
                new Room(12,3,"S",360),

                new Room(1,4,"D",250),
                new Room(2,4,"D",170),
                new Room(11,4,"S",150),
                new Room(21,4,"F",300),
                new Room(22,4,"F",310),
                new Room(23,4,"F",320),
                new Room(24,4,"F",320),

                new Room(1,5,"D",290),
                new Room(11,5,"S",185),
                new Room(21,5,"F",360),
                new Room(21,5,"F",370),
                new Room(22,5,"F",380),
                new Room(23,5,"F",380),

                new Room(1,6,"D",200),
                new Room(2,6,"D",200),
                new Room(3,6,"D",200),
                new Room(4,6,"D",200),
                new Room(11,6,"S",150),
                new Room(12,6,"S",150),
                new Room(13,6,"S",150),
                new Room(14,6,"S",150),
                new Room(21,6,"F",220),
                new Room(22,6,"F",220),
                new Room(23,6,"F",220),
                new Room(24,6,"F",220),
            };
#endregion


#region Query #1 (You get this one for free :-))
// 1) List full details of all Hotels
var query1 = from hotel in hotels
             select hotel;

PrintEnumerableQueryResult("Query #1 - Full details of all Hotels", query1);
#endregion


#region Query #2
// 2) List full details of all hotels in Roskilde
var query2 = from hotel in hotels
             where hotel.Address.Contains("Roskilde")
             select hotel;
 PrintEnumerableQueryResult("Query #2 - Full details of all hotels in Roskilde", query2);
#endregion


#region Query #3
// 3) List the names of all hotels in Roskilde
var query3 = from hotel in hotels
             where hotel.Address.Contains("Roskilde")
             select hotel.Name;
PrintEnumerableQueryResult("Query #3 - Names of all hotels in Roskilde", query3);
#endregion


#region Query #4
// 4) List all double rooms with a price below 400 kr. pr. night
var query4 = from room in rooms
             where room.Price < 400
             select room;
 PrintEnumerableQueryResult("Query #4 - All double rooms with a price below 400 kr", query4);
#endregion


#region Query #5
// 5) List all double or family rooms with a price below 
//    400 kr. pr. night, ordered by price

var query5 = from room in rooms
             where room.Price < 400 && room.Type == "F"
             select room;

PrintEnumerableQueryResult("Query #5 - All double or family rooms with a price below 400 kr. (ordered by price)", query5);
#endregion


#region Query #6
// 6) List all hotels that start with "P"
var query6 = from hotel in hotels
             where hotel.Name.Substring(0,1) == "P"
             select hotel.Name;
PrintEnumerableQueryResult("Query #6 - All hotels that start with \"P\"", query6);
#endregion


#region Query #7
// 7) Print the number of hotels
var query7 = from hotel in hotels
             select hotel;
PrintNumericQueryResult("Query # 7 - Total number of hotels", query7.Count());
#endregion


#region Query #8
// 8) Print the number of hotels in Roskilde:
var query8 = from hotel in hotels
             where hotel.Address.Contains("Roskilde")
             select hotel;
PrintNumericQueryResult("Query # 8 - Total number of hotels in Roskilde", query8.Count());
#endregion


#region Query #9
// 9) Print the average price of a room
var query9 = from room in rooms
             select room.Price;
PrintNumericQueryResult("Query # 9 - Average price of a room", query9.Sum());
#endregion


#region Query #10
// 10) Print the total reveneue per night from all double rooms:
var query10 = from room in rooms
              where room.Type == "D"
              select room.Price;
PrintNumericQueryResult("Query # 10 - Total price for all double rooms", query10.Sum()); 
#endregion


void PrintEnumerableQueryResult<T>(string leadText, IEnumerable<T> queryResult)
{
    Console.WriteLine(leadText);
    Console.WriteLine("---------------------------------");
    foreach (var item in queryResult)
    {
        Console.WriteLine(item);
    }
    Console.WriteLine();
    Console.WriteLine();
}

void PrintNumericQueryResult(string leadText, double queryResult)
{
    Console.WriteLine($"{leadText}: {queryResult:F0}");
    Console.WriteLine();
    Console.WriteLine();
}
