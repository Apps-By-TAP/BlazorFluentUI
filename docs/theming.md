# Theming

BlazorFluentUI ships with a built-in theming system inspired by Fluent UI's design tokens. Themes are applied through CSS custom properties, so every component automatically responds to theme changes without re-rendering the entire tree.

## How It Works

1. **`IThemeProvider`** is registered as a service and holds the current `Theme` object.
2. The **`<Theme>`** Razor component wraps your application, reads the current theme from `IThemeProvider`, and generates CSS variables on the `:root` element.
3. Component stylesheets reference these CSS variables (e.g. `var(--palette-ThemePrimary)`) so they adapt to whatever theme is active.
4. When `IThemeProvider.ChangeTheme()` is called, the `ThemeChanged` event fires and the `<Theme>` component re-renders its CSS variables — all child components pick up the new colors instantly.

## Built-In Palettes

The library includes two palettes out of the box:

| Palette | Class | Description |
|---|---|---|
| Light | `LightThemePalette` | Standard light color scheme |
| Dark | `DarkThemePalette` | Standard dark color scheme |

## Setting Up a Theme

Register the theme provider in your `Program.cs`:

```csharp
using AppsByTAP.BlazorFluentUI.Components.Theme.Models;
using AppsByTAP.BlazorFluentUI.Components.Theme.Themes.Light;

builder.Services.AddSingleton<IThemeProvider>(new ThemeProvider(new LightThemePalette()));
```

Then wrap your app with the `<Theme>` component:

```razor
@using AppsByTAP.BlazorFluentUI.Components.Theme

<Theme>
    @Body
</Theme>
```

## Switching Themes at Runtime

Inject `IThemeProvider` into any component and call `ChangeTheme()`:

```razor
@using AppsByTAP.BlazorFluentUI.Components.Theme.Models
@using AppsByTAP.BlazorFluentUI.Components.Theme.Themes.Light
@using AppsByTAP.BlazorFluentUI.Components.Theme.Themes.Dark
@using AppsByTAP.BlazorFluentUI.Components.Toggle

@inject IThemeProvider ThemeProvider

<Toggle Label="Dark Mode" @bind-IsChecked="isDark" />

@code {
    private bool _isDark;

    private bool isDark
    {
        get => _isDark;
        set
        {
            _isDark = value;

            IPalette palette = value
                ? new DarkThemePalette()
                : new LightThemePalette();

            ThemeProvider.ChangeTheme(ThemeProvider.CreateTheme(palette));
        }
    }
}
```

## Theme Object Structure

A `Theme` object contains three parts:

```
Theme
├── Palette           (IPalette)          — raw color values
├── SemanticColors    (ISemanticColors)    — colors mapped to UI purposes
└── SemanticTextColors(ISemanticTextColors)— text colors mapped to UI purposes
```

### Palette (`IPalette`)

The palette defines the raw color tokens. Both `LightThemePalette` and `DarkThemePalette` implement `IPalette`. Key properties include:

| Property | Description |
|---|---|
| `ThemePrimary` | Primary brand color |
| `ThemeDarkAlt` | Slightly darker primary variant |
| `ThemeDark` | Darker primary variant |
| `ThemeDarker` | Darkest primary variant |
| `ThemeLight` | Light primary variant |
| `ThemeLighter` | Lighter primary variant |
| `ThemeLighterAlt` | Lightest primary variant |
| `NeutralPrimary` | Primary neutral color |
| `NeutralDark` | Dark neutral |
| `NeutralLight` | Light neutral |
| `NeutralLighter` | Lighter neutral |
| `NeutralLighterAlt` | Lightest neutral |
| `NeutralSecondary` | Secondary neutral |
| `NeutralSecondaryAlt` | Secondary neutral alternate |
| `NeutralTertiary` | Tertiary neutral |
| `NeutralTertiaryAlt` | Tertiary neutral alternate |
| `NeutralQuaternary` | Quaternary neutral |
| `NeutralQuaternaryAlt` | Quaternary neutral alternate |
| `Black` | Pure black |
| `White` | Pure white |
| `Accent` | Accent color |
| `RedDark` | Dark red for errors |

### Semantic Colors (`ISemanticColors`)

Semantic colors map palette values to specific UI purposes. They are generated automatically by `ThemeProvider.CreateTheme()`. Categories include:

| Category | Examples |
|---|---|
| **Body** | `BodyBackground`, `BodyBackgroundHovered`, `BodyStandoutBackground`, `BodyDivider` |
| **Buttons** | `ButtonBackground`, `ButtonBackgroundHovered`, `ButtonBackgroundPressed`, `ButtonBorder`, `PrimaryButtonBackground`, `PrimaryButtonBorder` |
| **Inputs** | `InputBorder`, `InputBorderHovered`, `InputBackground`, `InputBackgroundChecked`, `InputFocusBorderAlt`, `InputIcon` |
| **Lists** | `ListBackground`, `ListItemBackgroundHovered`, `ListItemBackgroundChecked` |
| **Menus** | `MenuBackground`, `MenuDivider`, `MenuIcon`, `MenuItemBackgroundHovered` |
| **Status** | `ErrorBackground`, `WarningBackground`, `SuccessBackground`, `WarningHighlight` |
| **Misc** | `DisabledBorder`, `FocusBorder`, `VariantBorder`, `ScrollbarTrack`, `ScrollbarThumb` |

### Semantic Text Colors (`ISemanticTextColors`)

Text-specific semantic colors. Categories include:

| Category | Examples |
|---|---|
| **Body** | `BodyText`, `BodyTextChecked`, `BodySubtext`, `DisabledBodyText` |
| **Links** | `ActionLink`, `ActionLinkHovered`, `Link`, `LinkHovered` |
| **Buttons** | `ButtonText`, `ButtonTextHovered`, `ButtonTextDisabled`, `PrimaryButtonText`, `AccentButtonText` |
| **Inputs** | `InputText`, `InputTextHovered`, `InputPlaceholderText`, `DisabledText` |
| **Lists** | `ListText` |
| **Menus** | `MenuItemText`, `MenuItemTextHovered` |
| **Status** | `ErrorText`, `WarningText`, `SuccessText` |

## CSS Variables

The `<Theme>` component generates CSS custom properties on `:root`. Variable names follow the pattern:

```
--palette-{PropertyName}
--semanticColors-{PropertyName}
--semanticTextColors-{PropertyName}
```

For example:

```css
:root {
    --palette-ThemePrimary: #0078d4;
    --semanticColors-ButtonBackground: #ffffff;
    --semanticTextColors-BodyText: #323130;
    /* ... */
}
```

You can reference these variables in your own CSS to stay consistent with the active theme:

```css
.my-custom-panel {
    background-color: var(--semanticColors-BodyBackground);
    color: var(--semanticTextColors-BodyText);
    border: 1px solid var(--semanticColors-VariantBorder);
}
```

## Creating a Custom Palette

To create a custom palette, implement the `IPalette` interface and provide your color values:

```csharp
using AppsByTAP.BlazorFluentUI.Components.Theme.Themes;

public class BrandPalette : IPalette
{
    public string ThemePrimary => "#e3008c";
    public string ThemeDarkAlt => "#c4007b";
    public string ThemeDark => "#a30068";
    // ... implement all IPalette properties
}
```

Then register it:

```csharp
builder.Services.AddSingleton<IThemeProvider>(new ThemeProvider(new BrandPalette()));
```

The `ThemeProvider` will automatically derive `SemanticColors` and `SemanticTextColors` from your palette.
