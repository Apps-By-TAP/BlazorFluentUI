using AppsByTAP.BlazorFluentUI.Components.Common;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System;
using System.Text.RegularExpressions;

namespace AppsByTAP.BlazorFluentUI.Components.SpinButton
{
    public partial class SpinButton : ComponentBase
    {
        [Parameter]
        public double MinValue { get; set; } = double.MinValue;
        [Parameter]
        public double MaxValue { get; set; } = double.MaxValue;
        [Parameter]
        public SpinButtonType Type { get; set; } = SpinButtonType.Whole;

        private int _wholeValue;
        [Parameter]
        public int WholeValue 
        {
            get => _wholeValue;
            set
            {
                if(_wholeValue == value) { return; }

                _wholeValue = value;
                WholeValueChanged.InvokeAsync(value);
                DisplayValue = $"{_wholeValue} {Suffix}";
            }
        
        }
        [Parameter]
        public EventCallback<int> WholeValueChanged { get; set; }

        private double _decimalValue;
        [Parameter]
        public double DecimalValue 
        {
            get => _decimalValue;
            set
            {
                if(_decimalValue == value) { return; }

                _decimalValue = value;
                DecimalValueChanged.InvokeAsync(value);
                DisplayValue = $"{_decimalValue} {Suffix}";
            }
        }

        [Parameter]
        public EventCallback<double> DecimalValueChanged { get; set; }
        [Parameter]
        public string Suffix { get; set; }
        [Parameter]
        public string Label { get; set; }
        [Parameter]
        public LabelPosition LabelPosition { get; set; } = LabelPosition.Above;
        [Parameter]
        public double IncrementAmount { get; set; }
        [Parameter]
        public int RoundingPlaces { get; set; } = 1;
        [Parameter]
        public EventCallback<double> OnIncrement { get; set; }
        [Parameter]
        public EventCallback<double> OnDecrement { get; set; }

        private string _displayValue;
        public string DisplayValue
        {
            get => _displayValue;
            set
            {
                if(value == _displayValue) { return; }

                Regex rex = new Regex(@"[0-9\.]+");
                Match match = rex.Match(value);

                if(match.Success)
                {
                    string decodedVal = match.Groups[0].Value;
                    _displayValue = decodedVal + " " + Suffix;

                    if(Type == SpinButtonType.Whole)
                    {
                        _wholeValue = int.Parse(decodedVal);
                    }
                    else
                    {
                        _decimalValue = Math.Round(double.Parse(decodedVal), RoundingPlaces);
                        decodedVal = _decimalValue.ToString();
                    }

                    _displayValue = decodedVal + " " + Suffix;
                }
            }
        }

        protected override void OnParametersSet()
        {
            if(IncrementAmount == 0)
            {
                IncrementAmount = Type == SpinButtonType.Whole ? 1d : .1;
            }

            DisplayValue = Type == SpinButtonType.Whole ? WholeValue.ToString() : DecimalValue.ToString();
        }

        private void OnMouseWheel(WheelEventArgs args)
        {
            if(args.DeltaY < 0)
            {
                Increment();
            }
            else
            {
                Decrement();
            }
        }

        private async void Increment()
        {
            if(Type == SpinButtonType.Whole)
            {
                if(WholeValue + IncrementAmount <= MaxValue)
                {
                    WholeValue += (int)Math.Round(IncrementAmount);
                    await OnIncrement.InvokeAsync(WholeValue);
                }
            }
            else
            {
                if(DecimalValue + IncrementAmount <= MaxValue)
                {
                    DecimalValue += IncrementAmount;
                    await OnIncrement.InvokeAsync(DecimalValue);
                }
            }
        }

        private async void Decrement()
        {
            if (Type == SpinButtonType.Whole)
            {
                if(WholeValue - IncrementAmount >= MinValue)
                {
                    WholeValue -= (int)Math.Round(IncrementAmount);
                    await OnDecrement.InvokeAsync(WholeValue);
                }
            }
            else
            {
                if(DecimalValue - IncrementAmount >= MinValue)
                {
                    DecimalValue -= IncrementAmount;
                    await OnDecrement.InvokeAsync(DecimalValue);
                }
            }
        }
    }
}
