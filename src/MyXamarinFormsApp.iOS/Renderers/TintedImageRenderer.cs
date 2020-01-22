using System.ComponentModel;
using MyXamarinFormsApp.iOS.Renderers;
using MyXamarinFormsApp.UI.Controls;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(TintedImage), typeof(TintedImageRenderer))]
namespace MyXamarinFormsApp.iOS.Renderers
{
    public class TintedImageRenderer : ImageRenderer
    {
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

            if (!(Element is TintedImage element))
                return;

            if (e.PropertyName == TintedImage.TintColorProperty.PropertyName || e.PropertyName == Image.SourceProperty.PropertyName)
                SetTint(element);
        }

        private void SetTint(TintedImage element)
        {
            if (Control?.Image == null || element == null)
                return;

            if (element.TintColor == Color.Transparent)
            {
                Control.Image = Control.Image?.ImageWithRenderingMode(UIImageRenderingMode.Automatic);
                Control.TintColor = null;
            }
            else
            {
                Control.Image = Control.Image?.ImageWithRenderingMode(UIImageRenderingMode.AlwaysTemplate);
                Control.TintColor = element.TintColor.ToUIColor();
            }
        }
    }
}