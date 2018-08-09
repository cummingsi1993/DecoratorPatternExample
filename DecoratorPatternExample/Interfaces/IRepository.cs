using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorPatternExample.Interfaces
{
    public interface IRepository<TModel>
    {
        /// <summary>
        /// Adds a model to the underlying store
        /// </summary>
        /// <param name="model"></param>
        void Add(TModel model);

        /// <summary>
        /// Deletes a model from the underlying store
        /// </summary>
        /// <param name="model"></param>
        void Delete(TModel model);

        /// <summary>
        /// Updates a model that is in the underlying store
        /// </summary>
        /// <param name="model"></param>
        void Update(TModel model);

        /// <summary>
        /// Gets a model in the underlying store
        /// </summary>
        /// <param name="id"></param>
        TModel GetById(int id);

    }
}
