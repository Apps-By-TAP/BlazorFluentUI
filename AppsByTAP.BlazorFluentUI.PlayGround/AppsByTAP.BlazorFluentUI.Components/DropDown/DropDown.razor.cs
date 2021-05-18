using AppsByTAP.BlazorFluentUI.Components.BaseComponent;
using AppsByTAP.BlazorFluentUI.Components.CheckBox;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppsByTAP.BlazorFluentUI.Components.DropDown
{
    public class DropDownViewModel<T> : BaseComponentViewModel
    {
        private T _selectedItem;
        [Parameter]
        public T SelectedItem
        {
            get => _selectedItem;
            set
            {
                if(_selectedItem is not null && _selectedItem.Equals(value)) { return; }

                _selectedItem = value;

                if(value is not null && !string.IsNullOrWhiteSpace(value.ToString()))
                {
                    _selectedDisplayText = value.ToString();
                }

                _displayDropDown = false;
                Task.Run(async () => await SelectedItemChanged.InvokeAsync(value));
            }
        }

        [Parameter]
        public EventCallback<T> SelectedItemChanged { get; set; }

        [Parameter]
        public List<T> ItemsSource { get; set; }

        [Parameter]
        public bool Disabled { get; set; }
        [Parameter]
        public bool IsMultiSelect { get; set; }

        private IList<T> _selectedItems;
        [Parameter]
        public IList<T> SelectedItems
        {
            get => _selectedItems;
            set
            {
                if (_selectedItems is not null && _selectedItems.Equals(value)) { return; }

                _selectedItems = value;

                if(SelectedItems.Count > 0)
                {
                    _selectedDisplayText = SelectedItems.Select(x => x.ToString()).Aggregate((x, y) => $"{x}, {y}");
                }
                else
                {
                    _selectedDisplayText = "Select Options";
                }

                Task.Run(async () => await SelectedItemsChanged.InvokeAsync(value));
            }
        }

        [Parameter]
        public EventCallback<IList<T>> SelectedItemsChanged { get; set; }

        protected bool _displayDropDown = false;
        protected string _selectedDisplayText { get; set; } = "Select an option";

        public override Task SetParametersAsync(ParameterView parameters)
        {
            bool isMulti = false;
            parameters.TryGetValue(nameof(IsMultiSelect), out isMulti);

            if(isMulti)
            {
                _selectedDisplayText = "Select Options";
                SelectedItems = new List<T>();
            }

            return base.SetParametersAsync(parameters);
        }

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
        }

        protected void MultiSelectChanged(CheckBoxChangedArgs args)
        {
            T tempItem = ItemsSource.FirstOrDefault(x => x.ToString() == args.ViewModel.Label);

            if(tempItem is not null && args.IsChecked)
            {
                IList<T> temp = SelectedItems;
                temp.Add(tempItem);
                SelectedItems = new List<T>(temp);
            }
            else if(tempItem is not null)
            {
                IList<T> temp = SelectedItems;
                temp.Remove(tempItem);
                SelectedItems = new List<T>(temp);
            }
        }
    }
}
