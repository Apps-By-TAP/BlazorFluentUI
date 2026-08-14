---
type: Blazor Component
title: "CheckboxGroup<T>"
description: "A generic data-driven group that renders each item as a CheckBox or Toggle."
resource: "../../../AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components/CheckboxGroup/CheckboxGroup.razor"
tags: [blazor, fluent-ui, component, api-reference]
status: stable
dotnet_type: "AppsByTAP.BlazorFluentUI.Components.CheckboxGroup.CheckboxGroup`1"
component_source: "AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components/CheckboxGroup/CheckboxGroup.razor"
generic_parameters: ["T"]
generated: { by: codex/gpt-5, at: 2026-08-14T00:00:00-04:00 }
verified: { by: "process:okf-docs-validator", at: 2026-08-14T00:00:00-04:00 }
verification_scope: api-contract-links-examples-and-theme-tokens
sources:
  - id: component-source
    resource: "../../../AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components/CheckboxGroup/CheckboxGroup.razor"
    title: "CheckboxGroup Razor source"
---

# CheckboxGroup<T>

A generic data-driven group that renders each item as a CheckBox or Toggle.

## Contract

- Namespace: `AppsByTAP.BlazorFluentUI.Components.CheckboxGroup`
- Compiled type: `AppsByTAP.BlazorFluentUI.Components.CheckboxGroup.CheckboxGroup<T>`
- Base type: `ComponentBase`
- Intended level: consumer-facing component.

### Generic type parameters

- `T`

## Parameters

The table lists the effective runtime contract, including inherited library and framework parameters.

<!-- parameters:start -->
| Name | Type | Default | Required | Binding | Declared by | Notes |
|---|---|---|---|---|---|---|
| `GroupDirection` | `GroupDirection` | `GroupDirection.Vertical` | No | `-` | `CheckboxGroup<T>` | Public component parameter; see behavior and gotchas below for component-specific effects. |
| `Height` | `string` | `"fit-content"` | No | `-` | `CheckboxGroup<T>` | Height value; consult the exact type for pixels versus CSS text. |
| `ItemsSource` | `List<T>` | `empty` | No | `-` | `CheckboxGroup<T>` | Items rendered by the component. |
| `Label` | `string` | `null` | No | `-` | `CheckboxGroup<T>` | Visible label text. |
| `SelectedItems` | `List<T>` | `empty` | No | `@bind-SelectedItems` | `CheckboxGroup<T>` | Current multi-selection. |
| `SelectedItemsChanged` | `EventCallback<List<T>>` | `default` | No | `-` | `CheckboxGroup<T>` | Binding callback paired with SelectedItems; normally supplied by @bind syntax. |
| `UseToggleSwitches` | `bool` | `false` | No | `-` | `CheckboxGroup<T>` | Public component parameter; see behavior and gotchas below for component-specific effects. |
| `Width` | `string` | `"auto"` | No | `-` | `CheckboxGroup<T>` | CSS width value. |
| `WrapItems` | `bool` | `false` | No | `-` | `CheckboxGroup<T>` | Public component parameter; see behavior and gotchas below for component-specific effects. |
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
<CheckboxGroup T="string" ItemsSource="@options" @bind-SelectedItems="selected" />
```

Configured/composed:

```razor
<CheckboxGroup T="string" Label="Features" ItemsSource="@options" @bind-SelectedItems="selected" GroupDirection="GroupDirection.Horizontal" WrapItems="true" UseToggleSwitches="true" />
```

## Rendered structure

- HTML elements observed in the Razor source: `div`.
- Composed component elements observed in the Razor source: `CheckBox`, `Toggle`, `Virtualize`.
- Elements may be conditional on parameters and internal state. Attribute forwarding is limited to the parameters shown in the contract table; do not assume arbitrary attributes reach the root.

## Associated types

- `EventCallback<List<T>>`
- `GroupDirection`
- `List<T>`

Exact enum members and model properties are listed in the [public supporting types reference](../references/public-types.md).

## Lifecycle and callback behavior

- Lifecycle methods implemented by this component: `OnParametersSet`.

- `SelectedItemsChanged` (`EventCallback<List<T>>`) is invoked with `SelectedItems`.

## Rendering, services, and assets

Injected services:

None.

JavaScript modules:

None.

Static asset contract:

- CSS isolation inputs: `AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components/CheckboxGroup/CheckboxGroup.razor.css`. They are bundled by the Razor class library build.
- No direct JavaScript module import is observable in this component source.

Source files:

- [CheckboxGroup.razor](../../../AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components/CheckboxGroup/CheckboxGroup.razor)
- [CheckboxGroup.razor.cs](../../../AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components/CheckboxGroup/CheckboxGroup.razor.cs)
- [CheckboxGroup.razor.css](../../../AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components/CheckboxGroup/CheckboxGroup.razor.css)

## Styling and theme tokens

No CSS custom properties are referenced directly by this component source.

The listed tokens are case-sensitive. Use the [Theme reference](theme.md) for their emitted values and customization rules.

## Accessibility

Inspect the rendered markup before assuming ARIA roles or keyboard behavior; the component does not add accessibility behavior beyond what is present in its source markup.

## Exceptions

No exception is thrown explicitly in the component source. Consumer callbacks, invalid templates/data, and JavaScript interop can still propagate their own failures.

## Gotchas and current limitations

- This is data-driven through ItemsSource; it does not accept ChildContent.
- Items are matched by Equals and duplicate/equal values cannot be selected independently.
- UseToggleSwitches changes the child component but preserves SelectedItems binding.

## Related knowledge

- [Component index](index.md)
- [Architecture and binding conventions](../architecture-and-binding.md)
- [Public supporting types](../references/public-types.md)
- [Static assets and JavaScript interop](../references/static-assets-and-js.md)
