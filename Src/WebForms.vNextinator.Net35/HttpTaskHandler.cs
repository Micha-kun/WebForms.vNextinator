using System;
using System.Threading.Tasks;
using System.Web;

namespace WebForms.vNextinator
{
    public abstract class HttpTaskHandler : IHttpAsyncHandler
    {
        private readonly bool _isReusable;

        protected HttpTaskHandler(bool isReusable = false)
        {
            _isReusable = isReusable;
        }

        bool IHttpHandler.IsReusable
        {
            get
            {
                return _isReusable;
            }
        }

        void IHttpHandler.ProcessRequest(HttpContext context)
        {
            var task = ProcessRequestAsync(context);
            if (task.Status == TaskStatus.Created)
            {
                task.RunSynchronously();
            } else
            {
                task.Wait();
            }
        }

        protected abstract Task ProcessRequestAsync(HttpContext context);

        IAsyncResult IHttpAsyncHandler.BeginProcessRequest(HttpContext context, AsyncCallback cb, object extraData)
        {
            var task = ProcessRequestAsync(context);
            if (cb != null)
            {
                task.ContinueWith(t => cb(t), TaskContinuationOptions.ExecuteSynchronously);
            }

            if (task.Status == TaskStatus.Created)
            {
                task.Start();
            }

            return task;
        }

        void IHttpAsyncHandler.EndProcessRequest(IAsyncResult result)
        {
            ((Task)result).Wait();
        }
    }
}
