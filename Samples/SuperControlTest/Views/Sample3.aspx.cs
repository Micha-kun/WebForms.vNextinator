using SuperControlTest.Presenters;
using SuperControlTest.ViewModels;
using System;
using WebForms.vNextinator.Mvpvm;

namespace SuperControlTest.Views
{
    public partial class Sample3 : PageView<ISample3Presenter, ISample3ViewModel>, ISample3View
    {
        public Sample3()
        {
        }

        public Sample3(ISample3Presenter presenter)
            : base(presenter)
        {
        }

        protected override void OnPreInit(EventArgs e)
        {
            base.OnPreInit(e);
            if (!this.IsPostBack) { this.Presenter.Init(); }
            btnSetNewValues.Click += BtnSetNewValues_Click;
        }

        void BtnSetNewValues_Click(object sender, EventArgs e)
        {
            Presenter.SetNewValues();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnInitComplete(e);
            if (this.IsPostBack) { this.Presenter.Init(this); }

        }

        public string TitleView
        {
            get { return txbNewTitle.Text; }
        }
        public string MutableLabelView
        {
            get { return txbNewLabelToShow.Text; }
        }

    }
}