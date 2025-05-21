using Microsoft.Maui.Controls;
using SchoolClassCompass.PageModels;  // This imports TaskDetailPageModel

namespace SchoolClassCompass.Pages
{
    public partial class TaskDetailPage : ContentPage
    {
        public TaskDetailPage(TaskDetailPageModel model)  // Now compiler knows TaskDetailPageModel
        {
            InitializeComponent();
            BindingContext = model;
        }
    }
}
