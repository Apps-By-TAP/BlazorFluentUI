---
type: Blazor Component
title: "FloatingActionButton"
description: "A floating action surface that can render an image, icon, text content, or a combination."
resource: "../../../AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components/FloatingActionButton/FloatingActionButton.razor"
tags: [blazor, fluent-ui, component, api-reference]
status: stable
dotnet_type: "AppsByTAP.BlazorFluentUI.Components.FloatingActionButton.FloatingActionButton"
component_source: "AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components/FloatingActionButton/FloatingActionButton.razor"
generic_parameters: []
generated: { by: codex/gpt-5, at: 2026-08-14T00:00:00-04:00 }
verified: { by: "process:okf-docs-validator", at: 2026-08-14T00:00:00-04:00 }
verification_scope: api-contract-links-examples-and-theme-tokens
sources:
  - id: component-source
    resource: "../../../AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components/FloatingActionButton/FloatingActionButton.razor"
    title: "FloatingActionButton Razor source"
---

# FloatingActionButton

A floating action surface that can render an image, icon, text content, or a combination.

## Contract

- Namespace: `AppsByTAP.BlazorFluentUI.Components.FloatingActionButton`
- Compiled type: `AppsByTAP.BlazorFluentUI.Components.FloatingActionButton.FloatingActionButton`
- Base type: `ComponentBase`
- Intended level: consumer-facing component.

### Generic type parameters

None.

## Parameters

The table lists the effective runtime contract, including inherited library and framework parameters.

<!-- parameters:start -->
| Name | Type | Default | Required | Binding | Declared by | Notes |
|---|---|---|---|---|---|---|
| `BottomNavigationIsVisible` | `bool` | `false` | No | `-` | `FloatingActionButton` | Public component parameter; see behavior and gotchas below for component-specific effects. |
| `ChildContent` | `RenderFragment` | `null` | No | `-` | `FloatingActionButton` | Child markup rendered by the component. |
| `Class` | `string` | `null` | No | `-` | `FloatingActionButton` | Additional CSS class string. |
| `ID` | `string` | `null` | No | `-` | `FloatingActionButton` | DOM id; required by masking features. |
| `Icon` | `IconTypes` | `IconTypes.None` | No | `-` | `FloatingActionButton` | IconTypes value rendered by the component. |
| `IconCompressor` | `double` | `0.1` | No | `-` | `FloatingActionButton` | Public component parameter; see behavior and gotchas below for component-specific effects. |
| `ImageUrl` | `string` | `""` | No | `-` | `FloatingActionButton` | Public component parameter; see behavior and gotchas below for component-specific effects. |
| `OnClick` | `EventCallback<MouseEventArgs>` | `default` | No | `-` | `FloatingActionButton` | Invoked for an accepted click. |
| `OnClickStopPropagation` | `bool` | `true` | No | `-` | `FloatingActionButton` | Controls Blazor click event propagation. |
| `Style` | `string` | `null` | No | `-` | `FloatingActionButton` | Inline CSS appended to the component root. |
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
<FloatingActionButton Icon="IconTypes.Edit" OnClick="Edit" />
```

Configured/composed:

```razor
<FloatingActionButton ID="create" Icon="IconTypes.Edit" BottomNavigationIsVisible="true" IconCompressor="1.2" OnClickStopPropagation="true" OnClick="Create" />
```

## Rendered structure

- HTML elements observed in the Razor source: `div`, `img`.
- Composed component elements observed in the Razor source: `AppsByTAP`.
- Elements may be conditional on parameters and internal state. Attribute forwarding is limited to the parameters shown in the contract table; do not assume arbitrary attributes reach the root.

## Associated types

- `IconTypes`

Exact enum members and model properties are listed in the [public supporting types reference](../references/public-types.md).

## Lifecycle and callback behavior

No lifecycle method is overridden in this component's Razor/code-behind files; normal ComponentBase parameter assignment and rendering apply.

- `OnClick` is declared as `EventCallback<MouseEventArgs>`; no direct InvokeAsync call is observable in this component's source files. A wrapper/base implementation may invoke it, or the current API may be inert.

## Rendering, services, and assets

Injected services:

None.

JavaScript modules:

None.

Static asset contract:

- CSS isolation inputs: `AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components/FloatingActionButton/FloatingActionButton.razor.css`. They are bundled by the Razor class library build.
- No direct JavaScript module import is observable in this component source.

Source files:

- [FloatingActionButton.razor](../../../AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components/FloatingActionButton/FloatingActionButton.razor)
- [FloatingActionButton.razor.cs](../../../AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components/FloatingActionButton/FloatingActionButton.razor.cs)
- [FloatingActionButton.razor.css](../../../AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components/FloatingActionButton/FloatingActionButton.razor.css)

## Styling and theme tokens

- `--semanticColors-ListBackground`
- `--semanticColors-ListItemBackgroundHovered`

The listed tokens are case-sensitive. Use the [Theme reference](theme.md) for their emitted values and customization rules.

## Accessibility

The interactive surface is div-based. Add an accessible wrapper or extend the component before relying on keyboard activation, native disabled behavior, or button/checkbox semantics.

## Exceptions

No exception is thrown explicitly in the component source. Consumer callbacks, invalid templates/data, and JavaScript interop can still propagate their own failures.

## Gotchas and current limitations

- BottomNavigationIsVisible changes bottom offset rather than observing a navigation component automatically.
- The clickable root is not a native button.
- ImageUrl, Icon, and ChildContent may all render; choose deliberately to avoid duplicate visuals.

## Related knowledge

- [Component index](index.md)
- [Architecture and binding conventions](../architecture-and-binding.md)
- [Public supporting types](../references/public-types.md)
- [Static assets and JavaScript interop](../references/static-assets-and-js.md)
