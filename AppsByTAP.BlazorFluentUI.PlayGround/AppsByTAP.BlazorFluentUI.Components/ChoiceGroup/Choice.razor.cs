using Microsoft.AspNetCore.Components;
using System;

namespace AppsByTAP.BlazorFluentUI.Components.ChoiceGroup
{
    public partial class Choice<T> : ComponentBase
    {
        [Parameter]
        public T Value { get; set; }
        [CascadingParameter]
        public ChoiceGroup<T> Parent { get; set; }
        [Parameter]
        public RenderFragment ChildContent { get; set; }
        [Parameter]
        public bool IsSelected { get; set; }
        [Parameter]
        public EventCallback<bool> IsSelectedChanged { get; set; }

        protected override void OnInitialized()
        {
            if (Parent == null)
                throw new ArgumentNullException(nameof(Parent), "Choice must exist within a ChoiceGroup. Also, make sure the T of ChoiceGroup matched the data type of Value.");
            base.OnInitialized();

            Parent.Register(this);

            Parent.SelectionChanged_ChildUpdate += Parent_SelectionChanged_ChildUpdate;
        }


        private async void Parent_SelectionChanged_ChildUpdate()
        {
            IsSelected = Parent.SelectedChoice == this;
            await InvokeAsync(() => StateHasChanged());
        }
    }
}
