using AppsByTAP.BlazorFluentUI.Components.BaseComponent;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Threading.Tasks;

namespace AppsByTAP.BlazorFluentUI.Components.Modal
{
    public class ModalViewModel : BaseComponentViewModel, IAsyncDisposable
    {
        [Inject] protected IJSRuntime JSRuntime { get; set; }

        private Task<IJSObjectReference> _module;
        private const string ImportPath = "./_content/AppsByTAP.BlazorFluentUI.Components/js/Modal.js";
        private Task<IJSObjectReference> Module => _module ??= JSRuntime.InvokeAsync<IJSObjectReference>("import", ImportPath).AsTask();

        private bool _showWindow;
        private bool _previousShowWindow;
        
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

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            await base.OnAfterRenderAsync(firstRender);
            
            // Handle scroll locking when ShowWindow changes
            if (_previousShowWindow != _showWindow)
            {
                _previousShowWindow = _showWindow;
                await ToggleBodyScrollAsync(_showWindow);
            }
        }

        protected async void Close()
        {
            ShowWindow = false;
            await OnClose.InvokeAsync();
            await ShowWindowChanged.InvokeAsync(false);
        }

        private async Task ToggleBodyScrollAsync(bool isOpen)
        {
            try
            {
                var module = await Module;
                if (isOpen)
                {
                    await module.InvokeVoidAsync("lockBodyScroll");
                }
                else
                {
                    await module.InvokeVoidAsync("unlockBodyScroll");
                }
            }
            catch
            {
                // Ignore JS interop errors (e.g., during prerendering)
            }
        }

        public async ValueTask DisposeAsync()
        {
            // Ensure body scroll is unlocked when component is disposed
            if (_showWindow)
            {
                try
                {
                    var module = await Module;
                    await module.InvokeVoidAsync("unlockBodyScroll");
                }
                catch
                {
                    // Ignore errors during disposal
                }
            }

            if (_module != null)
            {
                try
                {
                    var module = await _module;
                    await module.DisposeAsync();
                }
                catch
                {
                    // Ignore errors during disposal
                }
            }
        }
    }
}
