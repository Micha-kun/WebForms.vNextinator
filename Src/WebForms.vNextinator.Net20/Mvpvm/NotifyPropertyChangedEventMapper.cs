using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;

namespace WebForms.vNextinator.Mvpvm
{
    public class NotifyPropertyChangedEventMapper : IDisposable
    {
        private readonly INotifyPropertyChanged observable;

        private readonly object observer;

        private readonly IDictionary<string, ICollection<MethodInfo>> trackedObserverPropertyMethodsDictionary = new Dictionary<string, ICollection<MethodInfo>>();

        public NotifyPropertyChangedEventMapper(INotifyPropertyChanged observable, object observer)
        {
            this.observable = observable;
            this.observer = observer;
            this.observable.PropertyChanged += this.HandlePropertyChanged;
            this.PrepareObserverPropertyHandlers();
        }

        ~NotifyPropertyChangedEventMapper()
        {
            this.Dispose(false);
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void PrepareObserverPropertyHandlers()
        {
            foreach (var method in this.observer.GetType().GetMethods())
            {
                foreach (PropertyChangedHandlerAttribute propertyChangedMethodAttribute in method.GetCustomAttributes(typeof(PropertyChangedHandlerAttribute), true))
                {
                    if (!this.trackedObserverPropertyMethodsDictionary.ContainsKey(propertyChangedMethodAttribute.PropertyName))
                    {
                        this.trackedObserverPropertyMethodsDictionary.Add(
                            propertyChangedMethodAttribute.PropertyName,
                            new List<MethodInfo> { method });
                    }
                    else
                    {
                        this.trackedObserverPropertyMethodsDictionary[propertyChangedMethodAttribute.PropertyName].Add(method);
                    }
                }
            }
        }

        private void HandlePropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (this.trackedObserverPropertyMethodsDictionary.ContainsKey(e.PropertyName))
            {
                foreach (var methodInfo in this.trackedObserverPropertyMethodsDictionary[e.PropertyName])
                {
                    methodInfo.Invoke(this.observer, new object[0]);
                }
            }
        }

        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.observable.PropertyChanged -= this.HandlePropertyChanged;
            }
        }
    }
}
