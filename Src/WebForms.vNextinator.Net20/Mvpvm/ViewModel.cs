using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

#if HAVE_EXPRESSION_LAMBDAS
using System.Linq.Expressions;
#endif

namespace WebForms.vNextinator.Mvpvm
{
    [Serializable]
    public abstract class ViewModel : IViewModel
    {
        [field: NonSerialized]
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        protected bool SetField<T>(ref T field, T value, [CallerMemberName] string propertyName = "")
        {
            if (EqualityComparer<T>.Default.Equals(field, value))
            {
                return false;
            }

            field = value;
            if (!string.IsNullOrEmpty(propertyName))
            {
                this.OnPropertyChanged(propertyName);
            }

            return true;
        }

#if HAVE_EXPRESSION_LAMBDAS
        protected bool SetField<T>(ref T field, T value, Expression<Func<T>> propertyExpression)
        {
            return SetField(ref field, value, GetPropertyName(propertyExpression));
        }

        private string GetPropertyName<T>(Expression<Func<T>> propertyExpression)
        {
            var member = propertyExpression.Body as MemberExpression;
            if (member == null)
            {
                return null;
            }

            return member.Member.Name;
        }
#endif
    }
}
