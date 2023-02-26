using RazorPageADODemo.Services.Repositories.ADO.Base;
using RazorPageADODemo.Services.Repositories.ADO.DTO;
using RazorPageADODemo.Services.Repositories.General.Model;
using System.Data.SqlClient;

namespace RazorPageADODemo.Services.Repositories.ADO.Model
{
    public class ADOOrderDTORepository : AppRepositoryBase<OrderDTO>, IOrderDTORepository
    {
        public ADOOrderDTORepository(IConfiguration configuration)
            : base(configuration, "Order")
        {
        }

        // Override for Create
        protected override string InsertValuesParameterList()
        {
            return "(@ID , @CustomerId, @ItemId, @Amount)";
        }

        // Override for Create
        protected override void AddInsertValues(OrderDTO? order, SqlCommand cmd)
        {
            if (order == null)
                throw new ArgumentNullException(nameof(order));

            cmd.Parameters.AddWithValue("@ID", order.ID);
            AddNonIdParameters(order, cmd);
        }


        // Override for Read
        protected override OrderDTO GetRowAsT(SqlDataReader reader)
        {
            int id = reader.GetInt32(0);
            int? customerId = reader.IsDBNull(1) ? null : reader.GetInt32(1);
            int? itemId = reader.IsDBNull(2) ? null : reader.GetInt32(2);
            int amount = reader.GetInt32(3);


            return new OrderDTO(id, customerId, itemId, amount);
        }


        // Override for Update
        protected override string UpdateValuesParameterList()
        {
            return "CustomerId = @CustomerId, ItemId = @ItemId, Amount = @Amount";
        }

        // Override for Update
        protected override void AddUpdateValues(OrderDTO? order, SqlCommand cmd)
        {
            if (order == null)
                throw new ArgumentNullException(nameof(order));

            AddNonIdParameters(order, cmd);
        }

        // Helper for setting parameter values.
        private void AddNonIdParameters(OrderDTO order, SqlCommand cmd)
        {
            cmd.Parameters.AddWithValue("@CustomerId", order.CustomerId);
            cmd.Parameters.AddWithValue("@ItemId", order.ItemId);
            cmd.Parameters.AddWithValue("@Amount", order.Amount);
        }
    }
}
