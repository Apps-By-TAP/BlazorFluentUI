using Microsoft.AspNetCore.Components;

namespace AppsByTAP.BlazorFluentUI.Components.Button
{
    public class TemplateButtonViewModel : ButtonBaseParameters
    {
        [Parameter]
        public RenderFragment ChildContent { get; set; }
        [Parameter]
        public string Border { get; set; } = "1px solid var(--semanticColors-ButtonBorder)";
        [Parameter]
        public string BorderRadius { get; set; } = "2px";
    }
}
