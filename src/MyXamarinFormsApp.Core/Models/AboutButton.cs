using MvvmCross.Commands;

namespace MyXamarinFormsApp.Core.Models
{
    public class AboutButton
    {
        public string CommandIconSource { get; set; }
        public string CommandText { get; set; }
        public IMvxCommand Command { get; set; }
    }
}