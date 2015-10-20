using System.Web.UI;
using System;

namespace WebForms.vNextinator
{
    public static class ControlFinder
    {
#if !HAVE_EXTENSION_METHODS
        public static TControl FindControl<TControl>(Control ctrl, string id) where TControl : Control
        {
            return ctrl.FindControl(id) as TControl;
        }

        public static bool TryFindControl<TControl>(Control ctrl, string id, out TControl result) where TControl: Control
        {
            result = FindControl<TControl>(ctrl, id);
            return result != null;
        }

        public static void GetControl<TControl>(Control ctrl, string id, Action<TControl> success, System.Action failure = null) where TControl : Control
        {
            TControl result;
            if (TryFindControl(ctrl, id, out result))
            {
                success(result);
                return;
            }

            if (failure != null)
            {
                failure();
            }
        }

#else
        public static TControl FindControl<TControl>(this Control ctrl, string id) where TControl : Control
        {
            return ctrl.FindControl(id) as TControl;
        }

        public static bool TryFindControl<TControl>(this Control ctrl, string id, out TControl result) where TControl : Control
        {
            result = ctrl.FindControl<TControl>(id);
            return result != null;
        }

        public static void GetControl<TControl>(this Control ctrl, string id, Action<TControl> success, Action failure = null) where TControl : Control
        {
            TControl result;
            if (ctrl.TryFindControl(id, out result))
            {
                success(result);
                return;
            }

            if (failure != null)
            {
                failure();
            }
        }
#endif

    }
}
