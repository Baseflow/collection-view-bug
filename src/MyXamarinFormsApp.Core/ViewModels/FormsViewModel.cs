using MvvmCross.Logging;
using MvvmCross.Navigation;

namespace MyXamarinFormsApp.Core.ViewModels
{
    public class FormsViewModel : BaseViewModel
    {
        public FormsViewModel(IMvxLogProvider logProvider, IMvxNavigationService navigationService) : base(logProvider, navigationService)
        {
        }
    }
}