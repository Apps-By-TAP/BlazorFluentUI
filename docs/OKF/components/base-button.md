---
type: Blazor Component
title: "BaseButton"
description: "The shared WPF-style button implementation used by several public button variants."
resource: "../../../AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components/Button/BaseButton.razor"
tags: [blazor, fluent-ui, component, api-reference]
status: stable
dotnet_type: "AppsByTAP.BlazorFluentUI.Components.Button.BaseButton"
component_source: "AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components/Button/BaseButton.razor"
generic_parameters: []
generated: { by: codex/gpt-5, at: 2026-08-14T00:00:00-04:00 }
verified: { by: "process:okf-docs-validator", at: 2026-08-14T00:00:00-04:00 }
verification_scope: api-contract-links-examples-and-theme-tokens
sources:
  - id: component-source
    resource: "../../../AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components/Button/BaseButton.razor"
    title: "BaseButton Razor source"
---

# BaseButton

The shared WPF-style button implementation used by several public button variants.

## Contract

- Namespace: `AppsByTAP.BlazorFluentUI.Components.Button`
- Compiled type: `AppsByTAP.BlazorFluentUI.Components.Button.BaseButton`
- Base type: `BaseButtonViewModel`
- Intended level: low-level or composition component; use directly only when its contract fits the scenario.

### Generic type parameters

None.

## Parameters

The table lists the effective runtime contract, including inherited library and framework parameters.

<!-- parameters:start -->
| Name | Type | Default | Required | Binding | Declared by | Notes |
|---|---|---|---|---|---|---|
| `ClassName` | `string` | `""` | No | `-` | `BaseComponentViewModel` | Additional CSS class string inherited from the library base type. |
| `Disabled` | `bool` | `false` | No | `-` | `ButtonBaseParameters` | Prevents the component action using component logic. |
| `ID` | `string` | `""` | No | `-` | `BaseComponentViewModel` | DOM id; required by masking features. |
| `Icon` | `IconTypes` | `IconTypes.None` | No | `-` | `ButtonBaseParameters` | IconTypes value rendered by the component. |
| `IsPrimary` | `bool` | `false` | No | `-` | `ButtonBaseParameters` | Public component parameter; see behavior and gotchas below for component-specific effects. |
| `OnClick` | `EventCallback<MouseEventArgs>` | `default` | No | `-` | `ButtonBaseParameters` | Invoked for an accepted click. |
| `OnClickStopPropagation` | `bool` | `false` | No | `-` | `ButtonBaseParameters` | Controls Blazor click event propagation. |
| `SecondaryText` | `string` | `null` | No | `-` | `BaseButtonViewModel` | Public component parameter; see behavior and gotchas below for component-specific effects. |
| `ShowIsBusy` | `bool` | `false` | No | `-` | `ButtonBaseParameters` | Public component parameter; see behavior and gotchas below for component-specific effects. |
| `Style` | `string` | `""` | No | `-` | `BaseComponentViewModel` | Inline CSS appended to the component root. |
| `Text` | `string` | `null` | No | `-` | `ButtonBaseParameters` | Primary display text. |
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
<BaseButton Text="Save" OnClick="Save" />
```

Configured/composed:

```razor
<BaseButton Text="Save" Icon="IconTypes.CheckMark" IsPrimary="true" ShowIsBusy="true" OnClick="SaveAsync" />
```

## Rendered structure

- HTML elements observed in the Razor source: `div`.
- Composed component elements observed in the Razor source: `Icon`, `TinySpinner`.
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

- CSS isolation inputs: `AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components/Button/BaseButton.razor.css`. They are bundled by the Razor class library build.
- No direct JavaScript module import is observable in this component source.

Source files:

- [BaseButton.razor](../../../AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components/Button/BaseButton.razor)
- [BaseButton.razor.cs](../../../AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components/Button/BaseButton.razor.cs)
- [BaseButton.razor.css](../../../AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components/Button/BaseButton.razor.css)

## Styling and theme tokens

- `--semanticColors-ButtonBackgroundChecked`
- `--semanticColors-ButtonBackgroundHovered`
- `--semanticColors-ButtonBorder`
- `--semanticColors-ListItemBackgroundCheckedHovered`
- `--semanticColors-PrimaryButtonBackground`
- `--semanticColors-PrimaryButtonBackgroundHovered`
- `--semanticColors-PrimaryButtonBackgroundPressed`
- `--semanticTextColors-ButtonText`
- `--semanticTextColors-DisabledText`
- `--semanticTextColors-PrimaryButtonText`

The listed tokens are case-sensitive. Use the [Theme reference](theme.md) for their emitted values and customization rules.

## Accessibility

The interactive surface is div-based. Add an accessible wrapper or extend the component before relying on keyboard activation, native disabled behavior, or button/checkbox semantics.

## Exceptions

No exception is thrown explicitly in the component source. Consumer callbacks, invalid templates/data, and JavaScript interop can still propagate their own failures.

## Gotchas and current limitations

- The clickable root is a div, not a native button; keyboard activation and native disabled semantics are not provided.
- ShowIsBusy controls temporary internal IsBusy state; IsBusy itself is not a parameter.
- OnClickInternal is async void, so consumer callback failures cannot be awaited by the caller.

## Related knowledge

- [Component index](index.md)
- [Architecture and binding conventions](../architecture-and-binding.md)
- [Public supporting types](../references/public-types.md)
- [Static assets and JavaScript interop](../references/static-assets-and-js.md)
