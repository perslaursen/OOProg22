
StockMarket market = new StockMarket();

market.GoodDay();
market.GoodDay();
market.BadDay();
market.GoodDay();
market.BadDay();

Console.WriteLine($"My earnings were {market.PortfolioEarningsPercentage:F2} %");
