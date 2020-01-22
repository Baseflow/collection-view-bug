using System.Threading.Tasks;
using MvvmCross.Commands;
using MvvmCross.Logging;
using MvvmCross.Navigation;
using MyXamarinFormsApp.Core.ViewModels.About;
using MyXamarinFormsApp.Core.ViewModels.Home;

namespace MyXamarinFormsApp.Core.ViewModels.Main
{
    public class MenuViewModel : BaseViewModel
    {
        public MenuViewModel(IMvxLogProvider logProvider, IMvxNavigationService navigationService) : base(logProvider, navigationService)
        {
        }

        private IMvxAsyncCommand _homeCommand;
        public IMvxAsyncCommand HomeCommand => _homeCommand ?? (_homeCommand = new MvxAsyncCommand(Home));
        private async Task Home()
        {
            await NavigationService.Navigate<HomeViewModel>();
        }

        private IMvxAsyncCommand _aboutCommand;
        public IMvxAsyncCommand AboutCommand => _aboutCommand ?? (_aboutCommand = new MvxAsyncCommand(About));
        private async Task About()
        {
            await NavigationService.Navigate<AboutViewModel>();
        }
    }
}
