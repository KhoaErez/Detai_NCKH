using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace ql_spkh.Model
{
    internal class logError
    {
        public static void log(string errorMessage)
        {
            try
            {
                string logDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "log");
                if (!Directory.Exists(logDirectory))
                {
                    Directory.CreateDirectory(logDirectory);
                }

                string logFileName = $"error_{DateTime.Now:yyyyMMdd}.txt";
                string logFilePath = Path.Combine(logDirectory, logFileName);

                using (StreamWriter writer = new StreamWriter(logFilePath, true))
                {
                    writer.WriteLine($"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] ERROR: {errorMessage}");
                }
            }
            catch (Exception)
            {
                string logDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "log");
                if (!Directory.Exists(logDirectory))
                {
                    Directory.CreateDirectory(logDirectory);
                }

                string logFileName = $"error_{DateTime.Now:yyyyMMdd}.txt";
                string logFilePath = Path.Combine(logDirectory, logFileName);

                using (StreamWriter writer = new StreamWriter(logFilePath, true))
                {
                    writer.WriteLine($"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] ERROR: Không thể tạo file log");
                }
            }
        }
    }
}
