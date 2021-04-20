using AppsByTAP.BlazorFluentUI.Components.Theme.Themes;

namespace AppsByTAP.BlazorFluentUI.Components.Theme.Models
{
    public class Theme
    {
        public IPalette Palette { get; set; }
        public ISemanticTextColors SemanticTextColors { get; set; }
        public ISemanticColors SemanticColors { get; set; }
    }
}
