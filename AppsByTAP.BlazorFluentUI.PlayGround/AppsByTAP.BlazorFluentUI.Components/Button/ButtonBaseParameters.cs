using AppsByTAP.BlazorFluentUI.Components.BaseComponent;
using AppsByTAP.BlazorFluentUI.Components.Icon;
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
        [Parameter]
        public bool OnClickStopPropagation { get; set; }
        [Parameter]
        public IconTypes Icon { get; set; } = IconTypes.None;
        [Parameter]
        public bool Disabled { get; set; }

        protected async void OnClickInternal(MouseEventArgs args)
        {
            if(!Disabled)
            {
                await OnClick.InvokeAsync(args);
            }
        }
    }
}
