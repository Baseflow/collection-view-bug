using Xamarin.Forms;

namespace MyXamarinFormsApp.UI.Controls
{
    public class Divider : BoxView
    {
        public static readonly BindableProperty OrientationProperty = BindableProperty.Create(nameof(Orientation), typeof(DividerOrientation), typeof(Divider), DividerOrientation.Horizontal, propertyChanged: OnOrientationPropertyChanged);
        public DividerOrientation Orientation
        {
            get => (DividerOrientation)GetValue(OrientationProperty);
            set => SetValue(OrientationProperty, value);
        }

        private static void OnOrientationPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (!(bindable is Divider control) || !(newValue is DividerOrientation orientation))
                return;

            if (orientation == DividerOrientation.Horizontal)
            {
                control.HeightRequest = 1;
                control.HorizontalOptions = LayoutOptions.FillAndExpand;
            }
            else
            {
                control.WidthRequest = 1;
                control.VerticalOptions = LayoutOptions.FillAndExpand;
            }
        }

        public Divider()
        {
            OnOrientationPropertyChanged(this, Orientation, Orientation);
        }
    }

    public enum DividerOrientation
    {
        Horizontal,
        Vertical
    }
}
