---
type: Blazor Component
title: "Persona"
description: "A user identity display with initials or image, name, title, and configurable sizing."
resource: "../../../AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components/Persona/Persona.razor"
tags: [blazor, fluent-ui, component, api-reference]
status: stable
dotnet_type: "AppsByTAP.BlazorFluentUI.Components.Persona.Persona"
component_source: "AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components/Persona/Persona.razor"
generic_parameters: []
generated: { by: codex/gpt-5, at: 2026-08-14T00:00:00-04:00 }
verified: { by: "process:okf-docs-validator", at: 2026-08-14T00:00:00-04:00 }
verification_scope: api-contract-links-examples-and-theme-tokens
sources:
  - id: component-source
    resource: "../../../AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components/Persona/Persona.razor"
    title: "Persona Razor source"
---

# Persona

A user identity display with initials or image, name, title, and configurable sizing.

## Contract

- Namespace: `AppsByTAP.BlazorFluentUI.Components.Persona`
- Compiled type: `AppsByTAP.BlazorFluentUI.Components.Persona.Persona`
- Base type: `PersonaViewModel`
- Intended level: consumer-facing component.

### Generic type parameters

None.

## Parameters

The table lists the effective runtime contract, including inherited library and framework parameters.

<!-- parameters:start -->
| Name | Type | Default | Required | Binding | Declared by | Notes |
|---|---|---|---|---|---|---|
| `BackgroundColor` | `string` | `null` | No | `-` | `PersonaViewModel` | Public component parameter; see behavior and gotchas below for component-specific effects. |
| `BorderRadius` | `int` | `50` | No | `-` | `PersonaViewModel` | Public component parameter; see behavior and gotchas below for component-specific effects. |
| `ClassName` | `string` | `""` | No | `-` | `BaseComponentViewModel` | Additional CSS class string inherited from the library base type. |
| `FirstName` | `string` | `null` | No | `-` | `PersonaViewModel` | Public component parameter; see behavior and gotchas below for component-specific effects. |
| `ID` | `string` | `""` | No | `-` | `BaseComponentViewModel` | DOM id; required by masking features. |
| `LastName` | `string` | `null` | No | `-` | `PersonaViewModel` | Public component parameter; see behavior and gotchas below for component-specific effects. |
| `Size` | `int` | `50` | No | `-` | `PersonaViewModel` | Public component parameter; see behavior and gotchas below for component-specific effects. |
| `Style` | `string` | `""` | No | `-` | `BaseComponentViewModel` | Inline CSS appended to the component root. |
| `Title` | `string` | `null` | No | `-` | `PersonaViewModel` | Public component parameter; see behavior and gotchas below for component-specific effects. |
| `UserImage` | `string` | `null` | No | `-` | `PersonaViewModel` | Public component parameter; see behavior and gotchas below for component-specific effects. |
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
<Persona FirstName="Ada" LastName="Lovelace" Title="Engineer" />
```

Configured/composed:

```razor
<Persona FirstName="Ada" LastName="Lovelace" Title="Engineer" UserImage="images/ada.jpg" Size="64" BorderRadius="32" BackgroundColor="var(--palette-ThemePrimary)" />
```

## Rendered structure

- HTML elements observed in the Razor source: `div`.
- Composed component elements observed in the Razor source: `FitText`.
- Elements may be conditional on parameters and internal state. Attribute forwarding is limited to the parameters shown in the contract table; do not assume arbitrary attributes reach the root.

## Associated types

No non-scalar supporting types beyond framework primitives.

Exact enum members and model properties are listed in the [public supporting types reference](../references/public-types.md).

## Lifecycle and callback behavior

- Lifecycle methods implemented by this component: `OnInitialized`, `OnParametersSet`.

No EventCallback parameters are exposed.

## Rendering, services, and assets

Injected services:

None.

JavaScript modules:

None.

Static asset contract:

- CSS isolation inputs: `AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components/Persona/Persona.razor.css`. They are bundled by the Razor class library build.
- No direct JavaScript module import is observable in this component source.

Source files:

- [Persona.razor](../../../AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components/Persona/Persona.razor)
- [Persona.razor.cs](../../../AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components/Persona/Persona.razor.cs)
- [Persona.razor.css](../../../AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components/Persona/Persona.razor.css)

## Styling and theme tokens

No CSS custom properties are referenced directly by this component source.

The listed tokens are case-sensitive. Use the [Theme reference](theme.md) for their emitted values and customization rules.

## Accessibility

Inspect the rendered markup before assuming ARIA roles or keyboard behavior; the component does not add accessibility behavior beyond what is present in its source markup.

## Exceptions

No exception is thrown explicitly in the component source. Consumer callbacks, invalid templates/data, and JavaScript interop can still propagate their own failures.

## Gotchas and current limitations

- BorderRadius is an integer pixel value, not a CSS string.
- UserImage switches from generated initials to an image.
- Initials are derived from FirstName/LastName; there is no Initials parameter.

## Related knowledge

- [Component index](index.md)
- [Architecture and binding conventions](../architecture-and-binding.md)
- [Public supporting types](../references/public-types.md)
- [Static assets and JavaScript interop](../references/static-assets-and-js.md)
