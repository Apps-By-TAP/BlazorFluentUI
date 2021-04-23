namespace AppsByTAP.BlazorFluentUI.Components.DropDown
{
    public record DropDownItem
    {
        public object Item { get; set; }
        public DropDownItemType Type { get; set; }

        public DropDownItem(object item, DropDownItemType type)
        {
            Item = item;
            Type = type;
        }

        public override string ToString() => Item.ToString();
    }
}
