using System;

namespace WebForms.vNextinator.Mvpvm
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public class PropertyChangedHandlerAttribute : Attribute
    {
        public PropertyChangedHandlerAttribute(string propertyName)
        {
            this.PropertyName = propertyName;
        }

        public string PropertyName { get; private set; }
    }
}
