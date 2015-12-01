using System;
using WebForms.vNextinator.Mvpvm;

namespace SuperControlTest.ViewModels
{
    public class Sample3ViewModel : ViewModel, SuperControlTest.ViewModels.ISample3ViewModel
    {
        private string title;
        private string label;
        private DateTime currentDateTime;

        public string Title
        {
            get { return title; }
            set
            {
                if (string.IsNullOrEmpty(value.Trim())) { value = "Default Title by ViewModel"; }
                SetField(ref title, value);
            }
        }

        public string LabelToShow
        {
            get { return label; }
            set
            {
                if (string.IsNullOrEmpty(value.Trim())) { value = "Default label by ViewModel"; }
                SetField(ref label, value);
            }
        }


        public DateTime CurrentDateTime
        {
            get { return currentDateTime; }
            set { SetField(ref currentDateTime, value); }
        }
    }
}