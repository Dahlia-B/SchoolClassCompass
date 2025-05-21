using CommunityToolkit.Mvvm.Input;
using SchoolClassCompass.Models;

namespace SchoolClassCompass.PageModels
{
    public interface IProjectTaskPageModel
    {
        IAsyncRelayCommand<ProjectTask> NavigateToTaskCommand { get; }
        bool IsBusy { get; }
    }
}