using System;

namespace AppsByTAP.BlazorFluentUI.Components.Calendar
{
    public class Date
    {
        public int Year { get; set; }
        public Months Month { get; set; }
        public DayOfWeek DayOfWeek { get; set; }
        public int DayOfMonth { get; set; }
        public bool IsToday { get; set; }
        public bool IsSelected { get; set; } = false;

        public Date(int year, Months month, DayOfWeek dayOfWeek, int dayOfMonth, bool isToday, bool isSelected = false)
        {
            Year = year;
            Month = month;
            DayOfWeek = dayOfWeek;
            DayOfMonth = dayOfMonth;
            IsToday = isToday;
            IsSelected = isSelected;
        }
    }
}