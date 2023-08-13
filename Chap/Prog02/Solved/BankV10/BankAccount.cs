
public class BankAccount
{
    #region Properties
    public double Balance
    {
        get; private set;
    }
    #endregion

    #region Constructor
    public BankAccount()
    {
        Balance = 0.0;
    }
    #endregion

    #region Methods
    public void Deposit(double amount)
    {
        if (amount > 0)
        {
            Balance = Balance + amount;
        }
    }

    public void Withdraw(double amount)
    {
        if ((amount > 0) && (amount <= Balance))
        {
            Balance = Balance - amount;
        }
    }
    #endregion
}
