using DecoratorPatternExample.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorPatternExample.RepositoryDecorators
{
    public class LoggingDecorator<TModel> : IRepository<TModel>
    {

        IRepository<TModel> repository;
        ILogger logger;
        public LoggingDecorator(IRepository<TModel> repository, ILogger logger)
        {
            this.repository = repository;
            this.logger = logger;
        }

        public void Add(TModel model)
        {
            logger.LogMessage("Adding a model");

            try
            {
                this.repository.Add(model);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.ToString());
                throw ex;
            }

        }

        public void Delete(TModel model)
        {
            logger.LogMessage("Deleting a model");

            try
            {
                this.repository.Delete(model);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.ToString());
                throw ex;
            }

        }

        public TModel GetById(int id)
        {
            logger.LogMessage("Getting a model");

            try
            {
                return this.repository.GetById(id);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.ToString());
                throw ex;
            }
        }

        public void Update(TModel model)
        {
            logger.LogMessage("Updating a model");

            try
            {
                this.repository.Update(model);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.ToString());
                throw ex;
            }
        }
    }
}
