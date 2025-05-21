﻿namespace SchoolClassCompass.Data
{
    public class TaskItem
    {
        public int Id { get; set; }
        public int ProjectID { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public bool IsCompleted { get; set; }
    }
}