using Castle.MicroKernel.Registration;
using SuperControlTest.DI;
using System;
using System.Web.Http;
using SuperControlTest.Presenters;
using WebForms.vNextinator;


namespace SuperControlTest
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            GlobalConfiguration.Configure(config =>
            {
                config.MapHttpAttributeRoutes();
                config.Routes.MapHttpRoute(
                    name: "DefaultApi",
                    routeTemplate: "api/{controller}/{id}",
                    defaults: new { id = RouteParameter.Optional }
                );
            });

            //Ninject depencency resolver
            DependencyResolver.SetDependencyResolver(
                NinjectDependencyResolver.Build(
                    kernel =>
                    {
                        kernel.Bind<IInjectionTest>().To<InjectionTest>();
                        kernel.Bind<IDefaultPresenter>().To<DefaultPresenter>();
                    }));

            /* Unity dependency resolver. Allows to decouple configuration from Resolver. You can reuse UnityDependentyResolver
             * and configure it in each app without touching it.
            DependencyResolver.SetDependencyResolver(UnityDependencyResolver.ConfigureAndGet(container =>
            {
                container.RegisterType<IInjectionTest, InjectionTest>();
                // container.RegisterType<AnotherIface, AnotherClass>();
                //and so on...
            })); */

            // Windsor dependency resolver.
            //DependencyResolver.SetDependencyResolver(WindsorDependencyResolver.ConfigureAndGet(container =>
            //      {
            //          container.Register(Component.For<IInjectionTest>().ImplementedBy<InjectionTest>());
            //      }));
        }
    }
}