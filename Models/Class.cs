// File: Models/Class.cs
using System.Collections.Generic;
using SchoolClassCompass.Models;

namespace SchoolClassCompass.Models
{
    public class Class
    {
        public string Name { get; set; } = string.Empty;
        public Teacher? Teacher { get; set; }
        public List<Student> Students { get; set; } = new();
    }
}
