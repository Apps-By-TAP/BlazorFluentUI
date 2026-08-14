---
type: Blazor Component
title: "PostButton"
description: "A native form-posting button that submits hidden name/value fields to a URL."
resource: "../../../AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components/Button/PostButton.razor"
tags: [blazor, fluent-ui, component, api-reference]
status: stable
dotnet_type: "AppsByTAP.BlazorFluentUI.Components.Button.PostButton"
component_source: "AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components/Button/PostButton.razor"
generic_parameters: []
generated: { by: codex/gpt-5, at: 2026-08-14T00:00:00-04:00 }
verified: { by: "process:okf-docs-validator", at: 2026-08-14T00:00:00-04:00 }
verification_scope: api-contract-links-examples-and-theme-tokens
sources:
  - id: component-source
    resource: "../../../AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components/Button/PostButton.razor"
    title: "PostButton Razor source"
---

# PostButton

A native form-posting button that submits hidden name/value fields to a URL.

## Contract

- Namespace: `AppsByTAP.BlazorFluentUI.Components.Button`
- Compiled type: `AppsByTAP.BlazorFluentUI.Components.Button.PostButton`
- Base type: `PostButtonViewModel`
- Intended level: consumer-facing component.

### Generic type parameters

None.

## Parameters

The table lists the effective runtime contract, including inherited library and framework parameters.

<!-- parameters:start -->
| Name | Type | Default | Required | Binding | Declared by | Notes |
|---|---|---|---|---|---|---|
| `ClassName` | `string` | `""` | No | `-` | `BaseComponentViewModel` | Additional CSS class string inherited from the library base type. |
| `Disabled` | `bool` | `false` | No | `-` | `PostButtonViewModel` | Prevents the component action using component logic. |
| `FormID` | `string` | `null` | No | `@bind-FormID` | `PostButtonViewModel` | Public component parameter; see behavior and gotchas below for component-specific effects. |
| `FormIDChanged` | `EventCallback<string>` | `default` | No | `-` | `PostButtonViewModel` | Binding callback paired with FormID; normally supplied by @bind syntax. |
| `HiddenValues` | `List<HiddenValue>` | `empty` | No | `-` | `PostButtonViewModel` | Public component parameter; see behavior and gotchas below for component-specific effects. |
| `ID` | `string` | `""` | No | `-` | `BaseComponentViewModel` | DOM id; required by masking features. |
| `IsPrimary` | `bool` | `false` | No | `-` | `PostButtonViewModel` | Public component parameter; see behavior and gotchas below for component-specific effects. |
| `Style` | `string` | `""` | No | `-` | `BaseComponentViewModel` | Inline CSS appended to the component root. |
| `Text` | `string` | `null` | No | `-` | `PostButtonViewModel` | Primary display text. |
| `Url` | `string` | `null` | No | `-` | `PostButtonViewModel` | Public component parameter; see behavior and gotchas below for component-specific effects. |
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
<PostButton Text="Submit" Url="/orders" />
```

Configured/composed:

```razor
<PostButton Text="Submit" Url="/orders" FormID="order-form" HiddenValues="@fields" IsPrimary="true" />
```

## Rendered structure

- HTML elements observed in the Razor source: `button`, `form`, `input`.
- Elements may be conditional on parameters and internal state. Attribute forwarding is limited to the parameters shown in the contract table; do not assume arbitrary attributes reach the root.

## Associated types

- `EventCallback<string>`
- `List<HiddenValue>`

Exact enum members and model properties are listed in the [public supporting types reference](../references/public-types.md).

## Lifecycle and callback behavior

No lifecycle method is overridden in this component's Razor/code-behind files; normal ComponentBase parameter assignment and rendering apply.

- `FormIDChanged` is declared as `EventCallback<string>`; no direct InvokeAsync call is observable in this component's source files. A wrapper/base implementation may invoke it, or the current API may be inert.

## Rendering, services, and assets

Injected services:

None.

JavaScript modules:

None.

Static asset contract:

- CSS isolation inputs: `AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components/Button/PostButton.razor.css`. They are bundled by the Razor class library build.
- No direct JavaScript module import is observable in this component source.

Source files:

- [PostButton.razor](../../../AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components/Button/PostButton.razor)
- [PostButton.razor.cs](../../../AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components/Button/PostButton.razor.cs)
- [PostButton.razor.css](../../../AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components/Button/PostButton.razor.css)

## Styling and theme tokens

- `--semanticColors-ButtonBackground`
- `--semanticColors-ButtonBackgroundChecked`
- `--semanticColors-ButtonBackgroundHovered`
- `--semanticColors-ButtonBorder`
- `--semanticColors-PrimaryButtonBackground`
- `--semanticColors-PrimaryButtonBackgroundHovered`
- `--semanticColors-PrimaryButtonBackgroundPressed`
- `--semanticTextColors-ButtonText`
- `--semanticTextColors-Link`
- `--semanticTextColors-PrimaryButtonText`

The listed tokens are case-sensitive. Use the [Theme reference](theme.md) for their emitted values and customization rules.

## Accessibility

Inspect the rendered markup before assuming ARIA roles or keyboard behavior; the component does not add accessibility behavior beyond what is present in its source markup.

## Exceptions

No exception is thrown explicitly in the component source. Consumer callbacks, invalid templates/data, and JavaScript interop can still propagate their own failures.

## Gotchas and current limitations

- Submitting navigates away using a native form post; OnClick is not available.
- HiddenValues is rendered directly as hidden inputs and should be treated as untrusted input when values come from users.

## Related knowledge

- [Component index](index.md)
- [Architecture and binding conventions](../architecture-and-binding.md)
- [Public supporting types](../references/public-types.md)
- [Static assets and JavaScript interop](../references/static-assets-and-js.md)
