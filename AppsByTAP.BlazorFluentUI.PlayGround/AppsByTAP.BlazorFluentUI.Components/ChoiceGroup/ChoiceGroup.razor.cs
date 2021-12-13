using Microsoft.AspNetCore.Components;
using System;

namespace AppsByTAP.BlazorFluentUI.Components.ChoiceGroup
{
    public partial class ChoiceGroup<T> : ComponentBase
    {
        [Parameter]
        public RenderFragment ChildContent { get; set; }

        public event Action SelectionChanged;

        public Choice<T> SelectedChoice { get; set; }

        public void ChildSelected(Choice<T> selectedChild)
        {
            SelectedChoice = selectedChild;
            SelectionChanged?.Invoke();
        }
    }
}
