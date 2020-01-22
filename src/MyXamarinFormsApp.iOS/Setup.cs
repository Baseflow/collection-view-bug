using MvvmCross;
using MvvmCross.Forms.Platforms.Ios.Core;
using MvvmCross.IoC;
using MyXamarinFormsApp.Core.Services.Interfaces;
using MyXamarinFormsApp.iOS.Services;

namespace MyXamarinFormsApp.iOS
{
    public class Setup : MvxFormsIosSetup<Core.App, UI.App>
    {
        protected override void InitializeFirstChance()
        {
            base.InitializeFirstChance();

            Mvx.IoCProvider.LazyConstructAndRegisterSingleton<IDeviceService, DeviceService>();
        }
    }
}
