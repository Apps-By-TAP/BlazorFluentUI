using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppsByTAP.BlazorFluentUI.Components.Button
{
    public class SplitButtonViewModel<T>: ButtonBaseParameters
    {
        [Parameter]
        public bool CanLightDismiss { get; set; }
        [Parameter]
        public string Width { get; set; }
        [Parameter]
        public T SelectedItem { get; set; }
        [Parameter]
        public EventCallback<T> SelectedItemChanged { get; set; }
        [Parameter]
        public List<T> ItemsSource { get; set; }
        [Parameter]
        public RenderFragment<T> SelectedItemTemplate { get; set; }
        [Parameter]
        public RenderFragment<T> DropDownTemplate { get; set; }

        protected readonly string _id = Guid.NewGuid().ToString();
        protected bool _isOpen;

        protected void Toggle()
        {
            _isOpen = !_isOpen;
        }

        protected async Task SelectItem(T item)
        {
            SelectedItem = item;
            await SelectedItemChanged.InvokeAsync(SelectedItem);
            _isOpen = false;
        }
    }
}
