using AppsByTAP.BlazorFluentUI.Components.BaseComponent;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppsByTAP.BlazorFluentUI.Components.DatePicker
{
    public class DatePickerViewModel : BaseComponentViewModel
    {
        [Inject]
        public IJSRuntime JSRuntime { get; set; }

        protected List<Date> _dates = new List<Date>();
        public DatePickerViewModel()
        {
            DateTime theFirst = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            DateTime temp;
            DayOfWeek startDay = theFirst.DayOfWeek;

            for(int i = ((int)startDay) * -1; i < 0; i++)
            {
                temp = theFirst.AddDays(i);
                _dates.Add(new Date(temp.Month.ToString(), temp.DayOfWeek, temp.Day));
            }

            for(int i = 0; i < 42- (int)startDay; i++)
            {
                temp = theFirst.AddDays(i);
                _dates.Add(new Date(temp.Month.ToString(), temp.DayOfWeek, temp.Day));
            }
        }

        protected async Task MouseMoved(MouseEventArgs args)
        {
            await JSRuntime.InvokeVoidAsync("GetElements", args.ClientX, args.ClientY);
        }

        protected async Task MouseExited(MouseEventArgs args)
        {
            await JSRuntime.InvokeVoidAsync("UnRevealHighlight");
        }
    }
}
