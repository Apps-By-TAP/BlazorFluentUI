using Microsoft.AspNetCore.Components;

namespace AppsByTAP.BlazorFluentUI.Components.Button
{
    public class CompoundButtonViewModel : ButtonBaseParameters
    {
        [Parameter]
        public string SecondaryText { get; set; }
    }
}
