using CommunityToolkit.Mvvm.Input;
using Repro1.Models;

namespace Repro1.PageModels
{
    public interface IProjectTaskPageModel
    {
        IAsyncRelayCommand<ProjectTask> NavigateToTaskCommand { get; }
        bool IsBusy { get; }
    }
}