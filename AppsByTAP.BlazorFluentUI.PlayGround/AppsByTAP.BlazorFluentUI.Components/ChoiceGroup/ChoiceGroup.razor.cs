using Microsoft.AspNetCore.Components;
using System;

namespace AppsByTAP.BlazorFluentUI.Components.ChoiceGroup
{
    public partial class ChoiceGroup<T> : ComponentBase
    {
        [Parameter]
        public RenderFragment ChildContent { get; set; }
        [Parameter]
        public EventCallback<T> SelectionChanged { get; set; }

        public event Action SelectionChanged_ChildUpdate;

        public Choice<T> SelectedChoice { get; set; }

        public async void ChildSelected(Choice<T> selectedChild)
        {
            SelectedChoice = selectedChild;
            SelectionChanged_ChildUpdate?.Invoke();
            await SelectionChanged.InvokeAsync(selectedChild.Value);
        }
    }
}
