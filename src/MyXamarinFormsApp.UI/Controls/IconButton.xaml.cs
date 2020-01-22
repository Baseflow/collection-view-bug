using System;
using MvvmCross.Commands;
using Xamarin.Forms;

namespace MyXamarinFormsApp.UI.Controls
{
    public partial class IconButton : Frame
    {
        public static readonly BindableProperty CommandProperty = BindableProperty.Create(nameof(Command), typeof(IMvxCommand), typeof(IconButton), null);

        public IMvxCommand Command
        {
            get => (IMvxCommand)GetValue(CommandProperty);
            set => SetValue(CommandProperty, value);
        }

        public static readonly BindableProperty CommandParameterProperty = BindableProperty.Create(nameof(CommandParameter), typeof(object), typeof(IconButton), null);

        public object CommandParameter
        {
            get => GetValue(CommandParameterProperty);
            set => SetValue(CommandParameterProperty, value);
        }

        public static readonly BindableProperty TextProperty = BindableProperty.Create(nameof(Text), typeof(string), typeof(IconButton), null);

        public string Text
        {
            get => (string)GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }

        public static readonly BindableProperty TextColorProperty = BindableProperty.Create(nameof(TextColor), typeof(Color), typeof(IconButton), Color.Default);

        public Color TextColor
        {
            get => (Color)GetValue(TextColorProperty);
            set => SetValue(TextColorProperty, value);
        }

        public static readonly BindableProperty FontFamilyProperty = BindableProperty.Create(nameof(FontFamily), typeof(string), typeof(IconButton), null);

        public string FontFamily
        {
            get => (string)GetValue(FontFamilyProperty);
            set => SetValue(FontFamilyProperty, value);
        }

        public static readonly BindableProperty FontSizeProperty = BindableProperty.Create(nameof(FontSize), typeof(double), typeof(IconButton), default(double));

        public double FontSize
        {
            get => (double)GetValue(FontSizeProperty);
            set => SetValue(FontSizeProperty, value);
        }

        public static readonly BindableProperty IconPositionProperty = BindableProperty.Create(nameof(IconPosition), typeof(IconPositions), typeof(IconButton), IconPositions.Left);

        public IconPositions IconPosition
        {
            get => (IconPositions)GetValue(IconPositionProperty);
            set => SetValue(IconPositionProperty, value);
        }

        public static readonly BindableProperty SpacingProperty = BindableProperty.Create(nameof(Spacing), typeof(double), typeof(IconButton), default(double));

        public double Spacing
        {

            get => (double)GetValue(SpacingProperty);
            set => SetValue(SpacingProperty, value);
        }

        public static readonly BindableProperty IconSourceProperty = BindableProperty.Create(nameof(IconSource), typeof(string), typeof(IconButton), null);

        public string IconSource
        {
            get => (string)GetValue(IconSourceProperty);
            set => SetValue(IconSourceProperty, value);
        }

        public static readonly BindableProperty IconColorProperty = BindableProperty.Create(nameof(IconColor), typeof(Color), typeof(IconButton), Color.Default);

        public Color IconColor
        {
            get => (Color)GetValue(IconColorProperty);
            set => SetValue(IconColorProperty, value);
        }

        public static readonly BindableProperty IconSizeProperty = BindableProperty.Create(nameof(IconSize), typeof(double), typeof(IconButton), default(double));

        public double IconSize
        {
            get => (double)GetValue(IconSizeProperty);
            set => SetValue(IconSizeProperty, value);
        }

        public static readonly BindableProperty IsChipProperty = BindableProperty.Create(nameof(IsChip), typeof(bool), typeof(IconButton), default(bool), propertyChanged: IsChipPropertyChanged);

        public bool IsChip
        {
            get => (bool)GetValue(IsChipProperty);
            set => SetValue(IsChipProperty, value);
        }

        private static void IsChipPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (!(bindable is IconButton control))
                return;

            control.RecalculateCornerRadius(control.Height);
        }

        public IconButton()
        {
            InitializeComponent();
        }

        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);

            RecalculateCornerRadius(height);
        }

        private void RecalculateCornerRadius(double height)
        {
            if (IsChip && height > 0)
                CornerRadius = (float)height / 2;
        }
    }

    public enum IconPositions
    {
        Left,
        Right
    }
}