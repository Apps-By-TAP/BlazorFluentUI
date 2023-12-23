using Microsoft.AspNetCore.Components;

namespace AppsByTAP.BlazorFluentUI.Components.BaseComponent
{
    public class BaseComponentViewModel : ComponentBase
    {
        [Parameter]
        public string Style { get; set; } = "";
        [Parameter]
        public string ClassName { get; set; } = "";
        [Parameter]
        public string ID { get; set; } = "";
    }
}
