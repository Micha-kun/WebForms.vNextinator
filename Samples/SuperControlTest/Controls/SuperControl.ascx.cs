using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web.Http;
using System.Web.UI;

namespace SuperControlTest.Controls
{
    public partial class SuperControl : UserControl, IScriptControl
    {
        public SuperControl()
        {
        }

        public SuperControl(InjectionTest test)
        {
            Debug.Assert(test != null);
        }

        #region IScriptControl Crap
        IEnumerable<ScriptDescriptor> IScriptControl.GetScriptDescriptors()
        {
            return Enumerable.Empty<ScriptDescriptor>();
        }

        IEnumerable<ScriptReference> IScriptControl.GetScriptReferences()
        {
            return GetScriptReferences();
        }

        protected override void OnPreRender(EventArgs e)
        {
            if (!this.DesignMode)
            {
                var sm = ScriptManager.GetCurrent(Page);
                if (sm == null)
                {
                    throw new InvalidOperationException("ScriptManager control is required on Page");
                }

                sm.RegisterScriptControl(this);
            }

            base.OnPreRender(e);
        }

        protected override void Render(HtmlTextWriter writer)
        {
            if (!DesignMode)
            {
                var sm = ScriptManager.GetCurrent(Page);
                sm.RegisterScriptDescriptors(this);
            }
            base.Render(writer);
        }

        private IEnumerable<ScriptReference> GetScriptReferences()
        {
            yield return new ScriptReference("~/Controls/SuperControl.js");
        }
        #endregion

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