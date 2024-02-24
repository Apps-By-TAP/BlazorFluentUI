using AppsByTAP.BlazorFluentUI.Components.BaseComponent;
using AppsByTAP.BlazorFluentUI.Components.Icon;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System;
using System.Diagnostics;

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
        [Parameter]
        public bool ShowIsBusy { get; set; }
        protected bool IsBusy { get; set; }

        protected async void OnClickInternal(MouseEventArgs args)
        {
            if(!Disabled)
            {
                if(ShowIsBusy) IsBusy = true;
                Debug.WriteLine("ButtonBaseParameters.OnClickInternal");
                await OnClick.InvokeAsync(args);
                if(ShowIsBusy)
                {
                    IsBusy = false;
                    StateHasChanged();
                }
            }
        }
    }
}
