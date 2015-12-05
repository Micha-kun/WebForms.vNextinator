using SuperControlTest.Presenters;
using SuperControlTest.ViewModels;
using System;
using System.Web.UI.WebControls;
using WebForms.vNextinator.Mvpvm;

namespace SuperControlTest.Views
{
    public partial class ToDoList : PageView<IToDoListPresenter, ToDoListViewModel>
    {
        protected override void OnPreInit(EventArgs e)
        {
            base.OnPreInit(e);
            if (!IsPostBack)
            {
                Presenter.Init();
            }
        }

        protected void rptToDoList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {

        }
    }
}