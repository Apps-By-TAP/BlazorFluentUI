using AppsByTAP.BlazorFluentUI.Components.BaseComponent;
using Microsoft.AspNetCore.Components;

namespace AppsByTAP.BlazorFluentUI.Components.Modal
{
    public class ModalViewModel : BaseComponentViewModel
    {
        private bool _showWindow;
        [Parameter]
        public bool ShowWindow
        {
            get => _showWindow;
            set
            {
                _showWindow = value;
                _displayType = value ? "block" : "none";
            }
        }

        [Parameter]
        public EventCallback<bool> ShowWindowChanged { get; set; }

        [Parameter]
        public RenderFragment Content { get; set; }
        [Parameter]
        public RenderFragment Header { get; set; }
        [Parameter]
        public EventCallback OnClose { get; set; }
        [Parameter]
        public string Width { get; set; } = "fit-content";
        [Parameter]
        public bool ShowHeader { get; set; } = true;
        [Parameter]
        public bool CanLightDismiss { get; set; } = true;

        protected int _layer = 10;
        protected string _displayType;

        protected override void OnAfterRender(bool firstRender)
        {
            if(firstRender) 
            {
                _layer = LayerCounter.GetLayer();
            }
        }

        protected async void Close()
        {
            ShowWindow = false;
            await OnClose.InvokeAsync();
            await ShowWindowChanged.InvokeAsync(false);
        }
    }
}
