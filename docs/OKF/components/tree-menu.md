---
type: Blazor Component
title: "TreeMenu<T>"
description: "A generic virtualized hierarchical menu with lazy child loading and selection."
resource: "../../../AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components/TreeMenu/TreeMenu.razor"
tags: [blazor, fluent-ui, component, api-reference]
status: stable
dotnet_type: "AppsByTAP.BlazorFluentUI.Components.TreeMenu.TreeMenu`1"
component_source: "AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components/TreeMenu/TreeMenu.razor"
generic_parameters: ["T"]
generated: { by: codex/gpt-5, at: 2026-08-14T00:00:00-04:00 }
verified: { by: "process:okf-docs-validator", at: 2026-08-14T00:00:00-04:00 }
verification_scope: api-contract-links-examples-and-theme-tokens
sources:
  - id: component-source
    resource: "../../../AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components/TreeMenu/TreeMenu.razor"
    title: "TreeMenu Razor source"
---

# TreeMenu<T>

A generic virtualized hierarchical menu with lazy child loading and selection.

## Contract

- Namespace: `AppsByTAP.BlazorFluentUI.Components.TreeMenu`
- Compiled type: `AppsByTAP.BlazorFluentUI.Components.TreeMenu.TreeMenu<T>`
- Base type: `ComponentBase`
- Intended level: consumer-facing component.

### Generic type parameters

- `T`

## Parameters

The table lists the effective runtime contract, including inherited library and framework parameters.

<!-- parameters:start -->
| Name | Type | Default | Required | Binding | Declared by | Notes |
|---|---|---|---|---|---|---|
| `BranchDisplay` | `RenderFragment<Branch<T>>` | `null` | No | `-` | `TreeMenu<T>` | Public component parameter; see behavior and gotchas below for component-specific effects. |
| `GetItems` | `Func<ItemsProviderRequest, T, IEnumerable<BranchItem<T>>>` | `null` | No | `-` | `TreeMenu<T>` | Loads child tree items for a parent and virtualization request. |
| `Items` | `List<T>` | `null` | No | `-` | `TreeMenu<T>` | Public component parameter; see behavior and gotchas below for component-specific effects. |
| `SelectedItem` | `T` | `null` | No | `@bind-SelectedItem` | `TreeMenu<T>` | Current single selected item. |
| `SelectedItemChanged` | `EventCallback<T>` | `default` | No | `-` | `TreeMenu<T>` | Binding callback paired with SelectedItem; normally supplied by @bind syntax. |
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
<TreeMenu T="Node" Items="@roots" GetItems="LoadChildren" BranchDisplay="@RenderBranch" />
```

Configured/composed:

```razor
<TreeMenu T="Node" Items="@roots" GetItems="LoadChildren" @bind-SelectedItem="selected" BranchDisplay="@RenderBranch" />
```

## Rendered structure

- HTML elements observed in the Razor source: `div`, `style`.
- Composed component elements observed in the Razor source: `Branch`, `BranchComponent`, `BranchItem`, `CascadingValue`, `ItemsProviderRequest`.
- Elements may be conditional on parameters and internal state. Attribute forwarding is limited to the parameters shown in the contract table; do not assume arbitrary attributes reach the root.

## Associated types

- `EventCallback<T>`
- `Func<ItemsProviderRequest, T, IEnumerable<BranchItem<T>>>`
- `List<T>`
- `RenderFragment<Branch<T>>`
- `T`

Exact enum members and model properties are listed in the [public supporting types reference](../references/public-types.md).

## Lifecycle and callback behavior

No lifecycle method is overridden in this component's Razor/code-behind files; normal ComponentBase parameter assignment and rendering apply.

- `SelectedItemChanged` (`EventCallback<T>`) is invoked with `value`.

## Rendering, services, and assets

Injected services:

None.

JavaScript modules:

None.

Static asset contract:

- No component-scoped ``.razor.css`` file is associated with this component.
- No direct JavaScript module import is observable in this component source.

Source files:

- [TreeMenu.razor](../../../AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components/TreeMenu/TreeMenu.razor)

## Styling and theme tokens

No CSS custom properties are referenced directly by this component source.

The listed tokens are case-sensitive. Use the [Theme reference](theme.md) for their emitted values and customization rules.

## Accessibility

Inspect the rendered markup before assuming ARIA roles or keyboard behavior; the component does not add accessibility behavior beyond what is present in its source markup.

## Exceptions

No exception is thrown explicitly in the component source. Consumer callbacks, invalid templates/data, and JavaScript interop can still propagate their own failures.

## Gotchas and current limitations

- Items, GetItems, and BranchDisplay are required for a useful tree.
- GetItems receives an ItemsProviderRequest plus the parent item and must return BranchItem<T> values.
- Branch<T>.Equals uses a generated ID while GetHashCode is not overridden.
- There is no nested ChildContent API.

## Related knowledge

- [Component index](index.md)
- [Architecture and binding conventions](../architecture-and-binding.md)
- [Public supporting types](../references/public-types.md)
- [Static assets and JavaScript interop](../references/static-assets-and-js.md)
