using System;
using System.Collections.Generic;

namespace WebForms.vNextinator.DI
{
    public interface IDependencyResolver
    {
        object GetService(Type serviceType);
     
        IEnumerable<object> GetServices(Type serviceType);
    }
}
