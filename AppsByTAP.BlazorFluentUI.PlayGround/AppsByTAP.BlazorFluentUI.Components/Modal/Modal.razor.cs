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


        protected string _displayType;

        protected async void Close()
        {
            ShowWindow = false;
            await ShowWindowChanged.InvokeAsync(false);
        }
    }
}
