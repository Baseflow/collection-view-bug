using MvvmCross.Forms.Presenters.Attributes;
using MvvmCross.Forms.Views;
using MyXamarinFormsApp.Core.ViewModels.Main;

namespace MyXamarinFormsApp.UI.Pages
{
    [MvxMasterDetailPagePresentation(MasterDetailPosition.Root, WrapInNavigationPage = false, NoHistory = true)]
    public partial class MainPage : MvxMasterDetailPage<MainViewModel>
    {
        private bool _firstTime = true;

        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            if (_firstTime)
            {
                ViewModel.ShowMenuCommand.Execute(null);
                ViewModel.ShowPageCommand.Execute(null);

                _firstTime = false;
            }

            base.OnAppearing();
        }
    }
}

