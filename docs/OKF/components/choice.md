---
type: Blazor Component
title: "Choice<T>"
description: "A BlazorFluentUI component."
resource: "../../../AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components/ChoiceGroup/Choice.razor"
tags: [blazor, fluent-ui, component, api-reference]
status: stable
dotnet_type: "AppsByTAP.BlazorFluentUI.Components.ChoiceGroup.Choice`1"
component_source: "AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components/ChoiceGroup/Choice.razor"
generic_parameters: ["T"]
generated: { by: codex/gpt-5, at: 2026-08-14T00:00:00-04:00 }
verified: { by: "process:okf-docs-validator", at: 2026-08-14T00:00:00-04:00 }
verification_scope: api-contract-links-examples-and-theme-tokens
sources:
  - id: component-source
    resource: "../../../AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components/ChoiceGroup/Choice.razor"
    title: "Choice Razor source"
---

# Choice<T>

A BlazorFluentUI component.

## Contract

- Namespace: `AppsByTAP.BlazorFluentUI.Components.ChoiceGroup`
- Compiled type: `AppsByTAP.BlazorFluentUI.Components.ChoiceGroup.Choice<T>`
- Base type: `ComponentBase`
- Intended level: low-level or composition component; use directly only when its contract fits the scenario.

### Generic type parameters

- `T`

## Parameters

The table lists the effective runtime contract, including inherited library and framework parameters.

<!-- parameters:start -->
| Name | Type | Default | Required | Binding | Declared by | Notes |
|---|---|---|---|---|---|---|
| `ChildContent` | `RenderFragment` | `null` | No | `-` | `Choice<T>` | Child markup rendered by the component. |
| `IsSelected` | `bool` | `false` | No | `@bind-IsSelected` | `Choice<T>` | Public component parameter; see behavior and gotchas below for component-specific effects. |
| `IsSelectedChanged` | `EventCallback<bool>` | `default` | No | `-` | `Choice<T>` | Binding callback paired with IsSelected; normally supplied by @bind syntax. |
| `Value` | `T` | `null` | No | `-` | `Choice<T>` | Current value. |
<!-- parameters:end -->

## Cascading parameters

Cascading values are supplied by an ancestor and must not be invented as normal component attributes.

<!-- cascading-parameters:start -->
| Name | Type | Default | Required | Binding | Declared by | Notes |
|---|---|---|---|---|---|---|
| `Parent` | `ChoiceGroup<T>` | `null` | No | `-` | `Choice<T>` | Public component parameter; see behavior and gotchas below for component-specific effects. |
<!-- cascading-parameters:end -->

## Examples

Minimal:

```razor
<Choice T="string" />
```

Configured/composed:

```razor
<Choice T="string" />
```

## Rendered structure

- HTML elements observed in the Razor source: `div`.
- Elements may be conditional on parameters and internal state. Attribute forwarding is limited to the parameters shown in the contract table; do not assume arbitrary attributes reach the root.

## Associated types

- `ChoiceGroup<T>`
- `EventCallback<bool>`
- `T`

Exact enum members and model properties are listed in the [public supporting types reference](../references/public-types.md).

## Lifecycle and callback behavior

- Lifecycle methods implemented by this component: `OnInitialized`.

- `IsSelectedChanged` is declared as `EventCallback<bool>`; no direct InvokeAsync call is observable in this component's source files. A wrapper/base implementation may invoke it, or the current API may be inert.

## Rendering, services, and assets

Injected services:

None.

JavaScript modules:

None.

Static asset contract:

- CSS isolation inputs: `AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components/ChoiceGroup/Choice.razor.css`. They are bundled by the Razor class library build.
- No direct JavaScript module import is observable in this component source.

Source files:

- [Choice.razor](../../../AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components/ChoiceGroup/Choice.razor)
- [Choice.razor.cs](../../../AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components/ChoiceGroup/Choice.razor.cs)
- [Choice.razor.css](../../../AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components/ChoiceGroup/Choice.razor.css)

## Styling and theme tokens

- `--palette-Black`
- `--semanticColors-ListItemBackgroundCheckedHovered`
- `--semanticColors-PrimaryButtonBackground`
- `--semanticTextColors-DisabledText`

The listed tokens are case-sensitive. Use the [Theme reference](theme.md) for their emitted values and customization rules.

## Accessibility

Inspect the rendered markup before assuming ARIA roles or keyboard behavior; the component does not add accessibility behavior beyond what is present in its source markup.

## Exceptions

- Explicit source throw: `ArgumentNullException(nameof(Parent), "Choice must exist within a ChoiceGroup. Also, make sure the T of ChoiceGroup matched the data type of Value.")`.

## Gotchas and current limitations

- Review the exact parameter table; this library intentionally uses WPF-style names rather than conventional Value parameters.

## Related knowledge

- [Component index](index.md)
- [Architecture and binding conventions](../architecture-and-binding.md)
- [Public supporting types](../references/public-types.md)
- [Static assets and JavaScript interop](../references/static-assets-and-js.md)
