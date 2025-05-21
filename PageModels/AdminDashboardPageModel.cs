using CommunityToolkit.Mvvm.ComponentModel;
using SchoolClassCompass.Models;
using SchoolClassCompass.Services;
using System.Collections.ObjectModel;
using System.Linq;

namespace SchoolClassCompass.PageModels
{
    public partial class AdminDashboardPageModel : ObservableObject
    {
        [ObservableProperty]
        private string schoolName = string.Empty;

        [ObservableProperty]
        private ObservableCollection<Teacher> teachers = new();

        [ObservableProperty]
        private ObservableCollection<Student> students = new();

        [ObservableProperty]
        private string tempLoginsDisplay = string.Empty;

        public AdminDashboardPageModel()
        {
            var school = AppData.School;

            if (school != null)
            {
                SchoolName = school.Name ?? "Unknown School";

                if (school.Teachers != null)
                    Teachers = new ObservableCollection<Teacher>(school.Teachers);

                if (school.Students != null)
                    Students = new ObservableCollection<Student>(school.Students);

                var teacherLogins = school.Teachers?
                    .Select(t => $"{t.Name}: {t.Username}/{t.Password}") ?? Enumerable.Empty<string>();

                var studentLogins = school.Students?
                    .Select(s => $"{s.Name}: {s.Username}/{s.Password}") ?? Enumerable.Empty<string>();

                TempLoginsDisplay = $"Teachers:\n{string.Join("\n", teacherLogins)}\n\nStudents:\n{string.Join("\n", studentLogins)}";
            }
        }
    }
}
