using Microsoft.AspNetCore.Components;

namespace AppsByTAP.BlazorFluentUI.Components.Callout
{
    public partial class Callout : ComponentBase
    {
        [Parameter]
        public RenderFragment ChildContent { get; set; }

        [Parameter]
        public EventCallback OnOpen { get; set; }
        [Parameter]
        public EventCallback OnClose { get; set; }

        private bool _isOpen;
        [Parameter]
        public bool IsOpen
        {
            get => _isOpen;
            set
            {
                if (_isOpen == value || Disabled) { return; }

                _isOpen = value;
                IsOpenChanged.InvokeAsync(IsOpen);

                if (value)
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
        [Parameter]
        public string Width { get; set; } = "300px";
        [Parameter]
        public int ItemsPanelHeight { get; set; } = -1;
        [Parameter]
        public bool Disabled { get; set; }
    }
}
