using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorPatternExample.Interfaces
{
    public interface IDatastoreSelector<TModel>
    {

        IRepositoryBuilder<TModel> Sql(DbContext context);
        IRepositoryBuilder<TModel> InMemory();

    }
}
