using Microsoft.AspNetCore.Components;

namespace AppsByTAP.BlazorFluentUI.Components.BaseComponent
{
    public abstract class BaseComponentViewModel : ComponentBase
    {
        [Parameter]
        public string Style { get; set; }
        [Parameter]
        public string ClassName { get; set; }
        [Parameter]
        public bool Required { get; set; } = false;

        public ValidationState ValidationState { get; set; } = ValidationState.Valid;

        public virtual bool Validate() => true;

    }
}
