using AppsByTAP.BlazorFluentUI.Components.Theme.Themes.Light;

namespace AppsByTAP.BlazorFluentUI.Components.Theme.Themes.Dark
{
    public class DarkSemanticTextColors : LightSemanticTextColors
    {
        public DarkSemanticTextColors(IPalette palette)
        {
            ButtonText = palette.Black;
            ButtonTextPressed = palette.NeutralDark;
            ButtonTextHovered = palette.NeutralPrimary;
            BodySubtext = palette.Black;

            MenuItemText = palette.NeutralPrimary;
            MenuItemTextHovered = palette.NeutralDark;
        }
    }
}
