using SuperControlTest.ViewModels;
using SuperControlTest.Views;
using WebForms.vNextinator.Mvpvm;

namespace SuperControlTest.Presenters
{
    public interface ISample3Presenter : IPresenter<ISample3ViewModel>
    {
        void Init();

        void Init(ISample3View view);

        void SetNewValues();
    }
}
