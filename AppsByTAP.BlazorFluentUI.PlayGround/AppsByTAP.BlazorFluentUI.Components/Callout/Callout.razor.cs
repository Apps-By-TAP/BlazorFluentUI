using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace AppsByTAP.BlazorFluentUI.Components.Callout
{
    public partial class Callout : ComponentBase
    {
        [Inject] IJSRuntime JSRuntime { get; set; }

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
        [Parameter]
        public bool CanLightDismiss { get; set; } = true;
        [Parameter]
        public string TargetID { get; set; }

        private string _left;
        private string _id = Guid.NewGuid().ToString();
        private string _display = "none";

        private Task<IJSObjectReference> _module;
        private const string ImportPath = "./_content/AppsByTAP.BlazorFluentUI.Components/js/Callout.js";
        private Task<IJSObjectReference> Module => _module ??= JSRuntime.InvokeAsync<IJSObjectReference>("import", ImportPath).AsTask();

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {

            if (firstRender)
            {
                _display = "default";
                StateHasChanged();
                IJSObjectReference mod = await Module;

                await mod.InvokeVoidAsync("registerResizeCallback", DotNetObjectReference.Create(this), _id, TargetID);

                int left = (int)await mod.InvokeAsync<double>("getNewLeftLocation", _id, TargetID);

                _left = left.ToString() == "0" ? "default" : left.ToString() + "px";

                StateHasChanged();
            }
        }

        [JSInvokable]
        public void LeftChanged(int left)
        {
            _left = left + "px";
            StateHasChanged();
        }
    }
}
