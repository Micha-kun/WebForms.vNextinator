using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using WebForms.vNextinator;

namespace SuperControlTest.DI
{
    /// <summary>
    ///  Unity dependency resolver. Allows to decouple configuration from Resolver. You can reuse UnityDependentyResolver
    ///   and configure it in each app without touching it.
    /// </summary>
    public sealed class UnityDependencyResolver : IDependencyResolver
    {
        private readonly IUnityContainer _container;

        private UnityDependencyResolver()
        {
            _container = new UnityContainer();
        }

        public object GetService(Type serviceType)
        {
            return _container.Resolve(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return _container.ResolveAll(serviceType);
        }

        public static IDependencyResolver ConfigureAndGet(Action<IUnityContainer> configSteps)
        {
            UnityDependencyResolver instance = new UnityDependencyResolver();
            configSteps(instance._container);
            return instance;

        }
    }
}