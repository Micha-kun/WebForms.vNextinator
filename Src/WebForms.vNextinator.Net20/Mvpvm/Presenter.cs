namespace WebForms.vNextinator.Mvpvm
{
    public abstract class Presenter<TViewModel> where TViewModel : IViewModel
    {
        protected Presenter(TViewModel viewModel)
        {
            ViewModel = viewModel;
        }

        public TViewModel ViewModel { get; private set; }
    }
}
