using System;
using Android.Util;
using MvvmCross.Platforms.Android;
using MyXamarinFormsApp.Core.Services.Interfaces;

namespace MyXamarinFormsApp.Droid.Services
{
    public class DeviceService : IDeviceService
    {
        private readonly IMvxAndroidCurrentTopActivity _contextService;

        public DeviceService(IMvxAndroidCurrentTopActivity contextService)
        {
            _contextService = contextService ?? throw new ArgumentNullException(nameof(contextService));
        }

        public float ScreenWidth
        {
            get
            {
                var displayMetrics = new DisplayMetrics();
                _contextService.Activity.WindowManager.DefaultDisplay.GetMetrics(displayMetrics);
                return displayMetrics.WidthPixels;
            }
        }
    }
}