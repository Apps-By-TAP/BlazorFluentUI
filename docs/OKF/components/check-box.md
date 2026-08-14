---
type: Blazor Component
title: "CheckBox"
description: "A WPF-style binary check control with configurable box placement."
resource: "../../../AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components/CheckBox/CheckBox.razor"
tags: [blazor, fluent-ui, component, api-reference]
status: stable
dotnet_type: "AppsByTAP.BlazorFluentUI.Components.CheckBox.CheckBox"
component_source: "AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components/CheckBox/CheckBox.razor"
generic_parameters: []
generated: { by: codex/gpt-5, at: 2026-08-14T00:00:00-04:00 }
verified: { by: "process:okf-docs-validator", at: 2026-08-14T00:00:00-04:00 }
verification_scope: api-contract-links-examples-and-theme-tokens
sources:
  - id: component-source
    resource: "../../../AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components/CheckBox/CheckBox.razor"
    title: "CheckBox Razor source"
---

# CheckBox

A WPF-style binary check control with configurable box placement.

## Contract

- Namespace: `AppsByTAP.BlazorFluentUI.Components.CheckBox`
- Compiled type: `AppsByTAP.BlazorFluentUI.Components.CheckBox.CheckBox`
- Base type: `CheckBoxViewModel`
- Intended level: consumer-facing component.

### Generic type parameters

None.

## Parameters

The table lists the effective runtime contract, including inherited library and framework parameters.

<!-- parameters:start -->
| Name | Type | Default | Required | Binding | Declared by | Notes |
|---|---|---|---|---|---|---|
| `BoxSide` | `BoxSide` | `BoxSide.Start` | No | `-` | `CheckBoxViewModel` | Public component parameter; see behavior and gotchas below for component-specific effects. |
| `ClassName` | `string` | `""` | No | `-` | `BaseComponentViewModel` | Additional CSS class string inherited from the library base type. |
| `ID` | `string` | `""` | No | `-` | `BaseComponentViewModel` | DOM id; required by masking features. |
| `IsChecked` | `bool` | `false` | No | `@bind-IsChecked` | `CheckBoxViewModel` | Current WPF-style checked state. |
| `IsCheckedChanged` | `EventCallback<bool>` | `default` | No | `-` | `CheckBoxViewModel` | Binding callback paired with IsChecked; normally supplied by @bind syntax. |
| `Label` | `string` | `null` | No | `-` | `CheckBoxViewModel` | Visible label text. |
| `OnChanged` | `EventCallback<CheckBoxChangedArgs>` | `default` | No | `-` | `CheckBoxViewModel` | Binding callback paired with On; normally supplied by @bind syntax. |
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
<CheckBox Label="Remember me" @bind-IsChecked="remember" />
```

Configured/composed:

```razor
<CheckBox Label="Enable feature" BoxSide="BoxSide.End" @bind-IsChecked="enabled" OnChanged="Changed" />
```

## Rendered structure

- HTML elements observed in the Razor source: `div`, `span`.
- Composed component elements observed in the Razor source: `Icon`.
- Elements may be conditional on parameters and internal state. Attribute forwarding is limited to the parameters shown in the contract table; do not assume arbitrary attributes reach the root.

## Associated types

- `BoxSide`
- `EventCallback<bool>`
- `EventCallback<CheckBoxChangedArgs>`

Exact enum members and model properties are listed in the [public supporting types reference](../references/public-types.md).

## Lifecycle and callback behavior

No lifecycle method is overridden in this component's Razor/code-behind files; normal ComponentBase parameter assignment and rendering apply.

- `IsCheckedChanged` (`EventCallback<bool>`) is invoked with `IsChecked`.
- `OnChanged` (`EventCallback<CheckBoxChangedArgs>`) is invoked with `new CheckBoxChangedArgs(IsChecked, this`.

## Rendering, services, and assets

Injected services:

None.

JavaScript modules:

None.

Static asset contract:

- CSS isolation inputs: `AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components/CheckBox/CheckBox.razor.css`. They are bundled by the Razor class library build.
- No direct JavaScript module import is observable in this component source.

Source files:

- [CheckBox.razor](../../../AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components/CheckBox/CheckBox.razor)
- [CheckBox.razor.cs](../../../AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components/CheckBox/CheckBox.razor.cs)
- [CheckBox.razor.css](../../../AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components/CheckBox/CheckBox.razor.css)

## Styling and theme tokens

- `--palette-Black`
- `--semanticColors-InputForegroundChecked`
- `--semanticColors-InputIcon`
- `--semanticTextColors-InputText`

The listed tokens are case-sensitive. Use the [Theme reference](theme.md) for their emitted values and customization rules.

## Accessibility

The interactive surface is div-based. Add an accessible wrapper or extend the component before relying on keyboard activation, native disabled behavior, or button/checkbox semantics.

## Exceptions

No exception is thrown explicitly in the component source. Consumer callbacks, invalid templates/data, and JavaScript interop can still propagate their own failures.

## Gotchas and current limitations

- The placement parameter is named BoxSide, not LabelSide.
- Both @bind-IsChecked and OnChanged can fire for one user action.
- The visual control is div-based and does not provide native checkbox keyboard behavior.

## Related knowledge

- [Component index](index.md)
- [Architecture and binding conventions](../architecture-and-binding.md)
- [Public supporting types](../references/public-types.md)
- [Static assets and JavaScript interop](../references/static-assets-and-js.md)
