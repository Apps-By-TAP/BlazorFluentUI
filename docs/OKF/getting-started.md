---
type: How-to Guide
title: Getting started
description: Configure a .NET 8 Blazor application to consume AppsByTAP.BlazorFluentUI 0.1.0 safely.
tags: [blazor, fluent-ui, installation, theme]
status: stable
generated: { by: codex/gpt-5, at: 2026-08-14T00:00:00-04:00 }
verified: { by: "process:okf-docs-validator", at: 2026-08-14T00:00:00-04:00 }
verification_scope: links-examples-and-source-configuration
sources:
  - id: project
    resource: "../../AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components/AppsByTAP.BlazorFluentUI.Components.csproj"
    title: Component project
  - id: theme-source
    resource: "../../AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components/Theme/Theme.razor"
    title: Theme component source
---

# Getting started

## Requirements

- .NET 8 SDK and a Blazor Server or Blazor WebAssembly application.
- A project/package reference to `AppsByTAP.BlazorFluentUI.Components` 0.1.0.
- Static web assets enabled by the normal Razor class library pipeline.

## Add the project reference

```xml
<ProjectReference Include="path/to/AppsByTAP.BlazorFluentUI.Components.csproj" />
```

## Register the theme provider

For Blazor Server, use scoped lifetime so one user's theme changes do not affect every circuit:

```csharp
using AppsByTAP.BlazorFluentUI.Components.Theme.Models;
using AppsByTAP.BlazorFluentUI.Components.Theme.Themes.Light;

builder.Services.AddScoped<IThemeProvider>(_ =>
    new ThemeProvider(new LightThemePalette()));
```

For WebAssembly, a singleton is application-local and appropriate:

```csharp
builder.Services.AddSingleton<IThemeProvider>(
    new ThemeProvider(new LightThemePalette()));
```

The parameterless `ThemeProvider()` constructor selects the dark palette. Pass a palette explicitly when initial appearance matters. See [Theme](components/theme.md) for runtime switching and custom palettes.

## Load Fabric icons

Add the bundled stylesheet to the host page or document head:

```html
<link href="_content/AppsByTAP.BlazorFluentUI.Components/css/fabric-icons-inline.css" rel="stylesheet" />
```

Components import their own JavaScript modules through Razor class library URLs; do not copy those files into the host. Masking loads `Mask.js`, which in turn depends on the bundled IMask script.

## Wrap the application

```razor
@using AppsByTAP.BlazorFluentUI.Components.Theme

<Theme>
    <Router AppAssembly="@typeof(App).Assembly">
        ...
    </Router>
</Theme>
```

`Theme` emits global `:root` variables and body styles and adds one wrapper `div` around its child content.

## Import only the namespaces you use

There is no single umbrella namespace. Add exact namespaces to `_Imports.razor`, for example:

```razor
@using AppsByTAP.BlazorFluentUI.Components.Button
@using AppsByTAP.BlazorFluentUI.Components.Icon
@using AppsByTAP.BlazorFluentUI.Components.TextField
@using AppsByTAP.BlazorFluentUI.Components.Toggle
```

Two public components are named `TextField`: one in `.TextField` and an `InputBase<string>` implementation in `.Forms`. Importing both creates an ambiguous tag; use namespace aliases or import only the intended one.

## First page

```razor
@page "/profile"

<TextField Label="Name" PlaceHolder="Enter your name" @bind-Value="name" />
<Toggle Label="Receive updates" @bind-IsChecked="receiveUpdates" />
<DefaultButton Text="Save" IsPrimary="true" ShowIsBusy="true" OnClick="SaveAsync" />

@code {
    private string name = "";
    private bool receiveUpdates;

    private Task SaveAsync() => Task.CompletedTask;
}
```

Before adding another property, open that component's page from the [component index](components/index.md). Incorrect component attributes may compile into a render tree and fail when Blazor applies parameters at runtime.
