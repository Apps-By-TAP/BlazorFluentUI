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

        [Parameter]
        public DateTime SelectedDate { get; set; } = DateTime.Now;
        [Parameter]
        public string DateFormat { get; set; } = "MM/dd/yyy";

        public DatePickerViewModel()
        {

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
