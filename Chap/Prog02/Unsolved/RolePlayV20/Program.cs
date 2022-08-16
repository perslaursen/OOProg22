
NumberGenerator theNumberGenerator = new NumberGenerator();
BattleLog theLog = new BattleLog();

Hero theHero = new Hero(theNumberGenerator, theLog);
Beast theBeast = new Beast(theNumberGenerator, theLog);

// Now battle...How do we do that (Hint: You need a loop)

theLog.PrintLog();
