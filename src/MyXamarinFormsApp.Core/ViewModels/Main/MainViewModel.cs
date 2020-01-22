using System.Threading.Tasks;
using MvvmCross.Commands;
using MvvmCross.Logging;
using MvvmCross.Navigation;
using MyXamarinFormsApp.Core.ViewModels.Home;

namespace MyXamarinFormsApp.Core.ViewModels.Main
{
    public class MainViewModel : BaseViewModel
    {
        public MainViewModel(IMvxLogProvider logProvider, IMvxNavigationService navigationService) : base(logProvider, navigationService)
        {

        }

        private IMvxAsyncCommand _showMenuCommand;
        public IMvxAsyncCommand ShowMenuCommand => _showMenuCommand ?? (_showMenuCommand = new MvxAsyncCommand(ShowMenu));
        private async Task ShowMenu()
        {
            await NavigationService.Navigate<MenuViewModel>();
        }

        private IMvxAsyncCommand _showPageCommand;
        public IMvxAsyncCommand ShowPageCommand => _showPageCommand ?? (_showPageCommand = new MvxAsyncCommand(ShowPage));
        private async Task ShowPage()
        {
            await NavigationService.Navigate<HomeViewModel>();
        }
    }
}
