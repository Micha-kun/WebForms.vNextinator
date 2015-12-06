using SuperControlTest.ViewModels;
using WebForms.vNextinator.Mvpvm;

namespace SuperControlTest.Presenters
{
    public interface IToDoListPresenter : IPresenter<ToDoListViewModel>
    {
        void Init();
        void AddItem(string text);
        void SaveItem(int itemIndex, string text);
        void DeleteItem(int itemIndex);
    }
}
