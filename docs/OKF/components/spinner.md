---
type: Blazor Component
title: "Spinner"
description: "A loading indicator with size and label-position options."
resource: "../../../AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components/Spinner/Spinner.razor"
tags: [blazor, fluent-ui, component, api-reference]
status: stable
dotnet_type: "AppsByTAP.BlazorFluentUI.Components.Spinner.Spinner"
component_source: "AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components/Spinner/Spinner.razor"
generic_parameters: []
generated: { by: codex/gpt-5, at: 2026-08-14T00:00:00-04:00 }
verified: { by: "process:okf-docs-validator", at: 2026-08-14T00:00:00-04:00 }
verification_scope: api-contract-links-examples-and-theme-tokens
sources:
  - id: component-source
    resource: "../../../AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components/Spinner/Spinner.razor"
    title: "Spinner Razor source"
---

# Spinner

A loading indicator with size and label-position options.

## Contract

- Namespace: `AppsByTAP.BlazorFluentUI.Components.Spinner`
- Compiled type: `AppsByTAP.BlazorFluentUI.Components.Spinner.Spinner`
- Base type: `SpinnerViewModel`
- Intended level: consumer-facing component.

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
<Spinner IsLoading="true" Label="Loading" />
```

Configured/composed:

```razor
<Spinner @bind-IsLoading="loading" Label="Loading data" Position="SpinnerLabelPosition.Bottom" Size="SpinnerSize.Large" ClassName="page-spinner" />
```

## Rendered structure

- HTML elements observed in the Razor source: `div`, `span`.
- Elements may be conditional on parameters and internal state. Attribute forwarding is limited to the parameters shown in the contract table; do not assume arbitrary attributes reach the root.

## Associated types

- `EventCallback<bool>`
- `SpinnerLabelPosition`
- `SpinnerSize`

Exact enum members and model properties are listed in the [public supporting types reference](../references/public-types.md).

## Lifecycle and callback behavior

No lifecycle method is overridden in this component's Razor/code-behind files; normal ComponentBase parameter assignment and rendering apply.

- `IsLoadingChanged` (`EventCallback<bool>`) is invoked with `_isLoading`.

## Rendering, services, and assets

Injected services:

None.

JavaScript modules:

None.

Static asset contract:

- CSS isolation inputs: `AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components/Spinner/Spinner.razor.css`. They are bundled by the Razor class library build.
- No direct JavaScript module import is observable in this component source.

Source files:

- [Spinner.razor](../../../AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components/Spinner/Spinner.razor)
- [Spinner.razor.cs](../../../AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components/Spinner/Spinner.razor.cs)
- [Spinner.razor.css](../../../AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components/Spinner/Spinner.razor.css)

## Styling and theme tokens

- `--semanticColors-InputPlaceholderBackgroundChecked`
- `--semanticTextColors-Link`

The listed tokens are case-sensitive. Use the [Theme reference](theme.md) for their emitted values and customization rules.

## Accessibility

Inspect the rendered markup before assuming ARIA roles or keyboard behavior; the component does not add accessibility behavior beyond what is present in its source markup.

## Exceptions

No exception is thrown explicitly in the component source. Consumer callbacks, invalid templates/data, and JavaScript interop can still propagate their own failures.

## Gotchas and current limitations

- SpinnerSize.xSmall intentionally begins with a lowercase x.
- IsLoading false hides the wrapper with display:none.
- Parameter setters compute CSS class state and produce analyzer warnings.

## Related knowledge

- [Component index](index.md)
- [Architecture and binding conventions](../architecture-and-binding.md)
- [Public supporting types](../references/public-types.md)
- [Static assets and JavaScript interop](../references/static-assets-and-js.md)
