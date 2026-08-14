---
type: Blazor Component
title: "TextField"
description: "An InputBase<string>-derived text field for EditForm validation and optional masking."
resource: "../../../AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components/Forms/TextField.razor"
tags: [blazor, fluent-ui, component, api-reference]
status: stable
dotnet_type: "AppsByTAP.BlazorFluentUI.Components.Forms.TextField"
component_source: "AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components/Forms/TextField.razor"
generic_parameters: []
generated: { by: codex/gpt-5, at: 2026-08-14T00:00:00-04:00 }
verified: { by: "process:okf-docs-validator", at: 2026-08-14T00:00:00-04:00 }
verification_scope: api-contract-links-examples-and-theme-tokens
sources:
  - id: component-source
    resource: "../../../AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components/Forms/TextField.razor"
    title: "TextField Razor source"
---

# TextField

An InputBase<string>-derived text field for EditForm validation and optional masking.

## Contract

- Namespace: `AppsByTAP.BlazorFluentUI.Components.Forms`
- Compiled type: `AppsByTAP.BlazorFluentUI.Components.Forms.TextField`
- Base type: `InputBase<string>`
- Intended level: consumer-facing component.

### Generic type parameters

None.

## Parameters

The table lists the effective runtime contract, including inherited library and framework parameters.

<!-- parameters:start -->
| Name | Type | Default | Required | Binding | Declared by | Notes |
|---|---|---|---|---|---|---|
| `AdditionalAttributes` | `IReadOnlyDictionary<string, object>` | `null` | No | `-` | `InputBase<string>` | Unmatched HTML attributes inherited from InputBase and applied to the input. |
| `CustomValidation` | `Func<string, ValidationResult<string>>` | `null` | No | `-` | `TextField` | Public component parameter; see behavior and gotchas below for component-specific effects. |
| `DisplayBorder` | `bool` | `true` | No | `-` | `TextField` | Public component parameter; see behavior and gotchas below for component-specific effects. |
| `DisplayName` | `string` | `null` | No | `-` | `InputBase<string>` | Display name used in validation messages. |
| `Height` | `int` | `-1` | No | `-` | `TextField` | Height value; consult the exact type for pixels versus CSS text. |
| `ID` | `string` | `null` | No | `-` | `TextField` | DOM id; required by masking features. |
| `IsMultiLine` | `bool` | `false` | No | `-` | `TextField` | Public component parameter; see behavior and gotchas below for component-specific effects. |
| `Label` | `string` | `null` | No | `-` | `TextField` | Visible label text. |
| `Mask` | `string` | `null` | No | `-` | `TextField` | Mask passed to the bundled IMask integration. |
| `MaxWidth` | `string` | `null` | No | `-` | `TextField` | CSS max-width value. |
| `MultiLineCanResize` | `bool` | `true` | No | `-` | `TextField` | Public component parameter; see behavior and gotchas below for component-specific effects. |
| `OnBlur` | `EventCallback<FocusEventArgs>` | `default` | No | `-` | `TextField` | Invoked when the input loses focus. |
| `PlaceHolder` | `string` | `null` | No | `-` | `TextField` | Input placeholder text; spelling is part of the public API. |
| `Type` | `TextFieldType` | `TextFieldType.text` | No | `-` | `TextField` | Selects the component input/behavior mode. |
| `Value` | `string` | `null` | No | `@bind-Value` | `InputBase<string>` | Current value. |
| `ValueChanged` | `EventCallback<string>` | `default` | No | `-` | `InputBase<string>` | Binding callback paired with Value; normally supplied by @bind syntax. |
| `ValueExpression` | `Expression<Func<string>>` | `null` | No | `-` | `InputBase<string>` | Expression used by InputBase/EditContext validation. |
| `Width` | `string` | `null` | No | `-` | `TextField` | CSS width value. |
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
<EditForm Model="@model"><TextField @bind-Value="model.Name" Label="Name" /></EditForm>
```

Configured/composed:

```razor
<EditForm Model="@model"><TextField ID="phone" @bind-Value="model.Phone" Label="Phone" Type="TextFieldType.tel" Mask="(000) 000-0000" CustomValidation="ValidatePhone" OnBlur="ValidateNow" /></EditForm>
```

## Rendered structure

- HTML elements observed in the Razor source: `div`, `input`, `string`, `textarea`.
- Composed component elements observed in the Razor source: `FocusEventArgs`, `IJSObjectReference`.
- Elements may be conditional on parameters and internal state. Attribute forwarding is limited to the parameters shown in the contract table; do not assume arbitrary attributes reach the root.

## Associated types

- `EventCallback<FocusEventArgs>`
- `EventCallback<string>`
- `Expression<Func<string>>`
- `Func<string, ValidationResult<string>>`
- `IReadOnlyDictionary<string, object>`
- `TextFieldType`

Exact enum members and model properties are listed in the [public supporting types reference](../references/public-types.md).

## Lifecycle and callback behavior

- Lifecycle methods implemented by this component: `OnAfterRenderAsync`.
- After-render work requires an interactive renderer; server prerendering alone cannot complete DOM or JavaScript work.
- The implementation contains a ``firstRender`` branch; initialization performed there is not repeated on ordinary re-renders.

- `OnBlur` is declared as `EventCallback<FocusEventArgs>`; no direct InvokeAsync call is observable in this component's source files. A wrapper/base implementation may invoke it, or the current API may be inert.
- `ValueChanged` is declared as `EventCallback<string>`; no direct InvokeAsync call is observable in this component's source files. A wrapper/base implementation may invoke it, or the current API may be inert.

## Rendering, services, and assets

Injected services:

- `IJSRuntime`

JavaScript modules:

- `./_content/AppsByTAP.BlazorFluentUI.Components/js/Mask.js`

Static asset contract:

- CSS isolation inputs: `AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components/Forms/TextField.razor.css`. They are bundled by the Razor class library build.
- Runtime JavaScript module imports: `./_content/AppsByTAP.BlazorFluentUI.Components/js/Mask.js`.

Source files:

- [TextField.razor](../../../AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components/Forms/TextField.razor)
- [TextField.razor.css](../../../AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components/Forms/TextField.razor.css)

## Styling and theme tokens

- `--label-font-weight`
- `--palette-Black`

The listed tokens are case-sensitive. Use the [Theme reference](theme.md) for their emitted values and customization rules.

## Accessibility

Use a visible label and stable ID where supported. Validation and masking do not replace accessible instructions or error association.

## Exceptions

- Explicit source throw: `ArgumentNullException(nameof(ID))`.

## Gotchas and current limitations

- This is distinct from Components.TextField.TextField and inherits InputBase<string>.
- CustomValidation and ValidationResult<T> are the corrected 0.1.0 names.
- Mask requires a non-empty ID and throws ArgumentNullException after first render otherwise.
- Default validation rejects null, empty, and whitespace-only values.

## Related knowledge

- [Component index](index.md)
- [Architecture and binding conventions](../architecture-and-binding.md)
- [Public supporting types](../references/public-types.md)
- [Static assets and JavaScript interop](../references/static-assets-and-js.md)
