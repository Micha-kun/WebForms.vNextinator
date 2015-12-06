using SuperControlTest.Presenters;
using SuperControlTest.ViewModels;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebForms.vNextinator.Mvpvm;

namespace SuperControlTest.Views
{
    public partial class ToDoList : PageView<IToDoListPresenter, ToDoListViewModel>
    {
        public ToDoList() : base()
        {
        }

        public ToDoList(IToDoListPresenter presenter) : base(presenter)
        {
        }

        protected override object SaveControlState()
        {
            return new Pair(base.SaveControlState(), this.ViewModel);
        }

        protected override void LoadControlState(object savedState)
        {
            var pair = savedState as Pair;
            base.LoadControlState(pair.First);
            var vm = pair.Second as ToDoListViewModel;
            ViewModel.Items = vm.Items;
        }

        protected override void OnPreInit(EventArgs e)
        {
            RegisterRequiresControlState(this);
            base.OnPreInit(e);
            if (!IsPostBack)
            {
                Presenter.Init();
            }
        }

        protected void rptToDoList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "Save":
                    Presenter.SaveItem(e.Item.ItemIndex, ((TextBox)e.Item.FindControl("tbxEdit")).Text);
                    break;
                case "Delete":
                    Presenter.DeleteItem(e.Item.ItemIndex);
                    break;
                default:
                    break;
            }
        }

        protected void Unnamed_Click(object sender, EventArgs e)
        {
            this.Presenter.AddItem(tbxAdd.Text);
            tbxAdd.Text = "";
        }
    }
}