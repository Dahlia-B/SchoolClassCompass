using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;

namespace SchoolClassCompass.PageModels
{
    public partial class TeacherDashboardPageModel : ObservableObject
    {
        // Fix for [ObservableProperty] warning MVVMTK0045
        private ObservableCollection<ClassModel> _classes = new();
        public ObservableCollection<ClassModel> Classes
        {
            get => _classes;
            set => SetProperty(ref _classes, value);
        }

        public TeacherDashboardPageModel()
        {
            // Initialize with sample data
            Classes = new ObservableCollection<ClassModel>();
            InitializeData();
        }

        private void InitializeData()
        {
            // Add null check to prevent dereference of possibly null reference
            var class1 = new ClassModel { Name = "Mathematics 101" };
            if (class1.Students != null) // Fix for CS8602 warning
            {
                class1.Students.Add(new StudentModel { Name = "John Doe" });
                class1.Students.Add(new StudentModel { Name = "Jane Smith" });
            }
            else
            {
                class1.Students = new ObservableCollection<StudentModel>
                {
                    new StudentModel { Name = "John Doe" },
                    new StudentModel { Name = "Jane Smith" }
                };
            }

            Classes.Add(class1);

            var class2 = new ClassModel { Name = "Science 202" };
            if (class2.Students != null) // Fix for CS8602 warning
            {
                class2.Students.Add(new StudentModel { Name = "Mike Johnson" });
                class2.Students.Add(new StudentModel { Name = "Lisa Brown" });
            }
            else
            {
                class2.Students = new ObservableCollection<StudentModel>
                {
                    new StudentModel { Name = "Mike Johnson" },
                    new StudentModel { Name = "Lisa Brown" }
                };
            }

            Classes.Add(class2);
        }
    }

    // Supporting model classes (if not defined elsewhere)
    public class ClassModel
    {
        public string Name { get; set; } = string.Empty;
        public ObservableCollection<StudentModel> Students { get; set; } = new();
    }

    public class StudentModel
    {
        public string Name { get; set; } = string.Empty;
    }
}