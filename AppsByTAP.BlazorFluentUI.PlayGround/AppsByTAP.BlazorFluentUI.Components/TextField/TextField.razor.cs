using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.JSInterop;
using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AppsByTAP.BlazorFluentUI.Components.TextField
{
    public partial class TextField : ComponentBase
    {
        [Inject] 
        IJSRuntime JSRuntime { get; set; }

        [Parameter]
        public string ID { get; set; }
        [Parameter]
        public string Label { get; set; }

        private string _value;
        [Parameter]
        public string Value 
        {
            get => _value;
            set
            {
                if(_value == value) { return; }

                _value = value;
                ValueChanged.InvokeAsync(Value);
            }
        }
        [Parameter]
        public EventCallback<string> ValueChanged { get; set; }
        [Parameter]
        public bool IsMultiLine { get; set; }
        [Parameter]
        public bool MultiLineCanResize { get; set; } = true;
        [Parameter]
        public string Width { get; set; }
        [Parameter]
        public string MaxWidth { get; set; }
        [Parameter]
        public int Height { get; set; } = -1;
        [Parameter]
        public string PlaceHolder { get; set; }
        [Parameter]
        public bool DisplayBorder { get; set; } = true;
        [Parameter]
        public string Mask { get; set; }
        [Parameter]
        public TextFieldType Type { get; set; }
        [Parameter]
        public string Class { get; set; }
        [Parameter]
        public string Style { get; set; }
        [Parameter]
        public double? Step { get; set; } = null;

        private Task<IJSObjectReference> _module;
        private const string ImportPath = "./_content/AppsByTAP.BlazorFluentUI.Components/js/Mask.js";
        private Task<IJSObjectReference> Module => _module ??= JSRuntime.InvokeAsync<IJSObjectReference>("import", ImportPath).AsTask();

        protected async override Task OnAfterRenderAsync(bool firstRender)
        {
            if(firstRender && !string.IsNullOrEmpty(Mask))
            {
                if (string.IsNullOrEmpty(ID))
                {
                    throw new ArgumentNullException(nameof(ID));
                }

                IJSObjectReference mod = await Module;
                await mod.InvokeVoidAsync("GenerateMask", ID, Mask);
            }
        }

        [Parameter]
        public EventCallback<FocusEventArgs> OnBlur { get; set; }
    }
}
