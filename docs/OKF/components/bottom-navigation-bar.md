---
type: Blazor Component
title: "BottomNavigationBar"
description: "A visual container that fixes navigation items into a horizontal bottom bar."
resource: "../../../AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components/BottomNavigationBar/BottomNavigationBar.razor"
tags: [blazor, fluent-ui, component, api-reference]
status: stable
dotnet_type: "AppsByTAP.BlazorFluentUI.Components.BottomNavigationBar.BottomNavigationBar"
component_source: "AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components/BottomNavigationBar/BottomNavigationBar.razor"
generic_parameters: []
generated: { by: codex/gpt-5, at: 2026-08-14T00:00:00-04:00 }
verified: { by: "process:okf-docs-validator", at: 2026-08-14T00:00:00-04:00 }
verification_scope: api-contract-links-examples-and-theme-tokens
sources:
  - id: component-source
    resource: "../../../AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components/BottomNavigationBar/BottomNavigationBar.razor"
    title: "BottomNavigationBar Razor source"
---

# BottomNavigationBar

A visual container that fixes navigation items into a horizontal bottom bar.

## Contract

- Namespace: `AppsByTAP.BlazorFluentUI.Components.BottomNavigationBar`
- Compiled type: `AppsByTAP.BlazorFluentUI.Components.BottomNavigationBar.BottomNavigationBar`
- Base type: `ComponentBase`
- Intended level: consumer-facing component.

### Generic type parameters

None.

## Parameters

The table lists the effective runtime contract, including inherited library and framework parameters.

<!-- parameters:start -->
| Name | Type | Default | Required | Binding | Declared by | Notes |
|---|---|---|---|---|---|---|
| `ChildContent` | `RenderFragment` | `null` | No | `-` | `BottomNavigationBar` | Child markup rendered by the component. |
| `Class` | `string` | `null` | No | `-` | `BottomNavigationBar` | Additional CSS class string. |
| `Style` | `string` | `null` | No | `-` | `BottomNavigationBar` | Inline CSS appended to the component root. |
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
<BottomNavigationBar><NavigationItem Text="Home" Url="/" Icon="IconTypes.Bank" /></BottomNavigationBar>
```

Configured/composed:

```razor
<BottomNavigationBar Class="app-nav" Style="height:64px"><NavigationItem Text="Home" Url="/" Icon="IconTypes.Bank" IsActive="true" /><NavigationItem Text="Search" Url="/search" Icon="IconTypes.Search" /></BottomNavigationBar>
```

## Rendered structure

- HTML elements observed in the Razor source: `div`, `style`.
- Elements may be conditional on parameters and internal state. Attribute forwarding is limited to the parameters shown in the contract table; do not assume arbitrary attributes reach the root.

## Associated types

No non-scalar supporting types beyond framework primitives.

Exact enum members and model properties are listed in the [public supporting types reference](../references/public-types.md).

## Lifecycle and callback behavior

No lifecycle method is overridden in this component's Razor/code-behind files; normal ComponentBase parameter assignment and rendering apply.

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

- [BottomNavigationBar.razor](../../../AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components/BottomNavigationBar/BottomNavigationBar.razor)

## Styling and theme tokens

- `--semanticColors-ListBackground`

The listed tokens are case-sensitive. Use the [Theme reference](theme.md) for their emitted values and customization rules.

## Accessibility

Inspect the rendered markup before assuming ARIA roles or keyboard behavior; the component does not add accessibility behavior beyond what is present in its source markup.

## Exceptions

No exception is thrown explicitly in the component source. Consumer callbacks, invalid templates/data, and JavaScript interop can still propagate their own failures.

## Gotchas and current limitations

- This component only lays out ChildContent; it does not manage active selection.
- Class is named `Class`, not `ClassName`.

## Related knowledge

- [Component index](index.md)
- [Architecture and binding conventions](../architecture-and-binding.md)
- [Public supporting types](../references/public-types.md)
- [Static assets and JavaScript interop](../references/static-assets-and-js.md)
