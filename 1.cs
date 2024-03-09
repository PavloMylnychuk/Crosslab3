using System;
using System.Collections.Generic;
using System.Linq;

class Date
{
    private int day;
    private int month;
    private int year;

    public Date(int day, int month, int year)
    {
        if (IsValidDate(day, month, year))
        {
            this.day = day;
            this.month = month;
            this.year = year;
        }
        else
        {
            throw new ArgumentException("Некоректна дата");
        }
    }

    public void PrintFullDate()
    {
        string monthName = GetMonthName();
        Console.WriteLine($"{day} {monthName} {year} року");
    }

    public void PrintShortDate()
    {
        Console.WriteLine($"{day:D2}.{month:D2}.{year}");
    }

    public bool IsValidDate(int day, int month, int year)
    {
        return day >= 1 && day <= 31 && month >= 1 && month <= 12;
    }

    public int DaysBetweenDates(Date otherDate)
    {
        DateTime date1 = new DateTime(year, month, day);
        DateTime date2 = new DateTime(otherDate.year, otherDate.month, otherDate.day);

        return Math.Abs((int)(date2 - date1).TotalDays);
    }

    public int Day
    {
        get { return day; }
        set
        {
            if (IsValidDate(value, month, year))
                day = value;
            else
                throw new ArgumentException("Некоректний день");
        }
    }

    public int Month
    {
        get { return month; }
        set
        {
            if (IsValidDate(day, value, year))
                month = value;
            else
                throw new ArgumentException("Некоректний місяць");
        }
    }

    public int Year
    {
        get { return year; }
        set
        {
            if (IsValidDate(day, month, value))
                year = value;
            else
                throw new ArgumentException("Некоректний рік");
        }
    }

    public int Century
    {
        get { return (year - 1) / 100 + 1; }
    }

    private string GetMonthName()
    {
        DateTime date = new DateTime(year, month, day);
        return date.ToString("MMMM");
    }
}

class Program
{
    static void Main()
    {
        Date[] dates = new Date[]
        {
            new Date(5, 1, 2022),
            new Date(15, 3, 2023),
            new Date(25, 12, 2021),
        };

        var orderedDates = dates.OrderBy(d => new DateTime(d.Year, d.Month, d.Day)).ToArray();
        Console.WriteLine("Впорядковані за зростанням дати:");
        foreach (var date in orderedDates)
        {
            date.PrintShortDate();
        }

        int maxDays = 0;
        Date startDate = null;
        Date endDate = null;

        for (int i = 0; i < dates.Length - 1; i++)
        {
            for (int j = i + 1; j < dates.Length; j++)
            {
                int daysBetween = dates[i].DaysBetweenDates(dates[j]);
                if (daysBetween > maxDays)
                {
                    maxDays = daysBetween;
                    startDate = dates[i];
                    endDate = dates[j];
                }
            }
        }

        Console.WriteLine($"Найбільша кількість днів між датами: {maxDays} ({startDate.PrintShortDate()} - {endDate.PrintShortDate()})");
    }
}
