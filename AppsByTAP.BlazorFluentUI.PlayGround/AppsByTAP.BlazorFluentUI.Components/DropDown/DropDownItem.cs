namespace AppsByTAP.BlazorFluentUI.Components.DropDown
{
    public record DropDownItem<T>
    {
        public T Item { get; set; }
        public DropDownItemType Type { get; set; }

        public DropDownItem(T item, DropDownItemType type)
        {
            Item = item;
            Type = type;
        }

        public override string ToString() => Item.ToString();
    }
}
