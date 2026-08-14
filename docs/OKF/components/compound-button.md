---
type: Blazor Component
title: "CompoundButton"
description: "A button variant with primary text and a secondary descriptive line."
resource: "../../../AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components/Button/CompoundButton.razor"
tags: [blazor, fluent-ui, component, api-reference]
status: stable
dotnet_type: "AppsByTAP.BlazorFluentUI.Components.Button.CompoundButton"
component_source: "AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components/Button/CompoundButton.razor"
generic_parameters: []
generated: { by: codex/gpt-5, at: 2026-08-14T00:00:00-04:00 }
verified: { by: "process:okf-docs-validator", at: 2026-08-14T00:00:00-04:00 }
verification_scope: api-contract-links-examples-and-theme-tokens
sources:
  - id: component-source
    resource: "../../../AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components/Button/CompoundButton.razor"
    title: "CompoundButton Razor source"
---

# CompoundButton

A button variant with primary text and a secondary descriptive line.

## Contract

- Namespace: `AppsByTAP.BlazorFluentUI.Components.Button`
- Compiled type: `AppsByTAP.BlazorFluentUI.Components.Button.CompoundButton`
- Base type: `CompoundButtonViewModel`
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
| `IsPrimary` | `bool` | `false` | No | `-` | `ButtonBaseParameters` | Public component parameter; see behavior and gotchas below for component-specific effects. |
| `OnClick` | `EventCallback<MouseEventArgs>` | `default` | No | `-` | `ButtonBaseParameters` | Invoked for an accepted click. |
| `OnClickStopPropagation` | `bool` | `false` | No | `-` | `ButtonBaseParameters` | Controls Blazor click event propagation. |
| `SecondaryText` | `string` | `null` | No | `-` | `CompoundButtonViewModel` | Public component parameter; see behavior and gotchas below for component-specific effects. |
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
<CompoundButton Text="Publish" SecondaryText="Make this visible" OnClick="Publish" />
```

Configured/composed:

```razor
<CompoundButton Text="Delete" SecondaryText="Cannot be undone" IsPrimary="true" Disabled="@isLocked" OnClick="Delete" />
```

## Rendered structure

- Composed component elements observed in the Razor source: `BaseButton`.
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

- No component-scoped ``.razor.css`` file is associated with this component.
- No direct JavaScript module import is observable in this component source.

Source files:

- [CompoundButton.razor](../../../AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components/Button/CompoundButton.razor)
- [CompoundButton.razor.cs](../../../AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components/Button/CompoundButton.razor.cs)

## Styling and theme tokens

No CSS custom properties are referenced directly by this component source.

The listed tokens are case-sensitive. Use the [Theme reference](theme.md) for their emitted values and customization rules.

## Accessibility

The interactive surface is div-based. Add an accessible wrapper or extend the component before relying on keyboard activation, native disabled behavior, or button/checkbox semantics.

## Exceptions

No exception is thrown explicitly in the component source. Consumer callbacks, invalid templates/data, and JavaScript interop can still propagate their own failures.

## Gotchas and current limitations

- Inherited Icon, ShowIsBusy, and OnClickStopPropagation are not forwarded by the current wrapper markup.
- SecondaryText is the only additional parameter over ButtonBaseParameters.

## Related knowledge

- [Component index](index.md)
- [Architecture and binding conventions](../architecture-and-binding.md)
- [Public supporting types](../references/public-types.md)
- [Static assets and JavaScript interop](../references/static-assets-and-js.md)
