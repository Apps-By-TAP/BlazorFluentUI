using AppsByTAP.BlazorFluentUI.Components.Common;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AppsByTAP.BlazorFluentUI.Components.ChoiceGroup
{
    public partial class ChoiceGroup<T> : ComponentBase
    {
        [Parameter]
        public string Label { get; set; }
        [Parameter]
        public RenderFragment ChildContent { get; set; }
        [Parameter]
        public EventCallback<T> SelectionChanged { get; set; }

        private T _selectedItem;
        [Parameter]
        public T SelectedItem 
        {
            get => _selectedItem;
            set
            {
                if (_selectedItem.Equals(value) && SelectedChoice is not null) { return; }

                _selectedItem = value;
                SelectedItemChanged.InvokeAsync(value);

                SelectedChoice = _choises.FirstOrDefault(x => x.Value.Equals(value));
                SelectionChanged_ChildUpdate?.Invoke();
            }
        }
        [Parameter]
        public EventCallback<T> SelectedItemChanged { get; set; }
        [Parameter]
        public GroupDirection GroupDirection { get; set; } = GroupDirection.Vertical;

        public event Action SelectionChanged_ChildUpdate;

        private Choice<T> _selectedChoise;
        public Choice<T> SelectedChoice
        {
            get => _selectedChoise;
            set
            {
                if(_selectedChoise == value) { return; }

                _selectedChoise = value;
            }
        }

        private List<Choice<T>> _choises = new List<Choice<T>>();

        protected override void OnAfterRender(bool firstRender)
        {
            if (firstRender)
            {
                if (SelectedItem is not null)
                {
                    ChildSelected(_choises.FirstOrDefault(x => x.Value.Equals(SelectedItem)));
                }
            }
        }

        public void Register(Choice<T> child)
        {
            if(!_choises.Contains(child))
            {
                _choises.Add(child);
            }
        }

        public async void ChildSelected(Choice<T> selectedChild)
        {
            if(selectedChild is not null)
            {
                SelectedItem = selectedChild.Value;
                await SelectionChanged.InvokeAsync(selectedChild.Value);
            }
        }
    }
}
