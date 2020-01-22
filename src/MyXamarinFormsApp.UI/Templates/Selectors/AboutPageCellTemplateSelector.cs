using MyXamarinFormsApp.Core.Models;
using Xamarin.Forms;

namespace MyXamarinFormsApp.UI.Templates.Selectors
{
    public class AboutPageCellTemplateSelector : DataTemplateSelector
    {
        public DataTemplate TextTemplate { get; set; }
        public DataTemplate ButtonTemplate { get; set; }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            return item is AboutText ? TextTemplate : ButtonTemplate;
        }
    }
}