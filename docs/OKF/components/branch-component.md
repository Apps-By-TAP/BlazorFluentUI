---
type: Blazor Component
title: "BranchComponent<T>"
description: "The recursive branch renderer used internally by TreeMenu<T>."
resource: "../../../AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components/TreeMenu/BranchComponent.razor"
tags: [blazor, fluent-ui, component, api-reference]
status: stable
dotnet_type: "AppsByTAP.BlazorFluentUI.Components.TreeMenu.BranchComponent`1"
component_source: "AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components/TreeMenu/BranchComponent.razor"
generic_parameters: ["T"]
generated: { by: codex/gpt-5, at: 2026-08-14T00:00:00-04:00 }
verified: { by: "process:okf-docs-validator", at: 2026-08-14T00:00:00-04:00 }
verification_scope: api-contract-links-examples-and-theme-tokens
sources:
  - id: component-source
    resource: "../../../AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components/TreeMenu/BranchComponent.razor"
    title: "BranchComponent Razor source"
---

# BranchComponent<T>

The recursive branch renderer used internally by TreeMenu<T>.

## Contract

- Namespace: `AppsByTAP.BlazorFluentUI.Components.TreeMenu`
- Compiled type: `AppsByTAP.BlazorFluentUI.Components.TreeMenu.BranchComponent<T>`
- Base type: `ComponentBase`
- Intended level: low-level or composition component; use directly only when its contract fits the scenario.

### Generic type parameters

- `T`

## Parameters

The table lists the effective runtime contract, including inherited library and framework parameters.

<!-- parameters:start -->
| Name | Type | Default | Required | Binding | Declared by | Notes |
|---|---|---|---|---|---|---|
| `BranchDisplay` | `RenderFragment<Branch<T>>` | `null` | No | `-` | `BranchComponent<T>` | Public component parameter; see behavior and gotchas below for component-specific effects. |
| `BranchRoot` | `Branch<T>` | `null` | No | `-` | `BranchComponent<T>` | Public component parameter; see behavior and gotchas below for component-specific effects. |
<!-- parameters:end -->

## Cascading parameters

Cascading values are supplied by an ancestor and must not be invented as normal component attributes.

<!-- cascading-parameters:start -->
| Name | Type | Default | Required | Binding | Declared by | Notes |
|---|---|---|---|---|---|---|
| `Parent` | `TreeMenu<T>` | `null` | No | `-` | `BranchComponent<T>` | Public component parameter; see behavior and gotchas below for component-specific effects. |
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
- Composed component elements observed in the Razor source: `AppsByTAP`, `Branch`, `BranchComponent`, `BranchItem`, `ItemContent`, `ItemsProviderResult`, `TinySpinner`, `Virtualize`.
- Elements may be conditional on parameters and internal state. Attribute forwarding is limited to the parameters shown in the contract table; do not assume arbitrary attributes reach the root.

## Associated types

- `Branch<T>`
- `RenderFragment<Branch<T>>`
- `TreeMenu<T>`

Exact enum members and model properties are listed in the [public supporting types reference](../references/public-types.md).

## Lifecycle and callback behavior

- Lifecycle methods implemented by this component: `Dispose`, `OnInitialized`.
- The component owns disposable state; allow the renderer to dispose it instead of retaining detached instances.

No EventCallback parameters are exposed.

## Rendering, services, and assets

Injected services:

None.

JavaScript modules:

None.

Static asset contract:

- No component-scoped ``.razor.css`` file is associated with this component.
- No direct JavaScript module import is observable in this component source.

Source files:

- [BranchComponent.razor](../../../AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components/TreeMenu/BranchComponent.razor)

## Styling and theme tokens

- `--semanticColors-ListItemBackgroundChecked`
- `--semanticColors-ListItemBackgroundHovered`

The listed tokens are case-sensitive. Use the [Theme reference](theme.md) for their emitted values and customization rules.

## Accessibility

Inspect the rendered markup before assuming ARIA roles or keyboard behavior; the component does not add accessibility behavior beyond what is present in its source markup.

## Exceptions

- Explicit source throw: `ArgumentNullException(nameof(Parent), "Choice must exist within a ChoiceGroup. Also, make sure the T of ChoiceGroup matched the data type of Value.")`.

## Gotchas and current limitations

- BranchComponent<T> is recursive infrastructure and must receive a cascading TreeMenu<T>.
- The current missing-parent exception message incorrectly refers to ChoiceGroup.
- Child loading and selection notifications include async void paths.

## Related knowledge

- [Component index](index.md)
- [Architecture and binding conventions](../architecture-and-binding.md)
- [Public supporting types](../references/public-types.md)
- [Static assets and JavaScript interop](../references/static-assets-and-js.md)
