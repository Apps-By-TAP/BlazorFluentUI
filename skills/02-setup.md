# 02 — Setup

## 1. Add the Project Reference

BlazorFluentUI is distributed as a source project rather than a NuGet package. Add a project reference directly to the component library's `.csproj` file:

```xml
<ProjectReference Include="path/to/AppsByTAP.BlazorFluentUI.Components.csproj" />
```

> **Note:** Because there is no published NuGet package, you must clone or copy the `AppsByTAP.BlazorFluentUI.Components` project into your solution and reference it as shown above. If the library is in the same repository, use a relative path (e.g. `../AppsByTAP.BlazorFluentUI.Components/AppsByTAP.BlazorFluentUI.Components.csproj`).

---

## 2. Register the Theme Provider

The `IThemeProvider` service **must** be registered before any component can render. Add this to `Program.cs`:

```csharp
using AppsByTAP.BlazorFluentUI.Components.Theme.Models;
using AppsByTAP.BlazorFluentUI.Components.Theme.Themes.Light;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

// Register with the built-in light palette
builder.Services.AddSingleton<IThemeProvider>(new ThemeProvider(new LightThemePalette()));

var app = builder.Build();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");
app.Run();
```

To start with a dark theme use `DarkThemePalette` instead:

```csharp
using AppsByTAP.BlazorFluentUI.Components.Theme.Themes.Dark;

builder.Services.AddSingleton<IThemeProvider>(new ThemeProvider(new DarkThemePalette()));
```

---

## 3. Add the Fabric Icons Stylesheet

In `Pages/_Host.cshtml` (Blazor Server), add inside `<head>`:

```html
<link href="_content/AppsByTAP.BlazorFluentUI.Components/css/fabric-icons-inline.css" rel="stylesheet" />
```

---

## 4. Wrap Your App with the `<Theme>` Component

In `App.razor` (or your root layout), wrap all content with `<Theme>`:

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

This injects CSS custom properties on `:root` so every child component picks up the active theme.

---

## 5. Import Component Namespaces

Add frequently used namespaces to `_Imports.razor` so you don't need to repeat them on every page:

```razor
@using AppsByTAP.BlazorFluentUI.Components.Button
@using AppsByTAP.BlazorFluentUI.Components.TextField
@using AppsByTAP.BlazorFluentUI.Components.DropDown
@using AppsByTAP.BlazorFluentUI.Components.CheckBox
@using AppsByTAP.BlazorFluentUI.Components.CheckboxGroup
@using AppsByTAP.BlazorFluentUI.Components.ChoiceGroup
@using AppsByTAP.BlazorFluentUI.Components.Toggle
@using AppsByTAP.BlazorFluentUI.Components.SpinButton
@using AppsByTAP.BlazorFluentUI.Components.Modal
@using AppsByTAP.BlazorFluentUI.Components.Callout
@using AppsByTAP.BlazorFluentUI.Components.Expander
@using AppsByTAP.BlazorFluentUI.Components.Tabs
@using AppsByTAP.BlazorFluentUI.Components.TreeMenu
@using AppsByTAP.BlazorFluentUI.Components.Icon
@using AppsByTAP.BlazorFluentUI.Components.Label
@using AppsByTAP.BlazorFluentUI.Components.Persona
@using AppsByTAP.BlazorFluentUI.Components.Spinner
@using AppsByTAP.BlazorFluentUI.Components.Chip
@using AppsByTAP.BlazorFluentUI.Components.FloatingActionButton
@using AppsByTAP.BlazorFluentUI.Components.BottomNavigationBar
@using AppsByTAP.BlazorFluentUI.Components.FitText
@using AppsByTAP.BlazorFluentUI.Components.Forms
@using AppsByTAP.BlazorFluentUI.Components.Theme.Models
```

---

## 6. Verify — Minimal Working Page

Create a page to confirm everything is wired up correctly:

```razor
@page "/test"
@using AppsByTAP.BlazorFluentUI.Components.Button
@using AppsByTAP.BlazorFluentUI.Components.TextField

<h1>BlazorFluentUI Test</h1>

<TextField Label="Name" @bind-Value="name" PlaceHolder="Enter your name" />
<DefaultButton Text="Hello" IsPrimary="true" OnClick="Greet" />
<p>@message</p>

@code {
    string name = "";
    string message = "";

    void Greet() => message = $"Hello, {name}!";
}
```

If the button renders with the primary blue color and the text field shows a bordered input, the setup is complete.

---

## Setup Checklist

- [ ] Project reference to `AppsByTAP.BlazorFluentUI.Components.csproj` added
- [ ] `IThemeProvider` registered in `Program.cs`
- [ ] `fabric-icons-inline.css` link added to `_Host.cshtml`
- [ ] `<Theme>` component wraps all content in `App.razor`
- [ ] Component `@using` statements added to `_Imports.razor`
