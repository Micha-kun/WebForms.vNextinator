namespace WebForms.vNextinator.Mvpvm
{
    public interface IPresenter<TViewModel> where TViewModel : IViewModel
    {
        TViewModel ViewModel { get; }
    }
}
