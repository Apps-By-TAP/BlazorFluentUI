using Microsoft.AspNetCore.Components;

namespace AppsByTAP.BlazorFluentUI.Components.TextField
{
    public partial class TextField : ComponentBase
    {
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
        public int Width { get; set; } = -1;
        [Parameter]
        public int Height { get; set; } = -1;
        [Parameter]
        public string PlaceHolder { get; set; }
        [Parameter]
        public bool DisplayBorder { get; set; } = true;
    }
}
