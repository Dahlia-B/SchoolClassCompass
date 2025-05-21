using SchoolClassCompass.Models;

namespace SchoolClassCompass.Services;

public static class AppData
{
    public static School School { get; set; } = new();
    public static List<Homework> Homeworks { get; set; } = new();
    public static List<BehaviorIncident> BehaviorIncidents { get; set; } = new();
    public static object? CurrentUser { get; set; }
}