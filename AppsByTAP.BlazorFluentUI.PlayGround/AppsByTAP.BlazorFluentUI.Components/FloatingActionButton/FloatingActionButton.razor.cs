using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace AppsByTAP.BlazorFluentUI.Components.FloatingActionButton
{
    public partial class FloatingActionButton
    {
        [Parameter]
        public bool BottomNavigationIsVisible { get; set; } = false;
        [Parameter]
        public string ImageUrl { get; set; } = "";
        [Parameter]
        public string Class { get; set; }
        [Parameter]
        public string Style { get; set; }
        [Parameter]
        public EventCallback<MouseEventArgs> OnClick { get; set; }
        [Parameter]
        public string ID { get; set; }
        [Parameter]
        public bool OnClickStopPropagation { get; set; } = true;
    }
}
