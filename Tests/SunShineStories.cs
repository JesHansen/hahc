using System;
using FluentAssertions;
using HyperAdvancedDateCalculator;
using Xunit;

namespace Tests
{
    public class SunShineStories
    {
        [Fact]
        public void WorkHappensOnWednesdays()
        {
            var sut = new DayCounter(new OnlyWednesdaysAreWorkingDays());
            var newYear = new DateTime(2019, 1, 1);
            var christmasEve = new DateTime(2019, 12, 24);
            sut.CountWorkingDays(newYear, christmasEve).Should().Be(51);
        }

        [Fact]
        public void UniversityStudents()
        {
            var sut = new DayCounter(new ScroogeCalendar());
            var newYear = new DateTime(2019, 1, 1);
            var christmasEve = new DateTime(2019, 12, 24);
            sut.CountWorkingDays(newYear, christmasEve).Should().Be(358);
        }

        [Fact]
        public void SomeDucksAreTerribleEmployees()
        {
            var sut = new DayCounter(new GladstoneGanderCalendar());
            var newYear = new DateTime(2019, 1, 1);
            var christmasEve = new DateTime(2019, 12, 24);
            sut.CountWorkingDays(newYear, christmasEve).Should().Be(0);
        }

        [Fact]
        public void FebruaryHas20WorkingDays()
        {
            var sut = new DayCounter(new WeekEndsOnlyHolidayCalendar());
            sut.CountWorkingDays(
                    new DateTime(2019, 2, 1),
                    new DateTime(2019, 2, 28))
                .Should().Be(20);
        }

        [Fact]
        public void SplitWeek()
        {
            var sut = new DayCounter(new WeekEndsOnlyHolidayCalendar());
            sut.CountWorkingDays(
                    new DateTime(2019, 5, 8),
                    new DateTime(2019, 5, 22))
                .Should().Be(11);
        }

        [Fact]
        public void JustToday()
        {
            var sut = new DayCounter(new WeekEndsOnlyHolidayCalendar());
            sut.CountWorkingDays(
                    new DateTime(2019, 5, 8),
                    new DateTime(2019, 5, 8))
                .Should().Be(1);
        }
    }

    class OnlyWednesdaysAreWorkingDays : IHolidayCalendar
    {
        public bool IsHoliday(DateTime day)
        {
            return day.DayOfWeek != DayOfWeek.Wednesday;
        }
    }

    class ScroogeCalendar : IHolidayCalendar
    {
        public bool IsHoliday(DateTime day) => false;
    }

    class GladstoneGanderCalendar : IHolidayCalendar
    {
        public bool IsHoliday(DateTime day) => true;
    }
}
