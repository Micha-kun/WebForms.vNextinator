using System;
using System.Collections.Generic;

namespace WebForms.vNextinator
{
    public class DefaultDependencyResolver : IDependencyResolver
    {
        private static readonly IEnumerable<object> Empty = new object[0]; 

        public object GetService(Type serviceType)
        {
            try
            {
                return Activator.CreateInstance(serviceType);
            }
            catch
            {
                return null;
            }
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return Empty;
        }
    }
}