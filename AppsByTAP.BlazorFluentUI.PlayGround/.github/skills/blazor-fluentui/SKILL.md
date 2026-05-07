---
name: blazor-fluentui
description: "Build Blazor UIs with the AppsByTAP.BlazorFluentUI component library. Use when: creating Blazor pages, implementing Fluent UI components, setting up theming, adding buttons/dropdowns/modals/forms, switching dark/light themes, customizing palettes, using CSS variables from the theme system."
argument-hint: "Describe the UI you want to build (e.g., 'a settings page with a form, dropdown, and dark theme toggle')"
---

# AppsByTAP.BlazorFluentUI Component Library

Build Blazor Server UIs using the AppsByTAP.BlazorFluentUI component library with built-in Fluent Design theming.

## When to Use

- Creating new Blazor pages or layouts that use Fluent UI components
- Adding buttons, dropdowns, modals, text fields, checkboxes, or other UI controls
- Setting up or customizing the theme system (light/dark mode, custom palettes)
- Styling components with the theme's CSS custom properties
- Implementing forms with validation, input masking, or multi-select controls

## Project Setup

**Target Framework:** .NET 6+ (net6.0 or newer)  
**Package:** `AppsByTAP.BlazorFluentUI.Components` (Razor Class Library)  
**Dependency:** `Microsoft.AspNetCore.Components.Web` 6.0.15

### 1. Register the Theme Provider

In `Program.cs` (.NET 6+):

```csharp
builder.Services.AddSingleton<IThemeProvider, ThemeProvider>();
```

Or in `Startup.cs` (.NET 5 / earlier):

```csharp
services.AddSingleton<IThemeProvider, ThemeProvider>();
```

### 2. Add the Theme Component

Wrap your app content with the `<Theme>` component (typically in `App.razor` or layout). This generates CSS custom properties on `:root` for all palette, semantic color, and text color values:

```razor
@using AppsByTAP.BlazorFluentUI.Components.Theme

<Theme>
    <Router AppAssembly="@typeof(App).Assembly">
        ...
    </Router>
</Theme>
```

The `<Theme>` component sets these body defaults:
- Font: `Segoe UI, SegoeUI, "Helvetica Neue", Helvetica, Arial, sans-serif`
- Font size: `15px`
- Body color: `var(--semanticTextColors-BodyText)`
- Body background: `var(--semanticColors-BodyBackground)`

### 3. Required Namespace Imports

Add to `_Imports.razor` or individual pages as needed:

```razor
@using AppsByTAP.BlazorFluentUI.Components.Button
@using AppsByTAP.BlazorFluentUI.Components.TextField
@using AppsByTAP.BlazorFluentUI.Components.DropDown
@using AppsByTAP.BlazorFluentUI.Components.CheckBox
@using AppsByTAP.BlazorFluentUI.Components.CheckboxGroup
@using AppsByTAP.BlazorFluentUI.Components.ChoiceGroup
@using AppsByTAP.BlazorFluentUI.Components.SpinButton
@using AppsByTAP.BlazorFluentUI.Components.Toggle
@using AppsByTAP.BlazorFluentUI.Components.Tabs
@using AppsByTAP.BlazorFluentUI.Components.Modal
@using AppsByTAP.BlazorFluentUI.Components.Callout
@using AppsByTAP.BlazorFluentUI.Components.Expander
@using AppsByTAP.BlazorFluentUI.Components.Spinner
@using AppsByTAP.BlazorFluentUI.Components.Icon
@using AppsByTAP.BlazorFluentUI.Components.Label
@using AppsByTAP.BlazorFluentUI.Components.Persona
@using AppsByTAP.BlazorFluentUI.Components.Chip
@using AppsByTAP.BlazorFluentUI.Components.FitText
@using AppsByTAP.BlazorFluentUI.Components.Common
@using AppsByTAP.BlazorFluentUI.Components.Theme.Models
@using AppsByTAP.BlazorFluentUI.Components.Theme.Themes.Light
@using AppsByTAP.BlazorFluentUI.Components.Theme.Themes.Dark
```

## Component Reference

Full component API details: [Component Catalog](./references/components.md)

### Quick Overview

| Component | Key Parameters | Notes |
|-----------|---------------|-------|
| `DefaultButton` | `Text`, `IsPrimary`, `OnClick`, `Icon`, `Disabled`, `ShowIsBusy` | Standard button |
| `CompoundButton` | Same as above + `SecondaryText` | Button with subtitle |
| `IconButton` | `Icon`, `OnClick`, `Disabled` | Icon-only button |
| `SplitButton` | `TItem`, `ItemsSource`, `SelectedItem`, `OnClick`, `Width` | Button with dropdown |
| `HyperLinkButton` | `Text`, `OnClick` | Hyperlink-styled button |
| `TextField` | `Value`, `Label`, `Mask`, `Type`, `IsMultiLine`, `PlaceHolder`, `Width`, `MaxWidth`, `CharacterLimit` | Text input with masking |
| `DropDown<T>` | `ItemsSource`, `SelectedItem`, `Label`, `IsMultiSelect`, `Width`, `ItemTemplate` | Single or multi-select dropdown |
| `BlankDropDown` | `DisplayInfo`, `Content`, `Width` | Unstyled custom dropdown |
| `CheckBox` | `Label`, `IsChecked`, `BoxSide` | Checkbox with label positioning |
| `CheckboxGroup<T>` | `ItemsSource`, `SelectedItems`, `UseToggleSwitches`, `GroupDirection`, `Label` | Multi-checkbox group |
| `ChoiceGroup<T>` | `SelectedItem`, `SelectedItemChanged`, `Label`, `GroupDirection` | Radio-button group |
| `Toggle` | `Label`, `IsChecked`, `LabelIsInline` | Toggle switch |
| `SpinButton` | `Type` (Whole/Decimal), `MinValue`, `MaxValue`, `Suffix`, `Label`, `LabelPosition` | Numeric stepper |
| `Tabs` / `Tab` | `Width`, `Height`, `TabContentCanScroll`, `DefaultOpenTab` / `Header`, `Color` | Tabbed container |
| `Modal` | `ShowWindow`, `Header`, `Content`, `CanLightDismiss`, `ShowHeader`, `Width` | Modal dialog |
| `Callout` | `IsOpen`, `Width`, `CanLightDismiss`, `TargetID` | Positioned popup |
| `Expander` | `Header`, `ChildContent`, `IsOpen` | Collapsible section |
| `Spinner` | `Label`, `Size`, `Position`, `IsLoading` | Loading indicator |
| `Icon` | `IconType` (60+ FabricMDL2 icons) | Fabric icon |
| `Label` | `Text`, `Disabled`, `Hidden` | Styled label |
| `Persona` | `FirstName`, `LastName`, `Title`, `UserImage`, `Size`, `BorderRadius` | User avatar with initials |
| `ChipSet` | `ItemsSource`, `ChipType` (Input/Filter), `Label`, `CreateNewItem` | Tag/chip collection |
| `FitText` | `Text`, `Compressor`, `Width`, `Height`, `Alignment` | Auto-sizing text |

### All Components Inherit From `BaseComponentViewModel`

Every component supports these base parameters:
- `Style` — inline CSS styles
- `ClassName` — additional CSS classes
- `ID` — HTML element ID

## Theming System

Full theming reference: [Theming Guide](./references/theming.md)

### Switch Between Light and Dark Themes

```razor
@inject IThemeProvider ThemeProvider

<button @onclick="ToggleTheme">Toggle Theme</button>

@code {
    private bool _isDark = true; // ThemeProvider defaults to dark

    private void ToggleTheme()
    {
        if (_isDark)
            ThemeProvider.ChangeTheme(ThemeProvider.CreateTheme(new LightThemePalette()));
        else
            ThemeProvider.ChangeTheme(ThemeProvider.CreateTheme(new DarkThemePalette()));

        _isDark = !_isDark;
    }
}
```

### Create a Custom Theme

Implement `IPalette` (or inherit from `LightThemePalette` / `DarkThemePalette` and override):

```csharp
using AppsByTAP.BlazorFluentUI.Components.Theme.Themes;
using AppsByTAP.BlazorFluentUI.Components.Theme.Themes.Light;

public class BrandPalette : LightThemePalette
{
    public override string ThemePrimary => "#6200ee";
    public override string ThemeDark => "#3700b3";
    public override string ThemeDarkAlt => "#5300d6";
    public override string Accent => "#03dac6";
    // Override only the colors you need to change
}
```

Then apply it:

```csharp
ThemeProvider.ChangeTheme(ThemeProvider.CreateTheme(new BrandPalette()));
```

### Use Theme CSS Variables in Custom Styles

All theme values are available as CSS custom properties. Variable naming convention:

| Category | Prefix | Example |
|----------|--------|---------|
| Palette colors | `--palette-` | `var(--palette-ThemePrimary)`, `var(--palette-White)` |
| Semantic colors | `--semanticColors-` | `var(--semanticColors-BodyBackground)`, `var(--semanticColors-ButtonBackgroundHovered)` |
| Semantic text colors | `--semanticTextColors-` | `var(--semanticTextColors-BodyText)`, `var(--semanticTextColors-PrimaryButtonText)` |

Example usage in CSS:

```css
.my-card {
    background-color: var(--semanticColors-BodyStandoutBackground);
    color: var(--semanticTextColors-BodyText);
    border: 1px solid var(--semanticColors-VariantBorder);
}

.my-card:hover {
    border-color: var(--semanticColors-VariantBorderHovered);
    background-color: var(--semanticColors-BodyBackgroundHovered);
}
```

## Common Patterns

### Two-Way Binding

Most components support `@bind-` syntax:

```razor
<TextField @bind-Value="name" />
<CheckBox @bind-IsChecked="isEnabled" />
<DropDown ItemsSource="items" @bind-SelectedItem="selected" />
<Toggle @bind-IsChecked="toggleState" />
<Modal @bind-ShowWindow="showModal" />
<Callout @bind-IsOpen="calloutOpen" />
```

### Generic Components

`DropDown<T>`, `ChoiceGroup<T>`, `CheckboxGroup<T>`, and `TreeMenu<T>` are generic. Specify the type explicitly when needed:

```razor
<ChoiceGroup T="char" @bind-SelectedItem="selectedChar">
    <Choice Value="@('a')">Option A</Choice>
    <Choice Value="@('b')">Option B</Choice>
</ChoiceGroup>
```

### DropDown with DropDownItem Wrapper

For headers and grouped items, use `DropDownItem<T>`:

```csharp
List<DropDownItem<string>> items = new()
{
    new DropDownItem<string>("Header", DropDownItemType.Header),
    new DropDownItem<string>("Item 1", DropDownItemType.Item),
    new DropDownItem<string>("Item 2", DropDownItemType.Item),
};
```

### DropDown with Custom Item Template

```razor
<DropDown TItem="MyModel" ItemsSource="items" @bind-SelectedItem="selected">
    <ItemTemplate>
        <div>
            <h4>@context.Title</h4>
            <p>@context.Description</p>
        </div>
    </ItemTemplate>
</DropDown>
```

### Event Handling with Stop Propagation

```razor
<div @onclick="ParentHandler">
    <DefaultButton Text="Click Me" OnClick="ButtonHandler" OnClickStopPropagation="true" />
</div>
```

### Enums Reference

| Enum | Values | Used By |
|------|--------|---------|
| `GroupDirection` | `Vertical`, `Horizontal` | CheckboxGroup, ChoiceGroup |
| `LabelPosition` | `Above`, `Left`, `Right`, `Below` | SpinButton |
| `SpinButtonType` | `Whole`, `Decimal` | SpinButton |
| `TextFieldType` | `text`, `number`, `tel`, `email`, `password` | TextField |
| `BoxSide` | `Start`, `End` | CheckBox |
| `SpinnerSize` | `Large`, `Medium`, `Small`, `xSmall` | Spinner |
| `SpinnerLabelPosition` | `Top`, `Left`, `Right`, `Bottom` | Spinner |
| `ChipType` | `Input`, `Filter` | Chip, ChipSet |
| `DropDownItemType` | `Item`, `Header` | DropDownItem |
| `IconTypes` | 60+ values (AlertSettings, Bank, Calendar, Cancel, CheckMark, ChevronDown, Delete, Edit, Filter, Mail, More, Search, Settings, PowerButton, etc.) | Icon, BaseButton |

## Full Example: Settings Page

```razor
@page "/settings"
@using AppsByTAP.BlazorFluentUI.Components.Button
@using AppsByTAP.BlazorFluentUI.Components.TextField
@using AppsByTAP.BlazorFluentUI.Components.DropDown
@using AppsByTAP.BlazorFluentUI.Components.Toggle
@using AppsByTAP.BlazorFluentUI.Components.CheckboxGroup
@using AppsByTAP.BlazorFluentUI.Components.Common
@using AppsByTAP.BlazorFluentUI.Components.Theme.Models
@using AppsByTAP.BlazorFluentUI.Components.Theme.Themes.Light
@using AppsByTAP.BlazorFluentUI.Components.Theme.Themes.Dark

@inject IThemeProvider ThemeProvider

<h2>Settings</h2>

<TextField Label="Display Name" @bind-Value="displayName" PlaceHolder="Enter your name" />
<TextField Label="Email" Type="TextFieldType.email" @bind-Value="email" />
<TextField Label="Phone" Mask="(000)000-0000" @bind-Value="phone" />
<TextField Label="Bio" IsMultiLine="true" PlaceHolder="Tell us about yourself" CharacterLimit="500" />

<Toggle Label="Dark Mode" @bind-IsChecked="isDark" LabelIsInline="true" />

<DropDown ItemsSource="languages" @bind-SelectedItem="selectedLang" Label="Language" Width="200px" />

<CheckboxGroup ItemsSource="notifications" @bind-SelectedItems="selectedNotifications"
    Label="Notification Preferences" GroupDirection="GroupDirection.Vertical" />

<DefaultButton Text="Save" IsPrimary="true" OnClick="Save" Icon="IconTypes.CheckMark" />
<DefaultButton Text="Cancel" OnClick="Cancel" />

@code {
    private string displayName = "";
    private string email = "";
    private string phone = "";
    private bool isDark = true;
    private string selectedLang = "English";
    private List<string> languages = new() { "English", "Spanish", "French", "German" };
    private List<string> notifications = new() { "Email", "SMS", "Push", "In-App" };
    private List<string> selectedNotifications = new() { "Email" };

    private void Save()
    {
        if (isDark)
            ThemeProvider.ChangeTheme(ThemeProvider.CreateTheme(new DarkThemePalette()));
        else
            ThemeProvider.ChangeTheme(ThemeProvider.CreateTheme(new LightThemePalette()));
    }

    private void Cancel() { }
}
```
