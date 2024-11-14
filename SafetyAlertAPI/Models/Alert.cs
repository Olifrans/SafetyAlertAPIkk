using System;

namespace SafetyAlertAPI.Models
{
    public class Alert
    {
        public int Id { get; set; }
        public DateTime TimeStamp { get; set; }
        public string? Location { get; set; }
        public string? AudioFilePath { get; set; }
        public string? VideoFilePath { get; set; }
    }
}
