using System;
using SuperControlTest.ViewModels;
using WebForms.vNextinator.Mvpvm;

namespace SuperControlTest.Presenters
{
    public class ToDoListPresenter : Presenter<ToDoListViewModel>, IToDoListPresenter
    {
        public ToDoListPresenter(ToDoListViewModel viewModel) : base(viewModel)
        {
        }

        public void AddItem(string text)
        {
            ViewModel.Items.Add(new ToDoListItem { Text = text });
        }

        public void DeleteItem(int itemIndex)
        {
            ViewModel.Items.RemoveAt(itemIndex);
        }

        public void Init()
        {
            ViewModel.Items.Clear();
            ViewModel.Items.Add(new ToDoListItem { Text = "Sample 1" });
            ViewModel.Items.Add(new ToDoListItem { Text = "Sample 2" });
        }

        public void SaveItem(int itemIndex, string text)
        {
            ViewModel.Items[itemIndex].Text = text;
        }
    }
}
