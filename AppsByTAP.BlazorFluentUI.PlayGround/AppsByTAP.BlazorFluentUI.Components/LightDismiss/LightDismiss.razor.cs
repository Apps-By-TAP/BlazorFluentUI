using Microsoft.AspNetCore.Components;

namespace AppsByTAP.BlazorFluentUI.Components.LightDismiss
{
    public partial class LightDismiss : ComponentBase
    {
        [Parameter]
        public bool IsOpen { get; set; }
        [Parameter]
        public EventCallback<bool> IsOpenChanged { get; set; }
        [Parameter]
        public EventCallback OnClose { get; set; }
        [Parameter]
        public int Layer { get; set; } = -1;

        protected void Close()
        {
            IsOpen = false;
            IsOpenChanged.InvokeAsync(IsOpen);
            OnClose.InvokeAsync();
        }
    }
}
