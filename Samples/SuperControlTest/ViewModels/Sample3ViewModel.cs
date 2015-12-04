using System;
using System.ComponentModel.DataAnnotations;
using WebForms.vNextinator.Mvpvm;

namespace SuperControlTest.ViewModels
{
    public class Sample3ViewModel : ViewModel, SuperControlTest.ViewModels.ISample3ViewModel
    {
        private string title;
        private string label;
        private DateTime currentDateTime;

        [Required(AllowEmptyStrings = false, ErrorMessage = "Title can not be empty.")]
        [StringLength(20, ErrorMessage = "Title length can not be longer than 20.")]
        public string Title
        {
            get { return title; }
            set
            {
                value = value.Trim();
                SetField(ref title, value);
            }
        }

        public string LabelToShow
        {
            get { return label; }
            set
            {
                value = value.Trim();
                if (string.IsNullOrEmpty(value)) { value = "Default label by ViewModel"; }
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