using DecoratorPatternExample.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorPatternExample.Interfaces
{
    public interface IRepositoryBuilder<TModel>
    {

        IDatastoreSelector<TModel> WithDataStore();

        IRepositoryBuilder<TModel> WithLogging(ILogger logger);

        IRepositoryBuilder<TModel> WithAuthorization(IAuthorizer authorizer, User user);

        IRepositoryBuilder<TModel> WithValidator(IValidator<TModel> validator);

        IRepository<TModel> CreateRepository();

    }
}
