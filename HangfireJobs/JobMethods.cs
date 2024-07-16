namespace HangfireJobs
{
    public class JobMethods
    {
        public static void ImmediateJob()
        {
            Console.WriteLine("Immediate job executed from the client!");
            Thread.Sleep(5000); // Add delay to see the job in Processing state
        }

        public static void DelayedJob()
        {
            Console.WriteLine("Delayed job executed from the client!");
            Thread.Sleep(5000); // Add delay to see the job in Processing state
        }

        public static void RecurringJobMethod()
        {
            Console.WriteLine("Recurring job executed from the client!");
            Thread.Sleep(5000); // Add delay to see the job in Processing state
        }

        public static void FiveMinuteJob()
        {
            Console.WriteLine("This job runs every 5 minutes from the client!");
            Thread.Sleep(5000); // Add delay to see the job in Processing state
        }

        public static void ParameterizedJob(string message, int count)
        {
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine($"{i + 1}: {message}");
            }
            Thread.Sleep(5000); // Add delay to see the job in Processing state
        }
    }
}
