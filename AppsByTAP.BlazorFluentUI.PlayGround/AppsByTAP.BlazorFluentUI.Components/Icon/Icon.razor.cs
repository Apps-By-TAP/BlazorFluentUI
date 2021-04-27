using AppsByTAP.BlazorFluentUI.Components.BaseComponent;
using Microsoft.AspNetCore.Components;

namespace AppsByTAP.BlazorFluentUI.Components.Icon
{
    public class IconViewModel : BaseComponentViewModel
    {
        [Parameter]
        public IconTypes IconType { get; set; }
    }
}
