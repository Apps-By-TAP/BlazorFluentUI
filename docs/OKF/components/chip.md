---
type: Blazor Component
title: "Chip"
description: "A single chip with input, choice, filter, or action presentation."
resource: "../../../AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components/Chip/Chip.razor"
tags: [blazor, fluent-ui, component, api-reference]
status: stable
dotnet_type: "AppsByTAP.BlazorFluentUI.Components.Chip.Chip"
component_source: "AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components/Chip/Chip.razor"
generic_parameters: []
generated: { by: codex/gpt-5, at: 2026-08-14T00:00:00-04:00 }
verified: { by: "process:okf-docs-validator", at: 2026-08-14T00:00:00-04:00 }
verification_scope: api-contract-links-examples-and-theme-tokens
sources:
  - id: component-source
    resource: "../../../AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components/Chip/Chip.razor"
    title: "Chip Razor source"
---

# Chip

A single chip with input, choice, filter, or action presentation.

## Contract

- Namespace: `AppsByTAP.BlazorFluentUI.Components.Chip`
- Compiled type: `AppsByTAP.BlazorFluentUI.Components.Chip.Chip`
- Base type: `ChipViewModel`
- Intended level: consumer-facing component.

### Generic type parameters

None.

## Parameters

The table lists the effective runtime contract, including inherited library and framework parameters.

<!-- parameters:start -->
| Name | Type | Default | Required | Binding | Declared by | Notes |
|---|---|---|---|---|---|---|
| `ChipType` | `ChipType` | `ChipType.Input` | No | `-` | `ChipViewModel` | Public component parameter; see behavior and gotchas below for component-specific effects. |
| `ClassName` | `string` | `""` | No | `-` | `BaseComponentViewModel` | Additional CSS class string inherited from the library base type. |
| `ID` | `string` | `""` | No | `-` | `BaseComponentViewModel` | DOM id; required by masking features. |
| `OnEdit` | `EventCallback<string>` | `default` | No | `-` | `ChipViewModel` | Public component parameter; see behavior and gotchas below for component-specific effects. |
| `OnRemove` | `EventCallback<string>` | `default` | No | `-` | `ChipViewModel` | Public component parameter; see behavior and gotchas below for component-specific effects. |
| `Style` | `string` | `""` | No | `-` | `BaseComponentViewModel` | Inline CSS appended to the component root. |
| `Text` | `string` | `null` | No | `-` | `ChipViewModel` | Primary display text. |
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
<Chip Text="Blazor" ChipType="ChipType.Input" />
```

Configured/composed:

```razor
<Chip Text="Production" ChipType="ChipType.Filter" OnEdit="EditChip" OnRemove="RemoveChip" />
```

## Rendered structure

- HTML elements observed in the Razor source: `div`, `span`.
- Elements may be conditional on parameters and internal state. Attribute forwarding is limited to the parameters shown in the contract table; do not assume arbitrary attributes reach the root.

## Associated types

- `ChipType`
- `EventCallback<string>`

Exact enum members and model properties are listed in the [public supporting types reference](../references/public-types.md).

## Lifecycle and callback behavior

- Lifecycle methods implemented by this component: `OnInitialized`.

- `OnEdit` (`EventCallback<string>`) is invoked with `ID`.
- `OnRemove` (`EventCallback<string>`) is invoked with `ID`.

## Rendering, services, and assets

Injected services:

None.

JavaScript modules:

None.

Static asset contract:

- CSS isolation inputs: `AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components/Chip/Chip.razor.css`. They are bundled by the Razor class library build.
- No direct JavaScript module import is observable in this component source.

Source files:

- [Chip.razor](../../../AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components/Chip/Chip.razor)
- [Chip.razor.cs](../../../AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components/Chip/Chip.razor.cs)
- [Chip.razor.css](../../../AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components/Chip/Chip.razor.css)

## Styling and theme tokens

- `--palette-Black`
- `--palette-White`
- `--semanticColors-ButtonBackgroundHovered`
- `--semanticColors-ButtonBorder`

The listed tokens are case-sensitive. Use the [Theme reference](theme.md) for their emitted values and customization rules.

## Accessibility

Inspect the rendered markup before assuming ARIA roles or keyboard behavior; the component does not add accessibility behavior beyond what is present in its source markup.

## Exceptions

No exception is thrown explicitly in the component source. Consumer callbacks, invalid templates/data, and JavaScript interop can still propagate their own failures.

## Gotchas and current limitations

- ChipType.Choice is the corrected 0.1.0 enum member; `Choise` was removed.
- OnRemove and OnEdit carry the generated or supplied ID value rather than Text or a chip model.
- Choice/filter state is managed by ChipSet; standalone use does not supply group coordination.

## Related knowledge

- [Component index](index.md)
- [Architecture and binding conventions](../architecture-and-binding.md)
- [Public supporting types](../references/public-types.md)
- [Static assets and JavaScript interop](../references/static-assets-and-js.md)
