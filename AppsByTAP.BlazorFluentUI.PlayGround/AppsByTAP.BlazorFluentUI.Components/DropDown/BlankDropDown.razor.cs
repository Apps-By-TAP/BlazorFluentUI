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
        [Parameter]
        public string ClassName { get; set; }
        [Parameter]
        public string Style { get; set; }

        private bool _isOpen;
        [Parameter]
        public bool IsOpen 
        {
            get => _isOpen;
            set
            {
                if(_isOpen == value) { return; }

                _isOpen = value;
                IsOpenChanged.InvokeAsync(IsOpen);

                if(value)
                {
                    OnOpen.InvokeAsync();
                }
                else
                {
                    OnClose.InvokeAsync();
                }
            }
        }
        [Parameter]
        public EventCallback<bool> IsOpenChanged { get; set; }


        protected void OpenDropDown()
        {
            if (!Disabled)
            {
                IsOpen = !IsOpen;
            }
        }

        protected void Close()
        {
            IsOpen = false;
        }
    }
}
