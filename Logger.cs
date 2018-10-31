using log4net.Core;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using log4net.Repository;
using log4net.Config;
using System.IO;

namespace dystopia_sharp
{
    public class Logger
    {
        static readonly Assembly entryAssembly = Assembly.GetEntryAssembly();
        ILog logger;
        Logger(string name)
        {
            logger = LogManager.GetLogger(entryAssembly, name);
        }

        public static void Init()
        {
            XmlConfigurator.Configure(LogManager.GetRepository(entryAssembly), new FileInfo("log4net.config"));
        }

        public static Logger Create<T>()
        {
            return new Logger(typeof(T).Name);
        }

        public static Logger Create(string name)
        {
            return new Logger(name);
        }

        public void Debug(string message)
        {
            logger.Debug(message);
        }
        public void Info(string message)
        {
            logger.Info(message);
        }
        public void Warn(string message)
        {
            logger.Warn(message);
        }
        public void Error(string message)
        {
            logger.Error(message);
        }
    }
}
