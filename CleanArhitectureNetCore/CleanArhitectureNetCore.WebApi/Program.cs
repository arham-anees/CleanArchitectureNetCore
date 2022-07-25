using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Events;
using System;

namespace CleanArhitectureNetCore.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {

            //Serilog configuration
            #region Serilog
            var config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: false)
            .Build();
            ExceptionLoggingPath path = new ExceptionLoggingPath();
            config.GetSection("ExceptionLoggingPath").Bind(path);
            string currentDate = $@"{ DateTime.Now.Year}\{ DateTime.Now.ToString("MMM")}\{ DateTime.Now.ToString("dd")}";
            Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Information()
            .WriteTo.Logger(c =>
                    c.Filter.ByIncludingOnly(e => e.Level == LogEventLevel.Information)
                    .WriteTo.File(string.Format(path.Activity, currentDate), rollingInterval: RollingInterval.Minute))
            .WriteTo.Logger(c =>
                    c.Filter.ByIncludingOnly(e => e.Level == LogEventLevel.Error)
                    .WriteTo.File(string.Format(path.Error, currentDate), rollingInterval: RollingInterval.Minute))
            .CreateLogger();
            #endregion
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseSerilog()
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
