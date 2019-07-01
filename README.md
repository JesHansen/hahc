Hyper Advanced Holiday Calendar™
=================================

The Hyper Advanced Holiday Calendar™ (HAHC) calculates how many working days
that span a date interval given by the starting and end dates. Both days are
included, as that is the most natural way to reasoning about working days.

Usage
-----
Clone the project. Invoke it with

```CSharp
dotnet run 2019-03-17 2019-05-03
```

to see the number to week days from the 17'th of March to the third of May.

The logic is in the `DayCounter` class. To use it, you have to instantiate it with an instance of an `IHolidayCalendar`. The included `WeekEndsOnlyHolidayCalendar` used by the command line tool counts Saturdays and Sundays as holidays.

If you want to use a different holiday calender, instantiate the `DayCounter` class with your own implementation of the `IHolidayCalendar` interface.
