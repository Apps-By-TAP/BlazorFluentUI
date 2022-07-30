using AppsByTAP.BlazorFluentUI.Components.BaseComponent;
using Microsoft.AspNetCore.Components;
using System.Text.RegularExpressions;

namespace AppsByTAP.BlazorFluentUI.Components.TextField
{
    public partial class TextFieldViewModel : BaseComponentViewModel
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
                
                if(Required)
                {
                    Validate();
                }
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
        [Parameter]
        public string Regex { get; set; } = "";

        public override bool Validate()
        {
            bool isValid = false;
            if (!string.IsNullOrEmpty(Regex))
            {
                isValid = new Regex(Regex).IsMatch(Value);
            }
            else
            {
                isValid = !string.IsNullOrEmpty(Value);
            }

            ValidationState = isValid ? ValidationState.Valid : ValidationState.Invalid;

            return isValid;
        }
    }
}
