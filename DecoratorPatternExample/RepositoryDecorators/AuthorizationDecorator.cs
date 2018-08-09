using DecoratorPatternExample.Interfaces;
using DecoratorPatternExample.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorPatternExample.RepositoryDecorators
{
    public class AuthorizationDecorator<TModel> : IRepository<TModel>
    {
        IRepository<TModel> repository;
        IAuthorizer authorizer;
        User user;
        public AuthorizationDecorator(IRepository<TModel> repository, IAuthorizer authorizer, User user)
        {
            this.repository = repository;
            this.authorizer = authorizer;
            this.user = user;
        }

        public void Add(TModel model)
        {
            if (this.authorizer.IsUserAuthorizedToAccessModel<TModel>(user))
            {
                this.repository.Add(model);
            }
            else
            {
                throw new UnauthorizedAccessException("The user attempted to access a resource that is not allowed");
            }
        }

        public void Delete(TModel model)
        {
            if (this.authorizer.IsUserAuthorizedToAccessModel<TModel>(user))
            {
                this.repository.Delete(model);
            }
            else
            {
                throw new UnauthorizedAccessException("The user attempted to access a resource that is not allowed");
            }
            
        }

        public TModel GetById(int id)
        {
            if (this.authorizer.IsUserAuthorizedToAccessModel<TModel>(user))
            {
                return this.repository.GetById(id);
            }
            else
            {
                throw new UnauthorizedAccessException("The user attempted to access a resource that is not allowed");
            }
            
        }

        public void Update(TModel model)
        {
            if (this.authorizer.IsUserAuthorizedToAccessModel<TModel>(user))
            {
                this.repository.Update(model);
            }
            else
            {
                throw new UnauthorizedAccessException("The user attempted to access a resource that is not allowed");
            }
        }
    }
}
