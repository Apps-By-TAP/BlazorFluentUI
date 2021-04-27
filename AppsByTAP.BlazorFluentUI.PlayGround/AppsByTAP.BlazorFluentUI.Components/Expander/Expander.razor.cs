using AppsByTAP.BlazorFluentUI.Components.BaseComponent;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppsByTAP.BlazorFluentUI.Components.Expander
{
    public class ExpanderViewModel : BaseComponentViewModel
    {
        [Parameter]
        public string Header { get; set; }
        [Parameter]
        public RenderFragment ChildContent { get; set; }

        protected bool IsOpen { get; set; }
        protected bool ChevronIsDown { get; set; } = false;

        protected async Task Clicked()
        {
            IsOpen = !IsOpen;

            await Task.Delay(200);
            ChevronIsDown = !ChevronIsDown;
        }
    }
}
