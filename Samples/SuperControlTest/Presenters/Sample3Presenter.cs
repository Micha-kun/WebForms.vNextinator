using SuperControlTest.ViewModels;
using System;
using WebForms.vNextinator.Mvpvm;

namespace SuperControlTest.Presenters
{
    public class Sample3Presenter : Presenter<Sample3ViewModel>, ISample3Presenter
    {
        public Sample3Presenter(Sample3ViewModel viewModel)
            : base(viewModel)
        {
        }

        public void Init()
        {
            ViewModel.Title = "Test title";
            ViewModel.LabelToShow = "This is a mutable label";
            ViewModel.CurrentDateTime = DateTime.Now;
        }

        public void SetNewTitle(string newTitle)
        {
            //Do bizness here
            ViewModel.Title = newTitle;
        }

        public void SetNewLabelToShow(string newLabelToShow)
        {
            //Do bizness here
            ViewModel.LabelToShow = newLabelToShow;
        }
    }
}