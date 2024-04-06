using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Threading.Tasks;

namespace AppsByTAP.BlazorFluentUI.Components.Button
{
    public class HyperLinkButtonViewModel : ButtonBaseParameters
    {
        [Parameter]
        public string IsBusyColor1 { get; set; } = "rgba(12,123,255)";
        [Parameter]
        public string IsBusyColor2 { get; set; } = "rgba(12,123,255, 0)";

        [Parameter]
        public string Url { get; set; }
        protected string _target;
        private TargetTypes _targetType = TargetTypes.Self;
        [Parameter]
        public TargetTypes TargetType 
        {
            get => _targetType;
            set
            {
                if(_targetType == value) { return; }

                _targetType = value;
                _target = _targetType switch
                {
                    TargetTypes.Blank => "_blank",
                    TargetTypes.Parent => "_parent",
                    TargetTypes.Top => "_top",
                    _ => "_self"
                };
            }
        }

        [Inject]
        public IJSRuntime JSRuntime { get; set; }
        private Task<IJSObjectReference> _module;
        private const string ImportPath = "./_content/AppsByTAP.BlazorFluentUI.Components/js/HyperLinkButton.js";
        private Task<IJSObjectReference> Module => _module ??= JSRuntime.InvokeAsync<IJSObjectReference>("import", ImportPath).AsTask();

        protected string _hyperID = Guid.NewGuid().ToString();

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if(firstRender && ShowIsBusy)
            {
                await Task.Delay(100);
                IJSObjectReference mod = await Module;
                await mod.InvokeVoidAsync("registerEvent", _hyperID);
            }
        }
    }

    public enum TargetTypes
    {
        Self, 
        Blank,
        Parent,
        Top
    }
}
