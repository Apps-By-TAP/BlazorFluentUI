---
type: Blazor Component
title: "IconButton"
description: "A compact icon-only clickable control."
resource: "../../../AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components/Button/IconButton.razor"
tags: [blazor, fluent-ui, component, api-reference]
status: stable
dotnet_type: "AppsByTAP.BlazorFluentUI.Components.Button.IconButton"
component_source: "AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components/Button/IconButton.razor"
generic_parameters: []
generated: { by: codex/gpt-5, at: 2026-08-14T00:00:00-04:00 }
verified: { by: "process:okf-docs-validator", at: 2026-08-14T00:00:00-04:00 }
verification_scope: api-contract-links-examples-and-theme-tokens
sources:
  - id: component-source
    resource: "../../../AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components/Button/IconButton.razor"
    title: "IconButton Razor source"
---

# IconButton

A compact icon-only clickable control.

## Contract

- Namespace: `AppsByTAP.BlazorFluentUI.Components.Button`
- Compiled type: `AppsByTAP.BlazorFluentUI.Components.Button.IconButton`
- Base type: `ComponentBase`
- Intended level: consumer-facing component.

### Generic type parameters

None.

## Parameters

The table lists the effective runtime contract, including inherited library and framework parameters.

<!-- parameters:start -->
| Name | Type | Default | Required | Binding | Declared by | Notes |
|---|---|---|---|---|---|---|
| `Class` | `string` | `null` | No | `-` | `IconButton` | Additional CSS class string. |
| `Disabled` | `bool` | `false` | No | `-` | `IconButton` | Prevents the component action using component logic. |
| `ID` | `string` | `null` | No | `-` | `IconButton` | DOM id; required by masking features. |
| `Icon` | `IconTypes` | `IconTypes.None` | No | `-` | `IconButton` | IconTypes value rendered by the component. |
| `OnClick` | `EventCallback<MouseEventArgs>` | `default` | No | `-` | `IconButton` | Invoked for an accepted click. |
| `Style` | `string` | `null` | No | `-` | `IconButton` | Inline CSS appended to the component root. |
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
<IconButton Icon="IconTypes.Settings" OnClick="OpenSettings" />
```

Configured/composed:

```razor
<IconButton Icon="IconTypes.Delete" Disabled="@isLocked" ID="delete-action" OnClick="Delete" />
```

## Rendered structure

- HTML elements observed in the Razor source: `div`, `style`.
- Composed component elements observed in the Razor source: `Icon`, `MouseEventArgs`.
- Elements may be conditional on parameters and internal state. Attribute forwarding is limited to the parameters shown in the contract table; do not assume arbitrary attributes reach the root.

## Associated types

- `IconTypes`

Exact enum members and model properties are listed in the [public supporting types reference](../references/public-types.md).

## Lifecycle and callback behavior

No lifecycle method is overridden in this component's Razor/code-behind files; normal ComponentBase parameter assignment and rendering apply.

- `OnClick` (`EventCallback<MouseEventArgs>`) is invoked with `no payload`.

## Rendering, services, and assets

Injected services:

None.

JavaScript modules:

None.

Static asset contract:

- No component-scoped ``.razor.css`` file is associated with this component.
- No direct JavaScript module import is observable in this component source.

Source files:

- [IconButton.razor](../../../AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components/Button/IconButton.razor)

## Styling and theme tokens

- `--semanticColors-ButtonBackgroundHovered`
- `--semanticColors-ButtonBorder`
- `--semanticColors-ListItemBackgroundCheckedHovered`
- `--semanticTextColors-DisabledText`

The listed tokens are case-sensitive. Use the [Theme reference](theme.md) for their emitted values and customization rules.

## Accessibility

The interactive surface is div-based. Add an accessible wrapper or extend the component before relying on keyboard activation, native disabled behavior, or button/checkbox semantics.

## Exceptions

No exception is thrown explicitly in the component source. Consumer callbacks, invalid templates/data, and JavaScript interop can still propagate their own failures.

## Gotchas and current limitations

- This is a div-based control without native button keyboard/disabled semantics.
- It does not inherit the common button Text, IsPrimary, or ShowIsBusy parameters.

## Related knowledge

- [Component index](index.md)
- [Architecture and binding conventions](../architecture-and-binding.md)
- [Public supporting types](../references/public-types.md)
- [Static assets and JavaScript interop](../references/static-assets-and-js.md)
