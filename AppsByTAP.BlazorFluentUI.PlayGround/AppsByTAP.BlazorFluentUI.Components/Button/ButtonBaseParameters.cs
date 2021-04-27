using AppsByTAP.BlazorFluentUI.Components.BaseComponent;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System;

namespace AppsByTAP.BlazorFluentUI.Components.Button
{
    public class ButtonBaseParameters : BaseComponentViewModel
    {
        [Parameter]
        public string Text { get; set; }
        [Parameter]
        public bool IsPrimary { get; set; }
        [Parameter]
        public EventCallback<MouseEventArgs> OnClick { get; set; }
    }
}
