---
type: Blazor Component
title: "Toggle"
description: "A WPF-style binary toggle switch with bindable IsChecked state."
resource: "../../../AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components/Toggle/Toggle.razor"
tags: [blazor, fluent-ui, component, api-reference]
status: stable
dotnet_type: "AppsByTAP.BlazorFluentUI.Components.Toggle.Toggle"
component_source: "AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components/Toggle/Toggle.razor"
generic_parameters: []
generated: { by: codex/gpt-5, at: 2026-08-14T00:00:00-04:00 }
verified: { by: "process:okf-docs-validator", at: 2026-08-14T00:00:00-04:00 }
verification_scope: api-contract-links-examples-and-theme-tokens
sources:
  - id: component-source
    resource: "../../../AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components/Toggle/Toggle.razor"
    title: "Toggle Razor source"
---

# Toggle

A WPF-style binary toggle switch with bindable IsChecked state.

## Contract

- Namespace: `AppsByTAP.BlazorFluentUI.Components.Toggle`
- Compiled type: `AppsByTAP.BlazorFluentUI.Components.Toggle.Toggle`
- Base type: `ComponentBase`
- Intended level: consumer-facing component.

### Generic type parameters

None.

## Parameters

The table lists the effective runtime contract, including inherited library and framework parameters.

<!-- parameters:start -->
| Name | Type | Default | Required | Binding | Declared by | Notes |
|---|---|---|---|---|---|---|
| `IsChecked` | `bool` | `false` | No | `@bind-IsChecked` | `Toggle` | Current WPF-style checked state. |
| `IsCheckedChanged` | `EventCallback<bool>` | `default` | No | `-` | `Toggle` | Binding callback paired with IsChecked; normally supplied by @bind syntax. |
| `Label` | `string` | `null` | No | `-` | `Toggle` | Visible label text. |
| `LabelIsInline` | `bool` | `false` | No | `-` | `Toggle` | Public component parameter; see behavior and gotchas below for component-specific effects. |
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
<Toggle Label="Notifications" @bind-IsChecked="notifications" />
```

Configured/composed:

```razor
<Toggle Label="Dark mode" LabelIsInline="true" @bind-IsChecked="darkMode" />
```

## Rendered structure

- HTML elements observed in the Razor source: `bool`, `div`.
- Elements may be conditional on parameters and internal state. Attribute forwarding is limited to the parameters shown in the contract table; do not assume arbitrary attributes reach the root.

## Associated types

- `EventCallback<bool>`

Exact enum members and model properties are listed in the [public supporting types reference](../references/public-types.md).

## Lifecycle and callback behavior

No lifecycle method is overridden in this component's Razor/code-behind files; normal ComponentBase parameter assignment and rendering apply.

- `IsCheckedChanged` (`EventCallback<bool>`) is invoked with `value`.

## Rendering, services, and assets

Injected services:

None.

JavaScript modules:

None.

Static asset contract:

- CSS isolation inputs: `AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components/Toggle/Toggle.razor.css`. They are bundled by the Razor class library build.
- No direct JavaScript module import is observable in this component source.

Source files:

- [Toggle.razor](../../../AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components/Toggle/Toggle.razor)
- [Toggle.razor.css](../../../AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components/Toggle/Toggle.razor.css)

## Styling and theme tokens

- `--palette-Black`
- `--palette-BlackTranslucent40`
- `--palette-White`
- `--semanticColors-ButtonBackgroundHovered`
- `--semanticColors-InputIcon`
- `--semanticTextColors-BodyText`

The listed tokens are case-sensitive. Use the [Theme reference](theme.md) for their emitted values and customization rules.

## Accessibility

The interactive surface is div-based. Add an accessible wrapper or extend the component before relying on keyboard activation, native disabled behavior, or button/checkbox semantics.

## Exceptions

No exception is thrown explicitly in the component source. Consumer callbacks, invalid templates/data, and JavaScript interop can still propagate their own failures.

## Gotchas and current limitations

- Use @bind-IsChecked; there is no Value parameter.
- The IsChecked setter invokes IsCheckedChanged and produces a Blazor analyzer warning.
- The visual switch is div-based and has no native checkbox keyboard semantics.

## Related knowledge

- [Component index](index.md)
- [Architecture and binding conventions](../architecture-and-binding.md)
- [Public supporting types](../references/public-types.md)
- [Static assets and JavaScript interop](../references/static-assets-and-js.md)
