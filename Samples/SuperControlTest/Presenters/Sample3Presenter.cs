using SuperControlTest.ViewModels;
using SuperControlTest.Views;
using System;
using WebForms.vNextinator.Mvpvm;

namespace SuperControlTest.Presenters
{
    public class Sample3Presenter : Presenter<ISample3ViewModel>, ISample3Presenter
    {
        public Sample3Presenter(ISample3ViewModel viewModel)
            : base(viewModel)
        {
        }

        public void Init()
        {
            ViewModel.Title = "Test title";
            ViewModel.LabelToShow = "This is a mutable label";
            ViewModel.CurrentDateTime = DateTime.Now;
        }

        public void Init(ISample3View view)
        {
            ViewModel.Title = view.TitleView;
            ViewModel.LabelToShow = view.MutableLabelView;
            ViewModel.CurrentDateTime = DateTime.Now;
        }

        public void SetNewValues()
        {
            //Do bizness here
            if (ViewModel.Title == "#") { ViewModel.LabelToShow = "Presenter has modified this value because Tile is #"; }
        }
    }
}