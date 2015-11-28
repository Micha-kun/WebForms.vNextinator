using System;
using WebForms.vNextinator.Mvpvm;

namespace SuperControlTest.ViewModels
{
    public class DefaultViewModel : ViewModel
    {
        private string title;

        private DateTime currentDateTime;

        public string Title
        {
            get { return title; }
            set { SetField(ref title, value); }
        }

        public DateTime CurrentDateTime
        {
            get { return currentDateTime; }
            set { SetField(ref currentDateTime, value); }
        }
    }
}