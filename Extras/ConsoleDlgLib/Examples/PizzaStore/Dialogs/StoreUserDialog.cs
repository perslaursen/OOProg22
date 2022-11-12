
/// <summary>
/// This class represents the top-level user options for a Pizza Store.
/// These options are: Manage Pizzas, manage Customers, or Quit.
/// </summary>
public class StoreUserDialog : UserDialogBase
{
    private PizzaRepository? _pizzaRepo;
    private CustomerRepository? _customerRepo;

    private PizzaRepository PizzaRepo => _pizzaRepo ??= new PizzaRepository();
    private CustomerRepository CustomerRepo => _customerRepo ??= new CustomerRepository();

    public override UserChoice InitUserChoice()
    {
        List<UserOption> initialOptions = new List<UserOption>
        {
            new UserOption("P", "Pizza", RunPizzaUserDialog),
            new UserOption("C", "Customer", RunCustomerUserDialog),
            new UserOption("Q", "Quit", RunQuit, true),
        };

        return new UserChoice(initialOptions);
    }

    private void RunPizzaUserDialog()
    {
        PizzaUserDialog pizzaUD = new PizzaUserDialog(PizzaRepo);
        pizzaUD.Run();
    }

    private void RunCustomerUserDialog()
    {
        CustomerUserDialog customerUD = new CustomerUserDialog(CustomerRepo);
        customerUD.Run();
    }

    private void RunQuit()
    {
        Console.WriteLine("You chose to quit... bye...");
    }
}
