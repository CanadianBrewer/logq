using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace CanadianBrewer.Utilities
{
    public class LogQ
    {
        private static BlockingCollection<LogData> _logItems; 
        private static bool _taskRunning = false;

        public LogQ(int capacity)
        {
            if (_taskRunning)
            {
                return;
            }

            _taskRunning = true;
            _logItems = new BlockingCollection<LogData>(capacity);
            Task.Run(() =>
            {
                while (_logItems.IsCompleted == false)
                {
                    var logData = _logItems.Take();
                    if (logData != null)
                    {
                        PersistLogData(logData);
                    }
                }
            });
        }

        public void AddItem(LogData logData)
        {
            _logItems.Add(logData);
        }

        private void PersistLogData(LogData logData)
        {
            using (StreamWriter sw = new StreamWriter("log.txt", true))
            {
                sw.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(logData));
                sw.Flush();
            }
        }
    }

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