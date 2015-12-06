using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using WebForms.vNextinator.Mvpvm;

namespace SuperControlTest.ViewModels
{
    [Serializable]
    public class ToDoListViewModel : ViewModel
    {
        private List<ToDoListItem> _items;

        public ToDoListViewModel()
        {
            _items = new List<ToDoListItem>();
        }

        public List<ToDoListItem> Items
        {
            get { return _items; }
            set { SetField<List<ToDoListItem>>(ref _items, value); }
        }
    }
}
