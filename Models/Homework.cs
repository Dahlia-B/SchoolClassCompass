namespace SchoolClassCompass.Models;

public class Homework
{
    public string Description { get; set; } = null!;
    public DateTime DueDate { get; set; }
    public double? Grade { get; set; }
    public bool IsComplete { get; set; }
}