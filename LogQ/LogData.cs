using System;
using System.Collections.Generic;

namespace CanadianBrewer.Utilities
{
    public class LogData
    {
        public string Assembly { get; set; }
        public string Class { get; set; }
        public string Method { get; set; }
        public string Message { get; set; }
        public string Exception { get; set; }
        public string StackTrace { get; set; }
        public Dictionary<string, object> Params { get; set; } = new Dictionary<string, object>();
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
