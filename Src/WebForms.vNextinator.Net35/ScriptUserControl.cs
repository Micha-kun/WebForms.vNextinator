using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;

namespace WebForms.vNextinator
{
    public abstract class ScriptUserControl : UserControl, IScriptControl
    {
        IEnumerable<ScriptDescriptor> IScriptControl.GetScriptDescriptors()
        {
            return GetScriptDescriptors();
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

        protected abstract IEnumerable<ScriptReference> GetScriptReferences();

        protected virtual IEnumerable<ScriptDescriptor> GetScriptDescriptors()
        {
            return Enumerable.Empty<ScriptDescriptor>();
        }
    }
}
