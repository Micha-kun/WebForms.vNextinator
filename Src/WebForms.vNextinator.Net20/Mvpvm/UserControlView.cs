using System;
using System.Web.UI;

namespace WebForms.vNextinator.Mvpvm
{
    public abstract class UserControlView<TPresenter, TViewModel> : UserControl
        where TViewModel : IViewModel
        where TPresenter : IPresenter<TViewModel>
    {
        private readonly NotifyPropertyChangedEventMapper _mapper;

        protected UserControlView()
        {
        }

        protected UserControlView(TPresenter presenter)
        {
            _mapper = new NotifyPropertyChangedEventMapper(presenter.ViewModel, this);
            Presenter = presenter;
        }

        protected TPresenter Presenter { get; private set; }

        protected TViewModel ViewModel { get { return Presenter.ViewModel; } }

        protected void ControlDataBind(object sender, EventArgs e)
        {
            var ctrl = sender as Control;
            if (ctrl != null)
            {
                ctrl.DataBind();
            }
        }

        protected override void OnUnload(EventArgs e)
        {
            base.OnUnload(e);
            if (_mapper != null)
            {
                _mapper.Dispose();
            }
        }
    }
}
