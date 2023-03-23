
using Microsoft.Data.SqlClient;

public class DBMethodsForCocktailDesolved : DBMethodsBase<CocktailDesolved>
{
    public DBMethodsForCocktailDesolved(string connectionString)
        : base(connectionString, "Cocktail", "(@Id , @Name)")
    {
    }

    protected override Dictionary<string, int> GetColIndices(SqlDataReader reader)
    {
        Dictionary<string, int> colIndices = new()
        {
            { "Id", reader.GetOrdinal("Id") },
            { "Name", reader.GetOrdinal("Name") },
        };

        return colIndices;
    }

    protected override CocktailDesolved GetRow(SqlDataReader reader, Dictionary<string, int> colIndices)
    {
        int id = reader.GetInt32(colIndices["Id"]);
        string name = reader.GetString(colIndices["Name"]);

        return new CocktailDesolved(id, name);
    }

    protected override void AddParameterValues(SqlCommand cmd, CocktailDesolved cocktail)
    {
        cmd.Parameters.AddWithValue("@Id", cocktail.Id);
        cmd.Parameters.AddWithValue("@Name", cocktail.Name);
    }
}