using System.Collections.Generic;
using System.Diagnostics;
using System.Web.Http;
using System.Web.UI;
using WebForms.vNextinator;

namespace SuperControlTest.Controls
{
    public partial class SuperControl : ScriptUserControl
    {
        public SuperControl()
        {
        }

        public SuperControl(IInjectionTest test)
            : this()
        {
            Debug.Assert(test != null);
        }

        protected override IEnumerable<ScriptReference> GetScriptReferences()
        {
            yield return new ScriptReference("~/Controls/SuperControl.js");
        }

        #region It's Magic!!

        [RoutePrefix("SuperControl")]
        public class SuperControlController : ApiController
        {
            [HttpGet]
            [Route("Click")]
            public string OnClick(string text)
            {
                return string.IsNullOrWhiteSpace(text) ? "You write nothing" : string.Format("You write {0}", text);
            }
        }

        #endregion

    }
}