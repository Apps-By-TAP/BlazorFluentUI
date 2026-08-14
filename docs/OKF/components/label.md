---
type: Blazor Component
title: "Label"
description: "A styled label element with hidden and disabled states."
resource: "../../../AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components/Label/Label.razor"
tags: [blazor, fluent-ui, component, api-reference]
status: stable
dotnet_type: "AppsByTAP.BlazorFluentUI.Components.Label.Label"
component_source: "AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components/Label/Label.razor"
generic_parameters: []
generated: { by: codex/gpt-5, at: 2026-08-14T00:00:00-04:00 }
verified: { by: "process:okf-docs-validator", at: 2026-08-14T00:00:00-04:00 }
verification_scope: api-contract-links-examples-and-theme-tokens
sources:
  - id: component-source
    resource: "../../../AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components/Label/Label.razor"
    title: "Label Razor source"
---

# Label

A styled label element with hidden and disabled states.

## Contract

- Namespace: `AppsByTAP.BlazorFluentUI.Components.Label`
- Compiled type: `AppsByTAP.BlazorFluentUI.Components.Label.Label`
- Base type: `ComponentBase`
- Intended level: consumer-facing component.

### Generic type parameters

None.

## Parameters

The table lists the effective runtime contract, including inherited library and framework parameters.

<!-- parameters:start -->
| Name | Type | Default | Required | Binding | Declared by | Notes |
|---|---|---|---|---|---|---|
| `Class` | `string` | `null` | No | `-` | `Label` | Additional CSS class string. |
| `Disabled` | `bool` | `false` | No | `-` | `Label` | Prevents the component action using component logic. |
| `Hidden` | `bool` | `false` | No | `-` | `Label` | Public component parameter; see behavior and gotchas below for component-specific effects. |
| `ID` | `string` | `null` | No | `-` | `Label` | DOM id; required by masking features. |
| `Style` | `string` | `null` | No | `-` | `Label` | Inline CSS appended to the component root. |
| `Text` | `string` | `null` | No | `-` | `Label` | Primary display text. |
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
<Label Text="First name" />
```

Configured/composed:

```razor
<Label ID="account-label" Text="Account" Class="section-label" Disabled="@locked" Hidden="@hideLabel" />
```

## Rendered structure

- HTML elements observed in the Razor source: `div`.
- Elements may be conditional on parameters and internal state. Attribute forwarding is limited to the parameters shown in the contract table; do not assume arbitrary attributes reach the root.

## Associated types

No non-scalar supporting types beyond framework primitives.

Exact enum members and model properties are listed in the [public supporting types reference](../references/public-types.md).

## Lifecycle and callback behavior

No lifecycle method is overridden in this component's Razor/code-behind files; normal ComponentBase parameter assignment and rendering apply.

No EventCallback parameters are exposed.

## Rendering, services, and assets

Injected services:

None.

JavaScript modules:

None.

Static asset contract:

- CSS isolation inputs: `AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components/Label/Label.razor.css`. They are bundled by the Razor class library build.
- No direct JavaScript module import is observable in this component source.

Source files:

- [Label.razor](../../../AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components/Label/Label.razor)
- [Label.razor.cs](../../../AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components/Label/Label.razor.cs)
- [Label.razor.css](../../../AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components/Label/Label.razor.css)

## Styling and theme tokens

- `--label-font-weight`
- `--semanticTextColors-DisabledText`

The listed tokens are case-sensitive. Use the [Theme reference](theme.md) for their emitted values and customization rules.

## Accessibility

Inspect the rendered markup before assuming ARIA roles or keyboard behavior; the component does not add accessibility behavior beyond what is present in its source markup.

## Exceptions

No exception is thrown explicitly in the component source. Consumer callbacks, invalid templates/data, and JavaScript interop can still propagate their own failures.

## Gotchas and current limitations

- Hidden uses component styling rather than conditional removal.
- This component does not associate itself with an input through a for parameter.

## Related knowledge

- [Component index](index.md)
- [Architecture and binding conventions](../architecture-and-binding.md)
- [Public supporting types](../references/public-types.md)
- [Static assets and JavaScript interop](../references/static-assets-and-js.md)
