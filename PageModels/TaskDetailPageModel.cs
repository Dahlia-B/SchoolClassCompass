using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SchoolClassCompass.Data;
using SchoolClassCompass.Models;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolClassCompass.PageModels
{
    public partial class TaskDetailPageModel : ObservableObject
    {
        public static string ProjectQueryKey => "project";

        [ObservableProperty]
        private string title = string.Empty;

        [ObservableProperty]
        private string description = string.Empty;

        [ObservableProperty]
        private bool isCompleted;

        [ObservableProperty]
        private bool isExistingProject;

        [ObservableProperty]
        private ObservableCollection<string> projects = new();

        [ObservableProperty]
        private string project = string.Empty;

        [ObservableProperty]
        private int selectedProjectIndex;

        private readonly TaskRepository taskRepository = new();

        public TaskDetailPageModel()
        {
            Projects = new ObservableCollection<string> { "Math", "Science", "History" };
            Project = Projects.FirstOrDefault() ?? string.Empty;
        }

        [RelayCommand]
        private async Task Save()
        {
            if (string.IsNullOrWhiteSpace(Title))
            {
                Debug.WriteLine("Title is required.");
                return;
            }

            var taskItem = new TaskItem
            {
                Title = Title,
                Description = Description,
                IsCompleted = IsCompleted,
                ProjectID = 0 // Set appropriately if you have real Project IDs
            };

            await taskRepository.SaveItemAsync(taskItem);
            IsExistingProject = true;
            Debug.WriteLine($"Saved task: {taskItem.Title}");
        }

        [RelayCommand]
        private async Task Delete()
        {
            if (!IsExistingProject)
            {
                Debug.WriteLine("No task to delete.");
                return;
            }

            var allTasks = await taskRepository.ListAsync();
            var taskItem = allTasks.FirstOrDefault(t => t.Title.Equals(Title, System.StringComparison.OrdinalIgnoreCase));
            if (taskItem != null)
            {
                await taskRepository.DeleteItemAsync(taskItem);
                Debug.WriteLine($"Deleted task: {taskItem.Title}");

                // Optionally clear form
                Title = string.Empty;
                Description = string.Empty;
                IsCompleted = false;
                Project = Projects.FirstOrDefault() ?? string.Empty;
                IsExistingProject = false;
            }
            else
            {
                Debug.WriteLine("Task not found.");
            }
        }
    }
}