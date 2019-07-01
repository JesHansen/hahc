using System;

namespace HyperAdvancedDateCalculator
{
    public class WeekEndsOnlyHolidayCalendar : IHolidayCalendar
    {
        public bool IsHoliday(DateTime day)
        {
            return day.DayOfWeek == DayOfWeek.Saturday || day.DayOfWeek == DayOfWeek.Sunday;
        }
    }
}