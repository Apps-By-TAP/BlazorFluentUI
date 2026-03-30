# 08 — Theming

```
Namespace: AppsByTAP.BlazorFluentUI.Components.Theme
         AppsByTAP.BlazorFluentUI.Components.Theme.Models
         AppsByTAP.BlazorFluentUI.Components.Theme.Themes.Light
         AppsByTAP.BlazorFluentUI.Components.Theme.Themes.Dark
```

---

## How It Works

1. **`IThemeProvider`** is registered as a singleton service and holds the current `Theme` object.
2. The `<Theme>` Razor component wraps the application, reads from `IThemeProvider`, and writes CSS custom properties onto `:root`.
3. All component stylesheets reference those variables (e.g. `var(--palette-ThemePrimary)`).
4. Calling `IThemeProvider.ChangeTheme()` fires `ThemeChanged`, causing `<Theme>` to regenerate the CSS variables — every component updates without re-rendering the full tree.

---

## Built-In Palettes

| Palette class | Description |
|---|---|
| `LightThemePalette` | Standard light color scheme |
| `DarkThemePalette` | Standard dark color scheme |

---

## Registering the Theme (Program.cs)

```csharp
using AppsByTAP.BlazorFluentUI.Components.Theme.Models;
using AppsByTAP.BlazorFluentUI.Components.Theme.Themes.Light;

// Light theme (default)
builder.Services.AddSingleton<IThemeProvider>(new ThemeProvider(new LightThemePalette()));
```

```csharp
using AppsByTAP.BlazorFluentUI.Components.Theme.Themes.Dark;

// Dark theme as default
builder.Services.AddSingleton<IThemeProvider>(new ThemeProvider(new DarkThemePalette()));
```

---

## Wrapping the App

In `App.razor` (or the root layout):

```razor
@using AppsByTAP.BlazorFluentUI.Components.Theme

<Theme>
    <Router AppAssembly="@typeof(App).Assembly">
        <Found Context="routeData">
            <RouteView RouteData="@routeData" DefaultLayout="@typeof(MainLayout)" />
        </Found>
        <NotFound>
            <LayoutView Layout="@typeof(MainLayout)">
                <p>Page not found.</p>
            </LayoutView>
        </NotFound>
    </Router>
</Theme>
```

---

## Switching Themes at Runtime

Inject `IThemeProvider` into any component and call `ChangeTheme()`:

```razor
@using AppsByTAP.BlazorFluentUI.Components.Theme.Models
@using AppsByTAP.BlazorFluentUI.Components.Theme.Themes.Light
@using AppsByTAP.BlazorFluentUI.Components.Theme.Themes.Dark
@using AppsByTAP.BlazorFluentUI.Components.Toggle

@inject IThemeProvider ThemeProvider

<Toggle Label="Dark Mode" @bind-IsChecked="isDark" LabelIsInline="true" />

@code {
    private bool _isDark;

    private bool isDark
    {
        get => _isDark;
        set
        {
            _isDark = value;
            IPalette palette = value ? new DarkThemePalette() : new LightThemePalette();
            ThemeProvider.ChangeTheme(ThemeProvider.CreateTheme(palette));
        }
    }
}
```

---

## Theme Object Structure

```
Theme
├── Palette             (IPalette)            — raw color tokens
├── SemanticColors      (ISemanticColors)     — colors mapped to UI purposes
└── SemanticTextColors  (ISemanticTextColors) — text colors mapped to UI purposes
```

### Palette key properties (`IPalette`)

| Property | Description |
|---|---|
| `ThemePrimary` | Primary brand color |
| `ThemeDarkAlt` | Slightly darker primary |
| `ThemeDark` | Darker primary |
| `ThemeDarker` | Darkest primary |
| `ThemeLight` | Light primary variant |
| `ThemeLighter` | Lighter primary |
| `ThemeLighterAlt` | Lightest primary |
| `NeutralPrimary` | Primary neutral |
| `NeutralDark` | Dark neutral |
| `NeutralLight` | Light neutral |
| `NeutralLighter` | Lighter neutral |
| `NeutralSecondary` | Secondary neutral |
| `NeutralTertiary` | Tertiary neutral |
| `Black` | Pure black |
| `White` | Pure white |
| `Accent` | Accent color |
| `RedDark` | Dark red (errors) |

### Semantic colors (`ISemanticColors`) — key categories

| Category | Examples |
|---|---|
| Body | `BodyBackground`, `BodyStandoutBackground`, `BodyDivider` |
| Buttons | `ButtonBackground`, `ButtonBorder`, `PrimaryButtonBackground` |
| Inputs | `InputBorder`, `InputBackground`, `InputFocusBorderAlt` |
| Lists | `ListBackground`, `ListItemBackgroundHovered` |
| Menus | `MenuBackground`, `MenuItemBackgroundHovered` |
| Status | `ErrorBackground`, `WarningBackground`, `SuccessBackground` |
| Misc | `DisabledBorder`, `FocusBorder`, `ScrollbarThumb` |

### Semantic text colors (`ISemanticTextColors`) — key categories

| Category | Examples |
|---|---|
| Body | `BodyText`, `BodySubtext`, `DisabledBodyText` |
| Links | `Link`, `LinkHovered`, `ActionLink` |
| Buttons | `ButtonText`, `PrimaryButtonText`, `ButtonTextDisabled` |
| Inputs | `InputText`, `InputPlaceholderText`, `DisabledText` |
| Status | `ErrorText`, `WarningText`, `SuccessText` |

---

## CSS Variables

The `<Theme>` component generates variables following this naming pattern:

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
}
```

### Using variables in your own CSS

```css
.my-card {
    background-color: var(--semanticColors-BodyBackground);
    color: var(--semanticTextColors-BodyText);
    border: 1px solid var(--semanticColors-VariantBorder);
}

.my-card:hover {
    background-color: var(--semanticColors-BodyBackgroundHovered);
}

.error-message {
    color: var(--semanticTextColors-ErrorText);
    background-color: var(--semanticColors-ErrorBackground);
}
```

---

## Creating a Custom Palette

Implement `IPalette` and provide all color values:

```csharp
using AppsByTAP.BlazorFluentUI.Components.Theme.Themes;

public class BrandPalette : IPalette
{
    public string ThemePrimary      => "#e3008c";
    public string ThemeDarkAlt      => "#c4007b";
    public string ThemeDark         => "#a30068";
    public string ThemeDarker       => "#800052";
    public string ThemeLight        => "#f7b3d9";
    public string ThemeLighter      => "#fbd2ea";
    public string ThemeLighterAlt   => "#fef0f8";
    public string NeutralPrimary    => "#323130";
    public string NeutralDark       => "#201f1e";
    public string NeutralLight      => "#edebe9";
    public string NeutralLighter    => "#f3f2f1";
    public string NeutralLighterAlt => "#faf9f8";
    public string NeutralSecondary  => "#605e5c";
    public string NeutralSecondaryAlt => "#8a8886";
    public string NeutralTertiary   => "#a19f9d";
    public string NeutralTertiaryAlt => "#c8c6c4";
    public string NeutralQuaternary => "#d2d0ce";
    public string NeutralQuaternaryAlt => "#e1dfdd";
    public string Black             => "#000000";
    public string White             => "#ffffff";
    public string Accent            => "#e3008c";
    public string RedDark           => "#a4262c";
}
```

Register it in `Program.cs`:

```csharp
builder.Services.AddSingleton<IThemeProvider>(new ThemeProvider(new BrandPalette()));
```

`ThemeProvider` will automatically derive `SemanticColors` and `SemanticTextColors` from your palette.
