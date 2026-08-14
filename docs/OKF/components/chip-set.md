---
type: Blazor Component
title: "ChipSet<TItem>"
description: "A generic collection of editable/selectable chips with optional new-item creation."
resource: "../../../AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components/Chip/ChipSet.razor"
tags: [blazor, fluent-ui, component, api-reference]
status: stable
dotnet_type: "AppsByTAP.BlazorFluentUI.Components.Chip.ChipSet`1"
component_source: "AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components/Chip/ChipSet.razor"
generic_parameters: ["TItem"]
generated: { by: codex/gpt-5, at: 2026-08-14T00:00:00-04:00 }
verified: { by: "process:okf-docs-validator", at: 2026-08-14T00:00:00-04:00 }
verification_scope: api-contract-links-examples-and-theme-tokens
sources:
  - id: component-source
    resource: "../../../AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components/Chip/ChipSet.razor"
    title: "ChipSet Razor source"
---

# ChipSet<TItem>

A generic collection of editable/selectable chips with optional new-item creation.

## Contract

- Namespace: `AppsByTAP.BlazorFluentUI.Components.Chip`
- Compiled type: `AppsByTAP.BlazorFluentUI.Components.Chip.ChipSet<TItem>`
- Base type: `ChipSetViewModel<TItem>`
- Intended level: consumer-facing component.

### Generic type parameters

- `TItem`

## Parameters

The table lists the effective runtime contract, including inherited library and framework parameters.

<!-- parameters:start -->
| Name | Type | Default | Required | Binding | Declared by | Notes |
|---|---|---|---|---|---|---|
| `ChipType` | `ChipType` | `ChipType.Input` | No | `-` | `ChipSetViewModel<TItem>` | Public component parameter; see behavior and gotchas below for component-specific effects. |
| `ClassName` | `string` | `""` | No | `-` | `BaseComponentViewModel` | Additional CSS class string inherited from the library base type. |
| `CreateNewItem` | `Func<string, TItem>` | `null` | No | `-` | `ChipSetViewModel<TItem>` | Converts entered text into T. |
| `ID` | `string` | `""` | No | `-` | `BaseComponentViewModel` | DOM id; required by masking features. |
| `ItemsSource` | `List<TItem>` | `null` | No | `@bind-ItemsSource` | `ChipSetViewModel<TItem>` | Items rendered by the component. |
| `ItemsSourceChanged` | `EventCallback<List<TItem>>` | `default` | No | `-` | `ChipSetViewModel<TItem>` | Binding callback paired with ItemsSource; normally supplied by @bind syntax. |
| `Label` | `string` | `null` | No | `-` | `ChipSetViewModel<TItem>` | Visible label text. |
| `SelectedItem` | `TItem` | `null` | No | `-` | `ChipSetViewModel<TItem>` | Current single selected item. |
| `SelectedItems` | `List<TItem>` | `null` | No | `-` | `ChipSetViewModel<TItem>` | Current multi-selection. |
| `SelectionType` | `SelectionType` | `SelectionType.Single` | No | `-` | `ChipSetViewModel<TItem>` | Public component parameter; see behavior and gotchas below for component-specific effects. |
| `Style` | `string` | `""` | No | `-` | `BaseComponentViewModel` | Inline CSS appended to the component root. |
| `Watermark` | `string` | `"Comma Separated Values"` | No | `-` | `ChipSetViewModel<TItem>` | Public component parameter; see behavior and gotchas below for component-specific effects. |
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
<ChipSet TItem="string" ItemsSource="@tags" ChipType="ChipType.Input" CreateNewItem="@(text => text)" />
```

Configured/composed:

```razor
<ChipSet TItem="string" Label="Tags" @bind-ItemsSource="tags" ChipType="ChipType.Filter" SelectionType="SelectionType.Multi" SelectedItems="@selectedTags" CreateNewItem="@(text => text)" Watermark="Add tag" />
```

## Rendered structure

- HTML elements observed in the Razor source: `div`, `input`.
- Composed component elements observed in the Razor source: `AppsByTAP`, `Chip`, `TItem`.
- Elements may be conditional on parameters and internal state. Attribute forwarding is limited to the parameters shown in the contract table; do not assume arbitrary attributes reach the root.

## Associated types

- `ChipType`
- `EventCallback<List<TItem>>`
- `Func<string, TItem>`
- `List<TItem>`
- `SelectionType`
- `TItem`

Exact enum members and model properties are listed in the [public supporting types reference](../references/public-types.md).

## Lifecycle and callback behavior

- Lifecycle methods implemented by this component: `OnInitialized`.

- `ItemsSourceChanged` (`EventCallback<List<TItem>>`) is invoked with `value`.

## Rendering, services, and assets

Injected services:

None.

JavaScript modules:

None.

Static asset contract:

- CSS isolation inputs: `AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components/Chip/ChipSet.razor.css`. They are bundled by the Razor class library build.
- No direct JavaScript module import is observable in this component source.

Source files:

- [ChipSet.razor](../../../AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components/Chip/ChipSet.razor)
- [ChipSet.razor.cs](../../../AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components/Chip/ChipSet.razor.cs)
- [ChipSet.razor.css](../../../AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components/Chip/ChipSet.razor.css)

## Styling and theme tokens

- `--palette-Black`
- `--semanticColors-ButtonBorder`
- `--semanticTextColors-BodyText`

The listed tokens are case-sensitive. Use the [Theme reference](theme.md) for their emitted values and customization rules.

## Accessibility

Inspect the rendered markup before assuming ARIA roles or keyboard behavior; the component does not add accessibility behavior beyond what is present in its source markup.

## Exceptions

No exception is thrown explicitly in the component source. Consumer callbacks, invalid templates/data, and JavaScript interop can still propagate their own failures.

## Gotchas and current limitations

- CreateNewItem must be supplied before the input-creation path is used.
- The implementation writes child component parameters from outside the child and currently produces BL0005 warnings.
- SelectionType.Single and Multi update different selection properties; no SelectedItemChanged/SelectedItemsChanged callbacks are exposed.

## Related knowledge

- [Component index](index.md)
- [Architecture and binding conventions](../architecture-and-binding.md)
- [Public supporting types](../references/public-types.md)
- [Static assets and JavaScript interop](../references/static-assets-and-js.md)
