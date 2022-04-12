using AppsByTAP.BlazorFluentUI.Components.BaseComponent;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace AppsByTAP.BlazorFluentUI.Components.Expander
{
    public class ExpanderViewModel : BaseComponentViewModel
    {
        [Parameter]
        public RenderFragment Header { get; set; }
        [Parameter]
        public RenderFragment ChildContent { get; set; }
        private bool _isOpen;
        [Parameter]
        public bool IsOpen 
        {
            get => _isOpen;
            set
            {
                if(value == _isOpen) { return; }

                _isOpen = value;
                ChevronIsDown = value;
            }
        }
        protected bool ChevronIsDown { get; set; } = false;

        protected async Task Clicked()
        {
            IsOpen = !IsOpen;

            await Task.Delay(200);
        }
    }
}
