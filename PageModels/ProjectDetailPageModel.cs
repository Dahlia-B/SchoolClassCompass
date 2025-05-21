using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SchoolClassCompass.Models;
using SchoolClassCompass.Data;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolClassCompass.PageModels
{
    public partial class ProjectDetailPageModel : ObservableObject
    {
        private readonly TaskRepository taskRepository = new();

        [ObservableProperty]
        private ObservableCollection<ProjectTask> tasks = new();

        // ... other properties omitted for brevity ...

        [RelayCommand]
        private async Task LoadTasksAsync()
        {
            var taskItems = await taskRepository.ListAsync();
            Tasks = new ObservableCollection<ProjectTask>(taskItems.Select(ToProjectTask));
        }

        [RelayCommand]
        private async Task SaveTask(ProjectTask task)
        {
            await taskRepository.SaveItemAsync(ToTaskItem(task));
            await LoadTasksAsync();
        }

        [RelayCommand]
        private async Task DeleteTask(ProjectTask task)
        {
            await taskRepository.DeleteItemAsync(ToTaskItem(task));
            await LoadTasksAsync();
        }

        private static TaskItem ToTaskItem(ProjectTask pt) =>
            new TaskItem
            {
                Id = pt.Id,
                ProjectID = pt.ProjectID,
                Title = pt.Title,
                Description = pt.Description,
                IsCompleted = pt.IsCompleted
            };

        private static ProjectTask ToProjectTask(TaskItem ti) =>
            new ProjectTask
            {
                Id = ti.Id,
                ProjectID = ti.ProjectID,
                Title = ti.Title,
                Description = ti.Description,
                IsCompleted = ti.IsCompleted
            };
    }
}