using SuperControlTest.Presenters;
using SuperControlTest.ViewModels;
using System;
using System.Web.UI;
using WebForms.vNextinator.Mvpvm;

namespace SuperControlTest.Views
{
    public partial class Sample2 : PageView<IDefaultPresenter, DefaultViewModel>
    {
        public Sample2()
        {
        }

        public Sample2(IDefaultPresenter presenter) : base(presenter)
        {
        }

        protected override void OnPreInit(EventArgs e)
        {
            base.OnPreInit(e);
            this.Presenter.Init();
        }
    }
}