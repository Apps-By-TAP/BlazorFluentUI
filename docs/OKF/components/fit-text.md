---
type: Blazor Component
title: "FitText"
description: "A JavaScript-assisted text container that scales content to fit configured bounds."
resource: "../../../AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components/FitText/FitText.razor"
tags: [blazor, fluent-ui, component, api-reference]
status: stable
dotnet_type: "AppsByTAP.BlazorFluentUI.Components.FitText.FitText"
component_source: "AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components/FitText/FitText.razor"
generic_parameters: []
generated: { by: codex/gpt-5, at: 2026-08-14T00:00:00-04:00 }
verified: { by: "process:okf-docs-validator", at: 2026-08-14T00:00:00-04:00 }
verification_scope: api-contract-links-examples-and-theme-tokens
sources:
  - id: component-source
    resource: "../../../AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components/FitText/FitText.razor"
    title: "FitText Razor source"
---

# FitText

A JavaScript-assisted text container that scales content to fit configured bounds.

## Contract

- Namespace: `AppsByTAP.BlazorFluentUI.Components.FitText`
- Compiled type: `AppsByTAP.BlazorFluentUI.Components.FitText.FitText`
- Base type: `ComponentBase`
- Intended level: consumer-facing component.

### Generic type parameters

None.

## Parameters

The table lists the effective runtime contract, including inherited library and framework parameters.

<!-- parameters:start -->
| Name | Type | Default | Required | Binding | Declared by | Notes |
|---|---|---|---|---|---|---|
| `Alignment` | `Alignment` | `Alignment.Center` | No | `-` | `FitText` | Public component parameter; see behavior and gotchas below for component-specific effects. |
| `ChildContent` | `RenderFragment` | `null` | No | `-` | `FitText` | Child markup rendered by the component. |
| `Class` | `string` | `null` | No | `-` | `FitText` | Additional CSS class string. |
| `Compressor` | `double` | `1` | No | `-` | `FitText` | Public component parameter; see behavior and gotchas below for component-specific effects. |
| `Height` | `string` | `"100%"` | No | `-` | `FitText` | Height value; consult the exact type for pixels versus CSS text. |
| `Style` | `string` | `null` | No | `-` | `FitText` | Inline CSS appended to the component root. |
| `Text` | `string` | `null` | No | `-` | `FitText` | Primary display text. |
| `Width` | `string` | `"100%"` | No | `-` | `FitText` | CSS width value. |
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
<FitText Text="Responsive heading" Width="320px" />
```

Configured/composed:

```razor
<FitText Compressor="1.2" Alignment="Alignment.Center" Width="100%" Height="80px"><strong>Dashboard</strong></FitText>
```

## Rendered structure

- HTML elements observed in the Razor source: `div`.
- Composed component elements observed in the Razor source: `IJSObjectReference`.
- Elements may be conditional on parameters and internal state. Attribute forwarding is limited to the parameters shown in the contract table; do not assume arbitrary attributes reach the root.

## Associated types

- `Alignment`

Exact enum members and model properties are listed in the [public supporting types reference](../references/public-types.md).

## Lifecycle and callback behavior

- Lifecycle methods implemented by this component: `OnAfterRenderAsync`, `OnInitializedAsync`.
- After-render work requires an interactive renderer; server prerendering alone cannot complete DOM or JavaScript work.
- The implementation contains a ``firstRender`` branch; initialization performed there is not repeated on ordinary re-renders.

No EventCallback parameters are exposed.

## Rendering, services, and assets

Injected services:

- `IJSRuntime`

JavaScript modules:

- `./_content/AppsByTAP.BlazorFluentUI.Components/js/FitText.js`

Static asset contract:

- No component-scoped ``.razor.css`` file is associated with this component.
- Runtime JavaScript module imports: `./_content/AppsByTAP.BlazorFluentUI.Components/js/FitText.js`.

Source files:

- [FitText.razor](../../../AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components/FitText/FitText.razor)

## Styling and theme tokens

No CSS custom properties are referenced directly by this component source.

The listed tokens are case-sensitive. Use the [Theme reference](theme.md) for their emitted values and customization rules.

## Accessibility

Inspect the rendered markup before assuming ARIA roles or keyboard behavior; the component does not add accessibility behavior beyond what is present in its source markup.

## Exceptions

No exception is thrown explicitly in the component source. Consumer callbacks, invalid templates/data, and JavaScript interop can still propagate their own failures.

## Gotchas and current limitations

- The FitText JS module must be available from the Razor class library static assets.
- Compressor participates in the calculated font size; invalid or zero values can produce unusable output.
- SetElementBounds is JS-invokable async void.

## Related knowledge

- [Component index](index.md)
- [Architecture and binding conventions](../architecture-and-binding.md)
- [Public supporting types](../references/public-types.md)
- [Static assets and JavaScript interop](../references/static-assets-and-js.md)
