using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;

namespace WebForms.vNextinator
{
    public class DependencyInjectedPageHandlerFactory : PageHandlerFactory
    {
        public override IHttpHandler GetHandler(HttpContext context, string requestType, string virtualPath, string path)
        {
            var page = base.GetHandler(context, requestType, virtualPath, path) as Page;
            if (page == null)
            {
                return null;
            }

            TemplateClassDependencyInjector.InjectDependency(page);
            page.PreInit += InitializeChildControls;
            return page;
        }

        private void InitializeChildControls(object sender, EventArgs e)
        {
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
                foreach (Control ctrl in control.Controls)
                {
                    var templateControl = ctrl as TemplateControl;
                    if (templateControl != null)
                    {
                        TemplateClassDependencyInjector.InjectDependency(templateControl);
                        queue.Enqueue(templateControl);
                    }
                }
            }
        }
    }
}
