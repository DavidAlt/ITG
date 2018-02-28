using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ITG.Desktop.Services
{
    public class LogService
    {
        private StringBuilder log;
        
        public LogService()
        {
            log = new StringBuilder();
        }

        public void Log(string line)
        {
            log.AppendLine(line);
        }

        public string ReadLog()
        {
            return log.ToString();
        }

        public void Reset()
        {
            log.Clear();
        }

        public void SaveToFile(string filename)
        {
            using (StreamWriter sw = new StreamWriter(filename))
            {
                sw.Write(log.ToString());
            }
        }

        public override string ToString()
        {
            return ReadLog();
        }
    }

}
