using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using AppsByTAP.BlazorFluentUI.Components.Common;
using System.Linq;

namespace AppsByTAP.BlazorFluentUI.Components.CheckboxGroup
{
    public partial class CheckboxGroup<T> : ComponentBase
    {
        private List<T> _itemsSource = new List<T>();
        [Parameter]
        public List<T> ItemsSource 
        {
            get => _itemsSource;
            set
            {
                if(_itemsSource == value) { return; }

                _itemsSource = value;
                _internalItemsSource = value.Select(x => new ItemWrapper<T>(x)).ToList();
            }
        }

        private List<T> _selectedItems = new List<T>();
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
        public string Height { get; set; } = "fit-content";
        [Parameter]
        public string Label { get; set; }

        private List<ItemWrapper<T>> _internalItemsSource = new List<ItemWrapper<T>>();

        protected override void OnParametersSet()
        {
            _internalItemsSource.ForEach(x => x.IsSelected = false);

            if(SelectedItems is not null)
            {
                foreach (T item in SelectedItems)
                {
                    ItemWrapper<T> temp = _internalItemsSource.FirstOrDefault(x => x.Item.Equals(item));

                    if (temp is not null)
                    {
                        temp.IsSelected = true;
                    }
                }
            }
        }

        private void CheckChanged(bool isChecked, ItemWrapper<T> value)
        {
            List<ItemWrapper<T>> temp = new List<ItemWrapper<T>>(_internalItemsSource);

            if (isChecked)
            {
                value.IsSelected = true;
            }
            else
            {
                value.IsSelected = false;
            }

            SelectedItems = temp.Where(x => x.IsSelected).Select(x => x.Item).ToList();

            SelectedItemsChanged.InvokeAsync(SelectedItems);
        }
    }

    class ItemWrapper<T>
    {
        public T Item { get; set; }
        public bool IsSelected { get; set; }

        public ItemWrapper(T item)
        {
            Item = item;
            IsSelected = false;
        }
    }
}
