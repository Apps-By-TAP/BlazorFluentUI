---
type: Concept
title: Architecture and binding conventions
description: The library's WPF-style API rules, component contract model, composition patterns, and agent implementation constraints.
tags: [blazor, fluent-ui, architecture, binding, agents]
status: stable
generated: { by: codex/gpt-5, at: 2026-08-14T00:00:00-04:00 }
verified: { by: "process:okf-docs-validator", at: 2026-08-14T00:00:00-04:00 }
verification_scope: links-and-binding-contracts
sources:
  - id: source
    resource: "../../AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components"
    title: Component library source
  - id: agent-guidance
    resource: "../../.github/.instructions.md"
    title: Repository agent guidance
---

# Architecture and binding conventions

## Source of truth

The compiled component assembly defines which attributes Blazor can apply. Each component page expands inherited `[Parameter]` properties and lists non-user-set cascading parameters separately. Source markup/code-behind defines whether a parameter is actually forwarded or acted upon; public presence alone does not guarantee behavior.

## WPF-style binding names

The library deliberately favors descriptive WPF-style state names:

| Scenario | Value parameter | Callback | Razor binding |
|---|---|---|---|
| CheckBox/Toggle | `IsChecked` | `IsCheckedChanged` | `@bind-IsChecked` |
| DropDown/ChoiceGroup/SplitButton | `SelectedItem` | `SelectedItemChanged` | `@bind-SelectedItem` |
| Multi-select DropDown | `SelectedItems` | `SelectedItemsChanged` | `@bind-SelectedItems` |
| Overlay/Expander | `IsOpen` | `IsOpenChanged` | `@bind-IsOpen` |
| Modal | `ShowWindow` | `ShowWindowChanged` | `@bind-ShowWindow` |
| Whole SpinButton | `WholeValue` | `WholeValueChanged` | `@bind-WholeValue` |
| Decimal SpinButton | `DecimalValue` | `DecimalValueChanged` | `@bind-DecimalValue` |
| Text inputs/InputBase | `Value` | `ValueChanged` | `@bind-Value` |

Do not replace these with guessed conventional names. Event callbacks such as `SelectionChanged`, `OnChanged`, or `OnClose` are additional notifications and are not substitutes for the documented binding pair.

## Generic components

Generic argument attributes match each component's `@typeparam`, not the view-model's internal generic name:

- `DropDown`, `SplitButton`, and `ChipSet` use `TItem`.
- `CheckboxGroup`, `Choice`, `ChoiceGroup`, `BranchComponent`, and `TreeMenu` use `T`.

Supply the same T to coordinated parent/child components. `Choice<T>`, `Tab`, and `BranchComponent<T>` depend on cascading parents; constructing them alone can throw or leave them unusable.

## Named fragments and templates

`ChildContent` can usually be implicit. Other `RenderFragment` parameters require named elements such as `<Header>`, `<Content>`, `<DisplayInfo>`, or `<ChildContent>`. Generic `RenderFragment<T>` parameters are supplied with delegates or Razor templates and receive the documented context type.

## Defaults and nullability

Nullable reference types are not enabled consistently in the library. A C# declaration without `?` is not proof that a value is runtime-required. The component pages report the constructed default and document behavioral requirements separately. `EditorRequired` is reflected in the Required column; most requirements in this codebase are enforced only by later null use or explicit exceptions.

## Events and side effects

Several state parameters use setters that invoke callbacks, producing BL0007 analyzer warnings. Several internal handlers are `async void`. Consumers should avoid reassigning state redundantly and must handle exceptions inside their own callbacks. Current behavior is documented rather than refactored in 0.1.0.

## Accessibility baseline

Many button, checkbox, toggle, tab, and expander surfaces use `div` markup rather than native interactive elements. Do not assume keyboard activation, focus management, ARIA state, or native disabled behavior. Modal/callout components do not provide a complete focus trap. Treat each page's accessibility section as a minimum implementation warning.

## Styling

Use only variables emitted by [Theme](components/theme.md). Palette, semantic-color, and semantic-text prefixes are not interchangeable. Component styles use CSS isolation where a `.razor.css` file exists; inline `<style>` blocks and global rules behave differently and are called out on the relevant page.
