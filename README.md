# BlazorFluentUI

A Blazor component library that provides [Fluent UI](https://developer.microsoft.com/en-us/fluentui) inspired components for Blazor Server applications. Built by [Apps-By-TAP](https://github.com/Apps-By-TAP).

## Features

- **20+ reusable UI components** — buttons, text fields, dropdowns, modals, toggles, spinners, and more
- **Light and Dark theme support** — a built-in theming system that uses CSS custom properties with full palette, semantic color, and semantic text color tokens
- **Generic components** — `DropDown<T>` and other components support generic type parameters for strongly typed data binding
- **Two-way data binding** — components follow Blazor conventions with `EventCallback` parameters for seamless binding
- **Form validation** — integrates with Blazor's `EditForm` and validation infrastructure
- **Office Fabric icons** — over 100 icons from the Office Fabric icon set are available through the `Icon` component
- **Input masking** — the `TextField` component supports regex-based input masks via JavaScript interop
- **Responsive modal and callout system** — with light-dismiss behavior and automatic z-index layering

## Components

| Component | Description |
|---|---|
| **Button** | Multiple variants — `DefaultButton`, `CompoundButton`, `IconButton`, `SplitButton`, `NavButton`, `HyperLinkButton`, and more |
| **TextField** | Single-line and multi-line text input with character limits, placeholder text, input masks, and multiple input types |
| **DropDown** | Generic dropdown (`DropDown<T>`) with single and multi-select modes, grouped items with headers, and custom item templates |
| **CheckBox** | Checkbox with configurable label positioning (start or end) |
| **CheckboxGroup** | Groups multiple checkboxes with horizontal or vertical layout; optionally renders as toggle switches |
| **ChoiceGroup** | Radio button group for single-selection scenarios |
| **Toggle** | Binary toggle switch with inline or stacked label |
| **SpinButton** | Numeric spinner for integer or decimal values with configurable suffix and rounding |
| **Modal** | Dialog window with header, close button, light-dismiss support, and configurable width |
| **Callout** | Overlay panel for contextual content |
| **Expander** | Collapsible section with header and chevron indicator |
| **Tabs** | Tabbed content container with scrollable tab panels |
| **TreeMenu** | Hierarchical menu built from branch components |
| **Icon** | Renders Office Fabric icons by type via the `IconTypes` enum |
| **Label** | Simple text label |
| **Persona** | Displays a user's avatar (initials-based), name, and title |
| **Spinner** | Loading indicator in multiple sizes and label positions |
| **Chip / ChipSet** | Chip input component for tag-like selections |
| **FloatingActionButton** | Floating action button |
| **BottomNavigationBar** | Mobile-style bottom navigation bar |
| **FitText** | Automatically scales text to fit its container |
| **LightDismiss** | Backdrop overlay used internally by modals and dropdowns |

## Quick Start

1. Add a reference to the `AppsByTAP.BlazorFluentUI.Components` project.

2. Register the theme provider in your `Program.cs` or `Startup.cs`:

   ```csharp
   using AppsByTAP.BlazorFluentUI.Components.Theme.Models;
   using AppsByTAP.BlazorFluentUI.Components.Theme.Themes.Light;

   // Register with a light theme
   builder.Services.AddSingleton<IThemeProvider>(new ThemeProvider(new LightThemePalette()));
   ```

3. Wrap your application content with the `Theme` component in your root layout:

   ```razor
   @using AppsByTAP.BlazorFluentUI.Components.Theme

   <Theme>
       @Body
   </Theme>
   ```

4. Add the required CSS to your `_Host.cshtml` or `index.html`:

   ```html
   <link href="_content/AppsByTAP.BlazorFluentUI.Components/css/fabric-icons-inline.css" rel="stylesheet" />
   ```

5. Use components in your Razor pages:

   ```razor
   @using AppsByTAP.BlazorFluentUI.Components.Button
   @using AppsByTAP.BlazorFluentUI.Components.TextField

   <DefaultButton Text="Click Me" OnClick="HandleClick" IsPrimary="true" />
   <TextField Label="Name" @bind-Value="name" PlaceHolder="Enter your name" />
   ```

## Documentation

Detailed documentation is available in the [`docs/`](docs/) directory:

- [Getting Started](docs/getting-started.md) — installation, project setup, and configuration
- [Components](docs/components.md) — full reference for every component including parameters and usage examples
- [Theming](docs/theming.md) — how to use the theme system, switch between light and dark themes, and create custom palettes

## Project Structure

```
BlazorFluentUI/
├── AppsByTAP.BlazorFluentUI.PlayGround/
│   ├── AppsByTAP.BlazorFluentUI.Components/   # Core component library (net6.0)
│   │   ├── BaseComponent/                     # Shared base classes
│   │   ├── Button/                            # Button components
│   │   ├── TextField/                         # Text input components
│   │   ├── DropDown/                          # Dropdown components
│   │   ├── CheckBox/                          # Checkbox component
│   │   ├── CheckboxGroup/                     # Checkbox group component
│   │   ├── ChoiceGroup/                       # Radio button group
│   │   ├── Toggle/                            # Toggle switch
│   │   ├── SpinButton/                        # Numeric spinner
│   │   ├── Modal/                             # Modal dialog
│   │   ├── Callout/                           # Callout overlay
│   │   ├── Expander/                          # Collapsible section
│   │   ├── Tabs/                              # Tab container
│   │   ├── TreeMenu/                          # Hierarchical menu
│   │   ├── Icon/                              # Fabric icons
│   │   ├── Label/                             # Text label
│   │   ├── Persona/                           # User profile display
│   │   ├── Spinner/                           # Loading spinner
│   │   ├── Chip/                              # Chip/tag component
│   │   ├── FloatingActionButton/              # FAB component
│   │   ├── BottomNavigationBar/               # Bottom nav bar
│   │   ├── FitText/                           # Auto-fit text
│   │   ├── LightDismiss/                      # Backdrop overlay
│   │   ├── Forms/                             # Form validation support
│   │   ├── Theme/                             # Theming system
│   │   ├── Common/                            # Shared enums and utilities
│   │   └── wwwroot/                           # Static assets (CSS, JS)
│   └── AppsByTAP.BlazorFluentUI.PlayGround.sln
├── docs/                                      # Documentation
├── LICENSE                                    # MIT License
└── README.md
```

## Requirements

- [.NET 6.0 SDK](https://dotnet.microsoft.com/download/dotnet/6.0) or later
- A Blazor Server project

## License

This project is licensed under the [MIT License](LICENSE).