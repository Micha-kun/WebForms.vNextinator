using System.Web.UI;

namespace WebForms.vNextinator
{
    public static class TemplateClassDependencyInjector
    {
        public static void InjectDependency(TemplateControl control)
        {
            try
            {
                var ctors = control.GetType()
                                   .BaseType.GetConstructors();
                if (ctors.Length > 0)
                {
                    var ctor = ctors[0];
                    for (int i = 1; i < ctors.Length; i++)
                    {
                        if (ctor.GetParameters()
                                .Length < ctors[i].GetParameters()
                                                  .Length)
                        {
                            ctor = ctors[i];
                        }
                    }

                    var paramTypes = ctor.GetParameters();
                    var paramValues = new object[paramTypes.Length];
                    for (int i = 0; i < paramTypes.Length; i++)
                    {
                        paramValues[i] = DependencyResolver.GetDependencyResolver()
                                                           .GetService(paramTypes[i].ParameterType);
                    }

                    ctor.Invoke(control, paramValues);
                }
            }
            catch { }
        }
    }
}