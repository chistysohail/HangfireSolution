using Hangfire;
using Hangfire.SqlServer;
using HangfireJobs;
using System;

namespace HangfireClient
{
    class Program
    {
        static void Main(string[] args)
        {
            GlobalConfiguration.Configuration
                .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
                .UseSimpleAssemblyNameTypeSerializer()
                .UseRecommendedSerializerSettings()
                .UseSqlServerStorage("Server=(localdb)\\mssqllocaldb;Database=HangfireDemo;Trusted_Connection=True;");

            // Schedule a background job to run immediately
            BackgroundJob.Enqueue(() => JobMethods.ImmediateJob());

            // Schedule a background job to run after a delay
            BackgroundJob.Schedule(() => JobMethods.DelayedJob(), TimeSpan.FromSeconds(10));

            // Schedule a recurring job to run every minute
            RecurringJob.AddOrUpdate("recurring-job", () => JobMethods.RecurringJobMethod(), Cron.Minutely);

            // Schedule another recurring job to run every 5 minutes
            RecurringJob.AddOrUpdate("five-minute-job", () => JobMethods.FiveMinuteJob(), "*/5 * * * *");

            // Schedule a parameterized job
            BackgroundJob.Enqueue(() => JobMethods.ParameterizedJob("Hello from the client with parameters!", 5));

            Console.WriteLine("Jobs have been scheduled. Press any key to exit...");
            Console.ReadKey();
        }
    }
}
