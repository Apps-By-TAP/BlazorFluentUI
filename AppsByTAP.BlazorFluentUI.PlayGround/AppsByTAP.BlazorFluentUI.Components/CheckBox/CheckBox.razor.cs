using AppsByTAP.BlazorFluentUI.Components.BaseComponent;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace AppsByTAP.BlazorFluentUI.Components.CheckBox
{
    public class CheckBoxViewModel : BaseComponentViewModel
    {
        private const string _showCheckMark = "showCheckMark";
        private const string _hideCheckMark = "hideCheckMark";

        [Parameter]
        public string Label { get; set; }

        private bool _isChecked;
        [Parameter]
        public bool IsChecked 
        {
            get => _isChecked;
            set
            {
                if(_isChecked == value) { return; }

                _isChecked = value;

                CheckVisibility = value ? _showCheckMark : _hideCheckMark;
            }
        }

        [Parameter]
        public EventCallback<bool> IsCheckedChanged { get; set; }
        [Parameter]
        public EventCallback<CheckBoxChangedArgs> OnChanged { get; set; }
        [Parameter]
        public BoxSide BoxSide { get; set; } = BoxSide.Start;

        protected string CheckVisibility { get; set; } = _hideCheckMark;

        protected async Task Clicked()
        {
            IsChecked = !IsChecked;
            await IsCheckedChanged.InvokeAsync(IsChecked);
            await OnChanged.InvokeAsync(new CheckBoxChangedArgs(IsChecked, this));
        }

        protected void MouseOver()
        {
            if(!IsChecked)
            {
                CheckVisibility = _showCheckMark;
            }
        }

        protected void MouseExit()
        {
            if(!IsChecked)
            {
                CheckVisibility = _hideCheckMark;
            }
        }
    }
}
