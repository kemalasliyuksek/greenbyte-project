using System;

namespace GreenByte.Models
{
    public enum LogType
    {
        Info,
        Error
    }

    public class LogModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public LogType LogType { get; set; }
        public string Message { get; set; }
        public DateTime LogTime { get; set; }
    }
}