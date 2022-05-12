using System;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace AppsByTAP.BlazorFluentUI.Components.DropDown
{
    public partial class BlankDropDown : ComponentBase
    {
        [Inject] IJSRuntime JSRuntime { get; set; }


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

        private Task<IJSObjectReference> _module;
        private const string ImportPath = "./_content/AppsByTAP.BlazorFluentUI.Components/js/BlankDropDown.js";
        private Task<IJSObjectReference> Module => _module ??= JSRuntime.InvokeAsync<IJSObjectReference>("import", ImportPath).AsTask();

        private readonly string _id = Guid.NewGuid().ToString();
        private int _top = -1;

        protected async void OpenDropDown()
        {
            if (!Disabled)
            {
                _top = -1;
                await Task.Delay(5); //Time for UI to update

                IJSObjectReference mod = await Module;

                if(!await mod.InvokeAsync<bool>("canExpandDown", _id))
                {
                    _top = (int)await mod.InvokeAsync<double>("getNewTopLocation", _id);
                }

                IsOpen = !IsOpen;
                StateHasChanged();
            }
        }

        protected void Close()
        {
            IsOpen = false;
        }
    }
}
