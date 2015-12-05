using System;
using System.Collections.ObjectModel;
using WebForms.vNextinator.Mvpvm;

namespace SuperControlTest.ViewModels
{
    [Serializable]
    public class ToDoListViewModel : ViewModel
    {
        private ObservableCollection<ToDoListItem> _items;

        public ToDoListViewModel()
        {
            _items = new ObservableCollection<ToDoListItem>();
        }

        public ObservableCollection<ToDoListItem> Items
        {
            get { return _items; }
            set { SetField<ObservableCollection<ToDoListItem>>(ref _items, value); }
        }
    }
}
