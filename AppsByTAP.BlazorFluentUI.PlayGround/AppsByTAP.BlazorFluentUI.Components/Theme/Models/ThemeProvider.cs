using System;
using AppsByTAP.BlazorFluentUI.Components.Theme.Themes;
using AppsByTAP.BlazorFluentUI.Components.Theme.Themes.Dark;
using AppsByTAP.BlazorFluentUI.Components.Theme.Themes.Light;

namespace AppsByTAP.BlazorFluentUI.Components.Theme.Models
{
    public class ThemeProvider : IThemeProvider
    {
        public event Action<Theme> ThemeChanged;

        private Theme _theme;

        public Theme Theme => _theme;

        public void ChangeTheme(Theme theme)
        {
            _theme = theme;

            ThemeChanged?.Invoke(_theme);
        }

        public ThemeProvider()
        {
            DarkThemePalette palette = new DarkThemePalette();

            _theme = CreateTheme(palette);
        }

        public Theme CreateTheme(IPalette palette)
        {
            bool isDark = palette is DarkThemePalette;

            return new Theme
            {
                Palette = palette,
                SemanticColors = CreateSemanticColorsFromPalette(palette, isDark),
                SemanticTextColors = CreateSemanticTextColorsFromPalette(palette, isDark)
            };
        }

        private static ISemanticColors CreateSemanticColorsFromPalette(IPalette palette, bool isDark)
        {
            return new LightSemanticColors()
            {
                BodyBackground = palette.White,
                BodyBackgroundHovered = palette.NeutralLighter,
                BodyBackgroundChecked = palette.NeutralLight,
                BodyStandoutBackground = palette.NeutralLighterAlt,
                BodyFrameBackground = palette.White,
                BodyFrameDivider = palette.NeutralLight,
                BodyDivider = palette.NeutralLight,
                DisabledBorder = palette.NeutralTertiaryAlt,
                FocusBorder = palette.NeutralSecondary,
                VariantBorder = palette.NeutralLight,
                VariantBorderHovered = palette.NeutralTertiary,
                DefaultStateBackground = palette.NeutralLighterAlt,

                // BUTTONS
                ButtonBackground = palette.White,
                ButtonBackgroundChecked = palette.NeutralTertiaryAlt,
                ButtonBackgroundHovered = palette.NeutralLighter,
                ButtonBackgroundCheckedHovered = palette.NeutralLight,
                ButtonBackgroundPressed = palette.NeutralLight,
                ButtonBackgroundDisabled = palette.NeutralLighter,
                ButtonBorder = palette.NeutralSecondaryAlt,
                ButtonBorderDisabled = palette.NeutralLighter,

                PrimaryButtonBackground = palette.ThemePrimary,
                PrimaryButtonBackgroundHovered = palette.ThemeDarkAlt,
                PrimaryButtonBackgroundPressed = palette.ThemeDark,
                PrimaryButtonBackgroundDisabled = palette.NeutralLighter,
                PrimaryButtonBorder = "transparent",

                AccentButtonBackground = palette.Accent,

                // INPUTS
                InputBorder = palette.NeutralSecondary,
                InputBorderHovered = palette.NeutralPrimary,
                InputBackground = palette.White,
                InputBackgroundChecked = palette.ThemePrimary,
                InputBackgroundCheckedHovered = palette.ThemeDark,
                InputPlaceholderBackgroundChecked = palette.ThemeLighter,
                InputForegroundChecked = palette.White,
                InputIcon = palette.ThemePrimary,
                InputIconHovered = palette.ThemeDark,
                InputIconDisabled = palette.NeutralTertiary,
                InputFocusBorderAlt = palette.ThemePrimary,
                SmallInputBorder = palette.NeutralSecondary,
                DisabledBackground = palette.NeutralLighter,

                // LISTS
                ListBackground = isDark ? palette.NeutralLighter : palette.White,
                ListItemBackgroundHovered = !isDark ? palette.NeutralLighter : palette.NeutralQuaternaryAlt,
                ListItemBackgroundChecked = palette.NeutralLight,
                ListItemBackgroundCheckedHovered = palette.NeutralQuaternaryAlt,

                ListHeaderBackgroundHovered = palette.NeutralLighter,
                ListHeaderBackgroundPressed = palette.NeutralLight,

                // MENUS
                MenuBackground = palette.White,
                MenuDivider = palette.NeutralTertiaryAlt,
                MenuIcon = palette.ThemePrimary,
                MenuHeader = palette.ThemePrimary,
                MenuItemBackgroundHovered = palette.NeutralLighter,
                MenuItemBackgroundPressed = palette.NeutralLight,

                ErrorBackground = !isDark ? "rgba(245, 135, 145, .2)" : "rgba(232, 17, 35, .5)",
                BlockingBackground = !isDark ? "rgba(250, 65, 0, .2)" : "rgba(234, 67, 0, .5)",
                WarningBackground = !isDark ? "rgba(255, 200, 10, .2)" : "rgba(255, 251, 0, .6)",
                WarningHighlight = !isDark ? "#ffb900" : "#fff100",
                SuccessBackground = !isDark ? "rgba(95, 210, 85, .2)" : "rgba(186, 216, 10, .4)",
            };
        }

        private static ISemanticTextColors CreateSemanticTextColorsFromPalette(IPalette palette, bool isDark)
        {
            return new LightSemanticTextColors()
            {
                BodyText = palette.NeutralPrimary,
                BodyTextChecked = palette.Black,
                BodySubtext = palette.NeutralSecondary,
                DisabledBodyText = palette.NeutralTertiary,
                DisabledBodySubtext = palette.NeutralTertiaryAlt,

                // LINKS
                ActionLink = palette.NeutralPrimary,
                ActionLinkHovered = palette.NeutralDark,
                Link = palette.ThemePrimary,
                LinkHovered = palette.ThemeDarker,

                // BUTTONS
                ButtonText = palette.NeutralPrimary,
                ButtonTextHovered = palette.NeutralDark,
                ButtonTextChecked = palette.NeutralDark,
                ButtonTextCheckedHovered = palette.Black,
                ButtonTextPressed = palette.NeutralDark,
                ButtonTextDisabled = palette.NeutralTertiary,

                PrimaryButtonText = palette.White,
                PrimaryButtonTextHovered = palette.White,
                PrimaryButtonTextPressed = palette.White,
                PrimaryButtonTextDisabled = palette.NeutralQuaternary,

                AccentButtonText = palette.White,

                // INPUTS
                InputText = palette.NeutralPrimary,
                InputTextHovered = palette.NeutralDark,
                InputPlaceholderText = palette.NeutralSecondary,
                DisabledText = palette.NeutralTertiary,
                DisabledSubtext = palette.NeutralQuaternary,

                // LISTS
                ListText = palette.NeutralPrimary,

                // MENUS
                MenuItemText = palette.NeutralPrimary,
                MenuItemTextHovered = palette.NeutralDark,

                ErrorText = !isDark ? palette.RedDark : "#ff5f5f",
                WarningText = !isDark ? "#333333" : "#ffffff",
                SuccessText = !isDark ? "#107C10" : "#92c353"
            };
        }
    }
}
