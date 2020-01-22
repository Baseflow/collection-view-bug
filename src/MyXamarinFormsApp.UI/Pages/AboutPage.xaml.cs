using MvvmCross.Forms.Presenters.Attributes;
using MyXamarinFormsApp.Core.ViewModels.About;
using Xamarin.Forms.Xaml;

namespace MyXamarinFormsApp.UI.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [MvxContentPagePresentation(WrapInNavigationPage = true)]
    public partial class AboutPage : BasePage<AboutViewModel>
    {
        public AboutPage()
        {
            InitializeComponent();
        }
    }
}
