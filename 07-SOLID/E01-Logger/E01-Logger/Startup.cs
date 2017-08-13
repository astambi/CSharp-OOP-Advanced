using E01_Logger.Enums;
using E01_Logger.Interfaces;
using E01_Logger.Models;
using E01_Logger.Models.Appenders;
using E01_Logger.Models.Layouts;
using System;
using System.Collections.Generic;

namespace E01_Logger
{
    public class Startup
    {
        public static void Main()
        {
            LibraryArchitecture();
            Implementation();
            Extensibility();
            ReportThreshold();

            //Controller();
        }

        private static void Controller()
        {
            // TODO

            List<IAppender> appenders = new List<IAppender>();

            int appenderCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < appenderCount; i++)
            {

            }
        }

        private static void ReportThreshold()
        {
            var simpleLayout = new SimpleLayout();
            var consoleAppender = new ConsoleAppender(simpleLayout);
            consoleAppender.ReportLevel = ReportLevel.Error;

            var logger = new Logger(consoleAppender);

            logger.Info("3/31/2015 5:33:07 PM", "Everything seems fine");
            logger.Warning("3/31/2015 5:33:07 PM", "Warning: ping is too high - disconnect imminent");
            logger.Error("3/31/2015 5:33:07 PM", "Error parsing request");
            logger.Critical("3/31/2015 5:33:07 PM", "No connection string found in App.config");
            logger.Fatal("3/31/2015 5:33:07 PM", "mscorlib.dll does not respond");
        }

        private static void Extensibility()
        {
            var xmlLayout = new XmlLayout();
            var consoleAppender = new ConsoleAppender(xmlLayout);
            var logger = new Logger(consoleAppender);

            logger.Fatal("3/31/2015 5:23:54 PM", "mscorlib.dll does not respond");
            logger.Critical("3/31/2015 5:23:54 PM", "No connection string found in App.config");
        }

        private static void Implementation()
        {
            var simpleLayout = new SimpleLayout();
            var consoleAppender = new ConsoleAppender(simpleLayout);

            var file = new LogFile();
            var fileAppender = new FileAppender(simpleLayout);
            fileAppender.File = file;

            var logger = new Logger(consoleAppender, fileAppender);
            logger.Error("3/26/2015 2:08:11 PM", "Error parsing JSON.");
            logger.Info("3/26/2015 2:08:11 PM", "User Pesho successfully registered.");
        }

        private static void LibraryArchitecture()
        {
            ILayout simpleLayout = new SimpleLayout();
            IAppender consoleAppender = new ConsoleAppender(simpleLayout);
            ILogger logger = new Logger(consoleAppender);

            logger.Error("3/26/2015 2:08:11 PM", "Error parsing JSON.");
            logger.Info("3/26/2015 2:08:11 PM", "User Pesho successfully registered.");
        }
    }
}