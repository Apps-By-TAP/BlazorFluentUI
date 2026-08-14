---
type: Blazor Component
title: "HyperLinkButton"
description: "An anchor-based button with target selection and optional busy animation."
resource: "../../../AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components/Button/HyperLinkButton.razor"
tags: [blazor, fluent-ui, component, api-reference]
status: stable
dotnet_type: "AppsByTAP.BlazorFluentUI.Components.Button.HyperLinkButton"
component_source: "AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components/Button/HyperLinkButton.razor"
generic_parameters: []
generated: { by: codex/gpt-5, at: 2026-08-14T00:00:00-04:00 }
verified: { by: "process:okf-docs-validator", at: 2026-08-14T00:00:00-04:00 }
verification_scope: api-contract-links-examples-and-theme-tokens
sources:
  - id: component-source
    resource: "../../../AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components/Button/HyperLinkButton.razor"
    title: "HyperLinkButton Razor source"
---

# HyperLinkButton

An anchor-based button with target selection and optional busy animation.

## Contract

- Namespace: `AppsByTAP.BlazorFluentUI.Components.Button`
- Compiled type: `AppsByTAP.BlazorFluentUI.Components.Button.HyperLinkButton`
- Base type: `HyperLinkButtonViewModel`
- Intended level: consumer-facing component.

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
| `IsBusyColor1` | `string` | `"rgba(12,123,255)"` | No | `-` | `HyperLinkButtonViewModel` | Public component parameter; see behavior and gotchas below for component-specific effects. |
| `IsBusyColor2` | `string` | `"rgba(12,123,255, 0)"` | No | `-` | `HyperLinkButtonViewModel` | Public component parameter; see behavior and gotchas below for component-specific effects. |
| `IsPrimary` | `bool` | `false` | No | `-` | `ButtonBaseParameters` | Public component parameter; see behavior and gotchas below for component-specific effects. |
| `OnClick` | `EventCallback<MouseEventArgs>` | `default` | No | `-` | `ButtonBaseParameters` | Invoked for an accepted click. |
| `OnClickStopPropagation` | `bool` | `false` | No | `-` | `ButtonBaseParameters` | Controls Blazor click event propagation. |
| `ShowIsBusy` | `bool` | `false` | No | `-` | `ButtonBaseParameters` | Public component parameter; see behavior and gotchas below for component-specific effects. |
| `Style` | `string` | `""` | No | `-` | `BaseComponentViewModel` | Inline CSS appended to the component root. |
| `TargetType` | `TargetTypes` | `TargetTypes.Self` | No | `-` | `HyperLinkButtonViewModel` | Public component parameter; see behavior and gotchas below for component-specific effects. |
| `Text` | `string` | `null` | No | `-` | `ButtonBaseParameters` | Primary display text. |
| `Url` | `string` | `null` | No | `-` | `HyperLinkButtonViewModel` | Public component parameter; see behavior and gotchas below for component-specific effects. |
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
<HyperLinkButton Text="Documentation" Url="/docs" />
```

Configured/composed:

```razor
<HyperLinkButton Text="Open report" Url="/report" TargetType="TargetTypes.Blank" Icon="IconTypes.ReceiptProcessing" />
```

## Rendered structure

- HTML elements observed in the Razor source: `div`, `style`.
- Elements may be conditional on parameters and internal state. Attribute forwarding is limited to the parameters shown in the contract table; do not assume arbitrary attributes reach the root.

## Associated types

- `IconTypes`
- `TargetTypes`

Exact enum members and model properties are listed in the [public supporting types reference](../references/public-types.md).

## Lifecycle and callback behavior

- Lifecycle methods implemented by this component: `OnAfterRenderAsync`.
- After-render work requires an interactive renderer; server prerendering alone cannot complete DOM or JavaScript work.
- The implementation contains a ``firstRender`` branch; initialization performed there is not repeated on ordinary re-renders.

- `OnClick` is declared as `EventCallback<MouseEventArgs>`; no direct InvokeAsync call is observable in this component's source files. A wrapper/base implementation may invoke it, or the current API may be inert.

## Rendering, services, and assets

Injected services:

- `IJSRuntime`

JavaScript modules:

- `./_content/AppsByTAP.BlazorFluentUI.Components/js/HyperLinkButton.js`

Static asset contract:

- CSS isolation inputs: `AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components/Button/HyperLinkButton.razor.css`. They are bundled by the Razor class library build.
- Runtime JavaScript module imports: `./_content/AppsByTAP.BlazorFluentUI.Components/js/HyperLinkButton.js`.

Source files:

- [HyperLinkButton.razor](../../../AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components/Button/HyperLinkButton.razor)
- [HyperLinkButton.razor.cs](../../../AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components/Button/HyperLinkButton.razor.cs)
- [HyperLinkButton.razor.css](../../../AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components/Button/HyperLinkButton.razor.css)

## Styling and theme tokens

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

- Busy CSS is registered only on first render when ShowIsBusy is already true.
- The component imports a JS module and also calls eval to append a style element.
- TargetType defaults to Self; the backing target string remains null until the setter runs, which behaves like the browser default.

## Related knowledge

- [Component index](index.md)
- [Architecture and binding conventions](../architecture-and-binding.md)
- [Public supporting types](../references/public-types.md)
- [Static assets and JavaScript interop](../references/static-assets-and-js.md)
