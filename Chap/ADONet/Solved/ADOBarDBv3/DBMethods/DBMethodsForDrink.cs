
using Microsoft.Data.SqlClient;

public class DBMethodsForDrink : DBMethodsBase<Drink>
{
    private DBMethodsForIngredient _dbIngredients;

    public DBMethodsForDrink(string connectionString, DBMethodsForIngredient dbIngredients) 
        : base(connectionString, "Drink", "(@Id , @Name, @AlcoholicPartId, @AlcoholicPartAmount, @NonAlcoholicPartId, @NonAlcoholicPartAmount)")
    {
        _dbIngredients = dbIngredients;
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

    protected override Drink GetRow(SqlDataReader reader, Dictionary<string, int> colIndices)
    {
        List<Ingredient> ingredients = _dbIngredients.ReadAllFromDB();

        int id = reader.GetInt32(colIndices["Id"]);
        string name = reader.GetString(colIndices["Name"]);
        int? alcoholicPartId = reader.IsDBNull(colIndices["AlcoholicPartId"]) ? null : reader.GetInt32(colIndices["AlcoholicPartId"]);
        int? nonAlcoholicPartId = reader.IsDBNull(colIndices["NonAlcoholicPartId"]) ? null : reader.GetInt32(colIndices["NonAlcoholicPartId"]);
        int? alcoholicPartAmount = reader.IsDBNull(colIndices["AlcoholicPartAmount"]) || (alcoholicPartId is null) ? null : reader.GetInt32(colIndices["AlcoholicPartAmount"]);
        int? nonAlcoholicPartAmount = reader.IsDBNull(colIndices["NonAlcoholicPartAmount"]) || (nonAlcoholicPartId is null) ? null : reader.GetInt32(colIndices["NonAlcoholicPartAmount"]);

        return new Drink(id, name, 
            ResolveIngredient(alcoholicPartId, ingredients), alcoholicPartAmount, 
            ResolveIngredient(nonAlcoholicPartId, ingredients), nonAlcoholicPartAmount);
    }

    protected override void AddParameterValues(SqlCommand cmd, Drink drink)
    {
        cmd.Parameters.AddWithValue("@Id", drink.Id);
        cmd.Parameters.AddWithValue("@Name", drink.Name);
        cmd.Parameters.AddWithValue("@AlcoholicPartId", drink.AlcoholicPart?.Id);
        cmd.Parameters.AddWithValue("@AlcoholicPartAmount", drink.AlcoholicPartAmount);
        cmd.Parameters.AddWithValue("@NonAlcoholicPartId", drink.NonAlcoholicPart?.Id);
        cmd.Parameters.AddWithValue("@NonAlcoholicPartAmount", drink.NonAlcoholicPartAmount);
    }

    private Ingredient? ResolveIngredient(int? ingId, List<Ingredient> ingredients)
    {
        if (ingId is null)
            return null;

        return ingredients.First(i => i.Id == ingId);
    }
}
