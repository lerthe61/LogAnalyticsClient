using System;

namespace LogAnalyticsClient
{
    public class LogSearchQuery
    {
        public string Query { get; set; }
        public int Top { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
    }
}