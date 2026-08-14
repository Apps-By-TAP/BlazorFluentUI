---
type: Blazor Component
title: "Tabs"
description: "A tab header and content host with an index-based initial selection."
resource: "../../../AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components/Tabs/Tabs.razor"
tags: [blazor, fluent-ui, component, api-reference]
status: stable
dotnet_type: "AppsByTAP.BlazorFluentUI.Components.Tabs.Tabs"
component_source: "AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components/Tabs/Tabs.razor"
generic_parameters: []
generated: { by: codex/gpt-5, at: 2026-08-14T00:00:00-04:00 }
verified: { by: "process:okf-docs-validator", at: 2026-08-14T00:00:00-04:00 }
verification_scope: api-contract-links-examples-and-theme-tokens
sources:
  - id: component-source
    resource: "../../../AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components/Tabs/Tabs.razor"
    title: "Tabs Razor source"
---

# Tabs

A tab header and content host with an index-based initial selection.

## Contract

- Namespace: `AppsByTAP.BlazorFluentUI.Components.Tabs`
- Compiled type: `AppsByTAP.BlazorFluentUI.Components.Tabs.Tabs`
- Base type: `ComponentBase`
- Intended level: consumer-facing component.

### Generic type parameters

None.

## Parameters

The table lists the effective runtime contract, including inherited library and framework parameters.

<!-- parameters:start -->
| Name | Type | Default | Required | Binding | Declared by | Notes |
|---|---|---|---|---|---|---|
| `ChildContent` | `RenderFragment` | `null` | No | `-` | `Tabs` | Child markup rendered by the component. |
| `Class` | `string` | `null` | No | `-` | `Tabs` | Additional CSS class string. |
| `DefaultOpenTab` | `int` | `0` | No | `-` | `Tabs` | Public component parameter; see behavior and gotchas below for component-specific effects. |
| `Height` | `string` | `"100%"` | No | `-` | `Tabs` | Height value; consult the exact type for pixels versus CSS text. |
| `Style` | `string` | `null` | No | `-` | `Tabs` | Inline CSS appended to the component root. |
| `TabContentCanScroll` | `bool` | `false` | No | `-` | `Tabs` | Public component parameter; see behavior and gotchas below for component-specific effects. |
| `Width` | `string` | `null` | No | `-` | `Tabs` | CSS width value. |
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
<Tabs><Tab Header="One"><p>First page</p></Tab><Tab Header="Two"><p>Second page</p></Tab></Tabs>
```

Configured/composed:

```razor
<Tabs Width="100%" Height="420px" DefaultOpenTab="1" TabContentCanScroll="true"><Tab Header="Summary">@summary</Tab><Tab Header="Details">@details</Tab></Tabs>
```

## Rendered structure

- HTML elements observed in the Razor source: `div`.
- Composed component elements observed in the Razor source: `CascadingValue`.
- Elements may be conditional on parameters and internal state. Attribute forwarding is limited to the parameters shown in the contract table; do not assume arbitrary attributes reach the root.

## Associated types

No non-scalar supporting types beyond framework primitives.

Exact enum members and model properties are listed in the [public supporting types reference](../references/public-types.md).

## Lifecycle and callback behavior

No lifecycle method is overridden in this component's Razor/code-behind files; normal ComponentBase parameter assignment and rendering apply.

No EventCallback parameters are exposed.

## Rendering, services, and assets

Injected services:

None.

JavaScript modules:

None.

Static asset contract:

- CSS isolation inputs: `AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components/Tabs/Tabs.razor.css`. They are bundled by the Razor class library build.
- No direct JavaScript module import is observable in this component source.

Source files:

- [Tabs.razor](../../../AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components/Tabs/Tabs.razor)
- [Tabs.razor.cs](../../../AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components/Tabs/Tabs.razor.cs)
- [Tabs.razor.css](../../../AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components/Tabs/Tabs.razor.css)

## Styling and theme tokens

- `--semanticTextColors-ButtonText`

The listed tokens are case-sensitive. Use the [Theme reference](theme.md) for their emitted values and customization rules.

## Accessibility

Inspect the rendered markup before assuming ARIA roles or keyboard behavior; the component does not add accessibility behavior beyond what is present in its source markup.

## Exceptions

No exception is thrown explicitly in the component source. Consumer callbacks, invalid templates/data, and JavaScript interop can still propagate their own failures.

## Gotchas and current limitations

- DefaultOpenTab is a zero-based index and is applied as children register.
- There is no public ActivePage parameter; active state is managed internally.
- TabContentCanScroll only changes the content container overflow behavior.

## Related knowledge

- [Component index](index.md)
- [Architecture and binding conventions](../architecture-and-binding.md)
- [Public supporting types](../references/public-types.md)
- [Static assets and JavaScript interop](../references/static-assets-and-js.md)
