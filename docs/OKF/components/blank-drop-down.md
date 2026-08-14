---
type: Blazor Component
title: "BlankDropDown"
description: "A low-level dropdown shell with templated display and panel content."
resource: "../../../AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components/DropDown/BlankDropDown.razor"
tags: [blazor, fluent-ui, component, api-reference]
status: stable
dotnet_type: "AppsByTAP.BlazorFluentUI.Components.DropDown.BlankDropDown"
component_source: "AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components/DropDown/BlankDropDown.razor"
generic_parameters: []
generated: { by: codex/gpt-5, at: 2026-08-14T00:00:00-04:00 }
verified: { by: "process:okf-docs-validator", at: 2026-08-14T00:00:00-04:00 }
verification_scope: api-contract-links-examples-and-theme-tokens
sources:
  - id: component-source
    resource: "../../../AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components/DropDown/BlankDropDown.razor"
    title: "BlankDropDown Razor source"
---

# BlankDropDown

A low-level dropdown shell with templated display and panel content.

## Contract

- Namespace: `AppsByTAP.BlazorFluentUI.Components.DropDown`
- Compiled type: `AppsByTAP.BlazorFluentUI.Components.DropDown.BlankDropDown`
- Base type: `ComponentBase`
- Intended level: low-level or composition component; use directly only when its contract fits the scenario.

### Generic type parameters

None.

## Parameters

The table lists the effective runtime contract, including inherited library and framework parameters.

<!-- parameters:start -->
| Name | Type | Default | Required | Binding | Declared by | Notes |
|---|---|---|---|---|---|---|
| `ClassName` | `string` | `null` | No | `-` | `BlankDropDown` | Additional CSS class string inherited from the library base type. |
| `Content` | `RenderFragment` | `null` | No | `-` | `BlankDropDown` | Named body fragment. |
| `Disabled` | `bool` | `false` | No | `-` | `BlankDropDown` | Prevents the component action using component logic. |
| `DisplayInfo` | `RenderFragment` | `null` | No | `-` | `BlankDropDown` | Public component parameter; see behavior and gotchas below for component-specific effects. |
| `IsOpen` | `bool` | `false` | No | `@bind-IsOpen` | `BlankDropDown` | Current overlay/expansion state. |
| `IsOpenChanged` | `EventCallback<bool>` | `default` | No | `-` | `BlankDropDown` | Binding callback paired with IsOpen; normally supplied by @bind syntax. |
| `ItemsPanelHeight` | `int` | `-1` | No | `-` | `BlankDropDown` | Public component parameter; see behavior and gotchas below for component-specific effects. |
| `Label` | `string` | `null` | No | `-` | `BlankDropDown` | Visible label text. |
| `OnClickStopPropagation` | `bool` | `true` | No | `-` | `BlankDropDown` | Controls Blazor click event propagation. |
| `OnClose` | `EventCallback` | `default` | No | `-` | `BlankDropDown` | Public component parameter; see behavior and gotchas below for component-specific effects. |
| `OnOpen` | `EventCallback` | `default` | No | `-` | `BlankDropDown` | Public component parameter; see behavior and gotchas below for component-specific effects. |
| `Style` | `string` | `null` | No | `-` | `BlankDropDown` | Inline CSS appended to the component root. |
| `Width` | `string` | `"300px"` | No | `-` | `BlankDropDown` | CSS width value. |
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
<BlankDropDown @bind-IsOpen="open"><DisplayInfo>Choose</DisplayInfo><Content><p>Custom content</p></Content></BlankDropDown>
```

Configured/composed:

```razor
<BlankDropDown Label="Actions" Width="320px" ItemsPanelHeight="240" @bind-IsOpen="open" OnOpen="Opened" OnClose="Closed"><DisplayInfo>@summary</DisplayInfo><Content>@menu</Content></BlankDropDown>
```

## Rendered structure

- HTML elements observed in the Razor source: `div`, `span`.
- Composed component elements observed in the Razor source: `AppsByTAP`, `Icon`, `LightDismiss`.
- Elements may be conditional on parameters and internal state. Attribute forwarding is limited to the parameters shown in the contract table; do not assume arbitrary attributes reach the root.

## Associated types

- `EventCallback<bool>`

Exact enum members and model properties are listed in the [public supporting types reference](../references/public-types.md).

## Lifecycle and callback behavior

No lifecycle method is overridden in this component's Razor/code-behind files; normal ComponentBase parameter assignment and rendering apply.

- `IsOpenChanged` (`EventCallback<bool>`) is invoked with `IsOpen`.
- `OnClose` (`EventCallback`) is invoked with `no payload`.
- `OnOpen` (`EventCallback`) is invoked with `no payload`.

## Rendering, services, and assets

Injected services:

- `IJSRuntime`

JavaScript modules:

- `./_content/AppsByTAP.BlazorFluentUI.Components/js/BlankDropDown.js`

Static asset contract:

- CSS isolation inputs: `AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components/DropDown/BlankDropDown.razor.css`. They are bundled by the Razor class library build.
- Runtime JavaScript module imports: `./_content/AppsByTAP.BlazorFluentUI.Components/js/BlankDropDown.js`.

Source files:

- [BlankDropDown.razor](../../../AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components/DropDown/BlankDropDown.razor)
- [BlankDropDown.razor.cs](../../../AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components/DropDown/BlankDropDown.razor.cs)
- [BlankDropDown.razor.css](../../../AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components/DropDown/BlankDropDown.razor.css)

## Styling and theme tokens

- `--palette-ThemePrimary`
- `--semanticColors-ButtonBorder`
- `--semanticColors-ListBackground`
- `--semanticColors-ListItemBackgroundCheckedHovered`
- `--semanticColors-ScrollbarThumb`
- `--semanticColors-ScrollbarTrack`
- `--semanticTextColors-DisabledText`

The listed tokens are case-sensitive. Use the [Theme reference](theme.md) for their emitted values and customization rules.

## Accessibility

Inspect the rendered markup before assuming ARIA roles or keyboard behavior; the component does not add accessibility behavior beyond what is present in its source markup.

## Exceptions

No exception is thrown explicitly in the component source. Consumer callbacks, invalid templates/data, and JavaScript interop can still propagate their own failures.

## Gotchas and current limitations

- DisplayInfo and Content are separate named fragments.
- The JS module is imported for positioning/measurement behavior.
- IsOpen has callback side effects and OnClickStopPropagation defaults to true.

## Related knowledge

- [Component index](index.md)
- [Architecture and binding conventions](../architecture-and-binding.md)
- [Public supporting types](../references/public-types.md)
- [Static assets and JavaScript interop](../references/static-assets-and-js.md)
