
BankAccount account = new BankAccount();
Console.WriteLine($"Balance is {account.Balance}");

account.Deposit(1000);
Console.WriteLine($"Balance is {account.Balance}");

account.Deposit(-200);
Console.WriteLine($"Balance is {account.Balance}");

account.Withdraw(-200);
Console.WriteLine($"Balance is {account.Balance}");

account.Withdraw(1500);
Console.WriteLine($"Balance is {account.Balance}");

account.Withdraw(800);
Console.WriteLine($"Balance is {account.Balance}");
