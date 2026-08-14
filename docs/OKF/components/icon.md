---
type: Blazor Component
title: "Icon"
description: "A wrapper for the bundled Office Fabric icon font using IconTypes."
resource: "../../../AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components/Icon/Icon.razor"
tags: [blazor, fluent-ui, component, api-reference]
status: stable
dotnet_type: "AppsByTAP.BlazorFluentUI.Components.Icon.Icon"
component_source: "AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components/Icon/Icon.razor"
generic_parameters: []
generated: { by: codex/gpt-5, at: 2026-08-14T00:00:00-04:00 }
verified: { by: "process:okf-docs-validator", at: 2026-08-14T00:00:00-04:00 }
verification_scope: api-contract-links-examples-and-theme-tokens
sources:
  - id: component-source
    resource: "../../../AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components/Icon/Icon.razor"
    title: "Icon Razor source"
---

# Icon

A wrapper for the bundled Office Fabric icon font using IconTypes.

## Contract

- Namespace: `AppsByTAP.BlazorFluentUI.Components.Icon`
- Compiled type: `AppsByTAP.BlazorFluentUI.Components.Icon.Icon`
- Base type: `IconViewModel`
- Intended level: consumer-facing component.

### Generic type parameters

None.

## Parameters

The table lists the effective runtime contract, including inherited library and framework parameters.

<!-- parameters:start -->
| Name | Type | Default | Required | Binding | Declared by | Notes |
|---|---|---|---|---|---|---|
| `ClassName` | `string` | `""` | No | `-` | `BaseComponentViewModel` | Additional CSS class string inherited from the library base type. |
| `ID` | `string` | `""` | No | `-` | `BaseComponentViewModel` | DOM id; required by masking features. |
| `IconType` | `IconTypes` | `IconTypes.None` | No | `-` | `IconViewModel` | IconTypes value mapped to a Fabric icon class. |
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
<Icon IconType="IconTypes.Settings" />
```

Configured/composed:

```razor
<Icon ID="status-icon" IconType="IconTypes.CheckMark" ClassName="status" Style="font-size:24px" />
```

## Rendered structure

- HTML elements observed in the Razor source: `span`.
- Elements may be conditional on parameters and internal state. Attribute forwarding is limited to the parameters shown in the contract table; do not assume arbitrary attributes reach the root.

## Associated types

- `IconTypes`

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

- No component-scoped ``.razor.css`` file is associated with this component.
- No direct JavaScript module import is observable in this component source.
- The host must load ``_content/AppsByTAP.BlazorFluentUI.Components/css/fabric-icons-inline.css`` for glyphs to render.

Source files:

- [Icon.razor](../../../AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components/Icon/Icon.razor)
- [Icon.razor.cs](../../../AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components/Icon/Icon.razor.cs)

## Styling and theme tokens

No CSS custom properties are referenced directly by this component source.

The listed tokens are case-sensitive. Use the [Theme reference](theme.md) for their emitted values and customization rules.

## Accessibility

Inspect the rendered markup before assuming ARIA roles or keyboard behavior; the component does not add accessibility behavior beyond what is present in its source markup.

## Exceptions

No exception is thrown explicitly in the component source. Consumer callbacks, invalid templates/data, and JavaScript interop can still propagate their own failures.

## Gotchas and current limitations

- The Fabric icon stylesheet must be linked by the host application.
- IconTypes member names map directly to bundled ms-Icon CSS class names, including legacy spellings.
- The icon is presentation-only and has no accessible label parameter.

## Related knowledge

- [Component index](index.md)
- [Architecture and binding conventions](../architecture-and-binding.md)
- [Public supporting types](../references/public-types.md)
- [Static assets and JavaScript interop](../references/static-assets-and-js.md)
