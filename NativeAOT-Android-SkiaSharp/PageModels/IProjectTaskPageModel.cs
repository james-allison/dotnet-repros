using CommunityToolkit.Mvvm.Input;
using NativeAOT_Android_SkiaSharp.Models;

namespace NativeAOT_Android_SkiaSharp.PageModels
{
    public interface IProjectTaskPageModel
    {
        IAsyncRelayCommand<ProjectTask> NavigateToTaskCommand { get; }
        bool IsBusy { get; }
    }
}