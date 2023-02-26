using RazorPageADODemo.Models;
using RazorPageADODemo.Services.Repositories.ADO.Base;
using RazorPageADODemo.Services.Repositories.General.Model;
using System.Data.SqlClient;

namespace RazorPageADODemo.Services.Repositories.ADO.Model
{
    /// <summary>
    /// Customer-specific ADO-based repository. Here we
    /// 1) Provide the specific table name to read data from.
    /// 2) Override the abstract methods from the repository base class.
    /// </summary>
    public class ADOCustomerRepository : AppRepositoryBase<Customer>, ICustomerRepository
    {
        public ADOCustomerRepository(IConfiguration configuration)
            : base(configuration, "Customer")
        {
        }

        // Override for Create
        protected override string InsertValuesParameterList()
        {
            return "(@ID , @Name, @Email, @Address)";
        }

        // Override for Create
        protected override void AddInsertValues(Customer? customer, SqlCommand cmd)
        {
            if (customer == null)
                throw new ArgumentNullException(nameof(customer));

            cmd.Parameters.AddWithValue("@ID", customer.ID);
            AddNonIdParameters(customer, cmd);
        }


        // Override for Read
        protected override Customer GetRowAsT(SqlDataReader reader)
        {
            int id = reader.GetInt32(0);
            string name = reader.GetString(1);
            string email = reader.GetString(2);
            string address = reader.GetString(3);

            return new Customer(id, name, email, address);
        }


        // Override for Update
        protected override string UpdateValuesParameterList()
        {
            return "Name = @Name, Email = @Email, Address = @Address";
        }

        // Override for Update
        protected override void AddUpdateValues(Customer? customer, SqlCommand cmd)
        {
            if (customer == null)
                throw new ArgumentNullException(nameof(customer));

            AddNonIdParameters(customer, cmd);
        }

        // Helper for setting parameter values.
        private void AddNonIdParameters(Customer customer, SqlCommand cmd)
        {
            cmd.Parameters.AddWithValue("@Name", customer.Name);
            cmd.Parameters.AddWithValue("@Email", customer.Email);
            cmd.Parameters.AddWithValue("@Address", customer.Address);
        }
    }
}
