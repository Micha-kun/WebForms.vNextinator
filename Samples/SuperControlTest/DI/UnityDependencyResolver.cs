using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using WebForms.vNextinator;
using Microsoft.Practices.Unity
using Microsoft.Practices.Unity.Configuration

namespace SuperControlTest.DI
{
    /// <summary>
    ///  Unity dependency resolver. Allows to decouple configuration from Resolver. You can reuse UnityDependentyResolver
   ///   and configure it in each app without touching it.
    /// </summary>
    public sealed class UnityDependencyResolver : IDependencyResolver
    {
        private IUnityContainer container;

        private UnityDependencyResolver()
        {
            container = new UnityContainer();
        }

        public object GetService(Type serviceType)
        {
            return container.Resolve(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return container.ResolveAll(serviceType);
        }

        public static IDependencyResolver ConfigureAndGet(Action<IUnityContainer> configSteps)
        {
            UnityDependencyResolver instance = new UnityDependencyResolver();
            configSteps(instance.container);
            return instance;

        }
    }
}