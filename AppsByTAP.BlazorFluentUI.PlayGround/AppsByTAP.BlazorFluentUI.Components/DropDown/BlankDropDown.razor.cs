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

        protected bool _displayDropDown = false;

        protected void OpenDropDown()
        {
            if (!Disabled)
            {
                _displayDropDown = !_displayDropDown;
            }
        }

        protected void Close()
        {
            _displayDropDown = false;
        }
    }
}
