using Microsoft.AspNetCore.Components;
using System;
using System.Threading.Tasks;

namespace AppsByTAP.BlazorFluentUI.Components.Tabs
{
    public partial class Tab : ComponentBase
    {
        [CascadingParameter]
        private Tabs Parent { get; set; }
        [Parameter]
        public RenderFragment ChildContent { get; set; }

        [Parameter]
        public string Header { get; set; }

        [Parameter]
        public string Color { get; set; } = "var(--semanticColors-ButtonText)";

        private string _viewState;
        private double _left = -40;
        private int _opacity;

        protected override void OnInitialized()
        {
            if (Parent == null)
                throw new ArgumentNullException(nameof(Parent), "TabPage must exist within a TabControl");
            base.OnInitialized();

            Parent.SelectionChanged += Parent_SelectionChanged;
            Parent.AddPage(this);
        }

        private async void Parent_SelectionChanged()
        {
            if(Parent.LastTab == this)
            {
                //_viewState = await Delay();
                _opacity = 0;
                _left = -40;
            }
            else
            {
                //_viewState = "block";
                await Task.Delay(100);
                _opacity = 1;
                _left = 0;
            }
            StateHasChanged();
        }

        private async Task<string> Delay()
        {
            await Task.Delay(300);
            return "none";
        }
    }
}
