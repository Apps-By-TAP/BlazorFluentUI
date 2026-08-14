---
type: Blazor Component
title: "SubmitButton"
description: "A native HTML submit button for Blazor forms with shared button styling, icon, disabled, click, and busy-state parameters."
resource: "../../../AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components/Button/SubmitButton.razor"
tags: [blazor, fluent-ui, component, api-reference]
status: stable
dotnet_type: "AppsByTAP.BlazorFluentUI.Components.Button.SubmitButton"
component_source: "AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components/Button/SubmitButton.razor"
generic_parameters: []
generated: { by: codex/gpt-5, at: 2026-08-14T00:00:00-04:00 }
verified: { by: "process:okf-docs-validator", at: 2026-08-14T00:00:00-04:00 }
verification_scope: api-contract-links-examples-and-theme-tokens
sources:
  - id: component-source
    resource: "../../../AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components/Button/SubmitButton.razor"
    title: "SubmitButton Razor source"
---

# SubmitButton

A native HTML submit button for Blazor forms with shared button styling, icon, disabled, click, and busy-state parameters.

## Contract

- Namespace: `AppsByTAP.BlazorFluentUI.Components.Button`
- Compiled type: `AppsByTAP.BlazorFluentUI.Components.Button.SubmitButton`
- Base type: `ButtonBaseParameters`
- Intended level: consumer-facing component.

### Generic type parameters

None.

## Parameters

The table lists the effective runtime contract, including inherited library and framework parameters.

<!-- parameters:start -->
| Name | Type | Default | Required | Binding | Declared by | Notes |
|---|---|---|---|---|---|---|
| `ClassName` | `string` | `""` | No | `-` | `BaseComponentViewModel` | Additional CSS class string inherited from the library base type. |
| `Disabled` | `bool` | `false` | No | `-` | `ButtonBaseParameters` | Prevents the component action using component logic. |
| `ID` | `string` | `""` | No | `-` | `BaseComponentViewModel` | DOM id; required by masking features. |
| `Icon` | `IconTypes` | `IconTypes.None` | No | `-` | `ButtonBaseParameters` | IconTypes value rendered by the component. |
| `IsPrimary` | `bool` | `false` | No | `-` | `ButtonBaseParameters` | Public component parameter; see behavior and gotchas below for component-specific effects. |
| `OnClick` | `EventCallback<MouseEventArgs>` | `default` | No | `-` | `ButtonBaseParameters` | Invoked for an accepted click. |
| `OnClickStopPropagation` | `bool` | `false` | No | `-` | `ButtonBaseParameters` | Controls Blazor click event propagation. |
| `ShowIsBusy` | `bool` | `false` | No | `-` | `ButtonBaseParameters` | Public component parameter; see behavior and gotchas below for component-specific effects. |
| `Style` | `string` | `""` | No | `-` | `BaseComponentViewModel` | Inline CSS appended to the component root. |
| `Text` | `string` | `null` | No | `-` | `ButtonBaseParameters` | Primary display text. |
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
<EditForm Model="@model" OnValidSubmit="SaveAsync">
    <DataAnnotationsValidator />
    <SubmitButton Text="Save" IsPrimary="true" />
</EditForm>
```

Configured/composed:

```razor
<EditForm Model="@model" OnValidSubmit="CreateAccountAsync">
    <DataAnnotationsValidator />
    <SubmitButton Text="Create account"
                  Icon="IconTypes.CheckMark"
                  IsPrimary="true"
                  Disabled="@saving"
                  OnClick="RecordSubmitAttempt"
                  OnClickStopPropagation="true" />
</EditForm>
```

## Rendered structure

- HTML elements observed in the Razor source: `button`, `div`.
- Composed component elements observed in the Razor source: `Icon`, `TinySpinner`.
- Elements may be conditional on parameters and internal state. Attribute forwarding is limited to the parameters shown in the contract table; do not assume arbitrary attributes reach the root.

## Associated types

- `IconTypes`

Exact enum members and model properties are listed in the [public supporting types reference](../references/public-types.md).

## Lifecycle and callback behavior

No lifecycle method is overridden in this component's Razor/code-behind files; normal ComponentBase parameter assignment and rendering apply.

- `OnClick` (`EventCallback<MouseEventArgs>`) is invoked with the native click arguments by inherited `OnClickInternal` when `Disabled` is false. `ShowIsBusy` sets internal `IsBusy` around that callback only.

## Rendering, services, and assets

Injected services:

None.

JavaScript modules:

None.

Static asset contract:

- CSS isolation inputs: `AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components/Button/SubmitButton.razor.css`. They are bundled by the Razor class library build.
- No direct JavaScript module import is observable in this component source.

Source files:

- [SubmitButton.razor](../../../AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components/Button/SubmitButton.razor)
- [SubmitButton.razor.css](../../../AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components/Button/SubmitButton.razor.css)

## Styling and theme tokens

- `--semanticColors-ButtonBackground`
- `--semanticColors-ButtonBackgroundChecked`
- `--semanticColors-ButtonBackgroundHovered`
- `--semanticColors-ButtonBorder`
- `--semanticColors-ListItemBackgroundCheckedHovered`
- `--semanticColors-PrimaryButtonBackground`
- `--semanticColors-PrimaryButtonBackgroundHovered`
- `--semanticColors-PrimaryButtonBackgroundPressed`
- `--semanticTextColors-ButtonText`
- `--semanticTextColors-DisabledText`
- `--semanticTextColors-PrimaryButtonText`

The listed tokens are case-sensitive. Use the [Theme reference](theme.md) for their emitted values and customization rules.

## Accessibility

The root is a native button with built-in keyboard activation and disabled semantics. Supply meaningful Text; Icon has no separate accessible-label parameter, and the busy spinner does not add a live-region announcement.

## Exceptions

No exception is thrown explicitly in the component source. Consumer callbacks, invalid templates/data, and JavaScript interop can still propagate their own failures.

## Gotchas and current limitations

- The root is a native `<button type="submit">`; inside an EditForm or HTML form it initiates form submission in addition to invoking OnClick.
- OnClickStopPropagation affects Blazor event bubbling but does not prevent the browser default submit action; the component exposes no prevent-default parameter.
- ShowIsBusy tracks only the inherited OnClick callback. It does not track EditForm.OnValidSubmit or OnSubmit work unless that work is also awaited by OnClick.
- OnClickInternal is inherited async void, so the renderer cannot await it and callback exceptions do not flow through a returned Task.
- Disabled is applied as the native disabled attribute and also suppresses inherited click handling.
- Unlike BaseButton, SubmitButton has no SecondaryText parameter and renders a native keyboard-operable button.

## Related knowledge

- [Component index](index.md)
- [Architecture and binding conventions](../architecture-and-binding.md)
- [Public supporting types](../references/public-types.md)
- [Static assets and JavaScript interop](../references/static-assets-and-js.md)
