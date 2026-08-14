---
type: Blazor Component
title: "TemplateButton"
description: "A button-like container whose visual content is supplied by a RenderFragment."
resource: "../../../AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components/Button/TemplateButton.razor"
tags: [blazor, fluent-ui, component, api-reference]
status: stable
dotnet_type: "AppsByTAP.BlazorFluentUI.Components.Button.TemplateButton"
component_source: "AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components/Button/TemplateButton.razor"
generic_parameters: []
generated: { by: codex/gpt-5, at: 2026-08-14T00:00:00-04:00 }
verified: { by: "process:okf-docs-validator", at: 2026-08-14T00:00:00-04:00 }
verification_scope: api-contract-links-examples-and-theme-tokens
sources:
  - id: component-source
    resource: "../../../AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components/Button/TemplateButton.razor"
    title: "TemplateButton Razor source"
---

# TemplateButton

A button-like container whose visual content is supplied by a RenderFragment.

## Contract

- Namespace: `AppsByTAP.BlazorFluentUI.Components.Button`
- Compiled type: `AppsByTAP.BlazorFluentUI.Components.Button.TemplateButton`
- Base type: `TemplateButtonViewModel`
- Intended level: consumer-facing component.

### Generic type parameters

None.

## Parameters

The table lists the effective runtime contract, including inherited library and framework parameters.

<!-- parameters:start -->
| Name | Type | Default | Required | Binding | Declared by | Notes |
|---|---|---|---|---|---|---|
| `Border` | `string` | `"1px solid var(--semanticColors-ButtonBorder)"` | No | `-` | `TemplateButtonViewModel` | Public component parameter; see behavior and gotchas below for component-specific effects. |
| `BorderRadius` | `string` | `"2px"` | No | `-` | `TemplateButtonViewModel` | Public component parameter; see behavior and gotchas below for component-specific effects. |
| `ChildContent` | `RenderFragment` | `null` | No | `-` | `TemplateButtonViewModel` | Child markup rendered by the component. |
| `ClassName` | `string` | `""` | No | `-` | `BaseComponentViewModel` | Additional CSS class string inherited from the library base type. |
| `Disabled` | `bool` | `false` | No | `-` | `ButtonBaseParameters` | Prevents the component action using component logic. |
| `ID` | `string` | `""` | No | `-` | `BaseComponentViewModel` | DOM id; required by masking features. |
| `Icon` | `IconTypes` | `IconTypes.None` | No | `-` | `ButtonBaseParameters` | IconTypes value rendered by the component. |
| `IsPrimary` | `bool` | `false` | No | `-` | `ButtonBaseParameters` | Public component parameter; see behavior and gotchas below for component-specific effects. |
| `OnClick` | `EventCallback<MouseEventArgs>` | `default` | No | `-` | `ButtonBaseParameters` | Invoked for an accepted click. |
| `OnClickStopPropagation` | `bool` | `false` | No | `-` | `ButtonBaseParameters` | Controls Blazor click event propagation. |
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
<TemplateButton><span>Custom action</span></TemplateButton>
```

Configured/composed:

```razor
<TemplateButton Border="none" BorderRadius="12px" OnClick="Run"><strong>Run</strong></TemplateButton>
```

## Rendered structure

- HTML elements observed in the Razor source: `div`.
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

- CSS isolation inputs: `AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components/Button/TemplateButton.razor.css`. They are bundled by the Razor class library build.
- No direct JavaScript module import is observable in this component source.

Source files:

- [TemplateButton.razor](../../../AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components/Button/TemplateButton.razor)
- [TemplateButton.razor.cs](../../../AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components/Button/TemplateButton.razor.cs)
- [TemplateButton.razor.css](../../../AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components/Button/TemplateButton.razor.css)

## Styling and theme tokens

- `--semanticColors-ButtonBorder`

The listed tokens are case-sensitive. Use the [Theme reference](theme.md) for their emitted values and customization rules.

## Accessibility

The interactive surface is div-based. Add an accessible wrapper or extend the component before relying on keyboard activation, native disabled behavior, or button/checkbox semantics.

## Exceptions

No exception is thrown explicitly in the component source. Consumer callbacks, invalid templates/data, and JavaScript interop can still propagate their own failures.

## Gotchas and current limitations

- The root is button-like markup rather than a native button.
- ChildContent controls presentation; Text and Icon inherited from the base contract are not rendered.

## Related knowledge

- [Component index](index.md)
- [Architecture and binding conventions](../architecture-and-binding.md)
- [Public supporting types](../references/public-types.md)
- [Static assets and JavaScript interop](../references/static-assets-and-js.md)
