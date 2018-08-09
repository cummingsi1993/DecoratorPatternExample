using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DecoratorPatternExample.Interfaces;

namespace DecoratorPatternExample.RepositoryDecorators
{
    public class ValidationDecorator<TModel> : IRepository<TModel>
    {
        IRepository<TModel> repository;
        IValidator<TModel> validator;
        public ValidationDecorator(IRepository<TModel> repository, IValidator<TModel> validator)
        {
            this.repository = repository;
            this.validator = validator;
        }

        public void Add(TModel model)
        {
            if (this.validator.IsValid(model))
            {
                this.repository.Add(model);
            }
            else
            {
                throw new InvalidOperationException("Tried to add a model that was not in a valid state");
            }
        }

        public void Delete(TModel model)
        {
            this.repository.Delete(model);
        }

        public TModel GetById(int id)
        {
            return this.repository.GetById(id);
        }

        public void Update(TModel model)
        {
            if (this.validator.IsValid(model))
            {
                this.repository.Update(model);
            }
            else
            {
                throw new InvalidOperationException("Tried to save a model that was not in a valid state");
            }
        }
    }
}
