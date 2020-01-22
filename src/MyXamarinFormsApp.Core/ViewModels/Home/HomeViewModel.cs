using MvvmCross.Logging;
using MvvmCross.Navigation;

namespace MyXamarinFormsApp.Core.ViewModels.Home
{
    public class HomeViewModel : BaseViewModel
    {
        public HomeViewModel(IMvxLogProvider logProvider, IMvxNavigationService navigationService) : base(logProvider, navigationService)
        {
        }
    }
}
