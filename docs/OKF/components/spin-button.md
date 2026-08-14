---
type: Blazor Component
title: "SpinButton"
description: "A whole-number or decimal input with buttons and mouse-wheel increment/decrement behavior."
resource: "../../../AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components/SpinButton/SpinButton.razor"
tags: [blazor, fluent-ui, component, api-reference]
status: stable
dotnet_type: "AppsByTAP.BlazorFluentUI.Components.SpinButton.SpinButton"
component_source: "AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components/SpinButton/SpinButton.razor"
generic_parameters: []
generated: { by: codex/gpt-5, at: 2026-08-14T00:00:00-04:00 }
verified: { by: "process:okf-docs-validator", at: 2026-08-14T00:00:00-04:00 }
verification_scope: api-contract-links-examples-and-theme-tokens
sources:
  - id: component-source
    resource: "../../../AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components/SpinButton/SpinButton.razor"
    title: "SpinButton Razor source"
---

# SpinButton

A whole-number or decimal input with buttons and mouse-wheel increment/decrement behavior.

## Contract

- Namespace: `AppsByTAP.BlazorFluentUI.Components.SpinButton`
- Compiled type: `AppsByTAP.BlazorFluentUI.Components.SpinButton.SpinButton`
- Base type: `ComponentBase`
- Intended level: consumer-facing component.

### Generic type parameters

None.

## Parameters

The table lists the effective runtime contract, including inherited library and framework parameters.

<!-- parameters:start -->
| Name | Type | Default | Required | Binding | Declared by | Notes |
|---|---|---|---|---|---|---|
| `DecimalValue` | `double` | `0` | No | `@bind-DecimalValue` | `SpinButton` | Public component parameter; see behavior and gotchas below for component-specific effects. |
| `DecimalValueChanged` | `EventCallback<double>` | `default` | No | `-` | `SpinButton` | Binding callback paired with DecimalValue; normally supplied by @bind syntax. |
| `IncrementAmount` | `double` | `0` | No | `-` | `SpinButton` | Public component parameter; see behavior and gotchas below for component-specific effects. |
| `Label` | `string` | `null` | No | `-` | `SpinButton` | Visible label text. |
| `LabelPosition` | `LabelPosition` | `LabelPosition.Above` | No | `-` | `SpinButton` | Public component parameter; see behavior and gotchas below for component-specific effects. |
| `MaxValue` | `double` | `double.MaxValue` | No | `-` | `SpinButton` | Public component parameter; see behavior and gotchas below for component-specific effects. |
| `MinValue` | `double` | `double.MinValue` | No | `-` | `SpinButton` | Public component parameter; see behavior and gotchas below for component-specific effects. |
| `OnDecrement` | `EventCallback<double>` | `default` | No | `-` | `SpinButton` | Public component parameter; see behavior and gotchas below for component-specific effects. |
| `OnIncrement` | `EventCallback<double>` | `default` | No | `-` | `SpinButton` | Public component parameter; see behavior and gotchas below for component-specific effects. |
| `RoundingPlaces` | `int` | `1` | No | `-` | `SpinButton` | Public component parameter; see behavior and gotchas below for component-specific effects. |
| `Suffix` | `string` | `null` | No | `-` | `SpinButton` | Public component parameter; see behavior and gotchas below for component-specific effects. |
| `TextFieldWidth` | `string` | `"60px"` | No | `-` | `SpinButton` | Public component parameter; see behavior and gotchas below for component-specific effects. |
| `Type` | `SpinButtonType` | `SpinButtonType.Whole` | No | `-` | `SpinButton` | Selects the component input/behavior mode. |
| `WholeValue` | `int` | `0` | No | `@bind-WholeValue` | `SpinButton` | Public component parameter; see behavior and gotchas below for component-specific effects. |
| `WholeValueChanged` | `EventCallback<int>` | `default` | No | `-` | `SpinButton` | Binding callback paired with WholeValue; normally supplied by @bind syntax. |
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
<SpinButton Label="Quantity" Type="SpinButtonType.Whole" @bind-WholeValue="quantity" />
```

Configured/composed:

```razor
<SpinButton Label="Opacity" Type="SpinButtonType.Decimal" MinValue="0" MaxValue="1" IncrementAmount="0.05" RoundingPlaces="2" Suffix="%" @bind-DecimalValue="opacity" />
```

## Rendered structure

- HTML elements observed in the Razor source: `div`, `style`.
- Composed component elements observed in the Razor source: `IconButton`, `TextField`.
- Elements may be conditional on parameters and internal state. Attribute forwarding is limited to the parameters shown in the contract table; do not assume arbitrary attributes reach the root.

## Associated types

- `EventCallback<double>`
- `EventCallback<int>`
- `LabelPosition`
- `SpinButtonType`

Exact enum members and model properties are listed in the [public supporting types reference](../references/public-types.md).

## Lifecycle and callback behavior

- Lifecycle methods implemented by this component: `OnParametersSet`.

- `DecimalValueChanged` (`EventCallback<double>`) is invoked with `DecimalValue`.
- `OnDecrement` is declared as `EventCallback<double>`; no direct InvokeAsync call is observable in this component's source files. A wrapper/base implementation may invoke it, or the current API may be inert.
- `OnIncrement` is declared as `EventCallback<double>`; no direct InvokeAsync call is observable in this component's source files. A wrapper/base implementation may invoke it, or the current API may be inert.
- `WholeValueChanged` (`EventCallback<int>`) is invoked with `WholeValue`.

## Rendering, services, and assets

Injected services:

None.

JavaScript modules:

None.

Static asset contract:

- CSS isolation inputs: `AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components/SpinButton/SpinButton.razor.css`. They are bundled by the Razor class library build.
- No direct JavaScript module import is observable in this component source.

Source files:

- [SpinButton.razor](../../../AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components/SpinButton/SpinButton.razor)
- [SpinButton.razor.cs](../../../AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components/SpinButton/SpinButton.razor.cs)
- [SpinButton.razor.css](../../../AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components/SpinButton/SpinButton.razor.css)

## Styling and theme tokens

- `--label-font-weight`
- `--palette-Black`

The listed tokens are case-sensitive. Use the [Theme reference](theme.md) for their emitted values and customization rules.

## Accessibility

Use a visible label and stable ID where supported. Validation and masking do not replace accessible instructions or error association.

## Exceptions

No exception is thrown explicitly in the component source. Consumer callbacks, invalid templates/data, and JavaScript interop can still propagate their own failures.

## Gotchas and current limitations

- Bind WholeValue or DecimalValue according to SpinButtonType; there is no Value parameter.
- SpinButtonType members are Whole and Decimal.
- OnIncrement and OnDecrement are declared but their invocations are commented out in current source.
- Parsing uses current-culture double parsing and a permissive regex.

## Related knowledge

- [Component index](index.md)
- [Architecture and binding conventions](../architecture-and-binding.md)
- [Public supporting types](../references/public-types.md)
- [Static assets and JavaScript interop](../references/static-assets-and-js.md)
