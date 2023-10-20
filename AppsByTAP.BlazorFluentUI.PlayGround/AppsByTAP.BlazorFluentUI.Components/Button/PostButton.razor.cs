using AppsByTAP.BlazorFluentUI.Components.BaseComponent;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppsByTAP.BlazorFluentUI.Components.Button
{
    public class PostButtonViewModel : BaseComponentViewModel
    {
        [Parameter]
        public string FormID { get; set; }
        [Parameter]
        public EventCallback<string> FormIDChanged { get; set; }
        [Parameter]
        public List<HiddenValue> HiddenValues { get; set; } = new List<HiddenValue>();
        [Parameter]
        public string Text { get; set; }
        [Parameter]
        public string Url { get; set; }
        [Parameter]
        public bool IsPrimary { get; set; }
        [Parameter]
        public bool Disabled { get; set; }
    }

    public class HiddenValue
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }
}
