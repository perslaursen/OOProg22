
PulseGenerator theGenerator = new PulseGenerator();

// Create some Clock objects


// Attach the relevant methods from the Clock objects 
// to the Pulse event in theGenerator


// Start pulsing... (don't mind the warning about "...not awaited")
theGenerator.Start(200);

Console.ReadKey();
