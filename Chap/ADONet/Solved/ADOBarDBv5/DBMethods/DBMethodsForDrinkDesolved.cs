
using Microsoft.Data.SqlClient;

public class DBMethodsForDrinkDesolved : DBMethodsBase<DrinkDesolved>
{
    public DBMethodsForDrinkDesolved(string connectionString)
        : base(connectionString, "Drink", "(@Id , @Name, @AlcoholicPartId, @AlcoholicPartAmount, @NonAlcoholicPartId, @NonAlcoholicPartAmount)")
    {
    }

    protected override Dictionary<string, int> GetColIndices(SqlDataReader reader)
    {
        Dictionary<string, int> colIndices = new()
        {
            { "Id", reader.GetOrdinal("Id") },
            { "Name", reader.GetOrdinal("Name") },
            { "AlcoholicPartId", reader.GetOrdinal("AlcoholicPartId") },
            { "AlcoholicPartAmount", reader.GetOrdinal("AlcoholicPartAmount") },
            { "NonAlcoholicPartId", reader.GetOrdinal("NonAlcoholicPartId") },
            { "NonAlcoholicPartAmount", reader.GetOrdinal("NonAlcoholicPartAmount") }
        };

        return colIndices;
    }

    protected override DrinkDesolved GetRow(SqlDataReader reader, Dictionary<string, int> colIndices)
    {
        int id = reader.GetInt32(colIndices["Id"]);
        string name = reader.GetString(colIndices["Name"]);
        int? alcoholicPartId = reader.IsDBNull(colIndices["AlcoholicPartId"]) ? null : reader.GetInt32(colIndices["AlcoholicPartId"]);
        int? nonAlcoholicPartId = reader.IsDBNull(colIndices["NonAlcoholicPartId"]) ? null : reader.GetInt32(colIndices["NonAlcoholicPartId"]);
        int? alcoholicPartAmount = reader.IsDBNull(colIndices["AlcoholicPartAmount"]) || (alcoholicPartId is null) ? null : reader.GetInt32(colIndices["AlcoholicPartAmount"]);
        int? nonAlcoholicPartAmount = reader.IsDBNull(colIndices["NonAlcoholicPartAmount"]) || (nonAlcoholicPartId is null) ? null : reader.GetInt32(colIndices["NonAlcoholicPartAmount"]);

        return new DrinkDesolved(id, name, 
            alcoholicPartId, alcoholicPartAmount,
            nonAlcoholicPartId, nonAlcoholicPartAmount);
    }

    protected override void AddParameterValues(SqlCommand cmd, DrinkDesolved drink)
    {
        cmd.Parameters.AddWithValue("@Id", drink.Id);
        cmd.Parameters.AddWithValue("@Name", drink.Name);
        cmd.Parameters.AddWithValue("@AlcoholicPartId", drink.AlcoholicPartId);
        cmd.Parameters.AddWithValue("@AlcoholicPartAmount", drink.AlcoholicPartAmount);
        cmd.Parameters.AddWithValue("@NonAlcoholicPartId", drink.NonAlcoholicPartId);
        cmd.Parameters.AddWithValue("@NonAlcoholicPartAmount", drink.NonAlcoholicPartAmount);
    }
}
