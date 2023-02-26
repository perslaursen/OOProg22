using RazorPageEFCDemo.Models;
using RazorPageEFCDemo.Services.Repositories.EFC.Base;
using RazorPageEFCDemo.Services.Repositories.General.Model;

namespace RazorPageEFCDemo.Services.Repositories.EFC.Model
{
    public class EFCCustomerRepository : EFCRepositoryBase<Customer>, ICustomerRepository
    {
        public EFCCustomerRepository(IConfiguration configuration) : base(configuration)
        {
        }
    }
}
