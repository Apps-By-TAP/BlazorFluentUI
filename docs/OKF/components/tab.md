---
type: Blazor Component
title: "Tab"
description: "A child tab page registered with a parent Tabs component through a cascading parameter."
resource: "../../../AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components/Tabs/Tab.razor"
tags: [blazor, fluent-ui, component, api-reference]
status: stable
dotnet_type: "AppsByTAP.BlazorFluentUI.Components.Tabs.Tab"
component_source: "AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components/Tabs/Tab.razor"
generic_parameters: []
generated: { by: codex/gpt-5, at: 2026-08-14T00:00:00-04:00 }
verified: { by: "process:okf-docs-validator", at: 2026-08-14T00:00:00-04:00 }
verification_scope: api-contract-links-examples-and-theme-tokens
sources:
  - id: component-source
    resource: "../../../AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components/Tabs/Tab.razor"
    title: "Tab Razor source"
---

# Tab

A child tab page registered with a parent Tabs component through a cascading parameter.

## Contract

- Namespace: `AppsByTAP.BlazorFluentUI.Components.Tabs`
- Compiled type: `AppsByTAP.BlazorFluentUI.Components.Tabs.Tab`
- Base type: `ComponentBase`
- Intended level: low-level or composition component; use directly only when its contract fits the scenario.

### Generic type parameters

None.

## Parameters

The table lists the effective runtime contract, including inherited library and framework parameters.

<!-- parameters:start -->
| Name | Type | Default | Required | Binding | Declared by | Notes |
|---|---|---|---|---|---|---|
| `ChildContent` | `RenderFragment` | `null` | No | `-` | `Tab` | Child markup rendered by the component. |
| `Color` | `string` | `"var(--semanticTextColors-ButtonText)"` | No | `-` | `Tab` | Public component parameter; see behavior and gotchas below for component-specific effects. |
| `Header` | `string` | `null` | No | `-` | `Tab` | Header text or named header fragment, according to the declared type. |
<!-- parameters:end -->

## Cascading parameters

Cascading values are supplied by an ancestor and must not be invented as normal component attributes.

<!-- cascading-parameters:start -->
| Name | Type | Default | Required | Binding | Declared by | Notes |
|---|---|---|---|---|---|---|
| `Parent` | `Tabs` | `null` | No | `-` | `Tab` | Public component parameter; see behavior and gotchas below for component-specific effects. |
<!-- cascading-parameters:end -->

## Examples

Minimal:

```razor
<Tabs><Tab Header="General"><p>General settings</p></Tab></Tabs>
```

Configured/composed:

```razor
<Tabs DefaultOpenTab="1"><Tab Header="General" Color="var(--palette-ThemePrimary)"><p>General</p></Tab><Tab Header="Security" Color="var(--palette-RedDark)"><p>Security</p></Tab></Tabs>
```

## Rendered structure

- HTML elements observed in the Razor source: `div`.
- Elements may be conditional on parameters and internal state. Attribute forwarding is limited to the parameters shown in the contract table; do not assume arbitrary attributes reach the root.

## Associated types

- `Tabs`

Exact enum members and model properties are listed in the [public supporting types reference](../references/public-types.md).

## Lifecycle and callback behavior

- Lifecycle methods implemented by this component: `OnInitialized`.

No EventCallback parameters are exposed.

## Rendering, services, and assets

Injected services:

None.

JavaScript modules:

None.

Static asset contract:

- CSS isolation inputs: `AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components/Tabs/Tab.razor.css`. They are bundled by the Razor class library build.
- No direct JavaScript module import is observable in this component source.

Source files:

- [Tab.razor](../../../AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components/Tabs/Tab.razor)
- [Tab.razor.cs](../../../AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components/Tabs/Tab.razor.cs)
- [Tab.razor.css](../../../AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components/Tabs/Tab.razor.css)

## Styling and theme tokens

- `--semanticTextColors-ButtonText`

The listed tokens are case-sensitive. Use the [Theme reference](theme.md) for their emitted values and customization rules.

## Accessibility

Inspect the rendered markup before assuming ARIA roles or keyboard behavior; the component does not add accessibility behavior beyond what is present in its source markup.

## Exceptions

- Explicit source throw: `ArgumentNullException(nameof(Parent), "TabPage must exist within a TabControl")`.

## Gotchas and current limitations

- Tab must be nested in Tabs or it throws ArgumentNullException during initialization.
- The public label parameter is Header, not Name.
- Parent is an internal cascading parameter and cannot be assigned by normal markup.

## Related knowledge

- [Component index](index.md)
- [Architecture and binding conventions](../architecture-and-binding.md)
- [Public supporting types](../references/public-types.md)
- [Static assets and JavaScript interop](../references/static-assets-and-js.md)
