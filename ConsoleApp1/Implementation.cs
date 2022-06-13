using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonePattern
{
    /// <summary>
    /// Singleton pattern representation class
    /// </summary>
    public class Logger
    {
        private static readonly Lazy<Logger> _lazyLogger 
            = new(() => new Logger());

        public static Logger Instance
        {
            get
            {
                return _lazyLogger.Value;
            }
        }

        protected Logger()
        {

        }

        public void Log(string message) => Console.WriteLine($"Message to log: {message}");
    }
}
