namespace AppsByTAP.BlazorFluentUI.Components.Theme.Themes.Dark
{
    public class DarkSemanticColors : LightSemanticColors
    {
        public DarkSemanticColors(IPalette palette)
        {
            DisabledBackground = palette.NeutralQuaternaryAlt;
            InputBackgroundChecked = palette.ThemePrimary;
            MenuBackground = palette.NeutralLighter;
            MenuItemBackgroundHovered = palette.NeutralQuaternaryAlt;
            MenuItemBackgroundPressed = palette.NeutralQuaternary;
            MenuDivider = palette.NeutralTertiaryAlt;
            MenuIcon = palette.ThemeDarkAlt;
            MenuHeader = palette.Black;
        }
    }
}
