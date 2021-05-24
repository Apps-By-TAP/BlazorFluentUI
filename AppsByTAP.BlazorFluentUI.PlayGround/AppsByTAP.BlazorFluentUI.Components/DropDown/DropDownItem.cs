namespace AppsByTAP.BlazorFluentUI.Components.DropDown
{
    public class DropDownItem<T>
    {
        public T Item { get; set; }
        public DropDownItemType Type { get; set; }
        public bool IsSelected { get; set; }

        public DropDownItem(T item, DropDownItemType type, bool isSelected = false)
        {
            Item = item;
            Type = type;
            IsSelected = isSelected;
        }

        public override string ToString() => Item.ToString();
    }
}
