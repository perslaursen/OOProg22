
using Microsoft.Data.SqlClient;
using System.Runtime.CompilerServices;

/// <summary>
/// This class contains a set of public CRUD-like methods for accessing a table
/// in the database defined by the connection string. The class acts as a base
/// class for classes accessing a specific table.
/// </summary>
public abstract class DBMethodsBase<T> where T : IHasId
{
    private string _connectionString;
    private string _tableName;
    private string _parameterList;

    public DBMethodsBase(string connectionString, string tableName, string parameterList)
    {
        _connectionString = connectionString;
        _tableName = tableName;
        _parameterList = parameterList;
    }


    #region Public CRUD-like methods
    
    /// <summary>
    /// Read and return all data from _tableName which matches the (optional) selection condition.
    /// (Could we have a risk for SQL injection here...?)
    /// </summary>   
    public List<T> ReadAllFromDB(string? whereCond = null)
    {
        List<T> data = new List<T>();
        string queryStr = $"SELECT * FROM {_tableName}" + (whereCond != null ? $" WHERE {whereCond}" : "");

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
    /// Write a single T object to the _tableName table
    /// </summary>
    public int WriteToDB(T t)
    {
        string queryStr = $"INSERT INTO {_tableName} VALUES " + _parameterList;

        try
        {
            // 1) Setup the connection with the "using" syntax
            using SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            // 2) Prepare the actual SQL command, including addition of parameter values
            SqlCommand cmd = new SqlCommand(queryStr, connection);
            AddParameterValues(cmd, t);

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
    /// Delete the T object matching the given id from the _tableName table
    /// </summary>
    public int DeleteFromDB(int id)
    {
        string queryStr = $"DELETE FROM {_tableName} WHERE Id = {id}";

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


    #region Protected abstract helper methods

    /// <summary>
    /// Returns a Dictionary mapping column names to column indices, 
    /// so we don't have to refer directly to column indices elsewhere.
    /// </summary>
    protected abstract Dictionary<string, int> GetColIndices(SqlDataReader reader);

    /// <summary>
    /// Gets a single row of data, i.e. the row SqlDataReader currently refers to.
    /// The data is then used to create a new object of type T.
    /// </summary>
    protected abstract T GetRow(SqlDataReader reader, Dictionary<string, int> colIndices);

    /// <summary>
    /// Adds actual parameters values to the parameterized query string in the SqlCommand.
    /// The parameter values are taken from the T object.
    /// </summary>
    protected abstract void AddParameterValues(SqlCommand cmd, T t); 

    #endregion


    /// <summary>
    /// Just a bit of rudimentary exception handling.
    /// </summary>
    private void SQLExceptionHandler(SqlException sqlEx, [CallerMemberName] string? caller = null)
    {
        Console.WriteLine($"NB: SqlException in {caller} for {_tableName} : {sqlEx.Message}");
    }
}
