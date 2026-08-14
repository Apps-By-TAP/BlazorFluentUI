---
type: Blazor Component
title: "TextField"
description: "The standalone WPF-style text input with binding, masking, input types, and character limits."
resource: "../../../AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components/TextField/TextField.razor"
tags: [blazor, fluent-ui, component, api-reference]
status: stable
dotnet_type: "AppsByTAP.BlazorFluentUI.Components.TextField.TextField"
component_source: "AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components/TextField/TextField.razor"
generic_parameters: []
generated: { by: codex/gpt-5, at: 2026-08-14T00:00:00-04:00 }
verified: { by: "process:okf-docs-validator", at: 2026-08-14T00:00:00-04:00 }
verification_scope: api-contract-links-examples-and-theme-tokens
sources:
  - id: component-source
    resource: "../../../AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components/TextField/TextField.razor"
    title: "TextField Razor source"
---

# TextField

The standalone WPF-style text input with binding, masking, input types, and character limits.

## Contract

- Namespace: `AppsByTAP.BlazorFluentUI.Components.TextField`
- Compiled type: `AppsByTAP.BlazorFluentUI.Components.TextField.TextField`
- Base type: `ComponentBase`
- Intended level: consumer-facing component.

### Generic type parameters

None.

## Parameters

The table lists the effective runtime contract, including inherited library and framework parameters.

<!-- parameters:start -->
| Name | Type | Default | Required | Binding | Declared by | Notes |
|---|---|---|---|---|---|---|
| `CharacterLimit` | `int` | `0` | No | `-` | `TextField` | Public component parameter; see behavior and gotchas below for component-specific effects. |
| `Class` | `string` | `null` | No | `-` | `TextField` | Additional CSS class string. |
| `DisplayBorder` | `bool` | `true` | No | `-` | `TextField` | Public component parameter; see behavior and gotchas below for component-specific effects. |
| `Height` | `int` | `-1` | No | `-` | `TextField` | Height value; consult the exact type for pixels versus CSS text. |
| `ID` | `string` | `null` | No | `-` | `TextField` | DOM id; required by masking features. |
| `IsMultiLine` | `bool` | `false` | No | `-` | `TextField` | Public component parameter; see behavior and gotchas below for component-specific effects. |
| `Label` | `string` | `null` | No | `-` | `TextField` | Visible label text. |
| `Mask` | `string` | `null` | No | `-` | `TextField` | Mask passed to the bundled IMask integration. |
| `MaxWidth` | `string` | `null` | No | `-` | `TextField` | CSS max-width value. |
| `MultiLineCanResize` | `bool` | `true` | No | `-` | `TextField` | Public component parameter; see behavior and gotchas below for component-specific effects. |
| `OnBlur` | `EventCallback<FocusEventArgs>` | `default` | No | `-` | `TextField` | Invoked when the input loses focus. |
| `PlaceHolder` | `string` | `null` | No | `-` | `TextField` | Input placeholder text; spelling is part of the public API. |
| `Step` | `double?` | `null` | No | `-` | `TextField` | Public component parameter; see behavior and gotchas below for component-specific effects. |
| `Style` | `string` | `null` | No | `-` | `TextField` | Inline CSS appended to the component root. |
| `Type` | `TextFieldType` | `TextFieldType.text` | No | `-` | `TextField` | Selects the component input/behavior mode. |
| `Value` | `string` | `""` | No | `@bind-Value` | `TextField` | Current value. |
| `ValueChanged` | `EventCallback<string>` | `default` | No | `-` | `TextField` | Binding callback paired with Value; normally supplied by @bind syntax. |
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
<TextField Label="Name" @bind-Value="name" />
```

Configured/composed:

```razor
<TextField ID="email" Label="Email" Type="TextFieldType.email" PlaceHolder="name@example.com" CharacterLimit="120" Width="100%" @bind-Value="email" OnBlur="ValidateEmail" />
```

## Rendered structure

- HTML elements observed in the Razor source: `div`, `input`, `textarea`.
- Composed component elements observed in the Razor source: `AppsByTAP`.
- Elements may be conditional on parameters and internal state. Attribute forwarding is limited to the parameters shown in the contract table; do not assume arbitrary attributes reach the root.

## Associated types

- `EventCallback<FocusEventArgs>`
- `EventCallback<string>`
- `TextFieldType`

Exact enum members and model properties are listed in the [public supporting types reference](../references/public-types.md).

## Lifecycle and callback behavior

- Lifecycle methods implemented by this component: `OnAfterRenderAsync`, `OnParametersSet`.
- After-render work requires an interactive renderer; server prerendering alone cannot complete DOM or JavaScript work.
- The implementation contains a ``firstRender`` branch; initialization performed there is not repeated on ordinary re-renders.

- `OnBlur` is declared as `EventCallback<FocusEventArgs>`; no direct InvokeAsync call is observable in this component's source files. A wrapper/base implementation may invoke it, or the current API may be inert.
- `ValueChanged` (`EventCallback<string>`) is invoked with `newVal`.

## Rendering, services, and assets

Injected services:

- `IJSRuntime`

JavaScript modules:

- `./_content/AppsByTAP.BlazorFluentUI.Components/js/Mask.js`

Static asset contract:

- CSS isolation inputs: `AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components/TextField/TextField.razor.css`. They are bundled by the Razor class library build.
- Runtime JavaScript module imports: `./_content/AppsByTAP.BlazorFluentUI.Components/js/Mask.js`.

Source files:

- [TextField.razor](../../../AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components/TextField/TextField.razor)
- [TextField.razor.cs](../../../AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components/TextField/TextField.razor.cs)
- [TextField.razor.css](../../../AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components/TextField/TextField.razor.css)

## Styling and theme tokens

- `--label-font-weight`
- `--palette-Black`
- `--semanticTextColors-ErrorText`

The listed tokens are case-sensitive. Use the [Theme reference](theme.md) for their emitted values and customization rules.

## Accessibility

Use a visible label and stable ID where supported. Validation and masking do not replace accessible instructions or error association.

## Exceptions

- Explicit source throw: `ArgumentNullException(nameof(ID))`.

## Gotchas and current limitations

- TextFieldType members are lowercase: text, number, tel, email, password.
- Mask requires ID and throws ArgumentNullException on first render otherwise.
- CharacterLimit truncates/blocks input according to component logic; it is not an HTML maxlength passthrough.
- This component is not InputBase and does not integrate with EditForm field validation automatically.

## Related knowledge

- [Component index](index.md)
- [Architecture and binding conventions](../architecture-and-binding.md)
- [Public supporting types](../references/public-types.md)
- [Static assets and JavaScript interop](../references/static-assets-and-js.md)
