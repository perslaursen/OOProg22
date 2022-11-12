
/// <summary>
/// User dialog for managing Customers
/// </summary>
public class CustomerUserDialog : CRUDUserDialogBase<Customer>
{
    public CustomerUserDialog(CustomerRepository repo) : base(repo)
    {
    }

    protected override void CreateNewSpecific(Customer customer)
    {
        string name = UserInputReader.ReadStringFromUser(FormatNewPrompt("Description"));
        string address = UserInputReader.ReadStringFromUser(FormatNewPrompt("Address"));
        string phone = UserInputReader.ReadStringFromUser(FormatNewPrompt("Phone"));

        customer.Name = name;
        customer.Address = address;
        customer.Phone = phone;
    }

    protected override Customer UpdateSpecific(Customer customer)
    {
        string name = UserInputReader.ReadStringFromUser(FormatUpdatePrompt("Description", customer.Name), customer.Name);
        string address = UserInputReader.ReadStringFromUser(FormatUpdatePrompt("Address", customer.Address), customer.Address);
        string phone = UserInputReader.ReadStringFromUser(FormatUpdatePrompt("Phone", customer.Phone), customer.Phone);

        customer.Name = name;
        customer.Address = address;
        customer.Phone = phone;

        return customer;
    }
}

