using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SchoolClassCompass.Models;
using SchoolClassCompass.Data;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Linq;

namespace SchoolClassCompass.PageModels
{
    public partial class MainPageModel : ObservableObject
    {
        private readonly TaskRepository taskRepository = new();

        [ObservableProperty]
        private ObservableCollection<ProjectTask> tasks = new();

        public MainPageModel()
        {
            LoadTasksAsync();
        }

        private async void LoadTasksAsync()
        {
            var taskItems = await taskRepository.ListAsync();
            Tasks = new ObservableCollection<ProjectTask>(taskItems.Select(ToProjectTask));
        }

        [RelayCommand]
        private async Task SaveTask(ProjectTask task)
        {
            var item = ToTaskItem(task);
            await taskRepository.SaveItemAsync(item);
            LoadTasksAsync();
        }

        [RelayCommand]
        private async Task DeleteTask(ProjectTask task)
        {
            var item = ToTaskItem(task);
            await taskRepository.DeleteItemAsync(item);
            LoadTasksAsync();
        }

        // Conversion helpers
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