using System.ComponentModel;
using Android.Content;
using Android.Graphics;
using MyXamarinFormsApp.Droid.Renderers;
using MyXamarinFormsApp.UI.Controls;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(TintedImage), typeof(TintedImageRenderer))]
namespace MyXamarinFormsApp.Droid.Renderers
{
    public class TintedImageRenderer : ImageRenderer
    {
        public TintedImageRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Image> e)
        {
            base.OnElementChanged(e);

            if (!(e.NewElement is TintedImage element))
                return;

            SetTint(element);
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (Control == null || !(Element is TintedImage element))
                return;

            if (e.PropertyName == TintedImage.TintColorProperty.PropertyName || e.PropertyName == Image.SourceProperty.PropertyName)
                SetTint(element);
        }

        private void SetTint(TintedImage element)
        {
            if (element.TintColor.Equals(Xamarin.Forms.Color.Transparent))
            {
                if (Control.ColorFilter != null)
                    Control.ClearColorFilter();

                return;
            }

            var colorFilter = new PorterDuffColorFilter(element.TintColor.ToAndroid(), PorterDuff.Mode.SrcIn);
            Control.SetColorFilter(colorFilter);
        }
    }
}