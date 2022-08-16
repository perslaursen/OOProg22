
// Create a PulseGenerator object
PulseGenerator thePulseGenerator = new PulseGenerator();

// Create some Stock objects


// Create some StockTrader objects


// Update stock prices on every Pulse event


// Make sure StockTrader objects are notified when
// the price of a stock changes


// Print out current stock prices on every Pulse event


// Print out the entire Trade log on the LastPulse event


// Start pulsing...
thePulseGenerator.Start(200, 20);

Console.ReadKey();
