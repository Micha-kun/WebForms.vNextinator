using System;
using System.Collections.Generic;
using System.Reflection;
using System.Web.UI;

namespace WebForms.vNextinator.DI
{
    public static class TemplateClassDependencyInjector
    {
        private static readonly Dictionary<Type, ConstructorInfo> _typeConstructor = new Dictionary<Type, ConstructorInfo>();

        public static void InjectDependency(TemplateControl control)
        {
            try
            {
                var ctrlType = control.GetType().BaseType;
                ConstructorInfo ctor;
                if (!_typeConstructor.TryGetValue(ctrlType, out ctor))
                {
                    var ctors = ctrlType.GetConstructors();
                    if (ctors.Length == 0)
                    {
                        return;
                    }

                    ctor = ctors[0];
                    for (int i = 1; i < ctors.Length; i++)
                    {
                        if (ctor.GetParameters()
                                .Length < ctors[i].GetParameters()
                                                  .Length)
                        {
                            ctor = ctors[i];
                        }
                    }

                    if (!_typeConstructor.ContainsKey(ctrlType))
                    {
                        _typeConstructor.Add(ctrlType, ctor);
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
            catch { }
        }
    }
}