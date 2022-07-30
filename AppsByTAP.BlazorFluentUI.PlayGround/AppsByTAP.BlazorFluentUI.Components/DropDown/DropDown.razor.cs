using AppsByTAP.BlazorFluentUI.Components.CheckBox;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace AppsByTAP.BlazorFluentUI.Components.DropDown
{
    public class DropDownViewModel<T> : InputBase<string>
    {//TODO: document.getElementById("1").parentNode.getBoundingClientRect()
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
            }
        }

        private EventCallback<T> _selectedItemChanged;
        [Parameter]
        public EventCallback<T> SelectedItemChanged 
        {
            get => _selectedItemChanged;
            set
            {
                _selectedItemChanged = value;
            }
        }

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
        public bool Required { get; set; }
        [Parameter]
        public string ClassName { get; set; }
        [Parameter]
        public string Style { get; set; }


        protected bool _displayDropDown = false;
        protected string _selectedDisplayText { get; set; } = "Select an option";

        private bool _isOpen;
        protected bool IsOpen
        {
            get => _isOpen;
            set
            {
                _isOpen = value;
            }
        }

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
            IsOpen = false;
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

        //public override bool Validate()
        //{
        //    bool isValid = IsMultiSelect ? SelectedItems is not null && SelectedItems.Count > 0 : SelectedItem is not null;
        //    ValidationState = isValid ? ValidationState.Valid : ValidationState.Invalid;

        //    return isValid;
        //}

        protected override bool TryParseValueFromString(string value, [MaybeNullWhen(false)] out string result, [NotNullWhen(false)] out string validationErrorMessage)
        {
            validationErrorMessage = "";

            if (IsMultiSelect)
            {
                result = string.Join(',', SelectedItems) ?? "";
            }
            else
            {
                result = SelectedItem.ToString() ?? "";
            }

            if (Required)
            {
                if(string.IsNullOrEmpty(result))
                {
                    validationErrorMessage = "Please select a value";
                    return false;
                }

                return true;
            }
            else
            {
                return true;
            }
        }
    }
}
