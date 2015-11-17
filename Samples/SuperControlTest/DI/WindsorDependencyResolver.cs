using Castle.Windsor;
using System;
using System.Collections.Generic;
using WebForms.vNextinator;

namespace SuperControlTest.DI
{
    public sealed class WindsorDependencyResolver : IDependencyResolver
    {
        private readonly IWindsorContainer _container;

        private WindsorDependencyResolver()
        {
            _container = new WindsorContainer();
        }

        public object GetService(Type serviceType)
        {
            return _container.Resolve(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return (object[])_container.ResolveAll(serviceType);
        }

        public static IDependencyResolver ConfigureAndGet(Action<IWindsorContainer> configSteps)
        {
            WindsorDependencyResolver instance = new WindsorDependencyResolver();
            configSteps(instance._container);
            return instance;
        }
    }
}