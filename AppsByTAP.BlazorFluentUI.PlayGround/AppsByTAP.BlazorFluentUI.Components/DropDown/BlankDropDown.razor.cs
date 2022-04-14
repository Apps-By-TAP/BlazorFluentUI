using AppsByTAP.BlazorFluentUI.Components.BaseComponent;
using Microsoft.AspNetCore.Components;

namespace AppsByTAP.BlazorFluentUI.Components.DropDown
{
    public partial class BlankDropDown : ComponentBase
    {
        [Parameter]
        public RenderFragment DisplayInfo { get; set; }
        [Parameter]
        public RenderFragment Content { get; set; }
        [Parameter]
        public bool Disabled { get; set; }
        [Parameter]
        public string Label { get; set; }
        [Parameter]
        public string Width { get; set; } = "300px";
        [Parameter]
        public int ItemsPanelHeight { get; set; } = -1;
        [Parameter]
        public EventCallback OnOpen { get; set; }
        [Parameter]
        public EventCallback OnClose { get; set; }

        protected bool _displayDropDown = false;

        protected async void OpenDropDown()
        {
            if (!Disabled)
            {
                _displayDropDown = !_displayDropDown;

                if(_displayDropDown)
                {
                    await OnOpen.InvokeAsync();
                }
                else{
                    await OnClose.InvokeAsync();
                }
            }
        }

        protected async void Close()
        {
            _displayDropDown = false;
            await OnClose.InvokeAsync();
        }
    }
}
