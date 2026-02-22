using NativeAOT_Android_SkiaSharp.Models;
using NativeAOT_Android_SkiaSharp.PageModels;

namespace NativeAOT_Android_SkiaSharp.Pages
{
    public partial class MainPage : ContentPage
    {
        public MainPage(MainPageModel model)
        {
            InitializeComponent();
            BindingContext = model;
        }
    }
}