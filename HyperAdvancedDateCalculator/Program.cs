using System;

namespace HyperAdvancedDateCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            if (ArgsInvalid(args, out var date1, out var date2))
                return;

            // Grab a calendar from somewhere, like a DI container etc.
            // Here we just consider all Saturdays and Sundays as holidays.
            var dayCounter = new DayCounter(new WeekEndsOnlyHolidayCalendar());
            var dayDiff = dayCounter.CountWorkingDays(date1, date2);

            Console.WriteLine($"There are {dayDiff} week days from " + 
                              $"{date1.ToShortDateString()} to {date2.ToShortDateString()}.");

        }

        private static bool ArgsInvalid(string[] args, out DateTime startDate, out DateTime endDate)
        {
            startDate = DateTime.MinValue;
            endDate = DateTime.MaxValue;
            if (args.Length != 2)
            {
                Console.WriteLine("Supply exactly two args: Start date and end date");
                return true;
            }

            if (DateTime.TryParse(args[0], out startDate) && DateTime.TryParse(args[1], out endDate))
            {
                return false;
            }

            Console.WriteLine("Supply two parameters that can be parsed as datetime objects.");
            return true;
        }
    }
}
