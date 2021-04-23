using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppsByTAP.BlazorFluentUI.Components.DropDown
{
    public class DropDownViewModel<T> : ComponentBase
    {
        [Parameter]
        public T SelectedItem { get; set; }

        [Parameter]
        public EventCallback<T> SelectedItemChanged { get; set; }

        [Parameter]
        public List<T> ItemsSource { get; set; }

        [Parameter]
        public bool Disabled { get; set; }

        protected bool _displayDropDown = false;

        protected void OpenDropDown()
        {
            if(!Disabled)
            {
                _displayDropDown = !_displayDropDown;
            }
        }

        protected void Close()
        {
            _displayDropDown = false;
        }

        protected async Task SelectItem(T selectedItem)
        {
            SelectedItem = selectedItem;
            _displayDropDown = false;
            await SelectedItemChanged.InvokeAsync(selectedItem);
        }
    }
}
