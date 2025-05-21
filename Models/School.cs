namespace SchoolClassCompass.Models;

public class School
{
    public string Name { get; set; } = null!;
    public List<Class> Classes { get; set; } = new();
    public List<Teacher> Teachers { get; set; } = new();
    public List<Student> Students { get; set; } = new();
}