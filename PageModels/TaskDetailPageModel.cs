using CommunityToolkit.Mvvm.ComponentModel;

namespace SchoolClassCompass.PageModels
{
    public partial class TaskDetailPageModel : ObservableObject
    {
        // Add this line:
        public static string ProjectQueryKey => "project";

        private string _title = string.Empty;
        private string _description = string.Empty;


        public TaskDetailPageModel()
        {
            // Initialization logic here if needed
        }
    }
}