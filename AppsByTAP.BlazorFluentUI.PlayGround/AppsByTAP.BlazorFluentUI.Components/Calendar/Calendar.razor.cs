using AppsByTAP.BlazorFluentUI.Components.BaseComponent;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AppsByTAP.BlazorFluentUI.Components.Calendar
{
    public class CalendarViewModel : BaseComponentViewModel
    {
        private DateTime _selectedDate;
        [Parameter]
        public DateTime SelectedDate 
        {
            get => _selectedDate;
            set
            {
                if(_selectedDate == value) { return; }

                _selectedDate = value;

                SelectedDateChanged.InvokeAsync(SelectedDate);

                if(value.Month != (int)_currentMonth)
                {
                    GenerateMonths();
                }

            }
        }

        [Parameter]
        public EventCallback<DateTime> SelectedDateChanged { get; set; }

        protected List<Date> _dates = new List<Date>();
        protected Months _currentMonth;

        public CalendarViewModel()
        {
            SelectedDate = DateTime.Now;
            GenerateMonths();
        }

        protected void SelectDate(Date selectedDate)
        {
            Date prevSelected= _dates.FirstOrDefault(x => x.IsSelected);

            if(prevSelected is not null)
            {
                prevSelected.IsSelected = false;
            }

            SelectedDate = new DateTime(selectedDate.Year, (int)selectedDate.Month, selectedDate.DayOfMonth);
            selectedDate.IsSelected = true;

            if(selectedDate.Month != _currentMonth)
            {
                GenerateMonths();
            }
        }

        private void GenerateMonths()
        {
            _dates.Clear();
            DateTime theFirst = new DateTime(SelectedDate.Year, SelectedDate.Month, 1);
            DateTime temp;
            DayOfWeek startDay = theFirst.DayOfWeek;

            _currentMonth = (Months)SelectedDate.Month;

            bool isToday = false;

            for(int i = ((int)startDay) * -1; i < 0; i++)
            {
                temp = theFirst.AddDays(i);
                isToday = temp.Day == DateTime.Now.Day && temp.Month == DateTime.Now.Month;
                _dates.Add(new Date(temp.Year, (Months)temp.Month, temp.DayOfWeek, temp.Day, isToday));
            }


            for(int i = 0; i < 42 - (int)startDay; i++)
            {
                temp = theFirst.AddDays(i);

                isToday = temp.Day == DateTime.Now.Day && temp.Month == DateTime.Now.Month;

                _dates.Add(new Date(temp.Year, (Months)temp.Month, temp.DayOfWeek, temp.Day, isToday, temp.Day == SelectedDate.Day));
            }
        }
    }
}
