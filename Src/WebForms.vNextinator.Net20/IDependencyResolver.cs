using System;
using System.Collections.Generic;

namespace WebForms.vNextinator
{
    public interface IDependencyResolver
    {
        object GetService(Type serviceType);
     
        IEnumerable<object> GetServices(Type serviceType);
    }
}
