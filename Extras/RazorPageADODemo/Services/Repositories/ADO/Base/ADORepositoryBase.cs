using RazorPageADODemo.Services.Repositories.General.Interfaces;
using System.Data.SqlClient;

namespace RazorPageADODemo.Services.Repositories.ADO.Base
{
    /// <summary>
    /// This class implements an ADO-based repository with CRUD functionality,
    /// by implementing the technology-neutral IRepository interface.
    /// All methods use direct database access, i.e. no in-memory storage of data.
    /// The repository is only intended to run fairly simple, single-table commands,
    /// so queries requiring e.g. joins are not directly supported.
    /// </summary>
    /// <typeparam name="T">Type of objects being stored</typeparam>
    public abstract class ADORepositoryBase<T> : IRepository<T> where T : class, IHasId
    {
        #region Properties and Constructor
        
        /// <summary>
        /// Full DB connection string
        /// </summary>
        protected string ConnStr { get; }

        /// <summary>
        /// Name of table in which objects of type T are stored.
        /// </summary>
        protected string TableName { get; }

        /// <summary>
        /// Both connection string and table name are injected by repository creator.
        /// We thereby decouple the repository from the strategy used for obtaining the
        /// connection string.
        /// </summary>
        public ADORepositoryBase(string connStr, string tableName)
        {
            ConnStr = connStr;
            TableName = tableName;
        }

        #endregion

        #region Public CRUD methods (+ a GetAll method). See IRepository for documentation.

        public List<T> GetAll(string? whereCond = null)
        {
            // If no condition is provided, "1 = 1" - which is of course always true -
            // is used as condition, to comply with the SELECT statement syntax.
            string where = string.IsNullOrEmpty(whereCond) ? "1 = 1" : whereCond;

            string queryStr = $"SELECT * FROM [{TableName}] WHERE {where}";
            List<T> result = RunReaderCommand(queryStr);

            return result;
        }

        public int Create(T t)
        {
            // Find the next available ID.
            int id = GetAll().Select(x => x.ID).DefaultIfEmpty(0).Max() + 1;
            t.ID = id;

            string queryStr = $"INSERT INTO [{TableName}] VALUES {InsertValuesParameterList()}";
            RunNonQueryCommand(t, queryStr, AddInsertValues);

            return id;
        }

        public T? Read(int id)
        {
            string queryStr = $"SELECT * FROM [{TableName}] WHERE ID = {id}";
            return RunReaderCommand(queryStr).FirstOrDefault();
        }

        public bool Update(int id, T t)
        {
            string queryStr = $"UPDATE [{TableName}] SET {UpdateValuesParameterList()} WHERE ID = {id}";
            return (RunNonQueryCommand(t, queryStr, AddUpdateValues) > 0);
        }

        public bool Delete(int id)
        {
            string queryStr = $"DELETE FROM [{TableName}] WHERE ID = {id}";
            return (RunNonQueryCommand(default, queryStr, null) > 0);
        }

        #endregion

        #region Abstract methods. Must be implemented in type-specific repositories.

        /// <summary>
        /// Retrieve a single row of data from the SqlDataReader, 
        /// and convert it into an instance of T.
        /// </summary>
        protected abstract T GetRowAsT(SqlDataReader reader);

        /// <summary>
        /// Create a parameter list (as a string) to use for an INSERT statement.
        /// The string could look like this: "(@ID , @Name, @Email, @Address)"
        /// </summary>
        protected abstract string InsertValuesParameterList();

        /// <summary>
        /// Add actual values to the INSERT parameter list.
        /// This will typically look like: cmd.Parameters.AddWithValue("@Name", c.Name);
        /// </summary>
        protected abstract void AddInsertValues(T? t, SqlCommand cmd);

        /// <summary>
        /// Create a parameter list (as a string) to use for an UPDATE statement.
        /// The string could look like this: ""Name = @Name, Email = @Email, Address = @Address""
        /// </summary>
        protected abstract string UpdateValuesParameterList();

        /// <summary>
        /// Add actual values to the UPDATE parameter list.
        /// This will typically look like: cmd.Parameters.AddWithValue("@Name", c.Name);
        /// </summary>
        protected abstract void AddUpdateValues(T? t, SqlCommand cmd);

        #endregion

        #region Helper methods for running SQL commands.

        /// <summary>
        /// Returns a List of objects of type T, according to the query string.
        /// These queries will ONLY be read-only queries, i.e. SELECT.
        /// </summary>
        protected List<T> RunReaderCommand(string queryStr)
        {
            List<T> data = new List<T>();

            try
            {
                // Prepare connection and command
                using SqlConnection connection = new SqlConnection(ConnStr);
                SqlCommand cmd = new SqlCommand(queryStr, connection);
                connection.Open();

                // Execute read command, and convert returned rows to objects.
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    data.Add(GetRowAsT(reader));
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine($"RunReaderCommand ({typeof(T)}) : {e.Message}");
            }

            return data;
        }

        /// <summary>
        /// Runs a command corresponding to the given query, by first 
        /// setting parameter values and then executing the command.
        /// The number of rows affected by the command is returned.
        /// </summary>
        protected int RunNonQueryCommand(T? t, string queryStr, Action<T?, SqlCommand>? addParametersFunc)
        {
            try
            {
                // Prepare connection and command (including setting parameter values).
                using SqlConnection connection = new SqlConnection(ConnStr);
                SqlCommand cmd = new SqlCommand(queryStr, connection);
                addParametersFunc?.Invoke(t, cmd);

                connection.Open();

                // Execute command, and return number of affected rows.
                return cmd.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                Console.WriteLine($"RunNonQueryCommand ({typeof(T)}) : {e.Message}");
            }

            return 0;
        } 

        #endregion
    }
}
