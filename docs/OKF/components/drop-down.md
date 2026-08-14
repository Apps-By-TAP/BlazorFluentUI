---
type: Blazor Component
title: "DropDown<TItem>"
description: "A generic single- or multi-select dropdown with optional item templates and grouped DropDownItem data."
resource: "../../../AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components/DropDown/DropDown.razor"
tags: [blazor, fluent-ui, component, api-reference]
status: stable
dotnet_type: "AppsByTAP.BlazorFluentUI.Components.DropDown.DropDown`1"
component_source: "AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components/DropDown/DropDown.razor"
generic_parameters: ["TItem"]
generated: { by: codex/gpt-5, at: 2026-08-14T00:00:00-04:00 }
verified: { by: "process:okf-docs-validator", at: 2026-08-14T00:00:00-04:00 }
verification_scope: api-contract-links-examples-and-theme-tokens
sources:
  - id: component-source
    resource: "../../../AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components/DropDown/DropDown.razor"
    title: "DropDown Razor source"
---

# DropDown<TItem>

A generic single- or multi-select dropdown with optional item templates and grouped DropDownItem data.

## Contract

- Namespace: `AppsByTAP.BlazorFluentUI.Components.DropDown`
- Compiled type: `AppsByTAP.BlazorFluentUI.Components.DropDown.DropDown<TItem>`
- Base type: `DropDownViewModel<TItem>`
- Intended level: consumer-facing component.

### Generic type parameters

- `TItem`

## Parameters

The table lists the effective runtime contract, including inherited library and framework parameters.

<!-- parameters:start -->
| Name | Type | Default | Required | Binding | Declared by | Notes |
|---|---|---|---|---|---|---|
| `ClassName` | `string` | `""` | No | `-` | `BaseComponentViewModel` | Additional CSS class string inherited from the library base type. |
| `Disabled` | `bool` | `false` | No | `-` | `DropDownViewModel<TItem>` | Prevents the component action using component logic. |
| `ID` | `string` | `""` | No | `-` | `BaseComponentViewModel` | DOM id; required by masking features. |
| `IsMultiSelect` | `bool` | `false` | No | `-` | `DropDownViewModel<TItem>` | Public component parameter; see behavior and gotchas below for component-specific effects. |
| `IsOpen` | `bool` | `false` | No | `@bind-IsOpen` | `DropDownViewModel<TItem>` | Current overlay/expansion state. |
| `IsOpenChanged` | `EventCallback<bool>` | `default` | No | `-` | `DropDownViewModel<TItem>` | Binding callback paired with IsOpen; normally supplied by @bind syntax. |
| `ItemTemplate` | `RenderFragment<TItem>` | `null` | No | `-` | `DropDownViewModel<TItem>` | Template used to render an item. |
| `ItemsSource` | `List<TItem>` | `null` | No | `-` | `DropDownViewModel<TItem>` | Items rendered by the component. |
| `Label` | `string` | `null` | No | `-` | `DropDownViewModel<TItem>` | Visible label text. |
| `OnClickStopPropagation` | `bool` | `true` | No | `-` | `DropDownViewModel<TItem>` | Controls Blazor click event propagation. |
| `SelectedItem` | `TItem` | `null` | No | `@bind-SelectedItem` | `DropDownViewModel<TItem>` | Current single selected item. |
| `SelectedItemChanged` | `EventCallback<TItem>` | `default` | No | `-` | `DropDownViewModel<TItem>` | Binding callback paired with SelectedItem; normally supplied by @bind syntax. |
| `SelectedItems` | `IEnumerable<TItem>` | `null` | No | `@bind-SelectedItems` | `DropDownViewModel<TItem>` | Current multi-selection. |
| `SelectedItemsChanged` | `EventCallback<IEnumerable<TItem>>` | `default` | No | `-` | `DropDownViewModel<TItem>` | Binding callback paired with SelectedItems; normally supplied by @bind syntax. |
| `Style` | `string` | `""` | No | `-` | `BaseComponentViewModel` | Inline CSS appended to the component root. |
| `Width` | `string` | `"300px"` | No | `-` | `DropDownViewModel<TItem>` | CSS width value. |
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
<DropDown TItem="string" Label="Color" ItemsSource="@colors" @bind-SelectedItem="color" />
```

Configured/composed:

```razor
<DropDown TItem="string" Label="Tags" ItemsSource="@tags" IsMultiSelect="true" @bind-SelectedItems="selectedTags" ItemTemplate="@RenderTag" Width="420px" />
```

## Rendered structure

- HTML elements observed in the Razor source: `div`.
- Composed component elements observed in the Razor source: `BlankDropDown`, `CheckBox`, `Content`, `DisplayInfo`, `TItem`.
- Elements may be conditional on parameters and internal state. Attribute forwarding is limited to the parameters shown in the contract table; do not assume arbitrary attributes reach the root.

## Associated types

- `EventCallback<bool>`
- `EventCallback<IEnumerable<TItem>>`
- `EventCallback<TItem>`
- `IEnumerable<TItem>`
- `List<TItem>`
- `RenderFragment<TItem>`
- `TItem`

Exact enum members and model properties are listed in the [public supporting types reference](../references/public-types.md).

## Lifecycle and callback behavior

- Lifecycle methods implemented by this component: `OnInitializedAsync`.

- `IsOpenChanged` (`EventCallback<bool>`) is invoked with `value`.
- `SelectedItemChanged` (`EventCallback<TItem>`) is invoked with `selectedItem.Item`.
- `SelectedItemsChanged` (`EventCallback<IEnumerable<TItem>>`) is invoked with `SelectedItems`.

## Rendering, services, and assets

Injected services:

None.

JavaScript modules:

None.

Static asset contract:

- CSS isolation inputs: `AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components/DropDown/DropDown.razor.css`. They are bundled by the Razor class library build.
- No direct JavaScript module import is observable in this component source.

Source files:

- [DropDown.razor](../../../AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components/DropDown/DropDown.razor)
- [DropDown.razor.cs](../../../AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components/DropDown/DropDown.razor.cs)
- [DropDown.razor.css](../../../AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components/DropDown/DropDown.razor.css)

## Styling and theme tokens

- `--semanticColors-ListItemBackgroundHovered`

The listed tokens are case-sensitive. Use the [Theme reference](theme.md) for their emitted values and customization rules.

## Accessibility

Inspect the rendered markup before assuming ARIA roles or keyboard behavior; the component does not add accessibility behavior beyond what is present in its source markup.

## Exceptions

No exception is thrown explicitly in the component source. Consumer callbacks, invalid templates/data, and JavaScript interop can still propagate their own failures.

## Gotchas and current limitations

- Use @bind-SelectedItem for single selection and @bind-SelectedItems for multi-selection.
- ItemsSource is List<T>, not IEnumerable<T>.
- Grouped headers require DropDownItem<T> values; ordinary T items are all selectable.
- The component hard-codes the inner BlankDropDown panel height to 250px.

## Related knowledge

- [Component index](index.md)
- [Architecture and binding conventions](../architecture-and-binding.md)
- [Public supporting types](../references/public-types.md)
- [Static assets and JavaScript interop](../references/static-assets-and-js.md)
