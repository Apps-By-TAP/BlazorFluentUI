---
type: Blazor Component
title: "SplitButton<TItem>"
description: "A generic primary action plus callout menu for choosing an item."
resource: "../../../AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components/Button/SplitButton.razor"
tags: [blazor, fluent-ui, component, api-reference]
status: stable
dotnet_type: "AppsByTAP.BlazorFluentUI.Components.Button.SplitButton`1"
component_source: "AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components/Button/SplitButton.razor"
generic_parameters: ["TItem"]
generated: { by: codex/gpt-5, at: 2026-08-14T00:00:00-04:00 }
verified: { by: "process:okf-docs-validator", at: 2026-08-14T00:00:00-04:00 }
verification_scope: api-contract-links-examples-and-theme-tokens
sources:
  - id: component-source
    resource: "../../../AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components/Button/SplitButton.razor"
    title: "SplitButton Razor source"
---

# SplitButton<TItem>

A generic primary action plus callout menu for choosing an item.

## Contract

- Namespace: `AppsByTAP.BlazorFluentUI.Components.Button`
- Compiled type: `AppsByTAP.BlazorFluentUI.Components.Button.SplitButton<TItem>`
- Base type: `SplitButtonViewModel<TItem>`
- Intended level: consumer-facing component.

### Generic type parameters

- `TItem`

## Parameters

The table lists the effective runtime contract, including inherited library and framework parameters.

<!-- parameters:start -->
| Name | Type | Default | Required | Binding | Declared by | Notes |
|---|---|---|---|---|---|---|
| `CanLightDismiss` | `bool` | `false` | No | `-` | `SplitButtonViewModel<TItem>` | Allows backdrop/outside-click dismissal. |
| `ClassName` | `string` | `""` | No | `-` | `BaseComponentViewModel` | Additional CSS class string inherited from the library base type. |
| `Disabled` | `bool` | `false` | No | `-` | `ButtonBaseParameters` | Prevents the component action using component logic. |
| `DropDownTemplate` | `RenderFragment<TItem>` | `null` | No | `-` | `SplitButtonViewModel<TItem>` | Public component parameter; see behavior and gotchas below for component-specific effects. |
| `ID` | `string` | `""` | No | `-` | `BaseComponentViewModel` | DOM id; required by masking features. |
| `Icon` | `IconTypes` | `IconTypes.None` | No | `-` | `ButtonBaseParameters` | IconTypes value rendered by the component. |
| `IsPrimary` | `bool` | `false` | No | `-` | `ButtonBaseParameters` | Public component parameter; see behavior and gotchas below for component-specific effects. |
| `ItemsSource` | `List<TItem>` | `null` | No | `-` | `SplitButtonViewModel<TItem>` | Items rendered by the component. |
| `OnClick` | `EventCallback<MouseEventArgs>` | `default` | No | `-` | `ButtonBaseParameters` | Invoked for an accepted click. |
| `OnClickStopPropagation` | `bool` | `false` | No | `-` | `ButtonBaseParameters` | Controls Blazor click event propagation. |
| `SelectedItem` | `TItem` | `null` | No | `@bind-SelectedItem` | `SplitButtonViewModel<TItem>` | Current single selected item. |
| `SelectedItemChanged` | `EventCallback<TItem>` | `default` | No | `-` | `SplitButtonViewModel<TItem>` | Binding callback paired with SelectedItem; normally supplied by @bind syntax. |
| `SelectedItemTemplate` | `RenderFragment<TItem>` | `null` | No | `-` | `SplitButtonViewModel<TItem>` | Public component parameter; see behavior and gotchas below for component-specific effects. |
| `ShowIsBusy` | `bool` | `false` | No | `-` | `ButtonBaseParameters` | Public component parameter; see behavior and gotchas below for component-specific effects. |
| `Style` | `string` | `""` | No | `-` | `BaseComponentViewModel` | Inline CSS appended to the component root. |
| `Text` | `string` | `null` | No | `-` | `ButtonBaseParameters` | Primary display text. |
| `Width` | `string` | `null` | No | `-` | `SplitButtonViewModel<TItem>` | CSS width value. |
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
<SplitButton TItem="string" ItemsSource="@actions" SelectedItemTemplate="@RenderAction" DropDownTemplate="@RenderAction" />
```

Configured/composed:

```razor
<SplitButton TItem="string" Text="Run" ItemsSource="@actions" @bind-SelectedItem="selectedAction" CanLightDismiss="true" SelectedItemTemplate="@RenderAction" DropDownTemplate="@RenderAction" />
```

## Rendered structure

- HTML elements observed in the Razor source: `div`, `span`.
- Composed component elements observed in the Razor source: `Callout`, `Icon`, `TinySpinner`, `TItem`.
- Elements may be conditional on parameters and internal state. Attribute forwarding is limited to the parameters shown in the contract table; do not assume arbitrary attributes reach the root.

## Associated types

- `EventCallback<TItem>`
- `IconTypes`
- `List<TItem>`
- `RenderFragment<TItem>`
- `TItem`

Exact enum members and model properties are listed in the [public supporting types reference](../references/public-types.md).

## Lifecycle and callback behavior

No lifecycle method is overridden in this component's Razor/code-behind files; normal ComponentBase parameter assignment and rendering apply.

- `OnClick` is declared as `EventCallback<MouseEventArgs>`; no direct InvokeAsync call is observable in this component's source files. A wrapper/base implementation may invoke it, or the current API may be inert.
- `SelectedItemChanged` (`EventCallback<TItem>`) is invoked with `SelectedItem`.

## Rendering, services, and assets

Injected services:

None.

JavaScript modules:

None.

Static asset contract:

- CSS isolation inputs: `AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components/Button/SplitButton.razor.css`. They are bundled by the Razor class library build.
- No direct JavaScript module import is observable in this component source.

Source files:

- [SplitButton.razor](../../../AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components/Button/SplitButton.razor)
- [SplitButton.razor.cs](../../../AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components/Button/SplitButton.razor.cs)
- [SplitButton.razor.css](../../../AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components/Button/SplitButton.razor.css)

## Styling and theme tokens

- `--palette-NeutralPrimary`
- `--semanticColors-ButtonBorder`
- `--semanticColors-ListItemBackgroundCheckedHovered`
- `--semanticColors-ListItemBackgroundHovered`
- `--semanticColors-PrimaryButtonBackground`
- `--semanticColors-PrimaryButtonBackgroundHovered`
- `--semanticColors-PrimaryButtonBackgroundPressed`
- `--semanticTextColors-DisabledText`
- `--semanticTextColors-PrimaryButtonText`

The listed tokens are case-sensitive. Use the [Theme reference](theme.md) for their emitted values and customization rules.

## Accessibility

Inspect the rendered markup before assuming ARIA roles or keyboard behavior; the component does not add accessibility behavior beyond what is present in its source markup.

## Exceptions

No exception is thrown explicitly in the component source. Consumer callbacks, invalid templates/data, and JavaScript interop can still propagate their own failures.

## Gotchas and current limitations

- TItem must be supplied and ItemsSource must be non-null before opening the menu.
- SelectedItemTemplate and DropDownTemplate are required for meaningful generic rendering.
- Selection closes the callout and invokes SelectedItemChanged.

## Related knowledge

- [Component index](index.md)
- [Architecture and binding conventions](../architecture-and-binding.md)
- [Public supporting types](../references/public-types.md)
- [Static assets and JavaScript interop](../references/static-assets-and-js.md)
