using System;
using SuperControlTest.ViewModels;
using WebForms.vNextinator.Mvpvm;

namespace SuperControlTest.Presenters
{
    public class DefaultPresenter : Presenter<DefaultViewModel>, IDefaultPresenter
    {
        public DefaultPresenter(DefaultViewModel viewModel) : base(viewModel)
        {
        }

        public void Init()
        {
            ViewModel.Title = "Test title";
            ViewModel.CurrentDateTime = DateTime.Now;
        }
    }
}