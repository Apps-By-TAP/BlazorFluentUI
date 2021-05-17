using AppsByTAP.BlazorFluentUI.Components.BaseComponent;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace AppsByTAP.BlazorFluentUI.Components.CheckBox
{
    public class CheckBoxViewModel : BaseComponentViewModel
    {
        [Parameter]
        public string Label { get; set; }

        [Parameter]
        public bool IsChecked { get; set; }
        [Parameter]
        public EventCallback<bool> IsCheckedChanged { get; set; }

        protected string CheckVisibility { get; set; } = "hideCheckMark";

        protected async Task Clicked()
        {
            IsChecked = !IsChecked;
            await IsCheckedChanged.InvokeAsync(IsChecked);
        }

        protected void MouseOver()
        {
            if(!IsChecked)
            {
                CheckVisibility = "showCheckMark";
            }
        }

        protected void MouseExit()
        {
            if(!IsChecked)
            {
                CheckVisibility = "hideCheckMark";
            }
        }
    }
}
