using System;
using System.Collections.Generic;
using System.Linq;
using MvvmCross;
using MvvmCross.Forms.Presenters.Attributes;
using MvvmCross.Forms.Views;
using MvvmCross.ViewModels;
using MyXamarinFormsApp.Core.Services.Interfaces;
using MyXamarinFormsApp.Core.ViewModels;
using MyXamarinFormsApp.UI.Controls;
using Xamarin.Forms;

namespace MyXamarinFormsApp.UI.Pages
{
    public partial class BasePage : MvxContentPage
    {
        private const string ICON_SOURCE_HAMBURGER = "icon_menu";
        private const string ICON_SOURCE_BACK = "icon_circle_left_arrow";
        private const string ICON_SOURCE_CLOSE = "icon_close";

        private TapGestureRecognizer _navBarActionTapGestureRecognizer;

        public new IList<TintedImage> ToolbarItems { get; set; } = new List<TintedImage>();

        public IconButton FloatingActionButton { get; set; }

        public View BasePageContent { get; set; }

        private MvxPagePresentationAttribute _presenterAttribute;
        public MvxPagePresentationAttribute PresenterAttribute => _presenterAttribute ?? (_presenterAttribute = GetPresenterAttribue(GetType()));

        private MvxPagePresentationAttribute GetPresenterAttribue(Type type)
        {
            return _presenterAttribute = (MvxPagePresentationAttribute)type.GetCustomAttributes(true).First(a => a.GetType().Namespace.StartsWith("MvvmCross", StringComparison.OrdinalIgnoreCase));
        }

        public static new readonly BindableProperty TitleProperty = BindableProperty.Create(nameof(Title), typeof(string), typeof(BasePage));
        public new string Title
        {
            get => (string)GetValue(TitleProperty);
            set => SetValue(TitleProperty, value);
        }

        public static readonly BindableProperty SubtitleProperty = BindableProperty.Create(nameof(Subtitle), typeof(string), typeof(BasePage), propertyChanged: SubtitlePropertyChanged);
        public string Subtitle
        {
            get => (string)GetValue(SubtitleProperty);
            set => SetValue(SubtitleProperty, value);
        }

        private static void SubtitlePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (!(bindable is BasePage basePage) || newValue == oldValue)
                return;

            var rowSpan = !string.IsNullOrWhiteSpace(basePage.Subtitle) ? 1 : 2;

            Grid.SetRowSpan(basePage.TitleLabel, rowSpan);
        }

        public static readonly BindableProperty ShowNavigationProperty = BindableProperty.Create(nameof(ShowNavigation), typeof(bool), typeof(BasePage), true);
        public bool ShowNavigation
        {
            get => (bool)GetValue(ShowNavigationProperty);
            set => SetValue(ShowNavigationProperty, value);
        }

        public static readonly BindableProperty ShowNavigationActionButtonProperty = BindableProperty.Create(nameof(ShowNavigationActionButton), typeof(bool), typeof(BasePage), true);
        public bool ShowNavigationActionButton
        {
            get => (bool)GetValue(ShowNavigationActionButtonProperty);
            set => SetValue(ShowNavigationActionButtonProperty, value);
        }

        protected IDeviceService _deviceService;
        protected IDeviceService DeviceService => _deviceService ?? (_deviceService = Mvx.IoCProvider.Resolve<IDeviceService>());

        public BasePage()
        {
            InitializeComponent();

            if (!PresenterAttribute.WrapInNavigationPage)
                ShowNavigation = false;

            if (PresenterAttribute is MvxContentPagePresentationAttribute)
            {
                var navigationPage = TopNavigationPage();

                if (navigationPage == null || navigationPage.Navigation.NavigationStack.Count == 0)
                    ShowNavigationActionButton = false;
            }

            NavigationPage.SetHasNavigationBar(this, false);
        }

        public NavigationPage TopNavigationPage(Page rootPage = null)
        {
            rootPage ??= Application.Current.MainPage;

            if (rootPage is NavigationPage navigationPage)
            {
                if (navigationPage.CurrentPage != null)
                {
                    // Check if there's a nested navigation
                    var navPage = TopNavigationPage(navigationPage.CurrentPage);
                    if (navPage != null)
                        return navPage;
                }

                // Check for modals
                var topMostModal = navigationPage?.Navigation?.ModalStack?.LastOrDefault();
                if (topMostModal != null && topMostModal != navigationPage)
                {
                    var currentModalNav = TopNavigationPage(topMostModal);
                    if (currentModalNav != null)
                        return currentModalNav;
                }

                return navigationPage;
            }

            // The page isn't a navigation page, so check
            // to see if it's a master detail, and if so, check
            // the Detail and Master pages for a navigation page
            if (rootPage is MasterDetailPage masterDetailsPage)
            {
                if (masterDetailsPage.Detail != null)
                {
                    var navDetailPage = TopNavigationPage(masterDetailsPage.Detail);
                    if (navDetailPage != null)
                        return navDetailPage;
                }

                if (masterDetailsPage.Master != null)
                {
                    var navMasterPage = TopNavigationPage(masterDetailsPage.Master);
                    if (navMasterPage != null)
                        return navMasterPage;
                }
            }

            // Nothing, all out of luck!
            return null;
        }

        protected override void OnParentSet()
        {
            base.OnParentSet();

            InitializeNavigationBar();
            InitializeContent();
            InitializeFloatingActionButton();
        }

        private void InitializeNavigationBar()
        {
            InitializeNavigationActionButton();
            InitializeNavigationToolbar();
        }

        private void InitializeNavigationActionButton()
        {
            NavBarActionButton.Source = PresenterAttribute.GetType().Name switch
            {
                nameof(MvxMasterDetailPagePresentationAttribute) => ICON_SOURCE_HAMBURGER,
                nameof(MvxModalPresentationAttribute) => ICON_SOURCE_CLOSE,
                _ => ICON_SOURCE_BACK,
            };
        }

        private void InitializeNavigationToolbar()
        {
            SetToolbarSize();

            foreach (var item in ToolbarItems)
            {
                if (item.Style == default)
                    item.Style = (Style)Application.Current.Resources["NavigationBarIconStyle"];

                ToolbarItemsContainer.Children.Add(item);
            }
        }

        private void SetToolbarSize()
        {
            var columnDefinitionWidth = CalculateToolbarSize();

            NavBarGrid.ColumnDefinitions[0].Width = columnDefinitionWidth;
            NavBarGrid.ColumnDefinitions[2].Width = columnDefinitionWidth;
        }

        private GridLength CalculateToolbarSize()
        {
            var count = Math.Max(ToolbarItems.Count, 1);

            var padding = (double)Application.Current.Resources["NavigationBarPadding"];
            var iconSize = (double)Application.Current.Resources["NavigationBarIconSize"];
            var spacing = (double)Application.Current.Resources["ToolbarItemSpacing"];

            var size = (padding * 2) + (iconSize * count) + (spacing * (count - 1));

            return new GridLength(size, GridUnitType.Absolute);
        }

        private void InitializeContent()
        {
            if (BasePageContent != null)
            {
                BasePageContent.WidthRequest = DeviceService.ScreenWidth; // If not applied the screen with the grid will strech out of the screen.
                BasePageContent.VerticalOptions = LayoutOptions.FillAndExpand;

                BasePageGrid.Children.Add(BasePageContent, 0, 1);
                Grid.SetColumnSpan(BasePageContent, 2);
                Grid.SetRowSpan(BasePageContent, 2);
            }
        }

        private void InitializeFloatingActionButton()
        {
            if (FloatingActionButton != null)
            {
                if (FloatingActionButton.Style == default)
                    FloatingActionButton.Style = (Style)Application.Current.Resources["FloatingActionButtonStyle"];

                BasePageGrid.Children.Add(FloatingActionButton, 1, 2);
            }
        }

        protected override void OnAppearing()
        {
            _navBarActionTapGestureRecognizer = new TapGestureRecognizer();
            NavBarActionButton.GestureRecognizers.Add(_navBarActionTapGestureRecognizer);

            if (PresenterAttribute is MvxMasterDetailPagePresentationAttribute)
            {
                _navBarActionTapGestureRecognizer.Tapped += HamburgerButton_Tapped;
            }
            else if (ViewModel is BaseViewModel baseViewModel)
            {
                _navBarActionTapGestureRecognizer.Command = baseViewModel.BackCommand;
            }

            base.OnAppearing();
        }

        protected override void OnDisappearing()
        {
            if (_navBarActionTapGestureRecognizer != null)
            {
                NavBarActionButton.GestureRecognizers.Remove(_navBarActionTapGestureRecognizer);
                _navBarActionTapGestureRecognizer = null;
            }

            base.OnDisappearing();
        }

        private void HamburgerButton_Tapped(object sender, EventArgs e)
        {
            if (Application.Current.MainPage is MasterDetailPage masterDetailPage)
            {
                masterDetailPage.IsPresented = true;
            }
        }
    }

    public class BasePage<TViewModel> : BasePage where TViewModel : class, IMvxViewModel
    {
        public static new readonly BindableProperty ViewModelProperty = BindableProperty.Create(nameof(ViewModel), typeof(TViewModel), typeof(IMvxElement<TViewModel>), default(TViewModel), BindingMode.Default, null, ViewModelChanged, null, null);

        public new TViewModel ViewModel
        {
            get => (TViewModel)base.ViewModel;
            set => base.ViewModel = value;
        }

        internal static void ViewModelChanged(BindableObject bindable, object oldvalue, object newvalue)
        {
            if (newvalue != null)
            {
                if (bindable is IMvxElement element)
                    element.DataContext = newvalue;
                else
                    bindable.BindingContext = newvalue;
            }
        }
    }
}