using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DecoratorPatternExample.Interfaces;
using DecoratorPatternExample.Model;

namespace DecoratorPatternExample.Builders
{
    public class RepositoryBuilder<TModel> : IRepositoryBuilder<TModel>, IDatastoreSelector<TModel>
        where TModel : BaseEntity
    {

        private IRepository<TModel> repository;


        private RepositoryBuilder()
        {
        }

        public static IRepositoryBuilder<TModel> Create()
        {
            return new RepositoryBuilder<TModel>();
        }

        IRepository<TModel> IRepositoryBuilder<TModel>.CreateRepository()
        {
            return repository;
        }

        IRepositoryBuilder<TModel> IDatastoreSelector<TModel>.InMemory()
        {
            repository = new Repositories.InMemoryRepository<TModel>();

            return this;
        }

        IRepositoryBuilder<TModel> IDatastoreSelector<TModel>.Sql(DbContext context)
        {
            repository = new Repositories.EFRepository<TModel>(context);

            return this;
        }

        IRepositoryBuilder<TModel> IRepositoryBuilder<TModel>.WithAuthorization(IAuthorizer authorizer, User user)
        {
            repository = new RepositoryDecorators.AuthorizationDecorator<TModel>(repository, authorizer, user);

            return this;
        }

        IDatastoreSelector<TModel> IRepositoryBuilder<TModel>.WithDataStore()
        {
            return this;
        }

        IRepositoryBuilder<TModel> IRepositoryBuilder<TModel>.WithLogging(ILogger logger)
        {
            repository = new RepositoryDecorators.LoggingDecorator<TModel>(repository, logger);
            return this;
        }

        IRepositoryBuilder<TModel> IRepositoryBuilder<TModel>.WithValidator(IValidator<TModel> validator)
        {

            repository = new RepositoryDecorators.ValidationDecorator<TModel>(repository, validator);

            return this;
        }
    }
}
