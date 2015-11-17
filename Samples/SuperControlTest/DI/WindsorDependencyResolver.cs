using Castle.Windsor;
using System;
using System.Collections.Generic;
using WebForms.vNextinator;

namespace SuperControlTest.DI
{
    public sealed class WindsorDependencyResolver : IDependencyResolver
    {
        private IWindsorContainer container;

        private WindsorDependencyResolver()
        {
            container = new WindsorContainer();
        }

        public object GetService(Type serviceType)
        {
            return container.Resolve(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return (IEnumerable<object>)container.ResolveAll(serviceType);
        }

        public static IDependencyResolver ConfigureAndGet(Action<IWindsorContainer> configSteps)
        {
            WindsorDependencyResolver instance = new WindsorDependencyResolver();
            configSteps(instance.container);
            return instance;

        }
    }
}