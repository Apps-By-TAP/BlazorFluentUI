using Microsoft.AspNetCore.Components;
using System;

namespace AppsByTAP.BlazorFluentUI.Components.ChoiceGroup
{
    public partial class ChoiceGroup : ComponentBase
    {
        [Parameter]
        public RenderFragment ChildContent { get; set; }

        public event Action SelectionChanged;

        public Choice SelectedChoice { get; set; }

        public void ChildSelected(Choice selectedChild)
        {
            SelectedChoice = selectedChild;
            SelectionChanged?.Invoke();
        }
    }
}
