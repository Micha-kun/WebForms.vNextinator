using SuperControlTest.DI;
using SuperControlTest.Presenters;
using SuperControlTest.ViewModels;
using System;
using System.Web.Http;
using WebForms.vNextinator.DI;


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
                        kernel.Bind<ISample3ViewModel>().To<Sample3ViewModel>();
                        kernel.Bind<ISample3Presenter>().To<Sample3Presenter>();
                        kernel.Bind<IToDoListPresenter>().To<ToDoListPresenter>();
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