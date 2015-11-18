using SuperControlTest.Presenters;
using SuperControlTest.ViewModels;
using System;
using WebForms.vNextinator.Mvpvm;

namespace SuperControlTest.Views
{
    public partial class Sample1 : PageView<IDefaultPresenter, DefaultViewModel>
    {
        public Sample1()
        {
        }

        public Sample1(IDefaultPresenter presenter) : base(presenter)
        {
        }

        protected override void OnPreInit(EventArgs e)
        {
            base.OnPreInit(e);
            this.Presenter.Init();
        }

        [PropertyChangedHandler("Title")]
        public void SetTitle()
        {
            Title = ViewModel.Title;
        }

        [PropertyChangedHandler("CurrentDateTime")]
        public void SetFormattedDateTime()
        {
            LblCurrentDateTime.Text = ViewModel.CurrentDateTime.ToString();
        }
    }
}