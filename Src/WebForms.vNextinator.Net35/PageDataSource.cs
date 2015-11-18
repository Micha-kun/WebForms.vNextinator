using System;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebForms.vNextinator
{
    [ToolboxData("<{0}:PageDataSource runat=\"server\"></{0}:PageDataSource>")]
    public class PageDataSource : ObjectDataSource
    {
        private object parentHost;

        public PageDataSource()
            : this(string.Empty, string.Empty)
        {
        }

        public PageDataSource(string typeName, string selectMethod)
            : base(typeName, selectMethod)
        {
            this.ObjectCreating += this.OnObjectCreating;
            this.ObjectDisposing += this.OnObjectDisposing;
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            this.FindParentHost(this);
        }

        private void FindParentHost(Control ctl)
        {
            if (ctl.Parent == null)
            {
                // ctl.Parent is Page
                // At the top of the control tree and user control was not found, use page base type instead
                this.TypeName = Assembly.CreateQualifiedName(this.Page.GetType().Assembly.FullName, this.Page.GetType().BaseType.FullName);
                this.parentHost = this.Page;
                return;
            }

            if (ctl.Parent is MasterPage || ctl.Parent is UserControl)
            {
                this.TypeName = Assembly.CreateQualifiedName(ctl.Parent.GetType().Assembly.FullName, ctl.Parent.GetType().BaseType.FullName);
                this.parentHost = ctl.Parent;
                return;
            }

            this.FindParentHost(ctl.Parent);
        }

        private void OnObjectCreating(object sender, ObjectDataSourceEventArgs e)
        {
            if (e == null)
            {
                throw new ArgumentNullException("e");
            }

            e.ObjectInstance = this.parentHost;
        }

        private void OnObjectDisposing(object sender, ObjectDataSourceDisposingEventArgs e)
        {
            if (e == null)
            {
                throw new ArgumentNullException("e");
            }

            e.Cancel = true;
        }
    }
}
