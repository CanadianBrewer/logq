using System;
using System.Collections.Generic;
using CanadianBrewer.Utilities;

namespace CanadianBrewer
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var logQ = new LogQ(10);

            for (var i = 0; i < 15; i++)
            {
                LogData logData = new LogData()
                {
                    Assembly = $"assembly+{i}",
                    Class = $"class+{i}",
                    CreatedBy = $"createdBy+{i}",
                    CreatedOn = DateTime.UtcNow,
                    Exception = $"exception+{i}",
                    Message = $"message+{i}",
                    Method = $"method+{i}",
                    StackTrace = $"stacktrace+{i}"
                };
                
                var p = new Dictionary<string, object>();
                p.Add("a", 1);
                p.Add("b", true);
                p.Add("c", DateTime.UtcNow);

                logData.Params = p;
                
                var s = Newtonsoft.Json.JsonConvert.SerializeObject(logData);
                System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
                sw.Start();
                logQ.AddItem(logData);
                sw.Stop();
                Console.WriteLine($"{sw.ElapsedMilliseconds} to add...");
            }

            System.Threading.Thread.Sleep(1000);
            Console.WriteLine("Done");
            Console.ReadLine();
        }
    }
}