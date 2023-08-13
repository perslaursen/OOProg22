
public class BankAccount
{
    /// <summary>
    /// Balance of the account; must not become negative
    /// </summary>
    public double Balance { get; private set; }

    /// <summary>
    /// Interest rate of the account; must be between 0.0 and 20.0
    /// </summary>
    public double InterestRate { get; }

    public BankAccount(double interestRate)
    {
        InterestRate = interestRate;
        Balance = 0.0;
    }

    public void Deposit(double amount)
    {
        Balance = Balance + amount;
    }

    public void Withdraw(double amount)
    {
        if (Balance < amount)
        {
            throw new WithdrawAmountTooLargeException($"Amount was {amount} kr., balance was {Balance} kr.");
        }

        Balance = Balance - amount;
    }
}