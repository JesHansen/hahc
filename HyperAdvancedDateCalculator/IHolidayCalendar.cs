using System;

namespace HyperAdvancedDateCalculator
{
    /// <summary>
    /// An external weekend- and holiday calendar
    /// </summary>
    public interface IHolidayCalendar
    {
        /// <summary>
        /// Return a boolean value indicating whether a given day is a holiday.
        /// </summary>
        /// <param name="day">The date to check.</param>
        /// <returns><c>true</c> if <paramref name="day"/> is a holiday.</returns>
        bool IsHoliday(DateTime day);
    }
}