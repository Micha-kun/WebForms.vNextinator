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

        public void Init()
        {
            ViewModel.Items.Clear();
            ViewModel.Items.Add(new ToDoListItem { Text = "Sample 1" });
            ViewModel.Items.Add(new ToDoListItem { Text = "Sample 2" });
        }
    }
}
