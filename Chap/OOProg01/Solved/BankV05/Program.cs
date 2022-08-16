
BankAccount myAccount = new BankAccount("Per Laursen");

Console.WriteLine($"Account holder is {myAccount.Name}");

myAccount.Deposit(2000);
Console.WriteLine($"Account balance is : {myAccount.Balance}");

myAccount.Withdraw(1500);
Console.WriteLine($"Account balance is : {myAccount.Balance}");
