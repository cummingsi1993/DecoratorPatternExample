using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorPatternExample.Repositories
{
    public class InMemoryRepository<TModel> : Interfaces.IRepository<TModel>
        where TModel : BaseEntity
    {

        Dictionary<int, TModel> datastore = new Dictionary<int, TModel>();

        public InMemoryRepository()
        {

        }

        public void Add(TModel model)
        {
            if (datastore.ContainsKey(model.Id))
            {
                throw new InvalidOperationException("A model with this key already exists in the store");
            }

            datastore.Add(model.Id, model);
        }

        public void Delete(TModel model)
        {

            if (!datastore.ContainsKey(model.Id))
            {
                throw new InvalidOperationException("A model with this key doesnt exist in the store");
            }

            datastore.Remove(model.Id);

        }

        public TModel GetById(int id)
        {
            if (!datastore.ContainsKey(id))
            {
                throw new InvalidOperationException("A model with this key doesnt exist in the store");
            }

            return datastore[id];
        }

        public void Update(TModel model)
        {
            if (!datastore.ContainsKey(model.Id))
            {
                throw new InvalidOperationException("A model with this key doesnt exist in the store");
            }

            datastore[model.Id] = model;
        }
    }
}
