using System;
using System.Threading;
using System.Threading.Tasks;
using System.Web.UI;

namespace WebForms.vNextinator
{
    public static class PageAsyncTaskHelper
    {
        public static PageAsyncTask ToPageAsyncTask(this Task task, Action<IAsyncResult> onTimeout = null)
        {
            Func<Task> func = () => task;
            return func.ToPageAsyncTask(onTimeout);

        }

        public static PageAsyncTask ToPageAsyncTask(this Func<Task> func, Action<IAsyncResult> onTimeout = null)
        {
            return new PageAsyncTask(
                (sender, e, cb, extraData) => func.BeginInvoke(cb, extraData),
                ar => func.EndInvoke(ar).Wait(),
                ar =>
                {
                    if (onTimeout == null)
                    {
                        return;
                    }

                    onTimeout(ar);
                }, 
                null);
        }



        public static PageAsyncTask ToPageAsyncTask(this Func<CancellationToken, Task> func)
        {
            var cts = new CancellationTokenSource();
            return new PageAsyncTask(
                (sender, e, cb, extraData) => func.BeginInvoke(cts.Token, cb, extraData),
                ar => func.EndInvoke(ar).Wait(),
                ar => cts.Cancel(), 
                null);
        }
    }
}
