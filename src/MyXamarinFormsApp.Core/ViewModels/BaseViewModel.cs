using System.Threading.Tasks;
using MvvmCross.Commands;
using MvvmCross.Logging;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;

namespace MyXamarinFormsApp.Core.ViewModels
{
    public abstract class BaseViewModel : MvxNavigationViewModel
    {
        public BaseViewModel(IMvxLogProvider logProvider, IMvxNavigationService navigationService) : base(logProvider, navigationService)
        {
        }

        private IMvxAsyncCommand _backCommand;
        public IMvxAsyncCommand BackCommand => _backCommand ?? (_backCommand = new MvxAsyncCommand(Back));
        public virtual async Task Back() => await NavigationService.Close(this);
    }
}
