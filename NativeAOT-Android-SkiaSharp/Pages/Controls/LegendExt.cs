using Syncfusion.Maui.Toolkit.Charts;

namespace NativeAOT_Android_SkiaSharp.Pages.Controls
{
    public class LegendExt : ChartLegend
    {
        protected override double GetMaximumSizeCoefficient()
        {
            return 0.5;
        }
    }
}
