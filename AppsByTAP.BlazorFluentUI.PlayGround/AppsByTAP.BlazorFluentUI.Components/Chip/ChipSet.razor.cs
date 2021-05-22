using AppsByTAP.BlazorFluentUI.Components.BaseComponent;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AppsByTAP.BlazorFluentUI.Components.Chip
{
    public class ChipSetViewModel<T> : BaseComponentViewModel
    {
        [Parameter]
        public ChipType ChipType { get; set; }
        
        private List<T> _itemsSource;
        [Parameter]
        public List<T> ItemsSource 
        {
            get => _itemsSource;
            set
            {
                if(_itemsSource == value) { return; }

                _itemsSource = value;

                _chips = _itemsSource.Select(x => new ChipViewModel
                {
                    ChipType = ChipType,
                    Text = x.ToString(),
                    ID = Guid.NewGuid().ToString()
                }).ToList();
            }
        }

        [Parameter]
        public T SelectedItem { get; set; }
        [Parameter]
        public List<T> SelectedItems { get; set; }
        [Parameter]
        public SelectionType SelectionType { get; set; } = SelectionType.Single;
        [Parameter]
        public string Label { get; set; }
        [Parameter]
        public Func<string, T> CreateNewItem { get; set; }

        protected List<ChipViewModel> _chips;

        private string _nextChipText = "";
        protected string NextChipText
        {
            get => _nextChipText;
            set
            {
                if (_nextChipText == value) { return; }

                _nextChipText = value;

                NextNoteOnChanged();
            }
        }

        protected override void OnInitialized()
        {
            base.OnInitialized();

            if (ItemsSource is null)
            {
                ItemsSource = new List<T>();
            }

            if (SelectedItems is null)
            {
                SelectedItems = new List<T>();
            }
        }

        protected void RemoveChip(string id)
        {
            ChipViewModel toRemove = _chips.FirstOrDefault(x => x.ID == id);

            if(toRemove is not null)
            {
                _chips.Remove(toRemove);
            }
        }

        protected void EditChip(string id)
        {

        }

        protected void NextNoteOnChanged()
        {
            string str = _nextChipText;
            if (str.Contains(','))
            {
                int index = str.IndexOf(',');
                string sub = str.Substring(0, index);

                if(CreateNewItem is not null)
                {
                    T newItem = CreateNewItem.Invoke(sub);

                    if (newItem is not null)
                    {
                        List<T> temp = new List<T>(ItemsSource);
                        temp.Add(newItem);
                        ItemsSource = temp;

                        _nextChipText = "";
                    }
                }

            }
        }
    }
}
