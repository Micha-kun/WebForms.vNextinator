using SuperControlTest.ViewModels;
using WebForms.vNextinator.Mvpvm;

namespace SuperControlTest.Presenters
{
    public interface IDefaultPresenter : IPresenter<DefaultViewModel>
    {
        void Init();
    }
}
