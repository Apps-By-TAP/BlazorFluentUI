---
type: Blazor Component
title: "ValidationInput"
description: "A minimal InputBase<string> input that participates in EditForm validation."
resource: "../../../AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components/TextField/ValidationInput.razor"
tags: [blazor, fluent-ui, component, api-reference]
status: stable
dotnet_type: "AppsByTAP.BlazorFluentUI.Components.TextField.ValidationInput"
component_source: "AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components/TextField/ValidationInput.razor"
generic_parameters: []
generated: { by: codex/gpt-5, at: 2026-08-14T00:00:00-04:00 }
verified: { by: "process:okf-docs-validator", at: 2026-08-14T00:00:00-04:00 }
verification_scope: api-contract-links-examples-and-theme-tokens
sources:
  - id: component-source
    resource: "../../../AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components/TextField/ValidationInput.razor"
    title: "ValidationInput Razor source"
---

# ValidationInput

A minimal InputBase<string> input that participates in EditForm validation.

## Contract

- Namespace: `AppsByTAP.BlazorFluentUI.Components.TextField`
- Compiled type: `AppsByTAP.BlazorFluentUI.Components.TextField.ValidationInput`
- Base type: `InputBase<string>`
- Intended level: low-level or composition component; use directly only when its contract fits the scenario.

### Generic type parameters

None.

## Parameters

The table lists the effective runtime contract, including inherited library and framework parameters.

<!-- parameters:start -->
| Name | Type | Default | Required | Binding | Declared by | Notes |
|---|---|---|---|---|---|---|
| `AdditionalAttributes` | `IReadOnlyDictionary<string, object>` | `null` | No | `-` | `InputBase<string>` | Unmatched HTML attributes inherited from InputBase and applied to the input. |
| `DisplayName` | `string` | `null` | No | `-` | `InputBase<string>` | Display name used in validation messages. |
| `Value` | `string` | `null` | No | `@bind-Value` | `InputBase<string>` | Current value. |
| `ValueChanged` | `EventCallback<string>` | `default` | No | `-` | `InputBase<string>` | Binding callback paired with Value; normally supplied by @bind syntax. |
| `ValueExpression` | `Expression<Func<string>>` | `null` | No | `-` | `InputBase<string>` | Expression used by InputBase/EditContext validation. |
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
<EditForm Model="@model"><ValidationInput @bind-Value="model.Name" /></EditForm>
```

Configured/composed:

```razor
<EditForm Model="@model"><DataAnnotationsValidator /><ValidationInput DisplayName="Name" class="form-control" @bind-Value="model.Name" /><ValidationMessage For="@(() => model.Name)" /></EditForm>
```

## Rendered structure

- HTML elements observed in the Razor source: `input`, `string`.
- Elements may be conditional on parameters and internal state. Attribute forwarding is limited to the parameters shown in the contract table; do not assume arbitrary attributes reach the root.

## Associated types

- `EventCallback<string>`
- `Expression<Func<string>>`
- `IReadOnlyDictionary<string, object>`

Exact enum members and model properties are listed in the [public supporting types reference](../references/public-types.md).

## Lifecycle and callback behavior

No lifecycle method is overridden in this component's Razor/code-behind files; normal ComponentBase parameter assignment and rendering apply.

- `ValueChanged` is declared as `EventCallback<string>`; no direct InvokeAsync call is observable in this component's source files. A wrapper/base implementation may invoke it, or the current API may be inert.

## Rendering, services, and assets

Injected services:

None.

JavaScript modules:

None.

Static asset contract:

- No component-scoped ``.razor.css`` file is associated with this component.
- No direct JavaScript module import is observable in this component source.

Source files:

- [ValidationInput.razor](../../../AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components/TextField/ValidationInput.razor)

## Styling and theme tokens

No CSS custom properties are referenced directly by this component source.

The listed tokens are case-sensitive. Use the [Theme reference](theme.md) for their emitted values and customization rules.

## Accessibility

Use a visible label and stable ID where supported. Validation and masking do not replace accessible instructions or error association.

## Exceptions

No exception is thrown explicitly in the component source. Consumer callbacks, invalid templates/data, and JavaScript interop can still propagate their own failures.

## Gotchas and current limitations

- ValidationInput inherits InputBase<string>; use it inside EditForm with a value expression produced by @bind-Value.
- It always renders type=text and rejects blank values.
- It is distinct from the richer Forms.TextField validation component.

## Related knowledge

- [Component index](index.md)
- [Architecture and binding conventions](../architecture-and-binding.md)
- [Public supporting types](../references/public-types.md)
- [Static assets and JavaScript interop](../references/static-assets-and-js.md)
