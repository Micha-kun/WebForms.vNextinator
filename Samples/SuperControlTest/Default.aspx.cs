using SuperControlTest.Controls;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebForms.vNextinator;

namespace SuperControlTest
{
    public class InjectionTest
    {

    }

    public partial class Default : System.Web.UI.Page
    {
        public Default()
        {
        }

        public Default(InjectionTest test) : this()
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