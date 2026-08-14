---
type: Blazor Component
title: "ChoiceGroup<T>"
description: "A generic single-selection radio group using cascading coordination with Choice children."
resource: "../../../AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components/ChoiceGroup/ChoiceGroup.razor"
tags: [blazor, fluent-ui, component, api-reference]
status: stable
dotnet_type: "AppsByTAP.BlazorFluentUI.Components.ChoiceGroup.ChoiceGroup`1"
component_source: "AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components/ChoiceGroup/ChoiceGroup.razor"
generic_parameters: ["T"]
generated: { by: codex/gpt-5, at: 2026-08-14T00:00:00-04:00 }
verified: { by: "process:okf-docs-validator", at: 2026-08-14T00:00:00-04:00 }
verification_scope: api-contract-links-examples-and-theme-tokens
sources:
  - id: component-source
    resource: "../../../AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components/ChoiceGroup/ChoiceGroup.razor"
    title: "ChoiceGroup Razor source"
---

# ChoiceGroup<T>

A generic single-selection radio group using cascading coordination with Choice children.

## Contract

- Namespace: `AppsByTAP.BlazorFluentUI.Components.ChoiceGroup`
- Compiled type: `AppsByTAP.BlazorFluentUI.Components.ChoiceGroup.ChoiceGroup<T>`
- Base type: `ComponentBase`
- Intended level: consumer-facing component.

### Generic type parameters

- `T`

## Parameters

The table lists the effective runtime contract, including inherited library and framework parameters.

<!-- parameters:start -->
| Name | Type | Default | Required | Binding | Declared by | Notes |
|---|---|---|---|---|---|---|
| `ChildContent` | `RenderFragment` | `null` | No | `-` | `ChoiceGroup<T>` | Child markup rendered by the component. |
| `Disabled` | `bool` | `false` | No | `-` | `ChoiceGroup<T>` | Prevents the component action using component logic. |
| `GroupDirection` | `GroupDirection` | `GroupDirection.Vertical` | No | `-` | `ChoiceGroup<T>` | Public component parameter; see behavior and gotchas below for component-specific effects. |
| `Label` | `string` | `null` | No | `-` | `ChoiceGroup<T>` | Visible label text. |
| `SelectedItem` | `T` | `null` | No | `@bind-SelectedItem` | `ChoiceGroup<T>` | Current single selected item. |
| `SelectedItemChanged` | `EventCallback<T>` | `default` | No | `-` | `ChoiceGroup<T>` | Binding callback paired with SelectedItem; normally supplied by @bind syntax. |
| `SelectionChanged` | `EventCallback<T>` | `default` | No | `-` | `ChoiceGroup<T>` | Binding callback paired with Selection; normally supplied by @bind syntax. |
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
<ChoiceGroup T="string" @bind-SelectedItem="choice"><Choice T="string" Value="A">Option A</Choice></ChoiceGroup>
```

Configured/composed:

```razor
<ChoiceGroup T="string" Label="Mode" @bind-SelectedItem="choice" SelectionChanged="ModeChanged" Disabled="@locked"><Choice T="string" Value="A">Automatic</Choice><Choice T="string" Value="M">Manual</Choice></ChoiceGroup>
```

## Rendered structure

- HTML elements observed in the Razor source: `div`.
- Composed component elements observed in the Razor source: `CascadingValue`.
- Elements may be conditional on parameters and internal state. Attribute forwarding is limited to the parameters shown in the contract table; do not assume arbitrary attributes reach the root.

## Associated types

- `EventCallback<T>`
- `GroupDirection`
- `T`

Exact enum members and model properties are listed in the [public supporting types reference](../references/public-types.md).

## Lifecycle and callback behavior

- Lifecycle methods implemented by this component: `OnAfterRender`.
- After-render work requires an interactive renderer; server prerendering alone cannot complete DOM or JavaScript work.
- The implementation contains a ``firstRender`` branch; initialization performed there is not repeated on ordinary re-renders.

- `SelectedItemChanged` (`EventCallback<T>`) is invoked with `value`.
- `SelectionChanged` (`EventCallback<T>`) is invoked with `selectedChild.Value`.

## Rendering, services, and assets

Injected services:

None.

JavaScript modules:

None.

Static asset contract:

- CSS isolation inputs: `AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components/ChoiceGroup/ChoiceGroup.razor.css`. They are bundled by the Razor class library build.
- No direct JavaScript module import is observable in this component source.

Source files:

- [ChoiceGroup.razor](../../../AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components/ChoiceGroup/ChoiceGroup.razor)
- [ChoiceGroup.razor.cs](../../../AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components/ChoiceGroup/ChoiceGroup.razor.cs)
- [ChoiceGroup.razor.css](../../../AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components/ChoiceGroup/ChoiceGroup.razor.css)

## Styling and theme tokens

No CSS custom properties are referenced directly by this component source.

The listed tokens are case-sensitive. Use the [Theme reference](theme.md) for their emitted values and customization rules.

## Accessibility

Inspect the rendered markup before assuming ARIA roles or keyboard behavior; the component does not add accessibility behavior beyond what is present in its source markup.

## Exceptions

No exception is thrown explicitly in the component source. Consumer callbacks, invalid templates/data, and JavaScript interop can still propagate their own failures.

## Gotchas and current limitations

- ChildContent must contain Choice<T> children using the same T.
- SelectedItem changes invoke both SelectedItemChanged and SelectionChanged.
- The internal child notification path uses async void.

## Related knowledge

- [Component index](index.md)
- [Architecture and binding conventions](../architecture-and-binding.md)
- [Public supporting types](../references/public-types.md)
- [Static assets and JavaScript interop](../references/static-assets-and-js.md)
