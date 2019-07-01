using System;

namespace HyperAdvancedDateCalculator
{
    public class DayCounter
    {
        private readonly IHolidayCalendar holidayCalendar;
        public DayCounter(IHolidayCalendar holidayCalendar) => this.holidayCalendar = holidayCalendar;

        public int CountWorkingDays(DateTime from, DateTime to)
        {
            var start = from <= to ? from : to;
            var end = from > to ? from : to;
            var dayIndex = start;
            int workingDays = 0;

            while (dayIndex <= end)
            {
                if (!holidayCalendar.IsHoliday(dayIndex))
                {
                    workingDays++;
                }
                dayIndex = dayIndex.AddDays(1);
            }

            return workingDays;
        }
    }
}
