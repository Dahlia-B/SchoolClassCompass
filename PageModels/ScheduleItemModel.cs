using System;

namespace SchoolClassCompass.PageModels
{
    public class ScheduleItemModel
    {
        public required string Title { get; set; }
        public required string Time { get; set; }

        // Alternatively, you could use this constructor approach:
        /*
        public string Title { get; set; } = string.Empty;
        public string Time { get; set; } = string.Empty;
        
        public ScheduleItemModel()
        {
            // Default constructor with initialized properties
        }
        
        public ScheduleItemModel(string title, string time)
        {
            Title = title;
            Time = time;
        }
        */
    }
}