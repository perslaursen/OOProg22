
double netPriceBook = 30;
double netPriceDVD = 50;
double netPriceGame = 100;

int noOfBooksInOrder = 8;
int noOfDVDsInOrder = 3;
int noOfGamesInOrder = 2;

// I have chosen a style where each part of the total price is
// calculated explicitly. All parts are then added up.
// I also print out each part of the price, both for information and
// to make it easier to find errors.

double taxPercentage = 10.0;
double creditCardFeePercentage = 2.0;
double shippingForAllItems = 49;

double netPriceForBooks = netPriceBook * noOfBooksInOrder;
double netPriceForDVDs = netPriceDVD * noOfDVDsInOrder;
double netPriceForGames = netPriceGame * noOfGamesInOrder;

Console.WriteLine($"Net price for books is {netPriceForBooks} kr.");
Console.WriteLine($"Net price for DVDs is {netPriceForDVDs} kr.");
Console.WriteLine($"Net price for games is {netPriceForGames} kr.");
Console.WriteLine("----------------------------------------------");

double netPriceForAllItems = netPriceForBooks + netPriceForDVDs + netPriceForGames;

Console.WriteLine($"Net price for all items is {netPriceForAllItems} kr.");
Console.WriteLine();

double taxForAllItems = netPriceForAllItems * (taxPercentage / 100);

Console.WriteLine($"Tax price for all items is {taxForAllItems} kr.");


double creditCardFeeForAllItems = (netPriceForAllItems + taxForAllItems + shippingForAllItems) *
                                  (creditCardFeePercentage / 100);

Console.WriteLine($"Credit card fee for all items is {creditCardFeeForAllItems} kr.");


Console.WriteLine($"Shipping for all items is {shippingForAllItems} kr.");
Console.WriteLine("----------------------------------------------");
Console.WriteLine();


double totalPrice = netPriceForAllItems + taxForAllItems +
                    shippingForAllItems + creditCardFeeForAllItems;

Console.WriteLine($"You ordered {noOfBooksInOrder} books, " +
                  $"{noOfDVDsInOrder} DVDs and " +
                  $"{noOfGamesInOrder} games");
Console.WriteLine($"Total cost including tax, shipping and credit card fee: {totalPrice} kr.");

