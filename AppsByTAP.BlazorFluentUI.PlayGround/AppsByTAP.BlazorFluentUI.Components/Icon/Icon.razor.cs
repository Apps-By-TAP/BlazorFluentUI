using Microsoft.AspNetCore.Components;

namespace AppsByTAP.BlazorFluentUI.Components.Icon
{
    public class IconViewModel : ComponentBase
    {
        [Parameter]
        public IconTypes IconType { get; set; }
    }
}
