---
type: Blazor Component
title: "NavigationItem"
description: "A clickable bottom-navigation entry that renders an icon or image and navigates to a URL."
resource: "../../../AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components/BottomNavigationBar/NavigationItem.razor"
tags: [blazor, fluent-ui, component, api-reference]
status: stable
dotnet_type: "AppsByTAP.BlazorFluentUI.Components.BottomNavigationBar.NavigationItem"
component_source: "AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components/BottomNavigationBar/NavigationItem.razor"
generic_parameters: []
generated: { by: codex/gpt-5, at: 2026-08-14T00:00:00-04:00 }
verified: { by: "process:okf-docs-validator", at: 2026-08-14T00:00:00-04:00 }
verification_scope: api-contract-links-examples-and-theme-tokens
sources:
  - id: component-source
    resource: "../../../AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components/BottomNavigationBar/NavigationItem.razor"
    title: "NavigationItem Razor source"
---

# NavigationItem

A clickable bottom-navigation entry that renders an icon or image and navigates to a URL.

## Contract

- Namespace: `AppsByTAP.BlazorFluentUI.Components.BottomNavigationBar`
- Compiled type: `AppsByTAP.BlazorFluentUI.Components.BottomNavigationBar.NavigationItem`
- Base type: `ComponentBase`
- Intended level: consumer-facing component.

### Generic type parameters

None.

## Parameters

The table lists the effective runtime contract, including inherited library and framework parameters.

<!-- parameters:start -->
| Name | Type | Default | Required | Binding | Declared by | Notes |
|---|---|---|---|---|---|---|
| `ActiveImageUrl` | `string` | `null` | No | `-` | `NavigationItem` | Public component parameter; see behavior and gotchas below for component-specific effects. |
| `Icon` | `IconTypes` | `IconTypes.None` | No | `-` | `NavigationItem` | IconTypes value rendered by the component. |
| `ImageUrl` | `string` | `null` | No | `-` | `NavigationItem` | Public component parameter; see behavior and gotchas below for component-specific effects. |
| `IsActive` | `bool` | `false` | No | `-` | `NavigationItem` | Public component parameter; see behavior and gotchas below for component-specific effects. |
| `Text` | `string` | `null` | No | `-` | `NavigationItem` | Primary display text. |
| `Url` | `string` | `null` | No | `-` | `NavigationItem` | Public component parameter; see behavior and gotchas below for component-specific effects. |
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
<NavigationItem Text="Home" Url="/" Icon="IconTypes.Bank" />
```

Configured/composed:

```razor
<NavigationItem Text="Profile" Url="/profile" ImageUrl="images/user.png" ActiveImageUrl="images/user-active.png" IsActive="@isProfile" />
```

## Rendered structure

- HTML elements observed in the Razor source: `div`, `img`, `style`.
- Composed component elements observed in the Razor source: `Icon`.
- Elements may be conditional on parameters and internal state. Attribute forwarding is limited to the parameters shown in the contract table; do not assume arbitrary attributes reach the root.

## Associated types

- `IconTypes`

Exact enum members and model properties are listed in the [public supporting types reference](../references/public-types.md).

## Lifecycle and callback behavior

No lifecycle method is overridden in this component's Razor/code-behind files; normal ComponentBase parameter assignment and rendering apply.

No EventCallback parameters are exposed.

## Rendering, services, and assets

Injected services:

- `NavigationManager`

JavaScript modules:

None.

Static asset contract:

- No component-scoped ``.razor.css`` file is associated with this component.
- No direct JavaScript module import is observable in this component source.

Source files:

- [NavigationItem.razor](../../../AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components/BottomNavigationBar/NavigationItem.razor)

## Styling and theme tokens

- `--palette-ThemePrimary`
- `--semanticColors-ListItemBackgroundHovered`

The listed tokens are case-sensitive. Use the [Theme reference](theme.md) for their emitted values and customization rules.

## Accessibility

Inspect the rendered markup before assuming ARIA roles or keyboard behavior; the component does not add accessibility behavior beyond what is present in its source markup.

## Exceptions

No exception is thrown explicitly in the component source. Consumer callbacks, invalid templates/data, and JavaScript interop can still propagate their own failures.

## Gotchas and current limitations

- Icon is the corrected 0.1.0 parameter name; the former `ICon` spelling was removed.
- ImageUrl takes visual precedence over Icon; ActiveImageUrl is used only when IsActive is true.
- Navigation is unconditional when clicked and uses NavigationManager.NavigateTo(Url).

## Related knowledge

- [Component index](index.md)
- [Architecture and binding conventions](../architecture-and-binding.md)
- [Public supporting types](../references/public-types.md)
- [Static assets and JavaScript interop](../references/static-assets-and-js.md)
