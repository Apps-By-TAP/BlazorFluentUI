---
type: Blazor Component
title: "Modal"
description: "A JavaScript-assisted modal with header/content fragments and optional light dismissal."
resource: "../../../AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components/Modal/Modal.razor"
tags: [blazor, fluent-ui, component, api-reference]
status: stable
dotnet_type: "AppsByTAP.BlazorFluentUI.Components.Modal.Modal"
component_source: "AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components/Modal/Modal.razor"
generic_parameters: []
generated: { by: codex/gpt-5, at: 2026-08-14T00:00:00-04:00 }
verified: { by: "process:okf-docs-validator", at: 2026-08-14T00:00:00-04:00 }
verification_scope: api-contract-links-examples-and-theme-tokens
sources:
  - id: component-source
    resource: "../../../AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components/Modal/Modal.razor"
    title: "Modal Razor source"
---

# Modal

A JavaScript-assisted modal with header/content fragments and optional light dismissal.

## Contract

- Namespace: `AppsByTAP.BlazorFluentUI.Components.Modal`
- Compiled type: `AppsByTAP.BlazorFluentUI.Components.Modal.Modal`
- Base type: `ModalViewModel`
- Intended level: consumer-facing component.

### Generic type parameters

None.

## Parameters

The table lists the effective runtime contract, including inherited library and framework parameters.

<!-- parameters:start -->
| Name | Type | Default | Required | Binding | Declared by | Notes |
|---|---|---|---|---|---|---|
| `CanLightDismiss` | `bool` | `true` | No | `-` | `ModalViewModel` | Allows backdrop/outside-click dismissal. |
| `ClassName` | `string` | `""` | No | `-` | `BaseComponentViewModel` | Additional CSS class string inherited from the library base type. |
| `Content` | `RenderFragment` | `null` | No | `-` | `ModalViewModel` | Named body fragment. |
| `Header` | `RenderFragment` | `null` | No | `-` | `ModalViewModel` | Header text or named header fragment, according to the declared type. |
| `ID` | `string` | `""` | No | `-` | `BaseComponentViewModel` | DOM id; required by masking features. |
| `OnClose` | `EventCallback` | `default` | No | `-` | `ModalViewModel` | Public component parameter; see behavior and gotchas below for component-specific effects. |
| `ShowHeader` | `bool` | `true` | No | `-` | `ModalViewModel` | Public component parameter; see behavior and gotchas below for component-specific effects. |
| `ShowWindow` | `bool` | `false` | No | `@bind-ShowWindow` | `ModalViewModel` | Current modal visibility state. |
| `ShowWindowChanged` | `EventCallback<bool>` | `default` | No | `-` | `ModalViewModel` | Binding callback paired with ShowWindow; normally supplied by @bind syntax. |
| `Style` | `string` | `""` | No | `-` | `BaseComponentViewModel` | Inline CSS appended to the component root. |
| `Width` | `string` | `"fit-content"` | No | `-` | `ModalViewModel` | CSS width value. |
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
<Modal @bind-ShowWindow="show"><Header>Confirm</Header><Content><p>Continue?</p></Content></Modal>
```

Configured/composed:

```razor
<Modal Width="640px" ShowHeader="true" CanLightDismiss="false" @bind-ShowWindow="show" OnClose="Closed"><Header><strong>Edit item</strong></Header><Content>@editor</Content></Modal>
```

## Rendered structure

- HTML elements observed in the Razor source: `div`.
- Composed component elements observed in the Razor source: `DefaultButton`, `LightDismiss`.
- Elements may be conditional on parameters and internal state. Attribute forwarding is limited to the parameters shown in the contract table; do not assume arbitrary attributes reach the root.

## Associated types

- `EventCallback<bool>`

Exact enum members and model properties are listed in the [public supporting types reference](../references/public-types.md).

## Lifecycle and callback behavior

- Lifecycle methods implemented by this component: `DisposeAsync`, `OnAfterRender`, `OnAfterRenderAsync`.
- After-render work requires an interactive renderer; server prerendering alone cannot complete DOM or JavaScript work.
- The implementation contains a ``firstRender`` branch; initialization performed there is not repeated on ordinary re-renders.
- The component owns disposable state; allow the renderer to dispose it instead of retaining detached instances.

- `OnClose` (`EventCallback`) is invoked with `no payload`.
- `ShowWindowChanged` (`EventCallback<bool>`) is invoked with `false`.

## Rendering, services, and assets

Injected services:

- `protected`

JavaScript modules:

- `./_content/AppsByTAP.BlazorFluentUI.Components/js/Modal.js`

Static asset contract:

- CSS isolation inputs: `AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components/Modal/Modal.razor.css`. They are bundled by the Razor class library build.
- Runtime JavaScript module imports: `./_content/AppsByTAP.BlazorFluentUI.Components/js/Modal.js`.

Source files:

- [Modal.razor](../../../AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components/Modal/Modal.razor)
- [Modal.razor.cs](../../../AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components/Modal/Modal.razor.cs)
- [Modal.razor.css](../../../AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components/Modal/Modal.razor.css)

## Styling and theme tokens

- `--palette-Black`
- `--palette-BlackTranslucent40`
- `--palette-White`
- `--semanticColors-ButtonBackgroundHovered`

The listed tokens are case-sensitive. Use the [Theme reference](theme.md) for their emitted values and customization rules.

## Accessibility

Overlay visibility is implemented, but focus trapping, focus restoration, Escape handling, and complete dialog semantics are not supplied automatically.

## Exceptions

No exception is thrown explicitly in the component source. Consumer callbacks, invalid templates/data, and JavaScript interop can still propagate their own failures.

## Gotchas and current limitations

- The Modal JS module is required for client behavior.
- ShowWindow is the bindable visibility property.
- CanLightDismiss controls backdrop clicks only; no focus trap is implemented.
- Width is inserted as CSS and defaults to fit-content.

## Related knowledge

- [Component index](index.md)
- [Architecture and binding conventions](../architecture-and-binding.md)
- [Public supporting types](../references/public-types.md)
- [Static assets and JavaScript interop](../references/static-assets-and-js.md)
