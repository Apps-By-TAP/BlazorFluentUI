# Theming Guide — AppsByTAP.BlazorFluentUI

The library uses a CSS custom property-based theme system inspired by Microsoft Fluent UI. All components automatically respond to theme changes.

## Architecture

```
IThemeProvider (singleton service)
├── Theme
│   ├── IPalette              — 52 raw color tokens
│   ├── ISemanticColors       — 60+ role-based background/border colors
│   └── ISemanticTextColors   — 30+ role-based text colors
└── Events
    └── ThemeChanged(Theme)   — notifies components of theme changes
```

The `<Theme>` component uses reflection to convert all palette, semantic color, and semantic text color properties into CSS custom properties on `:root`.

---

## Setup

### 1. Register the Service

```csharp
// Program.cs (.NET 6+)
builder.Services.AddSingleton<IThemeProvider, ThemeProvider>();
```

### 2. Wrap Your App

In your root layout or `App.razor`:

```razor
@using AppsByTAP.BlazorFluentUI.Components.Theme

<Theme>
    @Body
</Theme>
```

**Default theme is Dark.** The `ThemeProvider()` parameterless constructor uses `DarkThemePalette`.

---

## Switching Themes at Runtime

```razor
@using AppsByTAP.BlazorFluentUI.Components.Theme.Models
@using AppsByTAP.BlazorFluentUI.Components.Theme.Themes.Light
@using AppsByTAP.BlazorFluentUI.Components.Theme.Themes.Dark

@inject IThemeProvider ThemeProvider

@code {
    private bool _isDark = true;

    private void ToggleTheme()
    {
        var palette = _isDark ? (IPalette)new LightThemePalette() : new DarkThemePalette();
        ThemeProvider.ChangeTheme(ThemeProvider.CreateTheme(palette));
        _isDark = !_isDark;
    }
}
```

---

## Built-in Palettes

### Light Theme (`LightThemePalette`)

| Token | Value | Usage |
|-------|-------|-------|
| `ThemePrimary` | `#0078d4` | Primary brand color (Microsoft Blue) |
| `ThemeDark` | `#005a9e` | Darker brand shade |
| `ThemeDarkAlt` | `#106ebe` | Alternative dark brand |
| `ThemeLight` | `#c7e0f4` | Light brand variant |
| `Black` | `#000000` | Pure black |
| `White` | `#ffffff` | Pure white (background) |
| `NeutralPrimary` | `#323130` | Primary text color |
| `NeutralSecondary` | `#605e5c` | Secondary text |
| `NeutralLight` | `#edebe9` | Light borders |
| `NeutralLighter` | `#f3f2f1` | Hover backgrounds |
| `Accent` | `#0078d4` | Accent color |
| `Red` | `#e81123` | Error/danger |
| `Green` | `#107c10` | Success |
| `Yellow` | `#ffb900` | Warning |
| `Orange` | `#d83b01` | Severe warning |

### Dark Theme (`DarkThemePalette`)

| Token | Value | Usage |
|-------|-------|-------|
| `ThemePrimary` | `#2899f5` | Lighter blue for dark backgrounds |
| `Black` | `#ffffff` | Inverted: white text on dark |
| `White` | `#1b1a19` | Inverted: dark background |
| `NeutralPrimary` | `#f3f2f1` | Light text for readability |
| `NeutralLight` | `#292827` | Dark borders |
| `NeutralLighter` | `#252423` | Slightly lighter dark bg |
| `Accent` | `#2899f5` | Bright accent for dark mode |

---

## CSS Custom Properties

The `<Theme>` component generates three sets of CSS custom properties on `:root`:

### Palette Variables (`--palette-*`)

```css
var(--palette-ThemePrimary)      /* #0078d4 or #2899f5 */
var(--palette-ThemeDark)
var(--palette-ThemeDarkAlt)
var(--palette-ThemeSecondary)
var(--palette-ThemeTertiary)
var(--palette-ThemeLight)
var(--palette-ThemeLighter)
var(--palette-ThemeLighterAlt)
var(--palette-Black)
var(--palette-White)
var(--palette-NeutralDark)
var(--palette-NeutralPrimary)
var(--palette-NeutralSecondary)
var(--palette-NeutralTertiary)
var(--palette-NeutralLight)
var(--palette-NeutralLighter)
var(--palette-NeutralLighterAlt)
var(--palette-Accent)
var(--palette-Red)
var(--palette-RedDark)
var(--palette-Green)
var(--palette-GreenDark)
var(--palette-Yellow)
var(--palette-Orange)
var(--palette-Blue)
var(--palette-Purple)
var(--palette-Teal)
var(--palette-Magenta)
/* ... and all 52 palette properties */
```

### Semantic Color Variables (`--semanticColors-*`)

These are role-based colors derived from the palette:

```css
/* Backgrounds */
var(--semanticColors-BodyBackground)
var(--semanticColors-BodyBackgroundHovered)
var(--semanticColors-BodyBackgroundChecked)
var(--semanticColors-BodyStandoutBackground)
var(--semanticColors-BodyFrameBackground)

/* Buttons */
var(--semanticColors-ButtonBackground)
var(--semanticColors-ButtonBackgroundHovered)
var(--semanticColors-ButtonBackgroundPressed)
var(--semanticColors-ButtonBackgroundDisabled)
var(--semanticColors-ButtonBackgroundChecked)
var(--semanticColors-ButtonBorder)
var(--semanticColors-ButtonBorderDisabled)
var(--semanticColors-PrimaryButtonBackground)
var(--semanticColors-PrimaryButtonBackgroundHovered)
var(--semanticColors-PrimaryButtonBackgroundPressed)
var(--semanticColors-PrimaryButtonBackgroundDisabled)
var(--semanticColors-PrimaryButtonBorder)
var(--semanticColors-AccentButtonBackground)

/* Inputs */
var(--semanticColors-InputBorder)
var(--semanticColors-InputBorderHovered)
var(--semanticColors-InputBackground)
var(--semanticColors-InputBackgroundChecked)
var(--semanticColors-InputBackgroundCheckedHovered)
var(--semanticColors-InputForegroundChecked)
var(--semanticColors-InputFocusBorderAlt)
var(--semanticColors-InputIcon)
var(--semanticColors-InputIconHovered)
var(--semanticColors-InputIconDisabled)
var(--semanticColors-DisabledBackground)

/* Borders */
var(--semanticColors-FocusBorder)
var(--semanticColors-VariantBorder)
var(--semanticColors-VariantBorderHovered)
var(--semanticColors-DisabledBorder)

/* Lists */
var(--semanticColors-ListBackground)
var(--semanticColors-ListItemBackgroundHovered)
var(--semanticColors-ListItemBackgroundChecked)
var(--semanticColors-ListItemBackgroundCheckedHovered)

/* Menus */
var(--semanticColors-MenuBackground)
var(--semanticColors-MenuDivider)
var(--semanticColors-MenuIcon)
var(--semanticColors-MenuHeader)
var(--semanticColors-MenuItemBackgroundHovered)
var(--semanticColors-MenuItemBackgroundPressed)

/* Status */
var(--semanticColors-ErrorBackground)
var(--semanticColors-BlockingBackground)
var(--semanticColors-WarningBackground)
var(--semanticColors-WarningHighlight)
var(--semanticColors-SuccessBackground)

/* Scrollbar */
var(--semanticColors-ScrollbarTrack)
var(--semanticColors-ScrollbarThumb)

/* Dividers */
var(--semanticColors-BodyDivider)
var(--semanticColors-BodyFrameDivider)
```

### Semantic Text Color Variables (`--semanticTextColors-*`)

```css
/* Body text */
var(--semanticTextColors-BodyText)
var(--semanticTextColors-BodyTextChecked)
var(--semanticTextColors-BodySubtext)
var(--semanticTextColors-DisabledBodyText)
var(--semanticTextColors-DisabledBodySubtext)

/* Links */
var(--semanticTextColors-Link)
var(--semanticTextColors-LinkHovered)
var(--semanticTextColors-ActionLink)
var(--semanticTextColors-ActionLinkHovered)

/* Buttons */
var(--semanticTextColors-ButtonText)
var(--semanticTextColors-ButtonTextHovered)
var(--semanticTextColors-ButtonTextChecked)
var(--semanticTextColors-ButtonTextCheckedHovered)
var(--semanticTextColors-ButtonTextPressed)
var(--semanticTextColors-ButtonTextDisabled)
var(--semanticTextColors-PrimaryButtonText)
var(--semanticTextColors-PrimaryButtonTextHovered)
var(--semanticTextColors-PrimaryButtonTextPressed)
var(--semanticTextColors-PrimaryButtonTextDisabled)
var(--semanticTextColors-AccentButtonText)

/* Inputs */
var(--semanticTextColors-InputText)
var(--semanticTextColors-InputTextHovered)
var(--semanticTextColors-InputPlaceholderText)
var(--semanticTextColors-DisabledText)
var(--semanticTextColors-DisabledSubtext)

/* Lists & Menus */
var(--semanticTextColors-ListText)
var(--semanticTextColors-MenuItemText)
var(--semanticTextColors-MenuItemTextHovered)

/* Status */
var(--semanticTextColors-ErrorText)
var(--semanticTextColors-WarningText)
var(--semanticTextColors-SuccessText)
```

---

## Creating a Custom Palette

### Option A: Inherit and Override

```csharp
using AppsByTAP.BlazorFluentUI.Components.Theme.Themes.Light;

public class BrandPalette : LightThemePalette
{
    public override string ThemePrimary => "#6200ee";
    public override string ThemeDark => "#3700b3";
    public override string ThemeDarkAlt => "#5300d6";
    public override string ThemeSecondary => "#7c4dff";
    public override string Accent => "#03dac6";
    // All other colors inherit from LightThemePalette
}
```

### Option B: Implement the Full Interface

```csharp
using AppsByTAP.BlazorFluentUI.Components.Theme.Themes;

public class FullCustomPalette : IPalette
{
    public string ThemeDarker => "#...";
    public string ThemeDark => "#...";
    public string ThemeDarkAlt => "#...";
    public string ThemePrimary => "#...";
    public string ThemeSecondary => "#...";
    public string ThemeTertiary => "#...";
    public string ThemeLight => "#...";
    public string ThemeLighter => "#...";
    public string ThemeLighterAlt => "#...";
    public string Black => "#000000";
    public string BlackTranslucent40 => "rgba(0,0,0,.4)";
    public string NeutralDark => "#...";
    public string NeutralPrimary => "#...";
    public string NeutralPrimaryAlt => "#...";
    public string NeutralSecondary => "#...";
    public string NeutralSecondaryAlt => "#...";
    public string NeutralTertiary => "#...";
    public string NeutralTertiaryAlt => "#...";
    public string NeutralQuaternary => "#...";
    public string NeutralQuaternaryAlt => "#...";
    public string NeutralLight => "#...";
    public string NeutralLighter => "#...";
    public string NeutralLighterAlt => "#...";
    public string Accent => "#...";
    public string White => "#ffffff";
    public string WhiteTranslucent40 => "rgba(255,255,255,.4)";
    // ... plus all status colors (Red, Green, Yellow, etc.)
}
```

### Apply Any Custom Palette

```csharp
@inject IThemeProvider ThemeProvider

@code {
    private void ApplyBrand()
    {
        ThemeProvider.ChangeTheme(ThemeProvider.CreateTheme(new BrandPalette()));
    }
}
```

The `ThemeProvider.CreateTheme(IPalette)` method automatically builds semantic and text colors from the palette. It detects if the palette is `DarkThemePalette` to apply dark-mode-specific logic.

---

## Using Theme Variables in Custom CSS

### In Scoped CSS (`.razor.css`)

```css
.my-card {
    background-color: var(--semanticColors-BodyStandoutBackground);
    color: var(--semanticTextColors-BodyText);
    border: 1px solid var(--semanticColors-VariantBorder);
    padding: 16px;
    border-radius: 4px;
}

.my-card:hover {
    background-color: var(--semanticColors-BodyBackgroundHovered);
    border-color: var(--semanticColors-VariantBorderHovered);
}

.error-banner {
    background-color: var(--semanticColors-ErrorBackground);
    color: var(--semanticTextColors-ErrorText);
}

.success-banner {
    background-color: var(--semanticColors-SuccessBackground);
    color: var(--semanticTextColors-SuccessText);
}
```

### In Inline Styles

```razor
<div style="background-color: var(--palette-ThemePrimary); color: var(--palette-White); padding: 8px;">
    Branded header
</div>
```

### Custom Scrollbar Styling

```css
::-webkit-scrollbar {
    width: 8px;
}
::-webkit-scrollbar-track {
    background: var(--semanticColors-ScrollbarTrack);
}
::-webkit-scrollbar-thumb {
    background: var(--semanticColors-ScrollbarThumb);
}
```

---

## IThemeProvider API

```csharp
public interface IThemeProvider
{
    Theme Theme { get; }                        // Current theme
    event Action<Theme> ThemeChanged;           // Subscribe to changes
    void ChangeTheme(Theme theme);              // Apply a new theme
    Theme CreateTheme(IPalette palette);        // Build theme from palette
}
```

### Registering a Custom Default Theme

To start with light theme instead of dark:

```csharp
builder.Services.AddSingleton<IThemeProvider>(new ThemeProvider(new LightThemePalette()));
```

Or with a brand palette:

```csharp
builder.Services.AddSingleton<IThemeProvider>(new ThemeProvider(new BrandPalette()));
```

---

## Label-Specific Theme Variables

The theme also generates two label-specific variables:

```css
var(--label-font-weight)    /* 600 */
var(--label-padding-bottom) /* 5px */
```

These are used by `Label` and other components with built-in labels.
