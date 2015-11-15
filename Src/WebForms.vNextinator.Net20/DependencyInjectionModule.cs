using System;
using System.Collections.Generic;
using System.Reflection;
using System.Web;
using System.Web.UI;

namespace WebForms.vNextinator
{
    public class DependencyInjectionModule : IHttpModule
    {
        private static readonly Dictionary<Type, IEnumerable<FieldInfo>> _typeFields = new Dictionary<Type, IEnumerable<FieldInfo>>();

        public void Init(HttpApplication context)
        {
            context.PreRequestHandlerExecute += Context_PreRequestHandlerExecute;
        }

        private void Context_PreRequestHandlerExecute(object sender, EventArgs e)
        {
            var context = (HttpApplication)sender;
            if (context.Context.CurrentHandler is Page)
            {
                var page = (Page)context.Context.CurrentHandler;
                TemplateClassDependencyInjector.InjectDependency(page);
                page.PreInit += InitializeChildControls;
            }

        }

        private void InitializeChildControls(object sender, EventArgs e)
        {
            var flags = BindingFlags.Instance | BindingFlags.NonPublic;
            var queue = new Queue<TemplateControl>();
            var page = (Page)sender;
            if (page.Master != null)
            {
                TemplateClassDependencyInjector.InjectDependency(page.Master);
                queue.Enqueue(page.Master);
            }

            queue.Enqueue(page);
            while (queue.Count > 0)
            {
                var control = queue.Dequeue();
                var ctrlType = control.GetType();
                IEnumerable<FieldInfo> fields;
                if (!_typeFields.TryGetValue(ctrlType, out fields))
                {
                    var fieldList = new List<FieldInfo>();
                    foreach (var field in ctrlType.GetFields(flags))
                    {
                        var type = field.FieldType;
                        if (typeof(UserControl).IsAssignableFrom(type))
                        {
                            fieldList.Add(field);
                            InitializeField(queue, control, field);
                        }
                    }

                    fields = fieldList.ToArray();
                    if (!_typeFields.ContainsKey(ctrlType))
                    {
                        _typeFields.Add(ctrlType, fields);
                    }

                }
                else
                {
                    foreach (var ctrlField in fields)
                    {
                        InitializeField(queue, control, ctrlField);
                    }
                }
            }
        }

        private static void InitializeField(Queue<TemplateControl> queue, TemplateControl control, FieldInfo field)
        {
            var userControl = field.GetValue(control) as UserControl;
            if (userControl != null)
            {
                TemplateClassDependencyInjector.InjectDependency(userControl);
                queue.Enqueue(userControl);
            }
        }

        public void Dispose()
        {
        }
    }
}
