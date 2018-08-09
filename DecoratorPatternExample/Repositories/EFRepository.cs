using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorPatternExample.Repositories
{
    public class EFRepository<TModel> : Interfaces.IRepository<TModel>
        where TModel : BaseEntity
    {
        DbContext context;
        public EFRepository(DbContext context)
        {
            this.context = context;
        }

        public void Add(TModel model)
        {
            context.Set<TModel>().Add(model);
            context.SaveChanges();
        }

        public void Delete(TModel model)
        {
            context.Set<TModel>().Remove(model);
            context.SaveChanges();
        }

        public TModel GetById(int id)
        {
            return context.Set<TModel>().FirstOrDefault(m => m.Id == id);
        }

        public void Update(TModel model)
        {
            var set = context.Set<TModel>();
            set.Attach(model);

            context.SaveChanges();
        }
    }
}
