---
type: Blazor Component
title: "Theme"
description: "The application theme boundary that emits palette and semantic CSS custom properties."
resource: "../../../AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components/Theme/Theme.razor"
tags: [blazor, fluent-ui, component, api-reference]
status: stable
dotnet_type: "AppsByTAP.BlazorFluentUI.Components.Theme.Theme"
component_source: "AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components/Theme/Theme.razor"
generic_parameters: []
generated: { by: codex/gpt-5, at: 2026-08-14T00:00:00-04:00 }
verified: { by: "process:okf-docs-validator", at: 2026-08-14T00:00:00-04:00 }
verification_scope: api-contract-links-examples-and-theme-tokens
sources:
  - id: component-source
    resource: "../../../AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components/Theme/Theme.razor"
    title: "Theme Razor source"
---

# Theme

The application theme boundary that emits palette and semantic CSS custom properties.

## Contract

- Namespace: `AppsByTAP.BlazorFluentUI.Components.Theme`
- Compiled type: `AppsByTAP.BlazorFluentUI.Components.Theme.Theme`
- Base type: `ComponentBase`
- Intended level: consumer-facing component.

### Generic type parameters

None.

## Parameters

The table lists the effective runtime contract, including inherited library and framework parameters.

<!-- parameters:start -->
| Name | Type | Default | Required | Binding | Declared by | Notes |
|---|---|---|---|---|---|---|
| `ChildContent` | `RenderFragment` | `null` | No | `-` | `Theme` | Child markup rendered by the component. |
<!-- parameters:end -->

## Cascading parameters

Cascading values are supplied by an ancestor and must not be invented as normal component attributes.

<!-- cascading-parameters:start -->
| Name | Type | Default | Required | Binding | Declared by | Notes |
|---|---|---|---|---|---|---|
<!-- cascading-parameters:end -->

## Examples

Minimal:

```razor
<Theme>@Body</Theme>
```

Configured/composed:

```razor
@inject IThemeProvider ThemeProvider

<Theme>@Body</Theme>

@code {
    void UseDark() => ThemeProvider.ChangeTheme(ThemeProvider.CreateTheme(new DarkThemePalette()));
}
```

## Rendered structure

- HTML elements observed in the Razor source: `div`, `style`.
- Elements may be conditional on parameters and internal state. Attribute forwarding is limited to the parameters shown in the contract table; do not assume arbitrary attributes reach the root.

## Associated types

No non-scalar supporting types beyond framework primitives.

Exact enum members and model properties are listed in the [public supporting types reference](../references/public-types.md).

## Lifecycle and callback behavior

- Lifecycle methods implemented by this component: `OnInitializedAsync`.

No EventCallback parameters are exposed.

## Rendering, services, and assets

Injected services:

None.

JavaScript modules:

None.

Static asset contract:

- No component-scoped ``.razor.css`` file is associated with this component.
- No direct JavaScript module import is observable in this component source.

Source files:

- [Theme.razor](../../../AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components/Theme/Theme.razor)

## Styling and theme tokens

- `--semanticColors-BodyBackground`
- `--semanticTextColors-BodyText`

The listed tokens are case-sensitive. Use the [Theme reference](theme.md) for their emitted values and customization rules.

## Accessibility

Inspect the rendered markup before assuming ARIA roles or keyboard behavior; the component does not add accessibility behavior beyond what is present in its source markup.

## Exceptions

No exception is thrown explicitly in the component source. Consumer callbacks, invalid templates/data, and JavaScript interop can still propagate their own failures.

## Gotchas and current limitations

- ThemeProvider() defaults to DarkThemePalette, not light.
- Dark semantic branching is selected with `palette is DarkThemePalette`; a dark custom IPalette that does not derive from DarkThemePalette is treated as light.
- The component subscribes to ThemeChanged but does not unsubscribe, so repeated disposal can retain handlers.
- The component adds a wrapper div and global :root/body styles.


## Provider registration and lifetime

Register `IThemeProvider` before rendering `Theme`. Use a scoped provider in Blazor Server so each circuit/user owns its theme. A singleton shares one mutable theme across every server circuit. In WebAssembly, singleton is appropriate because the application runs in one browser process.

```csharp
// Blazor Server: one theme provider per circuit.
builder.Services.AddScoped<IThemeProvider>(_ =>
    new ThemeProvider(new LightThemePalette()));

// Blazor WebAssembly: one provider for the browser application.
builder.Services.AddSingleton<IThemeProvider>(
    new ThemeProvider(new LightThemePalette()));
```

The parameterless `ThemeProvider()` constructor starts with `DarkThemePalette`. Passing a palette to the constructor makes the initial selection explicit.

## Runtime theme switching

`IThemeProvider.Theme` exposes the current `Models.Theme`. `CreateTheme(IPalette)` derives semantic colors; `ChangeTheme(Models.Theme)` stores it and raises `ThemeChanged`. The `Theme` component listens to that event, re-renders its style block, and every descendant using the variables updates through CSS.

```csharp
@inject IThemeProvider ThemeProvider

void UseLight() => ThemeProvider.ChangeTheme(
    ThemeProvider.CreateTheme(new LightThemePalette()));

void UseDark() => ThemeProvider.ChangeTheme(
    ThemeProvider.CreateTheme(new DarkThemePalette()));
```

`Theme` emits the variables on `:root`, applies body font/background/text rules globally, and wraps `ChildContent` in an extra `div`. It subscribes to `ThemeChanged` during initialization; current source does not implement `IDisposable` or unsubscribe.

## Creating a custom palette

All 50 `IPalette` properties are required. The safest light-theme customization is to derive from `LightThemePalette` and override only the virtual values that change:

```csharp
public sealed class BrandLightPalette : LightThemePalette
{
    public override string ThemePrimary => "#5c2d91";
    public override string ThemeDarkAlt => "#4b2477";
    public override string ThemeDark => "#3b1c5f";
    public override string Accent => ThemePrimary;
}
```

For a dark theme, derive from `DarkThemePalette`:

```csharp
public sealed class BrandDarkPalette : DarkThemePalette
{
    public override string ThemePrimary => "#b4a0ff";
    public override string Accent => ThemePrimary;
}
```

This inheritance choice affects behavior: `ThemeProvider.CreateTheme` tests `palette is DarkThemePalette`. A custom class that merely implements `IPalette` is treated as light even if its colors are dark. Implementing `IPalette` directly is supported, but requires all 50 properties and produces light semantic branching unless the type also derives from `DarkThemePalette`.

## CSS variable naming and derivation

- Palette property `ThemePrimary` becomes `--palette-ThemePrimary`.
- Semantic color property `ButtonBackground` becomes `--semanticColors-ButtonBackground`.
- Semantic text property `ButtonText` becomes `--semanticTextColors-ButtonText`.
- Names and casing are exact; semantic text tokens must not use the `semanticColors` prefix.
- `ScrollbarTrack` and `ScrollbarThumb` are concrete `LightSemanticColors` properties and are emitted at runtime even though the current `ISemanticColors` interface omits them.
- `--label-font-weight` and `--label-padding-bottom` are appended directly by `Theme` rather than coming from a C# theme interface.

Use semantic tokens for contextual states and text, and palette tokens for raw color choices. Component CSS should not invent fallback token names.
## Complete emitted CSS-variable reference

Theme emits exactly 141 variables: 50 palette colors, 58 semantic colors (including the concrete scrollbar properties), 31 semantic text colors, and two label layout variables. Values below are the runtime results for the built-in palettes.

### Palette variables (50)

| CSS variable | Light | Dark |
|---|---|---|
| `--palette-Accent` | `#0078d4` | `#2899f5` |
| `--palette-Black` | `#000000` | `#ffffff` |
| `--palette-BlackTranslucent40` | `rgba(0,0,0,.4)` | `rgba(255,255,255,.4)` |
| `--palette-Blue` | `#0078d4` | `#0078d4` |
| `--palette-BlueDark` | `#002050` | `#002050` |
| `--palette-BlueLight` | `#00bcf2` | `#00bcf2` |
| `--palette-BlueMid` | `#00188f` | `#00188f` |
| `--palette-Green` | `#107c10` | `#107c10` |
| `--palette-GreenDark` | `#004b1c` | `#004b1c` |
| `--palette-GreenLight` | `#bad80a` | `#bad80a` |
| `--palette-Magenta` | `#b4009e` | `#b4009e` |
| `--palette-MagentaDark` | `#5c005c` | `#5c005c` |
| `--palette-MagentaLight` | `#e3008c` | `#e3008c` |
| `--palette-NeutralDark` | `#201f1e` | `#faf9f8` |
| `--palette-NeutralLight` | `#edebe9` | `#292827` |
| `--palette-NeutralLighter` | `#f3f2f1` | `#252423` |
| `--palette-NeutralLighterAlt` | `#faf9f8` | `#201f1e` |
| `--palette-NeutralPrimary` | `#323130` | `#f3f2f1` |
| `--palette-NeutralPrimaryAlt` | `#3b3a39` | `#c8c6c4` |
| `--palette-NeutralQuaternary` | `#d2d0ce` | `#3b3a39` |
| `--palette-NeutralQuaternaryAlt` | `#e1dfdd` | `#323130` |
| `--palette-NeutralSecondary` | `#605e5c` | `#a19f9d` |
| `--palette-NeutralSecondaryAlt` | `#8a8886` | `#979693` |
| `--palette-NeutralTertiary` | `#a19f9d` | `#797775` |
| `--palette-NeutralTertiaryAlt` | `#c8c6c4` | `#484644` |
| `--palette-Orange` | `#d83b01` | `#d83b01` |
| `--palette-OrangeLight` | `#ea4300` | `#ea4300` |
| `--palette-OrangeLighter` | `#ff8c00` | `#ff8c00` |
| `--palette-Purple` | `#5c2d91` | `#5c2d91` |
| `--palette-PurpleDark` | `#32145a` | `#32145a` |
| `--palette-PurpleLight` | `#b4a0ff` | `#b4a0ff` |
| `--palette-Red` | `#e81123` | `#e81123` |
| `--palette-RedDark` | `#a4262c` | `#F1707B` |
| `--palette-Teal` | `#008272` | `#008272` |
| `--palette-TealDark` | `#004b50` | `#004b50` |
| `--palette-TealLight` | `#00b294` | `#00b294` |
| `--palette-ThemeDark` | `#005a9e` | `#6cb8f6` |
| `--palette-ThemeDarkAlt` | `#106ebe` | `#3aa0f3` |
| `--palette-ThemeDarker` | `#004578` | `#82c7ff` |
| `--palette-ThemeLight` | `#c7e0f4` | `#004c87` |
| `--palette-ThemeLighter` | `#deecf9` | `#043862` |
| `--palette-ThemeLighterAlt` | `#eff6fc` | `#092c47` |
| `--palette-ThemePrimary` | `#0078d4` | `#2899f5` |
| `--palette-ThemeSecondary` | `#2b88d8` | `#0078d4` |
| `--palette-ThemeTertiary` | `#71afe5` | `#235a85` |
| `--palette-White` | `#ffffff` | `#1b1a19` |
| `--palette-WhiteTranslucent40` | `rgba(255,255,255,.4)` | `rgba(27,26,25,.4)` |
| `--palette-Yellow` | `#ffb900` | `#ffb900` |
| `--palette-YellowDark` | `#d29200` | `#d29200` |
| `--palette-YellowLight` | `#fff100` | `#fff100` |

### Semantic color variables (58)

| CSS variable | Light | Dark |
|---|---|---|
| `--semanticColors-AccentButtonBackground` | `#0078d4` | `#2899f5` |
| `--semanticColors-BlockingBackground` | `rgba(250, 65, 0, .2)` | `rgba(234, 67, 0, .5)` |
| `--semanticColors-BodyBackground` | `#ffffff` | `#1b1a19` |
| `--semanticColors-BodyBackgroundChecked` | `#edebe9` | `#292827` |
| `--semanticColors-BodyBackgroundHovered` | `#f3f2f1` | `#252423` |
| `--semanticColors-BodyDivider` | `#edebe9` | `#292827` |
| `--semanticColors-BodyFrameBackground` | `#ffffff` | `#1b1a19` |
| `--semanticColors-BodyFrameDivider` | `#edebe9` | `#292827` |
| `--semanticColors-BodyStandoutBackground` | `#faf9f8` | `#201f1e` |
| `--semanticColors-ButtonBackground` | `#ffffff` | `#1b1a19` |
| `--semanticColors-ButtonBackgroundChecked` | `#c8c6c4` | `#484644` |
| `--semanticColors-ButtonBackgroundCheckedHovered` | `#edebe9` | `#292827` |
| `--semanticColors-ButtonBackgroundDisabled` | `#f3f2f1` | `#252423` |
| `--semanticColors-ButtonBackgroundHovered` | `#f3f2f1` | `#252423` |
| `--semanticColors-ButtonBackgroundPressed` | `#edebe9` | `#292827` |
| `--semanticColors-ButtonBorder` | `#8a8886` | `#979693` |
| `--semanticColors-ButtonBorderDisabled` | `#f3f2f1` | `#252423` |
| `--semanticColors-DefaultStateBackground` | `#faf9f8` | `#201f1e` |
| `--semanticColors-DisabledBackground` | `#f3f2f1` | `#252423` |
| `--semanticColors-DisabledBorder` | `#c8c6c4` | `#484644` |
| `--semanticColors-ErrorBackground` | `rgba(245, 135, 145, .2)` | `rgba(232, 17, 35, .5)` |
| `--semanticColors-FocusBorder` | `#605e5c` | `#a19f9d` |
| `--semanticColors-InputBackground` | `#ffffff` | `#1b1a19` |
| `--semanticColors-InputBackgroundChecked` | `#0078d4` | `#2899f5` |
| `--semanticColors-InputBackgroundCheckedHovered` | `#005a9e` | `#6cb8f6` |
| `--semanticColors-InputBorder` | `#605e5c` | `#a19f9d` |
| `--semanticColors-InputBorderHovered` | `#323130` | `#f3f2f1` |
| `--semanticColors-InputFocusBorderAlt` | `#0078d4` | `#2899f5` |
| `--semanticColors-InputForegroundChecked` | `#ffffff` | `#1b1a19` |
| `--semanticColors-InputIcon` | `#0078d4` | `#2899f5` |
| `--semanticColors-InputIconDisabled` | `#a19f9d` | `#797775` |
| `--semanticColors-InputIconHovered` | `#005a9e` | `#6cb8f6` |
| `--semanticColors-InputPlaceholderBackgroundChecked` | `#deecf9` | `#043862` |
| `--semanticColors-ListBackground` | `#ffffff` | `#252423` |
| `--semanticColors-ListHeaderBackgroundHovered` | `#f3f2f1` | `#252423` |
| `--semanticColors-ListHeaderBackgroundPressed` | `#edebe9` | `#292827` |
| `--semanticColors-ListItemBackgroundChecked` | `#edebe9` | `#292827` |
| `--semanticColors-ListItemBackgroundCheckedHovered` | `#e1dfdd` | `#323130` |
| `--semanticColors-ListItemBackgroundHovered` | `#f3f2f1` | `#323130` |
| `--semanticColors-MenuBackground` | `#ffffff` | `#1b1a19` |
| `--semanticColors-MenuDivider` | `#c8c6c4` | `#484644` |
| `--semanticColors-MenuHeader` | `#0078d4` | `#2899f5` |
| `--semanticColors-MenuIcon` | `#0078d4` | `#2899f5` |
| `--semanticColors-MenuItemBackgroundHovered` | `#f3f2f1` | `#252423` |
| `--semanticColors-MenuItemBackgroundPressed` | `#edebe9` | `#292827` |
| `--semanticColors-PrimaryButtonBackground` | `#0078d4` | `#2899f5` |
| `--semanticColors-PrimaryButtonBackgroundDisabled` | `#f3f2f1` | `#252423` |
| `--semanticColors-PrimaryButtonBackgroundHovered` | `#106ebe` | `#3aa0f3` |
| `--semanticColors-PrimaryButtonBackgroundPressed` | `#005a9e` | `#6cb8f6` |
| `--semanticColors-PrimaryButtonBorder` | `transparent` | `transparent` |
| `--semanticColors-ScrollbarThumb` | `#cecece` | `#636363` |
| `--semanticColors-ScrollbarTrack` | `#f4f4f4` | `#212121` |
| `--semanticColors-SmallInputBorder` | `#605e5c` | `#a19f9d` |
| `--semanticColors-SuccessBackground` | `rgba(95, 210, 85, .2)` | `rgba(186, 216, 10, .4)` |
| `--semanticColors-VariantBorder` | `#edebe9` | `#292827` |
| `--semanticColors-VariantBorderHovered` | `#a19f9d` | `#797775` |
| `--semanticColors-WarningBackground` | `rgba(255, 200, 10, .2)` | `rgba(255, 251, 0, .6)` |
| `--semanticColors-WarningHighlight` | `#ffb900` | `#fff100` |

### Semantic text variables (31)

| CSS variable | Light | Dark |
|---|---|---|
| `--semanticTextColors-AccentButtonText` | `#ffffff` | `#1b1a19` |
| `--semanticTextColors-ActionLink` | `#323130` | `#f3f2f1` |
| `--semanticTextColors-ActionLinkHovered` | `#201f1e` | `#faf9f8` |
| `--semanticTextColors-BodySubtext` | `#605e5c` | `#a19f9d` |
| `--semanticTextColors-BodyText` | `#323130` | `#f3f2f1` |
| `--semanticTextColors-BodyTextChecked` | `#000000` | `#ffffff` |
| `--semanticTextColors-ButtonText` | `#323130` | `#f3f2f1` |
| `--semanticTextColors-ButtonTextChecked` | `#201f1e` | `#faf9f8` |
| `--semanticTextColors-ButtonTextCheckedHovered` | `#000000` | `#ffffff` |
| `--semanticTextColors-ButtonTextDisabled` | `#a19f9d` | `#797775` |
| `--semanticTextColors-ButtonTextHovered` | `#201f1e` | `#faf9f8` |
| `--semanticTextColors-ButtonTextPressed` | `#201f1e` | `#faf9f8` |
| `--semanticTextColors-DisabledBodySubtext` | `#c8c6c4` | `#484644` |
| `--semanticTextColors-DisabledBodyText` | `#a19f9d` | `#797775` |
| `--semanticTextColors-DisabledSubtext` | `#d2d0ce` | `#3b3a39` |
| `--semanticTextColors-DisabledText` | `#a19f9d` | `#797775` |
| `--semanticTextColors-ErrorText` | `#a4262c` | `#ff5f5f` |
| `--semanticTextColors-InputPlaceholderText` | `#605e5c` | `#a19f9d` |
| `--semanticTextColors-InputText` | `#323130` | `#f3f2f1` |
| `--semanticTextColors-InputTextHovered` | `#201f1e` | `#faf9f8` |
| `--semanticTextColors-Link` | `#0078d4` | `#2899f5` |
| `--semanticTextColors-LinkHovered` | `#004578` | `#82c7ff` |
| `--semanticTextColors-ListText` | `#323130` | `#f3f2f1` |
| `--semanticTextColors-MenuItemText` | `#323130` | `#f3f2f1` |
| `--semanticTextColors-MenuItemTextHovered` | `#201f1e` | `#faf9f8` |
| `--semanticTextColors-PrimaryButtonText` | `#ffffff` | `#1b1a19` |
| `--semanticTextColors-PrimaryButtonTextDisabled` | `#d2d0ce` | `#3b3a39` |
| `--semanticTextColors-PrimaryButtonTextHovered` | `#ffffff` | `#1b1a19` |
| `--semanticTextColors-PrimaryButtonTextPressed` | `#ffffff` | `#1b1a19` |
| `--semanticTextColors-SuccessText` | `#107C10` | `#92c353` |
| `--semanticTextColors-WarningText` | `#333333` | `#ffffff` |

### Label variables (2)

| CSS variable | Light | Dark |
|---|---|---|
| `--label-font-weight` | `600` | `600` |
| `--label-padding-bottom` | `5px` | `5px` |

## Related knowledge

- [Component index](index.md)
- [Architecture and binding conventions](../architecture-and-binding.md)
- [Public supporting types](../references/public-types.md)
- [Static assets and JavaScript interop](../references/static-assets-and-js.md)
