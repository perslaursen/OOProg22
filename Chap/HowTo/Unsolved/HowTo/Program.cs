//ChainLinkInt linkC = new ChainLinkInt(12);
//ChainLinkInt linkB = new ChainLinkInt(7, linkC);
//ChainLinkInt linkA = new ChainLinkInt(29, linkB);

//ChainLinkInt? link = linkA;

//while (link != null)
//{
//    Console.WriteLine(link.Value);
//    link = link.Next;
//}

//ChainLinkDouble linkC3 = new ChainLinkDouble(12);
//ChainLinkDouble linkB2 = new ChainLinkDouble(7, linkC3);
//ChainLinkDouble linkA1 = new ChainLinkDouble(29, linkB2);

//ChainLinkDouble? link1 = linkA1;

//while (link1 != null)
//{
//    Console.WriteLine(link1.Value);
//    link1 = link1.Next;
//}

//ChainLink<int> linkedC = new ChainLink<int>(12);
//ChainLink<int> linkedB = new ChainLink<int>(7, linkedC);
//ChainLink<int> linkedA = new ChainLink<int>(29, linkedB);

//ChainLink<int>? linked = linkedA;

////while (linked != null)
////{
////    Console.WriteLine(linked.Value);
////    linked = linked.Next;
////}

//void PrintChainedCollection<T>(ChainLink<T> start)
//{
//    ChainLink<T>? linked = start;
//    while (linked != null)
//    {
//        Console.WriteLine(linked.Value);
//        linked = linked.Next;
//    }
//}

//PrintChainedCollection<int>(linked);

Person silas = new Person(3,"silas");

Person josh = new Person(2,"josh");

Item ball = new Item(1, "Ball");

Item ball2 = new Item(2, "Football");

Console.WriteLine(silas);
Console.WriteLine(josh);
Console.WriteLine(ball);
Console.WriteLine(ball2);