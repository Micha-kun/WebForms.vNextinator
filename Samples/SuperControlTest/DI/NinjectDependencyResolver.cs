
using Ninject;
using SuperControlTest.Presenters;
using System;
using System.Collections.Generic;
using WebForms.vNextinator;

namespace SuperControlTest.DI
{
    public sealed class NinjectDependencyResolver : IDependencyResolver
    {
        private StandardKernel _kernel;

        public NinjectDependencyResolver()
        {
            _kernel = new StandardKernel();
            AddBindings();
        }

        public object GetService(Type serviceType)
        {
            return _kernel.Get(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return _kernel.GetAll(serviceType);
        }

        private void AddBindings()
        {
            _kernel.Bind<IInjectionTest>().To<InjectionTest>();
            _kernel.Bind<IDefaultPresenter>().To<DefaultPresenter>();
        }
    }
}