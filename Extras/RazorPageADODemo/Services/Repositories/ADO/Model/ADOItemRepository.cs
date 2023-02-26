using RazorPageADODemo.Models;
using RazorPageADODemo.Services.Repositories.ADO.Base;
using RazorPageADODemo.Services.Repositories.General.Model;
using System.Data.SqlClient;

namespace RazorPageADODemo.Services.Repositories.ADO.Model
{
    /// <summary>
    /// Item-specific ADO-based repository. Here we
    /// 1) Provide the specific table name to read data from.
    /// 2) Override the abstract methods from the repository base class.
    /// </summary>
    public class ADOItemRepository : AppRepositoryBase<Item>, IItemRepository
    {
        public ADOItemRepository(IConfiguration configuration)
            : base(configuration, "Item")
        {
        }

        // Override for Create
        protected override string InsertValuesParameterList()
        {
            return "(@ID , @Name, @Price)";
        }

        // Override for Create
        protected override void AddInsertValues(Item? item, SqlCommand cmd)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            cmd.Parameters.AddWithValue("@ID", item.ID);
            AddNonIdParameters(item, cmd);
        }


        // Override for Read
        protected override Item GetRowAsT(SqlDataReader reader)
        {
            int id = reader.GetInt32(0);
            string name = reader.GetString(1);
            var price = reader.GetDouble(2);

            return new Item(id, name, price);
        }


        // Override for Update
        protected override string UpdateValuesParameterList()
        {
            return "Name = @Name, Price = @Price";
        }

        // Override for Update
        protected override void AddUpdateValues(Item? item, SqlCommand cmd)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            AddNonIdParameters(item, cmd);
        }

        // Helper for setting parameter values.
        private void AddNonIdParameters(Item item, SqlCommand cmd)
        {
            cmd.Parameters.AddWithValue("@Name", item.Name);
            cmd.Parameters.AddWithValue("@Price", item.Price);
        }
    }
}
