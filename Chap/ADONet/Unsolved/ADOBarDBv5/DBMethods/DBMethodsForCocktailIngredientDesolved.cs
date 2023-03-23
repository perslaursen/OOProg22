
using Microsoft.Data.SqlClient;

public class DBMethodsForCocktailIngredientDesolved : DBMethodsBase<CocktailIngredientDesolved>
{
    public DBMethodsForCocktailIngredientDesolved(string connectionString)
    : base(connectionString, "CocktailIngredient", "(@Id, @CocktailId , @IngredientId, @AmountInCl)")
    {
    }

    protected override Dictionary<string, int> GetColIndices(SqlDataReader reader)
    {
        Dictionary<string, int> colIndices = new()
        {
            { "Id", reader.GetOrdinal("Id") },
            { "CocktailId", reader.GetOrdinal("CocktailId") },
            { "IngredientId", reader.GetOrdinal("IngredientId") },
            { "AmountInCl", reader.GetOrdinal("AmountInCl") },
        };

        return colIndices;
    }

    protected override CocktailIngredientDesolved GetRow(SqlDataReader reader, Dictionary<string, int> colIndices)
    {
        int id = reader.GetInt32(colIndices["Id"]);
        int cocktailId = reader.GetInt32(colIndices["CocktailId"]);
        int ingredientId = reader.GetInt32(colIndices["IngredientId"]);
        int amountInCl = reader.GetInt32(colIndices["AmountInCl"]);

        return new CocktailIngredientDesolved(id, cocktailId, ingredientId, amountInCl);
    }

    protected override void AddParameterValues(SqlCommand cmd, CocktailIngredientDesolved cid)
    {
        cmd.Parameters.AddWithValue("@Id", cid.Id);
        cmd.Parameters.AddWithValue("@CocktailId", cid.CocktailId);
        cmd.Parameters.AddWithValue("@IngredientId", cid.IngredientId);
        cmd.Parameters.AddWithValue("@AmountInCl", cid.AmountInCl);
    }
}
