using Serilog;
using Serilog.Sinks.SystemConsole.Themes;
using System;

namespace SerilogConsoleApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            MyLogger.CreateLogger();
            Log.ForContext("SourceContext", "Main").Information("Start");
            TestLoger logerTest = new TestLoger();


            Log.CloseAndFlush();
            Console.ReadKey();
        }
    }

    public static class MyLogger
    {
        public static void CreateLogger()
        {
            string logTemplate = "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u}] [{SourceContext}] {Message}{NewLine}{Exception}";
            var dateTime = DateTime.Now;
            string dateString = dateTime.ToString("dd-MM-yyyy");

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Information()
                .WriteTo.Console(theme: AnsiConsoleTheme.Code, outputTemplate: logTemplate)
                .WriteTo.File($"log-{dateString}.txt", outputTemplate: logTemplate)
                // .WriteTo.LiterateConsole()
                .WriteTo.Seq("http://localhost:5341")
                .CreateLogger();
        }
    }

    class TestLoger
    {
        public TestLoger()
        {
            Log.ForContext("SourceContext", typeof(TestLoger).Name).Information("Wirte log Information level 1");
            // Verbose and Debug hidden
            Log.ForContext("SourceContext", typeof(TestLoger).Name).Verbose("wirte log Verbose level 2");
            Log.ForContext("SourceContext", typeof(TestLoger).Name).Debug("wirte log Debug level 3");

            Log.ForContext("SourceContext", typeof(TestLoger).Name).Warning("wirte log Warning level 4");
            Log.ForContext("SourceContext", typeof(TestLoger).Name).Error("wirte log Error level 5");
            Log.ForContext("SourceContext", typeof(TestLoger).Name).Fatal("wirte log Fatal level 6");

        }
    }
}
