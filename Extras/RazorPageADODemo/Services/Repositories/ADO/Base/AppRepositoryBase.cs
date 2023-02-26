using RazorPageADODemo.Services.Repositories.General.Interfaces;

namespace RazorPageADODemo.Services.Repositories.ADO.Base
{
    /// <summary>
    /// Application-specific repository base class. It is here we decide that 
    /// the connection string is read from the application settings file.
    /// </summary>
    public abstract class AppRepositoryBase<T> : ADORepositoryBase<T> where T : class, IHasId
    {
        protected AppRepositoryBase(IConfiguration configuration, string tableName) 
            : base(configuration["ConnectionStrings:DefaultConnection"], tableName)
        {
        }
    }
}
