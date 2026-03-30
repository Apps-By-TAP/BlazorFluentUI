# 01 — Overview

## What Is BlazorFluentUI?

**BlazorFluentUI** is a **Blazor Server** component library that provides [Fluent UI](https://developer.microsoft.com/en-us/fluentui)-inspired UI components for .NET 6+ applications. It delivers a consistent, modern UI built on CSS custom properties with full light/dark theme support.

> **Important:** This library targets **Blazor Server** applications only. It is not compatible with Blazor WebAssembly. Ensure your project is a Blazor Server app before adding a reference.

Key capabilities:
- **20+ reusable components** — buttons, text fields, dropdowns, modals, toggles, spinners, and more
- **Built-in theming** — light and dark palettes using CSS design tokens
- **Generic components** — `DropDown<T>` supports strongly typed data binding
- **Two-way data binding** — follows Blazor's `@bind-*` conventions
- **Form validation** — integrates with Blazor's `EditForm` and `DataAnnotationsValidator`
- **Office Fabric icons** — 100+ icons via the `IconTypes` enum
- **Input masking** — regex-based masks on `TextField` via JS interop

---

## Component Catalogue

| Component | Description |
|---|---|
| `DefaultButton` / `IconButton` / `CompoundButton` / `SplitButton` | Button variants |
| `TextField` | Single-line and multi-line text input |
| `DropDown<T>` | Generic dropdown — single or multi-select |
| `CheckBox` | Checkbox with configurable label side |
| `CheckboxGroup` | Groups checkboxes horizontally or vertically |
| `ChoiceGroup` / `Choice` | Radio button group |
| `Toggle` | Binary on/off switch |
| `SpinButton` | Numeric spinner (integer or decimal) |
| `Modal` | Dialog window with backdrop |
| `Callout` | Contextual overlay panel |
| `Expander` | Collapsible section with chevron |
| `Tabs` / `Tab` | Tabbed content container |
| `TreeMenu` / `BranchComponent` | Hierarchical tree menu |
| `Icon` | Office Fabric icon by `IconTypes` enum |
| `Label` | Plain text label |
| `Persona` | Avatar with initials, name, and title |
| `Spinner` | Loading indicator |
| `ChipSet` / `Chip` | Tag-style chip input |
| `FloatingActionButton` | FAB for primary screen action |
| `BottomNavigationBar` / `NavigationItem` | Mobile bottom nav bar |
| `FitText` | Auto-scales text to fit its container |
| `LightDismiss` | Backdrop overlay (used internally) |
| `ValidationInput` | Form-bound `TextField` for use in `EditForm` |

---

## Namespace Structure

Every component lives under `AppsByTAP.BlazorFluentUI.Components.<Folder>`:

```
AppsByTAP.BlazorFluentUI.Components.Button
AppsByTAP.BlazorFluentUI.Components.TextField
AppsByTAP.BlazorFluentUI.Components.DropDown
AppsByTAP.BlazorFluentUI.Components.CheckBox
AppsByTAP.BlazorFluentUI.Components.CheckboxGroup
AppsByTAP.BlazorFluentUI.Components.ChoiceGroup
AppsByTAP.BlazorFluentUI.Components.Toggle
AppsByTAP.BlazorFluentUI.Components.SpinButton
AppsByTAP.BlazorFluentUI.Components.Modal
AppsByTAP.BlazorFluentUI.Components.Callout
AppsByTAP.BlazorFluentUI.Components.Expander
AppsByTAP.BlazorFluentUI.Components.Tabs
AppsByTAP.BlazorFluentUI.Components.TreeMenu
AppsByTAP.BlazorFluentUI.Components.Icon
AppsByTAP.BlazorFluentUI.Components.Label
AppsByTAP.BlazorFluentUI.Components.Persona
AppsByTAP.BlazorFluentUI.Components.Spinner
AppsByTAP.BlazorFluentUI.Components.Chip
AppsByTAP.BlazorFluentUI.Components.FloatingActionButton
AppsByTAP.BlazorFluentUI.Components.BottomNavigationBar
AppsByTAP.BlazorFluentUI.Components.FitText
AppsByTAP.BlazorFluentUI.Components.LightDismiss
AppsByTAP.BlazorFluentUI.Components.Forms
AppsByTAP.BlazorFluentUI.Components.Theme
AppsByTAP.BlazorFluentUI.Components.Theme.Models
AppsByTAP.BlazorFluentUI.Components.Theme.Themes.Light
AppsByTAP.BlazorFluentUI.Components.Theme.Themes.Dark
AppsByTAP.BlazorFluentUI.Components.Common          (shared enums)
```

---

## Key Conventions

| Convention | Detail |
|---|---|
| Two-way binding | Use `@bind-Value`, `@bind-IsChecked`, `@bind-SelectedItem`, etc. |
| Click handling | `OnClick="MethodName"` or `OnClick="() => expression"` |
| CSS customization | Every component accepts `ClassName` and/or `Style` parameters |
| Icons | Pass an `IconTypes` enum value (e.g. `IconTypes.Save`) |
| Disabled state | Most interactive components accept `Disabled="true"` |
| Busy state | Buttons accept `IsBusy="true"` to show an inline spinner |
| Generic components | `DropDown<T>` requires a `TItem` type parameter |

---

## Requirements

- .NET 6.0 SDK or later
- Blazor **Server** application (not WebAssembly)
