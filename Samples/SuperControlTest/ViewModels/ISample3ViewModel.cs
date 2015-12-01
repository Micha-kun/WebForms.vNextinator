using SuperControlTest.Views;
using System;
using WebForms.vNextinator.Mvpvm;

namespace SuperControlTest.ViewModels
{
    public interface ISample3ViewModel : IViewModel
    {
        DateTime CurrentDateTime { get; set; }
        string LabelToShow { get; set; }
        string Title { get; set; }
    }
}
