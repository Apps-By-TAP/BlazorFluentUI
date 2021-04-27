using System;

namespace AppsByTAP.BlazorFluentUI.Components.DatePicker
{
    public record Date(string month, DayOfWeek DayOfWeek, int DayOfMonth);
}