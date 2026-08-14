---
type: Blazor Component
title: "TinySpinner"
description: "A compact spinner variant that shares the Spinner parameter contract but omits label markup."
resource: "../../../AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components/Spinner/TinySpinner.razor"
tags: [blazor, fluent-ui, component, api-reference]
status: stable
dotnet_type: "AppsByTAP.BlazorFluentUI.Components.Spinner.TinySpinner"
component_source: "AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components/Spinner/TinySpinner.razor"
generic_parameters: []
generated: { by: codex/gpt-5, at: 2026-08-14T00:00:00-04:00 }
verified: { by: "process:okf-docs-validator", at: 2026-08-14T00:00:00-04:00 }
verification_scope: api-contract-links-examples-and-theme-tokens
sources:
  - id: component-source
    resource: "../../../AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components/Spinner/TinySpinner.razor"
    title: "TinySpinner Razor source"
---

# TinySpinner

A compact spinner variant that shares the Spinner parameter contract but omits label markup.

## Contract

- Namespace: `AppsByTAP.BlazorFluentUI.Components.Spinner`
- Compiled type: `AppsByTAP.BlazorFluentUI.Components.Spinner.TinySpinner`
- Base type: `SpinnerViewModel`
- Intended level: low-level or composition component; use directly only when its contract fits the scenario.

### Generic type parameters

None.

## Parameters

The table lists the effective runtime contract, including inherited library and framework parameters.

<!-- parameters:start -->
| Name | Type | Default | Required | Binding | Declared by | Notes |
|---|---|---|---|---|---|---|
| `ClassName` | `string` | `""` | No | `-` | `BaseComponentViewModel` | Additional CSS class string inherited from the library base type. |
| `ID` | `string` | `""` | No | `-` | `BaseComponentViewModel` | DOM id; required by masking features. |
| `IsLoading` | `bool` | `true` | No | `@bind-IsLoading` | `SpinnerViewModel` | Controls spinner visibility. |
| `IsLoadingChanged` | `EventCallback<bool>` | `default` | No | `-` | `SpinnerViewModel` | Binding callback paired with IsLoading; normally supplied by @bind syntax. |
| `Label` | `string` | `null` | No | `-` | `SpinnerViewModel` | Visible label text. |
| `Position` | `SpinnerLabelPosition` | `SpinnerLabelPosition.Bottom` | No | `-` | `SpinnerViewModel` | Public component parameter; see behavior and gotchas below for component-specific effects. |
| `Size` | `SpinnerSize` | `SpinnerSize.Large` | No | `-` | `SpinnerViewModel` | Public component parameter; see behavior and gotchas below for component-specific effects. |
| `Style` | `string` | `""` | No | `-` | `BaseComponentViewModel` | Inline CSS appended to the component root. |
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
<TinySpinner IsLoading="true" Size="SpinnerSize.xSmall" />
```

Configured/composed:

```razor
<TinySpinner ID="save-progress" IsLoading="@saving" Size="SpinnerSize.Small" ClassName="inline-progress" />
```

## Rendered structure

- HTML elements observed in the Razor source: `div`, `span`, `style`.
- Elements may be conditional on parameters and internal state. Attribute forwarding is limited to the parameters shown in the contract table; do not assume arbitrary attributes reach the root.

## Associated types

- `EventCallback<bool>`
- `SpinnerLabelPosition`
- `SpinnerSize`

Exact enum members and model properties are listed in the [public supporting types reference](../references/public-types.md).

## Lifecycle and callback behavior

No lifecycle method is overridden in this component's Razor/code-behind files; normal ComponentBase parameter assignment and rendering apply.

- `IsLoadingChanged` is declared as `EventCallback<bool>`; no direct InvokeAsync call is observable in this component's source files. A wrapper/base implementation may invoke it, or the current API may be inert.

## Rendering, services, and assets

Injected services:

None.

JavaScript modules:

None.

Static asset contract:

- No component-scoped ``.razor.css`` file is associated with this component.
- No direct JavaScript module import is observable in this component source.

Source files:

- [TinySpinner.razor](../../../AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components/Spinner/TinySpinner.razor)

## Styling and theme tokens

- `--semanticColors-InputPlaceholderBackgroundChecked`
- `--semanticTextColors-Link`

The listed tokens are case-sensitive. Use the [Theme reference](theme.md) for their emitted values and customization rules.

## Accessibility

Inspect the rendered markup before assuming ARIA roles or keyboard behavior; the component does not add accessibility behavior beyond what is present in its source markup.

## Exceptions

No exception is thrown explicitly in the component source. Consumer callbacks, invalid templates/data, and JavaScript interop can still propagate their own failures.

## Gotchas and current limitations

- TinySpinner inherits Label and Position but does not render label markup.
- SpinnerSize.xSmall intentionally begins with a lowercase x.
- IsLoading is bindable even though consumers usually set it one-way.

## Related knowledge

- [Component index](index.md)
- [Architecture and binding conventions](../architecture-and-binding.md)
- [Public supporting types](../references/public-types.md)
- [Static assets and JavaScript interop](../references/static-assets-and-js.md)
