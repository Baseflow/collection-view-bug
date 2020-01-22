using MyXamarinFormsApp.Core.Services.Interfaces;
using UIKit;

namespace MyXamarinFormsApp.iOS.Services
{
    public class DeviceService : IDeviceService
    {
        public float ScreenWidth => (float)UIScreen.MainScreen.Bounds.Width;
    }
}