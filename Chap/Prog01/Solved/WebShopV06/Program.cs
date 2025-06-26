
double netPriceBook = 30;
double netPriceDVD = 50;
double netPriceGame = 100;

int noOfBooksInOrder = 0;
int noOfDVDsInOrder = 12;
int noOfGamesInOrder = 4;

double totalNetPrice = netPriceBook * noOfBooksInOrder + netPriceDVD * noOfDVDsInOrder + netPriceGame * noOfGamesInOrder;

// SO#1 - The net total price (no taxes, etc.) is more than 1.000 kr.
bool receiveSpecialOffer1 = (totalNetPrice > 1000);

// SO#2 - You have ordered more books than games
bool receiveSpecialOffer2 = noOfBooksInOrder > noOfGamesInOrder;

// SO#3 - You have ordered at least 10 items of one kind
bool receiveSpecialOffer3 = (noOfBooksInOrder >= 10) || 
                            (noOfDVDsInOrder >= 10) || 
                            (noOfGamesInOrder >= 10);

// SO#4 - You have ordered between 10 and 20 (incl.) DVDs,
//        or
//        at least 5 games
bool receiveSpecialOffer4 = 
    ((noOfDVDsInOrder >= 10) && (noOfDVDsInOrder <= 20)) || 
    (noOfGamesInOrder >= 5);


Console.WriteLine($"You ordered {noOfBooksInOrder} books, " +
                  $"{noOfDVDsInOrder} DVDs and " +
                  $"{noOfGamesInOrder} games");
Console.WriteLine($"You qualify for special offer #1 : {receiveSpecialOffer1}");
Console.WriteLine($"You qualify for special offer #2 : {receiveSpecialOffer2}");
Console.WriteLine($"You qualify for special offer #3 : {receiveSpecialOffer3}");
Console.WriteLine($"You qualify for special offer #4 : {receiveSpecialOffer4}");


// EXTRA - step 4

// Line up all combinations were 2-out-of-4 offers are true:
bool case1 = !receiveSpecialOffer1 && !receiveSpecialOffer2 && receiveSpecialOffer3 && receiveSpecialOffer4;
bool case2 = !receiveSpecialOffer1 && receiveSpecialOffer2 && !receiveSpecialOffer3 && receiveSpecialOffer4;
bool case3 = !receiveSpecialOffer1 && receiveSpecialOffer2 && receiveSpecialOffer3 && !receiveSpecialOffer4;
bool case4 = receiveSpecialOffer1 && !receiveSpecialOffer2 && !receiveSpecialOffer3 && receiveSpecialOffer4;
bool case5 = receiveSpecialOffer1 && !receiveSpecialOffer2 && receiveSpecialOffer3 && !receiveSpecialOffer4;
bool case6 = receiveSpecialOffer1 && receiveSpecialOffer2 && !receiveSpecialOffer3 && !receiveSpecialOffer4;

// If JUST ONE of the above is true, we have hit a 2-out-of-four combination

bool receiveExtraSpecialOffer = case1 || case2 || case3 || case4 || case5 || case6;
Console.WriteLine($"You qualify for the extra special offer: {receiveExtraSpecialOffer}");

