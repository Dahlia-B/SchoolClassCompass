using System;
using System.Collections.ObjectModel;
using System.Linq;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SchoolClassCompass.Models; // Ensure these classes exist and are properly defined

namespace SchoolClassCompass.PageModels
{
    public partial class AdminSignupPageModel : ObservableObject
    {
        [ObservableProperty]
        private string schoolName = string.Empty;

        [ObservableProperty]
        private bool signupComplete;

        [ObservableProperty]
        private string tempLoginsDisplay = string.Empty;

        [ObservableProperty]
        private ObservableCollection<Class> classes = new();

        [ObservableProperty]
        private ObservableCollection<Teacher> teachers = new();

        [ObservableProperty]
        private ObservableCollection<Student> students = new();

        public AdminSignupPageModel()
        {
            // Collections already initialized by [ObservableProperty]
        }

        [RelayCommand]
        private void AddClass(string className)
        {
            if (!string.IsNullOrWhiteSpace(className))
            {
                Classes.Add(new Class { Name = className });
            }
        }

        [RelayCommand]
        private void AddTeacher(string teacherName)
        {
            if (!string.IsNullOrWhiteSpace(teacherName))
            {
                Teachers.Add(new Teacher { Name = teacherName });
            }
        }

        [RelayCommand]
        private void AddStudent(string studentName)
        {
            if (!string.IsNullOrWhiteSpace(studentName))
            {
                Students.Add(new Student { Name = studentName });
            }
        }

        [RelayCommand]
        private void CompleteSignup()
        {
            if (string.IsNullOrWhiteSpace(SchoolName) || Teachers.Count == 0 || Students.Count == 0 || Classes.Count == 0)
                return;

            int userId = 1000;
            foreach (var t in Teachers)
            {
                t.Username = $"t{userId++}";
                t.Password = Guid.NewGuid().ToString("N")[..8];
            }

            userId = 2000;
            foreach (var s in Students)
            {
                s.Username = $"s{userId++}";
                s.Password = Guid.NewGuid().ToString("N")[..8];
            }

            // Round-robin assign teachers and students
            for (int i = 0; i < Classes.Count; i++)
            {
                Classes[i].Teacher = Teachers[i % Teachers.Count];
                Classes[i].Students = new List<Student>(Students); // Clone the student list
            }

            AppData.School = new School
            {
                Name = SchoolName,
                Classes = Classes.ToList(),
                Teachers = Teachers.ToList(),
                Students = Students.ToList()
            };

            TempLoginsDisplay = "Teachers:\n" + string.Join("\n", Teachers.Select(t => $"{t.Name}: {t.Username}/{t.Password}")) +
                                "\n\nStudents:\n" + string.Join("\n", Students.Select(s => $"{s.Name}: {s.Username}/{s.Password}"));
            SignupComplete = true;
        }
    }
}
