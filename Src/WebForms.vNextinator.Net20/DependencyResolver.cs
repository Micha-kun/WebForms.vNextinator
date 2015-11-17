using System.Web.UI;

namespace WebForms.vNextinator
{
    public static class DependencyResolver
    {
        private static IDependencyResolver _dependencyResolver;

        internal static IDependencyResolver GetDependencyResolver()
        {
            return _dependencyResolver ?? new DefaultDependencyResolver();
        }

        public static void SetDependencyResolver(IDependencyResolver resolver)
        {
            _dependencyResolver = resolver;
        }

#if !HAVE_EXTENSION_METHODS
        public static Control LoadInjectedControl(TemplateControl templateControl, string virtualPath)
        {
            var ctrl = templateControl.LoadControl(virtualPath);
            var userControl = ctrl as TemplateControl;
            if (userControl != null)
            {
                TemplateClassDependencyInjector.InjectDependency(userControl);
            }

            return ctrl;
        }
#else
         public static Control LoadInjectedControl(this TemplateControl templateControl, string virtualPath)
        {
            var ctrl = templateControl.LoadControl(virtualPath);
            var userControl = ctrl as TemplateControl;
            if (userControl != null)
            {
                TemplateClassDependencyInjector.InjectDependency(userControl);
            }

            return ctrl;
        }
#endif
    }
}