using AppsByTAP.BlazorFluentUI.Components.BaseComponent;
using Microsoft.AspNetCore.Components;

namespace AppsByTAP.BlazorFluentUI.Components.Spinner
{
    public class SpinnerViewModel : BaseComponentViewModel
    {
        private const string _largeSpinner = "largeSpinner";
        private const string _mediumSpinner = "mediumSpinner";
        private const string _smallSpinner = "smallSpinner";
        private const string _xsmallSpinner = "xsmallSpinner";

        private string _label;
        [Parameter]
        public string Label 
        {
            get => _label;
            set
            {
                if(_label == value) { return; }

                _label = value;
                SetLabel();
            }
        }

        private SpinnerLabelPosition _position;
        [Parameter]
        public SpinnerLabelPosition Position
        {
            get => _position;
            set
            {
                if (_position == value) { return; }

                _position = value;
                SetLabel();
            }
        }

        private bool _isLoading;
        [Parameter]
        public bool IsLoading 
        {
            get => _isLoading;
            set 
            {
                if (_isLoading == value) { return; }

                _isLoading = value;

                IsLoadingChanged.InvokeAsync(_isLoading);
            }
        }

        [Parameter]
        public EventCallback<bool> IsLoadingChanged { get; set; }

        private SpinnerSize _size;
        [Parameter]
        public SpinnerSize Size 
        {
            get => _size;
            set
            {
                if(_size == value) { return; }

                _size = value;

                switch(value)
                {
                    case SpinnerSize.Large:
                        _spinnerSizeClass = _largeSpinner;
                        break;

                    case SpinnerSize.Medium:
                        _spinnerSizeClass = _mediumSpinner;
                        break;

                    case SpinnerSize.Small:
                        _spinnerSizeClass = _smallSpinner;
                        break;

                    case SpinnerSize.xSmall:
                        _spinnerSizeClass = _xsmallSpinner;
                        break;
                }
            }
        }

        protected string _spinnerSizeClass;

        protected string _labelTop { get; set; }

        protected string _labelLeft { get; set; }

        protected string _labelRight { get; set; }
        protected string _labelBottom { get; set; }

        public SpinnerViewModel()
        {
            Position = SpinnerLabelPosition.Bottom;
            IsLoading = true;
            _spinnerSizeClass = _largeSpinner;
        }

        private void SetLabel()
        {
            _labelTop = "";
            _labelLeft = "";
            _labelRight = "";
            _labelBottom = "";

            switch(Position)
            {
                case SpinnerLabelPosition.Top:
                    _labelTop = Label;
                    break;

                case SpinnerLabelPosition.Left:
                    _labelLeft = Label;
                    break;

                case SpinnerLabelPosition.Right:
                    _labelRight = Label;
                    break;

                case SpinnerLabelPosition.Bottom:
                    _labelBottom = Label;
                    break;

            }
        }
    }
}
