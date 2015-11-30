
using SuperControlTest.ViewModels;
using WebForms.vNextinator.Mvpvm;

namespace SuperControlTest.Presenters
{
    public interface ISample3Presenter : IPresenter<Sample3ViewModel>
    {
        void Init();

        void SetNewTitle(string newTitle);

        void SetNewLabelToShow(string newLabelToShow);
    }
}
