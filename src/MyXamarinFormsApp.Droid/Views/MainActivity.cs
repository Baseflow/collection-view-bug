using Android.App;
using Android.OS;
using MvvmCross.Forms.Platforms.Android.Views;
using MyXamarinFormsApp.Core.ViewModels;

namespace MyXamarinFormsApp.Droid
{
    [Activity(
        Theme = "@style/AppTheme")]
    public class MainActivity : MvxFormsAppCompatActivity<FormsViewModel>
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);
        }
    }
}
