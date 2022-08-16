
// ListMethods test
List<int> aList = new List<int> { 23, 86, 51, 11, 39 };
ListMethods listMethodsObject = new ListMethods();

int smallest = listMethodsObject.FindSmallestNumber(aList);
Console.WriteLine($"The smallest number in the list is : {smallest}");

int average = listMethodsObject.FindAverage(aList);
Console.WriteLine($"The average of the list is : {average}");

