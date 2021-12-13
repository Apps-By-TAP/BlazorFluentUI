using Microsoft.AspNetCore.Components;
using System;

namespace AppsByTAP.BlazorFluentUI.Components.ChoiceGroup
{
    public partial class Choice : ComponentBase
    {
        [CascadingParameter]
        public ChoiceGroup Parent { get; set; }
        [Parameter]
        public RenderFragment ChildContent { get; set; }
        [Parameter]
        public bool IsSelected { get; set; }
        [Parameter]
        public EventCallback<bool> IsSelectedChanged { get; set; }

        protected override void OnInitialized()
        {
            if (Parent == null)
                throw new ArgumentNullException(nameof(Parent), "TabPage must exist within a TabControl");
            base.OnInitialized();

            Parent.SelectionChanged += Parent_SelectionChanged;
        }


        private async void Parent_SelectionChanged()
        {
            IsSelected = Parent.SelectedChoice == this;
            await InvokeAsync(() => StateHasChanged());
        }
    }
}
