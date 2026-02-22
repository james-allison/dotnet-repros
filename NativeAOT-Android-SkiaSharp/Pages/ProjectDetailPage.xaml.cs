using NativeAOT_Android_SkiaSharp.Models;

namespace NativeAOT_Android_SkiaSharp.Pages
{
    public partial class ProjectDetailPage : ContentPage
    {
        public ProjectDetailPage(ProjectDetailPageModel model)
        {
            InitializeComponent();

            BindingContext = model;
        }
    }
}
