using Serilog;
using Serilog.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multitaschenrechner
{
    public class Logging
    {
        static public Logger logger = new LoggerConfiguration()
            .WriteTo.File("log-.txt", rollingInterval:
            RollingInterval.Day, retainedFileCountLimit: 7).CreateLogger();
    }
}
