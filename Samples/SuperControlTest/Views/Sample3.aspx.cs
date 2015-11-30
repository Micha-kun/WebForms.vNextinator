using SuperControlTest.Presenters;
using SuperControlTest.ViewModels;
using System;
using WebForms.vNextinator.Mvpvm;

namespace SuperControlTest.Views
{
    public partial class Sample3 : PageView<ISample3Presenter, Sample3ViewModel>
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
            this.Presenter.Init();
            txbNewTitle.TextChanged += TxbNewTitle_TextChanged;
            txbNewLabelToShow.TextChanged += TxbNewLabelToShow_TextChanged;
        }

        void TxbNewLabelToShow_TextChanged(object sender, EventArgs e)
        {
            Presenter.SetNewLabelToShow(txbNewLabelToShow.Text);
        }

        void TxbNewTitle_TextChanged(object sender, EventArgs e)
        {
            Presenter.SetNewTitle(txbNewTitle.Text);
        }



    }
}