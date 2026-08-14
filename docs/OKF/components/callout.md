---
type: Blazor Component
title: "Callout"
description: "A positioned overlay anchored to a target element ID with optional light dismiss."
resource: "../../../AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components/Callout/Callout.razor"
tags: [blazor, fluent-ui, component, api-reference]
status: stable
dotnet_type: "AppsByTAP.BlazorFluentUI.Components.Callout.Callout"
component_source: "AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components/Callout/Callout.razor"
generic_parameters: []
generated: { by: codex/gpt-5, at: 2026-08-14T00:00:00-04:00 }
verified: { by: "process:okf-docs-validator", at: 2026-08-14T00:00:00-04:00 }
verification_scope: api-contract-links-examples-and-theme-tokens
sources:
  - id: component-source
    resource: "../../../AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components/Callout/Callout.razor"
    title: "Callout Razor source"
---

# Callout

A positioned overlay anchored to a target element ID with optional light dismiss.

## Contract

- Namespace: `AppsByTAP.BlazorFluentUI.Components.Callout`
- Compiled type: `AppsByTAP.BlazorFluentUI.Components.Callout.Callout`
- Base type: `ComponentBase`
- Intended level: consumer-facing component.

### Generic type parameters

None.

## Parameters

The table lists the effective runtime contract, including inherited library and framework parameters.

<!-- parameters:start -->
| Name | Type | Default | Required | Binding | Declared by | Notes |
|---|---|---|---|---|---|---|
| `CanLightDismiss` | `bool` | `true` | No | `-` | `Callout` | Allows backdrop/outside-click dismissal. |
| `ChildContent` | `RenderFragment` | `null` | No | `-` | `Callout` | Child markup rendered by the component. |
| `Disabled` | `bool` | `false` | No | `-` | `Callout` | Prevents the component action using component logic. |
| `IsOpen` | `bool` | `false` | No | `@bind-IsOpen` | `Callout` | Current overlay/expansion state. |
| `IsOpenChanged` | `EventCallback<bool>` | `default` | No | `-` | `Callout` | Binding callback paired with IsOpen; normally supplied by @bind syntax. |
| `ItemsPanelHeight` | `int` | `-1` | No | `-` | `Callout` | Public component parameter; see behavior and gotchas below for component-specific effects. |
| `OnClose` | `EventCallback` | `default` | No | `-` | `Callout` | Public component parameter; see behavior and gotchas below for component-specific effects. |
| `OnOpen` | `EventCallback` | `default` | No | `-` | `Callout` | Public component parameter; see behavior and gotchas below for component-specific effects. |
| `TargetID` | `string` | `null` | No | `-` | `Callout` | DOM id of the element used for positioning. |
| `Width` | `string` | `"300px"` | No | `-` | `Callout` | CSS width value. |
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
<Callout TargetID="help-button" @bind-IsOpen="showHelp"><p>Help text</p></Callout>
```

Configured/composed:

```razor
<Callout TargetID="actions" Width="360px" ItemsPanelHeight="240" CanLightDismiss="true" @bind-IsOpen="open" OnClose="Closed"><p>Actions</p></Callout>
```

## Rendered structure

- HTML elements observed in the Razor source: `div`.
- Composed component elements observed in the Razor source: `LightDismiss`.
- Elements may be conditional on parameters and internal state. Attribute forwarding is limited to the parameters shown in the contract table; do not assume arbitrary attributes reach the root.

## Associated types

- `EventCallback<bool>`

Exact enum members and model properties are listed in the [public supporting types reference](../references/public-types.md).

## Lifecycle and callback behavior

- Lifecycle methods implemented by this component: `OnAfterRenderAsync`.
- After-render work requires an interactive renderer; server prerendering alone cannot complete DOM or JavaScript work.
- The implementation contains a ``firstRender`` branch; initialization performed there is not repeated on ordinary re-renders.

- `IsOpenChanged` (`EventCallback<bool>`) is invoked with `IsOpen`.
- `OnClose` (`EventCallback`) is invoked with `no payload`.
- `OnOpen` (`EventCallback`) is invoked with `no payload`.

## Rendering, services, and assets

Injected services:

- `IJSRuntime`

JavaScript modules:

- `./_content/AppsByTAP.BlazorFluentUI.Components/js/Callout.js`

Static asset contract:

- CSS isolation inputs: `AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components/Callout/Callout.razor.css`. They are bundled by the Razor class library build.
- Runtime JavaScript module imports: `./_content/AppsByTAP.BlazorFluentUI.Components/js/Callout.js`.

Source files:

- [Callout.razor](../../../AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components/Callout/Callout.razor)
- [Callout.razor.cs](../../../AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components/Callout/Callout.razor.cs)
- [Callout.razor.css](../../../AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components/Callout/Callout.razor.css)

## Styling and theme tokens

- `--semanticColors-ListBackground`
- `--semanticColors-ScrollbarThumb`
- `--semanticColors-ScrollbarTrack`

The listed tokens are case-sensitive. Use the [Theme reference](theme.md) for their emitted values and customization rules.

## Accessibility

Overlay visibility is implemented, but focus trapping, focus restoration, Escape handling, and complete dialog semantics are not supplied automatically.

## Exceptions

No exception is thrown explicitly in the component source. Consumer callbacks, invalid templates/data, and JavaScript interop can still propagate their own failures.

## Gotchas and current limitations

- TargetID must identify an existing DOM element for JS positioning.
- IsOpen invokes OnOpen/OnClose from its setter; parameter setters with side effects produce Blazor analyzer warnings.
- No focus trap or Escape-key behavior is implemented by the component.

## Related knowledge

- [Component index](index.md)
- [Architecture and binding conventions](../architecture-and-binding.md)
- [Public supporting types](../references/public-types.md)
- [Static assets and JavaScript interop](../references/static-assets-and-js.md)
