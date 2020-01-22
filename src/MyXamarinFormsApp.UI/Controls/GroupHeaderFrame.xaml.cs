using Xamarin.Forms;

namespace MyXamarinFormsApp.UI.Controls
{
    public partial class GroupHeaderFrame : Frame
    {
        public static readonly BindableProperty TextProperty = BindableProperty.Create(nameof(Text), typeof(string), typeof(GroupHeaderFrame), null, propertyChanged: TextChanged);

        public string Text
        {
            get => (string)GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }

        private static void TextChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (!(bindable is GroupHeaderFrame control) || !(newValue is string text))
                return;

            SetLabel(control, text);
        }

        public static readonly BindableProperty IsRequiredProperty = BindableProperty.Create(nameof(IsRequired), typeof(bool), typeof(GroupHeaderFrame), false, propertyChanged: IsRequiredChanged);

        public bool IsRequired
        {
            get => (bool)GetValue(IsRequiredProperty);
            set => SetValue(IsRequiredProperty, value);
        }

        private static void IsRequiredChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (!(bindable is GroupHeaderFrame control) || !(newValue is bool isRequired))
                return;

            control.IsRequired = isRequired;
        }

        private static void SetLabel(GroupHeaderFrame control, string text)
        {
            var formattedText = new FormattedString();
            if (!string.IsNullOrWhiteSpace(text))
            {
                var style = Application.Current.Resources["GroupHeaderLabelStyle"] as Style;
                formattedText.Spans.Add(new Span { Text = text, Style = style });
            }
            if (control.IsRequired)
            {
                var style = Application.Current.Resources["RequiredStarSpanStyle"] as Style;
                formattedText.Spans.Add(new Span { Text = "*", Style = style });
            }

            control.Label.FormattedText = formattedText;
        }

        public GroupHeaderFrame()
        {
            InitializeComponent();
        }
    }
}