using SuperControlTest.Presenters;
using SuperControlTest.ViewModels;
using System;
using WebForms.vNextinator.Mvpvm;

namespace SuperControlTest.Views
{
    public partial class Default : PageView<IDefaultPresenter, DefaultViewModel>
    {
        public Default()
        {
        }

        public Default(IDefaultPresenter presenter) : base(presenter)
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
            Title = Presenter.ViewModel.Title;
        }

        [PropertyChangedHandler("CurrentDateTime")]
        public void SetFormattedDateTime()
        {
            LblCurrentDateTime.Text = Presenter.ViewModel.CurrentDateTime.ToString();
        }
    }
}