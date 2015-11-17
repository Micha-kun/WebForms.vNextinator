using SuperControlTest.Controls;
using System;
using System.Diagnostics;
using WebForms.vNextinator;

namespace SuperControlTest
{
    public interface IInjectionTest
    {
    }

    public class InjectionTest : IInjectionTest
    {

    }

    public partial class Default : System.Web.UI.Page
    {
        public Default()
        {
        }

        public Default(IInjectionTest test)
            : this()
        {
            Debug.Assert(test != null);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            var findControl1 = this.FindControl<SuperControl>("SuperControl");
            Debug.Assert(findControl1 != null);
            SuperControl findControl2;
            Debug.Assert(this.TryFindControl("SuperControl", out findControl2));
            this.GetControl<SuperControl>("SuperControl", ctrl => Debug.Assert(ctrl != null));
        }
    }
}