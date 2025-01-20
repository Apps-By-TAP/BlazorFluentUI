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
                ItemsSourceChanged.InvokeAsync(value);

                GenerateChips();
            }
        }
        [Parameter]
        public EventCallback<List<T>> ItemsSourceChanged { get; set; }

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
        [Parameter]
        public string Watermark { get; set; } = "Comma Separated Values";

        protected List<ChipViewModel> _chips = new List<ChipViewModel>();

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
                _itemsSource.RemoveAt(toRemove.GroupIndex);

                GenerateChips();
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

        private void GenerateChips()
        {
            _chips.Clear();
            for (int i = 0; i < _itemsSource.Count; i++)
            {
                _chips.Add(new ChipViewModel
                {
                    ChipType = ChipType,
                    Text = _itemsSource[i].ToString(),
                    ID = Guid.NewGuid().ToString(),
                    GroupIndex = i
                });
            }
        }
    }
}
