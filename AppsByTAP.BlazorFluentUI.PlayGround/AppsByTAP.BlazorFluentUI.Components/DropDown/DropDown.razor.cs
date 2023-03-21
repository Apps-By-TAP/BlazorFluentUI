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
    {//TODO: document.getElementById("1").parentNode.getBoundingClientRect()
        private T _selectedItem;
        [Parameter]
        public T SelectedItem
        {
            get => _selectedItem;
            set
            {
                if(value is null)
                {
                    _selectedItem = value;
                    _selectedDisplayText = "Select an option";
                    return;
                }

                if(_selectedItem is not null && _selectedItem.Equals(value)) { return; }

                _selectedItem = value;

                if(value is not null && !string.IsNullOrWhiteSpace(value.ToString()))
                {
                    _selectedDisplayText = value.ToString();
                }

                _displayDropDown = false;
            }
        }

        [Parameter]
        public EventCallback<T> SelectedItemChanged { get; set; }

        private List<T> _itemsSource;
        [Parameter]
        public List<T> ItemsSource 
        {
            get => _itemsSource;
            set
            {
                if(_itemsSource == value) { return; }

                _itemsSource = value;

                Items = value.Select(x => new DropDownItem<T>(x, (x is DropDownItem<T> ddi ? ddi.Type : DropDownItemType.Item), false)).ToList();

            }
        }

        protected List<DropDownItem<T>> Items { get; set; }

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
                if (value is null)
                {
                    _selectedItems = new List<T>();
                    _selectedDisplayText = "Select Options";
                    return;
                }

                if (_selectedItems is not null && _selectedItems.Equals(value)) { return; }

                _selectedItems = value;

                if(SelectedItems.Count > 0)
                {
                    _selectedDisplayText = SelectedItems.Select(x => x.ToString()).Aggregate((x, y) => $"{x}, {y}");


                    Items.ForEach(x => x.IsSelected = SelectedItems.Contains(x.Item));

                }
                else
                {
                    _selectedDisplayText = "Select Options";

                    Items.ForEach(x => x.IsSelected = false);
                }
            }
        }

        [Parameter]
        public EventCallback<IList<T>> SelectedItemsChanged { get; set; }
        [Parameter]
        public string Label { get; set; }
        [Parameter]
        public string Width { get; set; } = "300px";
        [Parameter]
        public bool OnClickStopPropagation { get; set; } = true;

        protected bool _displayDropDown = false;
        protected string _selectedDisplayText { get; set; } = "Select an option";
        protected bool _isOpen;

        protected override Task OnInitializedAsync()
        {
            if(IsMultiSelect)
            {
                _selectedDisplayText = "Select Options";
                SelectedItems = new List<T>();
            }

            return base.OnInitializedAsync();
        }

        protected async Task SelectItem(DropDownItem<T> selectedItem)
        {
            SelectedItem = selectedItem.Item;
            await SelectedItemChanged.InvokeAsync(selectedItem.Item);
            _isOpen = false;
        }

        protected async Task MultiSelectChanged(CheckBoxChangedArgs args)
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

            await SelectedItemsChanged.InvokeAsync(SelectedItems);
        }
    }
}
