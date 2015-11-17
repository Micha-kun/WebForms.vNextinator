
using Ninject;
using System;
using System.Collections.Generic;
using WebForms.vNextinator;

namespace SuperControlTest.DI
{
    public sealed class NinjectDependencyResolver : IDependencyResolver
    {
        private readonly StandardKernel _kernel;

        private NinjectDependencyResolver()
        {
            _kernel = new StandardKernel();
        }

        public object GetService(Type serviceType)
        {
            return _kernel.Get(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return _kernel.GetAll(serviceType);
        }

        public static IDependencyResolver Build(Action<IKernel> setupAction)
        {
            var resolver = new NinjectDependencyResolver();
            setupAction(resolver._kernel);
            return resolver;
        }
    }
}