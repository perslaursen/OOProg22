
using System.Diagnostics;

Stopwatch watch = new Stopwatch();
PiCalc calculatorOrg = new PiCalc();
PiCalcFixedTasks calculatorFixed = new PiCalcFixedTasks();
PiCalcListOfTasks calculatorList = new PiCalcListOfTasks();
PiCalcParallel calculatorParallel = new PiCalcParallel();

Console.WriteLine("Started");
watch.Start();
// double numPi = calculatorOrg.Calculate(100000000);
// double numPi = calculatorFixed.Calculate(100000000);
//double numPi = calculatorList.Calculate(100000000, 8);
double numPi = calculatorParallel.Calculate(100000000, 8);
watch.Stop();
Console.WriteLine("Done");

Console.WriteLine($"Numeric PI = {numPi:0.000000}");
Console.WriteLine($"Real PI    = {Math.PI:0.000000}");
Console.WriteLine($"Took {watch.ElapsedMilliseconds} milliSecs");
Console.WriteLine();
