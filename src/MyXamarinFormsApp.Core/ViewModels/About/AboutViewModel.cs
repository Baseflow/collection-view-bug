using System;
using System.Collections.Generic;
using System.Linq;
using MvvmCross.Commands;
using MvvmCross.Logging;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using MyXamarinFormsApp.Core.Models;

namespace MyXamarinFormsApp.Core.ViewModels.About
{
    public class AboutViewModel : BaseViewModel
    {
        public AboutViewModel(IMvxLogProvider logProvider, IMvxNavigationService navigationService) : base(logProvider, navigationService)
        {
        }

        private IMvxCommand _fooCommand;
        public IMvxCommand FooCommand => _fooCommand ?? (_fooCommand = new MvxCommand(Foo));
        private void Foo()
        {
        }

        private MvxObservableCollection<KeyedList<string, object>> _aboutList;
        public MvxObservableCollection<KeyedList<string, object>> AboutList
        {
            get
            {
                if (_aboutList == null)
                {
                    var applicationList = new KeyedList<string, object>("Application", new List<AboutText>() {
                        new AboutText()
                        {
                            Label = "MyXamarinFormsApp",
                            Value = "x.x.x"
                        }
                    });
                    var supportList = new KeyedList<string, object>("Support", new List<AboutButton>() {
                        new AboutButton()
                        {
                            CommandIconSource = "icon_phone",
                            CommandText = "Tech Support Phone",
                            Command = FooCommand
                        },
                        new AboutButton()
                        {
                            CommandIconSource = "icon_camera",
                            CommandText = "Tech Support Web Portal",
                            Command = FooCommand
                        }
                    });
                    var deviceList = new KeyedList<string, object>("Device", new List<AboutText>() {
                        new AboutText()
                        {
                            Label = "Device  ID",
                            Value = Guid.NewGuid().ToString()
                        },
                        new AboutText()
                        {
                            Label = "OS Version",
                            Value = "x.x"
                        },
                        new AboutText()
                        {
                            Label = "IP Address",
                            Value = "xxx.xxx.xxx.xxx"
                        },
                        new AboutText()
                        {
                            Label = "Scanner Model",
                            Value = "Hidden"
                        },
                        new AboutText()
                        {
                            Label = "Scanner Firmware",
                            Value = "Hidden"
                        }
                    });
                    var sessionList = new KeyedList<string, object>("Session", new List<AboutText>() {
                        new AboutText()
                        {
                            Label = "User",
                            Value = "John Doe"
                        },
                        new AboutText()
                        {
                            Label = "Connected To",
                            Value = "https://hidden.hidden.com/"
                        },
                        new AboutText()
                        {
                            Label = "Site ID",
                            Value = "Hidden"
                        },
                        new AboutText()
                        {
                            Label = "Customer ID",
                            Value = "Hidden"
                        }
                    });

                    _aboutList = new MvxObservableCollection<KeyedList<string, object>>
                    {
                        applicationList,
                        supportList,
                        deviceList,
                        sessionList
                    };
                }
                return _aboutList;
            }
        }
    }

    public class KeyedList<TKey, TItem> : List<TItem>
    {
        public TKey Key { get; protected set; }
        public bool ShowViewAll { get; protected set; }
        public bool ShowCount { get; protected set; }

        public KeyedList(TKey key, IEnumerable<TItem> items, bool showViewAll = false, bool showCount = false) : base(items)
        {
            Key = key;
            ShowViewAll = showViewAll;
            ShowCount = showCount;
        }

        public KeyedList(IGrouping<TKey, TItem> grouping) : base(grouping)
        {
            Key = grouping.Key;
        }
    }
}
