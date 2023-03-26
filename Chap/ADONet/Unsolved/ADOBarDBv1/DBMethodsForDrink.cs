
using Microsoft.Data.SqlClient;
using System.Runtime.CompilerServices;

/// <summary>
/// This class contains a set of public CRUD-like methods for accessing the DrinkFlat table
/// in the database defined by the connection string. The class is NOT complete, and there is 
/// definitely room for improvement w.r.t. structure and parameterization.
/// </summary>
public class DBMethodsForDrink
{
    private string _connectionString;

    public DBMethodsForDrink(string connectionString)
    {
        _connectionString = connectionString;
    }


    #region Public CRUD-like methods
    
    /// <summary>
    /// Read and return all data from the DrinkFlat table
    /// </summary>
    public List<Drink> ReadAllFromDB()
    {
        List<Drink> data = new List<Drink>();
        string queryStr = "SELECT * FROM DrinkFlat";

        try
        {
            // 1) Setup the connection with the "using" syntax
            using SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            // 2) Prepare and execute the actual SQL command
            SqlCommand cmd = new SqlCommand(queryStr, connection);
            SqlDataReader reader = cmd.ExecuteReader();

            // 3) Process the retrieved data
            Dictionary<string, int> colIndices = GetColIndices(reader);
            while (reader.Read())
            {
                data.Add(GetRow(reader, colIndices));
            }
        }
        catch (SqlException e)
        {
            SQLExceptionHandler(e);
        }

        return data;
    }

    /// <summary>
    /// Write a single Drink object to the DrinkFlat table
    /// </summary>
    public int WriteToDB(Drink drink)
    {
        string queryStr = "INSERT INTO DrinkFlat VALUES " +
            $"(@Id , @Name, @AlcoholicPart, @AlcoholicPartAmount, @NonAlcoholicPart, @NonAlcoholicPartAmount)";

        try
        {
            // 1) Setup the connection with the "using" syntax
            using SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            // 2) Prepare the actual SQL command, including addition of parameter values
            SqlCommand cmd = new SqlCommand(queryStr, connection);
            AddParameterValues(cmd, drink);

            // 3) Execute the actual SQL command
            return cmd.ExecuteNonQuery();
        }
        catch (SqlException e)
        {
            SQLExceptionHandler(e);
        }

        return 0;
    }

    /// <summary>
    /// Delete the Drink object matching the given id from the DrinkFlat table
    /// </summary>
    public int DeleteFromDB(int id)
    {
        string queryStr = $"DELETE FROM DrinkFlat WHERE Id = {id}";

        try
        {
            // 1) Setup the connection with the "using" syntax
            using SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            // 2) Prepare the actual SQL command
            SqlCommand cmd = new SqlCommand(queryStr, connection);

            // 3) Execute the actual SQL command
            return cmd.ExecuteNonQuery();
        }
        catch (SqlException e)
        {
            SQLExceptionHandler(e);
        }

        return 0;
    }

    #endregion


    #region Private helper methods
    
    /// <summary>
    /// Returns a Dictionary mapping column names to column indices, 
    /// so we don't have to refer directly to column indices elsewhere.
    /// </summary>
    private Dictionary<string, int> GetColIndices(SqlDataReader reader)
    {
        Dictionary<string, int> colIndices = new()
    {
        { "Id", reader.GetOrdinal("Id") },
        { "Name", reader.GetOrdinal("Name") },
        { "AlcoholicPart", reader.GetOrdinal("AlcoholicPart") },
        { "AlcoholicPartAmount", reader.GetOrdinal("AlcoholicPartAmount") },
        { "NonAlcoholicPart", reader.GetOrdinal("NonAlcoholicPart") },
        { "NonAlcoholicPartAmount", reader.GetOrdinal("NonAlcoholicPartAmount") }
    };

        return colIndices;
    }

    /// <summary>
    /// Gets a single row of data, i.e. the row SqlDataReader currently refers to.
    /// The data is then used to create a new Drink object.
    /// </summary>
    private Drink GetRow(SqlDataReader reader, Dictionary<string, int> colIndices)
    {
        int id = reader.GetInt32(colIndices["Id"]);
        string name = reader.GetString(colIndices["Name"]);
        string alcoholicPart = reader.GetString(colIndices["AlcoholicPart"]);
        string nonAlcoholicPart = reader.GetString(colIndices["NonAlcoholicPart"]);
        int alcoholicPartAmount = reader.GetInt32(colIndices["AlcoholicPartAmount"]);
        int nonAlcoholicPartAmount = reader.GetInt32(colIndices["NonAlcoholicPartAmount"]);

        return new Drink(id, name, alcoholicPart, alcoholicPartAmount, nonAlcoholicPart, nonAlcoholicPartAmount);
    }

    /// <summary>
    /// Adds actual parameters values to the parameterized query string in the SqlCommand.
    /// The parameter values are taken from the Drink object.
    /// </summary>
    private void AddParameterValues(SqlCommand cmd, Drink drink)
    {
        cmd.Parameters.AddWithValue("@Id", drink.Id);
        cmd.Parameters.AddWithValue("@Name", drink.Name);
        cmd.Parameters.AddWithValue("@AlcoholicPart", drink.AlcoholicPart);
        cmd.Parameters.AddWithValue("@AlcoholicPartAmount", drink.AlcoholicPartAmount);
        cmd.Parameters.AddWithValue("@NonAlcoholicPart", drink.NonAlcoholicPart);
        cmd.Parameters.AddWithValue("@NonAlcoholicPartAmount", drink.NonAlcoholicPartAmount);
    }

    private void SQLExceptionHandler(SqlException sqlEx, [CallerMemberName] string? caller = null)
    {
        Console.WriteLine($"NB: SqlException in {caller} : {sqlEx.Message}");
    }
    
    #endregion
}
