using Xamarin.Forms;

namespace MyXamarinFormsApp.UI.Controls
{
    public partial class IconLabel : StackLayout
    {
        public IconLabel()
        {
            InitializeComponent();

            Label.IsVisible = false;
            ImageLeft.IsVisible = false;
            ImageRight.IsVisible = false;
        }

        public static readonly BindableProperty TextProperty = BindableProperty.Create(nameof(Text), typeof(string), typeof(IconLabel), null, propertyChanged: TextPropertyChanged);

        public string Text
        {
            get => (string)GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }

        private static void TextPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (!(bindable is IconLabel control) || !(newValue is string text))
                return;

            control.Label.IsVisible = !string.IsNullOrWhiteSpace(text);
        }

        public static readonly BindableProperty TextColorProperty = BindableProperty.Create(nameof(TextColor), typeof(Color), typeof(IconLabel), Color.Default);

        public Color TextColor
        {
            get => (Color)GetValue(TextColorProperty);
            set => SetValue(TextColorProperty, value);
        }

        public static readonly BindableProperty FontFamilyProperty = BindableProperty.Create(nameof(FontFamily), typeof(string), typeof(IconLabel), null);

        public string FontFamily
        {
            get => (string)GetValue(FontFamilyProperty);
            set => SetValue(FontFamilyProperty, value);
        }

        public static readonly BindableProperty FontSizeProperty = BindableProperty.Create(nameof(FontSize), typeof(double), typeof(IconLabel), default(double));

        public double FontSize
        {
            get => (double)GetValue(FontSizeProperty);
            set => SetValue(FontSizeProperty, value);
        }

        public static readonly BindableProperty IconPositionProperty = BindableProperty.Create(nameof(IconPosition), typeof(IconPositions), typeof(IconButton), IconPositions.Left, propertyChanged: IconPositionPropertyChanged);

        public IconPositions IconPosition
        {
            get => (IconPositions)GetValue(IconPositionProperty);
            set => SetValue(IconPositionProperty, value);
        }

        private static void IconPositionPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (!(bindable is IconLabel control) || !(newValue is IconPositions iconPosition))
                return;

            control.ImageLeft.IsVisible = iconPosition == IconPositions.Left;
            control.ImageRight.IsVisible = iconPosition == IconPositions.Right;
        }

        public static readonly BindableProperty IconSourceProperty = BindableProperty.Create(nameof(IconSource), typeof(string), typeof(IconLabel), null, propertyChanged: IconSourcePropertyChanged);

        public string IconSource
        {
            get => (string)GetValue(IconSourceProperty);
            set => SetValue(IconSourceProperty, value);
        }

        private static void IconSourcePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (!(bindable is IconLabel control) || !(newValue is string iconSource))
                return;

            control.ImageLeft.IsVisible = !string.IsNullOrWhiteSpace(iconSource) && control.IconPosition == IconPositions.Left;
            control.ImageRight.IsVisible = !string.IsNullOrWhiteSpace(iconSource) && control.IconPosition == IconPositions.Right;
        }

        public static readonly BindableProperty IconColorProperty = BindableProperty.Create(nameof(IconColor), typeof(Color), typeof(IconLabel), Color.Default);

        public Color IconColor
        {
            get => (Color)GetValue(IconColorProperty);
            set => SetValue(IconColorProperty, value);
        }

        public static readonly BindableProperty IconSizeProperty = BindableProperty.Create(nameof(IconSize), typeof(double), typeof(IconLabel), default(double));

        public double IconSize
        {
            get => (double)GetValue(IconSizeProperty);
            set => SetValue(IconSizeProperty, value);
        }

        public static readonly BindableProperty IconVerticalOptionsProperty = BindableProperty.Create(nameof(IconVerticalOptions), typeof(LayoutOptions), typeof(IconLabel), LayoutOptions.Center);

        public LayoutOptions IconVerticalOptions
        {
            get => (LayoutOptions)GetValue(IconVerticalOptionsProperty);
            set => SetValue(IconVerticalOptionsProperty, value);
        }
    }
}
