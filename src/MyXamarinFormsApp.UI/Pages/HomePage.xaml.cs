using MvvmCross.Forms.Presenters.Attributes;
using MyXamarinFormsApp.Core.ViewModels.Home;
using Xamarin.Forms.Xaml;

namespace MyXamarinFormsApp.UI.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [MvxMasterDetailPagePresentation(MasterDetailPosition.Detail, WrapInNavigationPage = true)]
    public partial class HomePage : BasePage<HomeViewModel>
    {
        public HomePage()
        {
            InitializeComponent();
        }
    }
}
