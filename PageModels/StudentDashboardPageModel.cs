using CommunityToolkit.Mvvm.ComponentModel;
using SchoolClassCompass.Models;
using SchoolClassCompass.Services;
using System.Collections.ObjectModel;
using System.Linq; // Ensure to import the LINQ namespace

public partial class StudentDashboardPageModel : ObservableObject
{
    [ObservableProperty] private ObservableCollection<Class> classes;

    public StudentDashboardPageModel()
    {
        var student = (Student)AppData.CurrentUser!;  // Ensure that AppData.CurrentUser is cast correctly.
        Classes = new ObservableCollection<Class>(
            AppData.School.Classes.Where(c => c.Students.Any(s => s.Username == student.Username))
        );
    }
}
