# Getting Started

This guide walks through adding BlazorFluentUI to an existing Blazor Server project.

## Prerequisites

- [.NET 6.0 SDK](https://dotnet.microsoft.com/download/dotnet/6.0) or later
- A Blazor Server application

## Installation

Add a project reference to the component library:

```xml
<ProjectReference Include="path/to/AppsByTAP.BlazorFluentUI.Components.csproj" />
```

## Register the Theme Provider

The theme provider must be registered as a service so components can access the current theme. Add the following to your `Program.cs` (or `Startup.cs` for older project templates):

### .NET 6+ (`Program.cs`)

```csharp
using AppsByTAP.BlazorFluentUI.Components.Theme.Models;
using AppsByTAP.BlazorFluentUI.Components.Theme.Themes.Light;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

// Register the theme provider with a light palette
builder.Services.AddSingleton<IThemeProvider>(new ThemeProvider(new LightThemePalette()));

var app = builder.Build();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");
app.Run();
```

### .NET 5 (`Startup.cs`)

```csharp
using AppsByTAP.BlazorFluentUI.Components.Theme.Models;
using AppsByTAP.BlazorFluentUI.Components.Theme.Themes.Light;

public void ConfigureServices(IServiceCollection services)
{
    services.AddRazorPages();
    services.AddServerSideBlazor();
    services.AddSingleton<IThemeProvider>(new ThemeProvider(new LightThemePalette()));
}
```

To start with a dark theme instead, use `DarkThemePalette`:

```csharp
using AppsByTAP.BlazorFluentUI.Components.Theme.Themes.Dark;

builder.Services.AddSingleton<IThemeProvider>(new ThemeProvider(new DarkThemePalette()));
```

## Add Static Assets

Include the Fabric icons CSS stylesheet in your `_Host.cshtml` (or `index.html` for Blazor WebAssembly):

```html
<link href="_content/AppsByTAP.BlazorFluentUI.Components/css/fabric-icons-inline.css" rel="stylesheet" />
```

## Wrap Your App with the Theme Component

In your root layout component (for example `App.razor` or `MainLayout.razor`), wrap the content with the `Theme` component. This injects CSS custom properties into the page so all child components pick up the current palette.

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

## Use Components

Import component namespaces in your `_Imports.razor` or at the top of individual pages:

```razor
@using AppsByTAP.BlazorFluentUI.Components.Button
@using AppsByTAP.BlazorFluentUI.Components.TextField
@using AppsByTAP.BlazorFluentUI.Components.DropDown
@using AppsByTAP.BlazorFluentUI.Components.CheckBox
@using AppsByTAP.BlazorFluentUI.Components.Toggle
@using AppsByTAP.BlazorFluentUI.Components.Modal
@using AppsByTAP.BlazorFluentUI.Components.Icon
@using AppsByTAP.BlazorFluentUI.Components.Spinner
```

Then use components on your pages:

```razor
@page "/demo"

@using AppsByTAP.BlazorFluentUI.Components.Button
@using AppsByTAP.BlazorFluentUI.Components.TextField
@using AppsByTAP.BlazorFluentUI.Components.Toggle

<h1>Demo Page</h1>

<TextField Label="Your Name" @bind-Value="name" PlaceHolder="Enter your name" />

<Toggle Label="Dark Mode" @bind-IsChecked="isDarkMode" />

<DefaultButton Text="Submit" OnClick="HandleSubmit" IsPrimary="true" />

@code {
    private string name = "";
    private bool isDarkMode = false;

    private void HandleSubmit()
    {
        // Handle the form submission
    }
}
```

## Next Steps

- [Components Reference](components.md) — detailed parameters and examples for every component
- [Theming](theming.md) — switching themes at runtime and creating custom palettes
