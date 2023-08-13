
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
        if (interestRate < 0.0 || interestRate > 20.0)
        {
            IllegalInterestRateException e = new IllegalInterestRateException($"Interest rate was {interestRate} %");
            throw e;
        }

        InterestRate = interestRate;
        Balance = 0.0;
    }

    public void Deposit(double amount)
    {
        if (amount < 0)
        {
            NegativeAmountException e = new NegativeAmountException($"Amount was {amount} kr.");
            throw e;
        }

        Balance = Balance + amount;
    }

    public void Withdraw(double amount)
    {
        if (amount < 0)
        {
            NegativeAmountException e = new NegativeAmountException($"Amount was {amount} kr.");
            throw e;
        }

        if (Balance < amount)
        {
            WithdrawAmountTooLargeException e = new WithdrawAmountTooLargeException($"Amount was {amount} kr., balance was {Balance} kr.");
            throw e;
        }

        Balance = Balance - amount;
    }
}
