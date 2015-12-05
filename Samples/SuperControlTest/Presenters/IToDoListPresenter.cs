using SuperControlTest.ViewModels;
using WebForms.vNextinator.Mvpvm;

namespace SuperControlTest.Presenters
{
    public interface IToDoListPresenter : IPresenter<ToDoListViewModel>
    {
        void Init();
    }
}
