using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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
        }
    }
}