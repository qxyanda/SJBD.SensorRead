using System;
using log4net;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SensorRead
{
    public static class Log
    {

        private static ILog _log = LogManager.GetLogger("TicketFace");

        public static void Info(string message)
        {
            System.Diagnostics.Debug.WriteLine($"{DateTime.Now.ToString()}:{message}");
            _log.Info(message);
        }
        public static void Error(string message, string location)
        {
            System.Diagnostics.Debug.WriteLine($"{DateTime.Now.ToString()}:{message}  location at {location}");
            _log.Error($"message  LocationAt {location}");
        }
    }
}
