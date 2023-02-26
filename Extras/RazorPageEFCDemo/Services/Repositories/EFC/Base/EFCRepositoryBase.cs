using Microsoft.EntityFrameworkCore;
using RazorPageEFCDemo.Data;
using RazorPageEFCDemo.Services.Repositories.General.Interfaces;

namespace RazorPageEFCDemo.Services.Repositories.EFC.Base
{
    public class EFCRepositoryBase<T> : IRepository<T> where T : class, IHasID, IUpdateFromOther<T>
    {
        private IConfiguration _configuration;

        public EFCRepositoryBase(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public List<T> GetAll(string whereCond = null)
        {
            using var context = new EFCDemoContext(_configuration);

            return SetWithIncludes(context).ToList();
        }

        public int Create(T t)
        {
            using var context = new EFCDemoContext(_configuration);

            context.Set<T>().Add(t);
            return context.SaveChanges();
        }

        public T Read(int id)
        {
            using var context = new EFCDemoContext(_configuration);

            return SetWithIncludes(context).FirstOrDefault(e => e.ID == id);
        }

        public bool Update(int id, T t)
        {
            using var context = new EFCDemoContext(_configuration);

            T tEx = context.Set<T>().Find(id);
            if (tEx != null)
            {
                tEx.Update(t);
                return (context.SaveChanges() > 0);
            }
            else
                return false;
        }

        public bool Delete(int id)
        {
            using var context = new EFCDemoContext(_configuration);

            T tEx = context.Set<T>().Find(id);
            if (tEx != null)
            {
                context.Set<T>().Remove(tEx);
                return (context.SaveChanges() > 0);
            }
            else
                return false;
        }

        protected virtual IQueryable<T> SetWithIncludes(EFCDemoContext context)
        {
            return context.Set<T>().AsNoTracking();
        }
    }
}
