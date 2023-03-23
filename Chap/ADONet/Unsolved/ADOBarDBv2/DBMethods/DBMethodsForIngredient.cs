
using Microsoft.Data.SqlClient;

public class DBMethodsForIngredient : DBMethodsBase<Ingredient>
{
    public DBMethodsForIngredient(string connectionString) 
        : base(connectionString, "Ingredient", "(@Id , @Name, @PricePerCl, @AlcoholPercent)")
    {
    }

    protected override Dictionary<string, int> GetColIndices(SqlDataReader reader)
    {
        Dictionary<string, int> colIndices = new()
        {
            { "Id", reader.GetOrdinal("Id") },
            { "Name", reader.GetOrdinal("Name") },
            { "PricePerCl", reader.GetOrdinal("PricePerCl") },
            { "AlcoholPercent", reader.GetOrdinal("AlcoholPercent") },
        };

        return colIndices;
    }

    protected override Ingredient GetRow(SqlDataReader reader, Dictionary<string, int> colIndices)
    {
        int id = reader.GetInt32(colIndices["Id"]);
        string name = reader.GetString(colIndices["Name"]);
        int pricePerCl = reader.GetInt32(colIndices["PricePerCl"]);
        double alcoholPercent = reader.GetDouble(colIndices["AlcoholPercent"]);

        return new Ingredient(id, name, pricePerCl, alcoholPercent);
    }

    protected override void AddParameterValues(SqlCommand cmd, Ingredient ingredient)
    {
        cmd.Parameters.AddWithValue("@Id", ingredient.Id);
        cmd.Parameters.AddWithValue("@Name", ingredient.Name);
        cmd.Parameters.AddWithValue("@PricePerCl", ingredient.PricePerCl);
        cmd.Parameters.AddWithValue("@AlcoholPercent", ingredient.AlcoholPercent);
    }
}
