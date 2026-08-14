---
type: Blazor Component
title: "LightDismiss"
description: "A fixed backdrop layer that closes its owning overlay when clicked."
resource: "../../../AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components/LightDismiss/LightDismiss.razor"
tags: [blazor, fluent-ui, component, api-reference]
status: stable
dotnet_type: "AppsByTAP.BlazorFluentUI.Components.LightDismiss.LightDismiss"
component_source: "AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components/LightDismiss/LightDismiss.razor"
generic_parameters: []
generated: { by: codex/gpt-5, at: 2026-08-14T00:00:00-04:00 }
verified: { by: "process:okf-docs-validator", at: 2026-08-14T00:00:00-04:00 }
verification_scope: api-contract-links-examples-and-theme-tokens
sources:
  - id: component-source
    resource: "../../../AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components/LightDismiss/LightDismiss.razor"
    title: "LightDismiss Razor source"
---

# LightDismiss

A fixed backdrop layer that closes its owning overlay when clicked.

## Contract

- Namespace: `AppsByTAP.BlazorFluentUI.Components.LightDismiss`
- Compiled type: `AppsByTAP.BlazorFluentUI.Components.LightDismiss.LightDismiss`
- Base type: `ComponentBase`
- Intended level: consumer-facing component.

### Generic type parameters

None.

## Parameters

The table lists the effective runtime contract, including inherited library and framework parameters.

<!-- parameters:start -->
| Name | Type | Default | Required | Binding | Declared by | Notes |
|---|---|---|---|---|---|---|
| `IsOpen` | `bool` | `false` | No | `@bind-IsOpen` | `LightDismiss` | Current overlay/expansion state. |
| `IsOpenChanged` | `EventCallback<bool>` | `default` | No | `-` | `LightDismiss` | Binding callback paired with IsOpen; normally supplied by @bind syntax. |
| `Layer` | `int` | `-1` | No | `-` | `LightDismiss` | Explicit z-index/layer value. |
| `OnClose` | `EventCallback` | `default` | No | `-` | `LightDismiss` | Public component parameter; see behavior and gotchas below for component-specific effects. |
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
<LightDismiss @bind-IsOpen="open" OnClose="Closed" />
```

Configured/composed:

```razor
<LightDismiss Layer="1000" @bind-IsOpen="overlayOpen" OnClose="CloseOverlay" />
```

## Rendered structure

- HTML elements observed in the Razor source: `div`.
- Elements may be conditional on parameters and internal state. Attribute forwarding is limited to the parameters shown in the contract table; do not assume arbitrary attributes reach the root.

## Associated types

- `EventCallback<bool>`

Exact enum members and model properties are listed in the [public supporting types reference](../references/public-types.md).

## Lifecycle and callback behavior

No lifecycle method is overridden in this component's Razor/code-behind files; normal ComponentBase parameter assignment and rendering apply.

- `IsOpenChanged` (`EventCallback<bool>`) is invoked with `IsOpen`.
- `OnClose` (`EventCallback`) is invoked with `no payload`.

## Rendering, services, and assets

Injected services:

None.

JavaScript modules:

None.

Static asset contract:

- CSS isolation inputs: `AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components/LightDismiss/LightDismiss.razor.css`. They are bundled by the Razor class library build.
- No direct JavaScript module import is observable in this component source.

Source files:

- [LightDismiss.razor](../../../AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components/LightDismiss/LightDismiss.razor)
- [LightDismiss.razor.cs](../../../AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components/LightDismiss/LightDismiss.razor.cs)
- [LightDismiss.razor.css](../../../AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components/LightDismiss/LightDismiss.razor.css)

## Styling and theme tokens

No CSS custom properties are referenced directly by this component source.

The listed tokens are case-sensitive. Use the [Theme reference](theme.md) for their emitted values and customization rules.

## Accessibility

Overlay visibility is implemented, but focus trapping, focus restoration, Escape handling, and complete dialog semantics are not supplied automatically.

## Exceptions

No exception is thrown explicitly in the component source. Consumer callbacks, invalid templates/data, and JavaScript interop can still propagate their own failures.

## Gotchas and current limitations

- Layer is allocated from a process-local counter when not supplied.
- Clicking the backdrop invokes OnClose and updates IsOpenChanged.
- It supplies no focus management or Escape-key handling.

## Related knowledge

- [Component index](index.md)
- [Architecture and binding conventions](../architecture-and-binding.md)
- [Public supporting types](../references/public-types.md)
- [Static assets and JavaScript interop](../references/static-assets-and-js.md)
