using DecoratorPatternExample.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorPatternExample.Interfaces
{
    public interface IAuthorizer
    {

        bool IsUserAuthorizedToAccessModel<TModel>(User user);

    }
}
