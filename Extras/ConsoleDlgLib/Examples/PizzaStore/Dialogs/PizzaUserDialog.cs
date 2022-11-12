
/// <summary>
/// User dialog for managing Pizzas
/// </summary>

public class PizzaUserDialog : CRUDUserDialogBase<Pizza>
{

    public PizzaUserDialog(PizzaRepository repo) : base(repo)
    {
    }

    protected override void CreateNewSpecific(Pizza pizza)
    {
        string name = UserInputReader.ReadStringFromUser(FormatNewPrompt("Description"));
        int price = UserInputReader.ReadIntFromUser(FormatNewPrompt("Price"));

        pizza.Description = name;
        pizza.Price = price;
    }

    protected override Pizza UpdateSpecific(Pizza pizza)
    {
        string name = UserInputReader.ReadStringFromUser(FormatUpdatePrompt("Description", pizza.Description), pizza.Description);
        int price = UserInputReader.ReadIntFromUser(FormatUpdatePrompt("Price", pizza.Price), pizza.Price);

        pizza.Description = name;
        pizza.Price = price;

        return pizza;
    }
}

