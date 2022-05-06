using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using AppsByTAP.BlazorFluentUI.Components.Common;

namespace AppsByTAP.BlazorFluentUI.Components.CheckboxGroup
{
    public partial class CheckboxGroup<T> : ComponentBase
    {
        [Parameter]
        public List<T> ItemsSource { get; set; }
        [Parameter]
        public List<T> SelectedItems { get; set; } = new List<T>();
        [Parameter]
        public EventCallback<List<T>> SelectedItemsChanged { get; set; }
        [Parameter]
        public bool UseToggleSwitches { get; set; }
        [Parameter]
        public GroupDirection GroupDirection { get; set; } = GroupDirection.Vertical;
        [Parameter]
        public bool WrapItems { get; set; }
        [Parameter]
        public string Width { get; set; } = "auto";
        [Parameter]
        public string Height { get; set; } = "auto";
        [Parameter]
        public string Label { get; set; }

        private void CheckChanged(bool isChecked, T value)
        {
            if(isChecked)
            {
                SelectedItems.Add(value);
            }
            else
            {
                SelectedItems.Remove(value);
            }

            SelectedItemsChanged.InvokeAsync(SelectedItems);
        }
    }
}
