---
type: Blazor Component
title: "Expander"
description: "A collapsible header/body container with bindable open state."
resource: "../../../AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components/Expander/Expander.razor"
tags: [blazor, fluent-ui, component, api-reference]
status: stable
dotnet_type: "AppsByTAP.BlazorFluentUI.Components.Expander.Expander"
component_source: "AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components/Expander/Expander.razor"
generic_parameters: []
generated: { by: codex/gpt-5, at: 2026-08-14T00:00:00-04:00 }
verified: { by: "process:okf-docs-validator", at: 2026-08-14T00:00:00-04:00 }
verification_scope: api-contract-links-examples-and-theme-tokens
sources:
  - id: component-source
    resource: "../../../AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components/Expander/Expander.razor"
    title: "Expander Razor source"
---

# Expander

A collapsible header/body container with bindable open state.

## Contract

- Namespace: `AppsByTAP.BlazorFluentUI.Components.Expander`
- Compiled type: `AppsByTAP.BlazorFluentUI.Components.Expander.Expander`
- Base type: `ExpanderViewModel`
- Intended level: consumer-facing component.

### Generic type parameters

None.

## Parameters

The table lists the effective runtime contract, including inherited library and framework parameters.

<!-- parameters:start -->
| Name | Type | Default | Required | Binding | Declared by | Notes |
|---|---|---|---|---|---|---|
| `ChildContent` | `RenderFragment` | `null` | No | `-` | `ExpanderViewModel` | Child markup rendered by the component. |
| `ClassName` | `string` | `""` | No | `-` | `BaseComponentViewModel` | Additional CSS class string inherited from the library base type. |
| `Header` | `RenderFragment` | `null` | No | `-` | `ExpanderViewModel` | Header text or named header fragment, according to the declared type. |
| `ID` | `string` | `""` | No | `-` | `BaseComponentViewModel` | DOM id; required by masking features. |
| `IsOpen` | `bool` | `false` | No | `@bind-IsOpen` | `ExpanderViewModel` | Current overlay/expansion state. |
| `IsOpenChanged` | `EventCallback<bool>` | `default` | No | `-` | `ExpanderViewModel` | Binding callback paired with IsOpen; normally supplied by @bind syntax. |
| `Style` | `string` | `""` | No | `-` | `BaseComponentViewModel` | Inline CSS appended to the component root. |
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
<Expander @bind-IsOpen="open"><Header>Details</Header><ChildContent><p>More information</p></ChildContent></Expander>
```

Configured/composed:

```razor
<Expander ID="advanced" ClassName="settings" @bind-IsOpen="advancedOpen"><Header><strong>Advanced</strong></Header><ChildContent>@advancedSettings</ChildContent></Expander>
```

## Rendered structure

- HTML elements observed in the Razor source: `div`, `span`.
- Composed component elements observed in the Razor source: `Icon`.
- Elements may be conditional on parameters and internal state. Attribute forwarding is limited to the parameters shown in the contract table; do not assume arbitrary attributes reach the root.

## Associated types

- `EventCallback<bool>`

Exact enum members and model properties are listed in the [public supporting types reference](../references/public-types.md).

## Lifecycle and callback behavior

No lifecycle method is overridden in this component's Razor/code-behind files; normal ComponentBase parameter assignment and rendering apply.

- `IsOpenChanged` (`EventCallback<bool>`) is invoked with `IsOpen`.

## Rendering, services, and assets

Injected services:

None.

JavaScript modules:

None.

Static asset contract:

- CSS isolation inputs: `AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components/Expander/Expander.razor.css`. They are bundled by the Razor class library build.
- No direct JavaScript module import is observable in this component source.

Source files:

- [Expander.razor](../../../AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components/Expander/Expander.razor)
- [Expander.razor.cs](../../../AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components/Expander/Expander.razor.cs)
- [Expander.razor.css](../../../AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components/Expander/Expander.razor.css)

## Styling and theme tokens

- `--semanticColors-ButtonBackgroundCheckedHovered`
- `--semanticColors-ButtonBackgroundHovered`
- `--semanticColors-ListBackground`

The listed tokens are case-sensitive. Use the [Theme reference](theme.md) for their emitted values and customization rules.

## Accessibility

Inspect the rendered markup before assuming ARIA roles or keyboard behavior; the component does not add accessibility behavior beyond what is present in its source markup.

## Exceptions

No exception is thrown explicitly in the component source. Consumer callbacks, invalid templates/data, and JavaScript interop can still propagate their own failures.

## Gotchas and current limitations

- The correct two-way binding is @bind-IsOpen.
- The open-state setter invokes IsOpenChanged and produces a Blazor analyzer warning.
- Header is clickable markup without built-in keyboard/ARIA expansion semantics.

## Related knowledge

- [Component index](index.md)
- [Architecture and binding conventions](../architecture-and-binding.md)
- [Public supporting types](../references/public-types.md)
- [Static assets and JavaScript interop](../references/static-assets-and-js.md)
