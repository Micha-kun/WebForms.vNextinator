using System;
using System.Collections.Generic;
using System.Reflection;
using System.Web;
using System.Web.UI;

namespace WebForms.vNextinator
{
    public class DependencyInjectionModule : IHttpModule
    {
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
            var flags =
            BindingFlags.Instance | BindingFlags.NonPublic;
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
                foreach (var field in control.GetType().GetFields(flags))
                {
                    var type = field.FieldType;
                    if (typeof(UserControl).IsAssignableFrom(type))
                    {
                        var userControl = field.GetValue(control) as UserControl;
                        if (userControl != null)
                        {
                            TemplateClassDependencyInjector.InjectDependency(userControl);
                            queue.Enqueue(userControl);
                        }
                    }
                }
            }
        }

        public void Dispose()
        {
        }
    }
}
