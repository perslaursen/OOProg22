
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
        Balance = Balance + amount;
    }

    public void Withdraw(double amount)
    {
        Balance = Balance - amount;
    }
    #endregion
}
