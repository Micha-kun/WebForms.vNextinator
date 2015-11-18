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

        public bool IsReusable
        {
            get { return _isReusable; }
        }

        public void ProcessRequest(HttpContext context)
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

        public IAsyncResult BeginProcessRequest(HttpContext context, AsyncCallback cb, object extraData)
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

        public void EndProcessRequest(IAsyncResult result)
        {
            ((Task)result).Wait();
        }
    }
}
