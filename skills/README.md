# BlazorFluentUI Skills

This folder contains skill files that teach AI (LLMs) how to use the **BlazorFluentUI** component library. Each file focuses on a specific area of the library and is self-contained with parameter tables, code examples, and usage notes.

## File Index

| File | Topic |
|---|---|
| [01-overview.md](01-overview.md) | What the library is, key concepts, and namespace structure |
| [02-setup.md](02-setup.md) | Installation, `Program.cs` registration, CSS, and the `Theme` wrapper |
| [03-buttons.md](03-buttons.md) | All button variants — `DefaultButton`, `IconButton`, `CompoundButton`, and more |
| [04-inputs.md](04-inputs.md) | `TextField`, `CheckBox`, `CheckboxGroup`, `ChoiceGroup`, `Toggle`, `SpinButton` |
| [05-overlays-and-layout.md](05-overlays-and-layout.md) | `Modal`, `Callout`, `Expander`, `Tabs` |
| [06-data-display.md](06-data-display.md) | `DropDown<T>`, `TreeMenu`, `Chip`/`ChipSet`, `Persona`, `Icon`, `Label`, `Spinner`, `FitText` |
| [07-navigation.md](07-navigation.md) | `BottomNavigationBar`, `FloatingActionButton` |
| [08-theming.md](08-theming.md) | Theme system, runtime switching, custom palettes, CSS variables |
| [09-forms.md](09-forms.md) | Form validation with `EditForm` and `ValidationInput` |
| [10-patterns.md](10-patterns.md) | Common real-world patterns and recipes |

## Quick Reference

```
Namespace root: AppsByTAP.BlazorFluentUI.Components
Component namespaces: AppsByTAP.BlazorFluentUI.Components.<ComponentFolder>
Theme namespace:      AppsByTAP.BlazorFluentUI.Components.Theme
```

## How to Use These Skills

- Read **01-overview** and **02-setup** first to understand the prerequisites.
- Jump directly to the relevant component file for parameter tables and copy-paste examples.
- Use **08-theming** whenever you need to adapt colors or support light/dark mode.
- Use **09-forms** whenever a page collects user input that needs validation.
- Use **10-patterns** for higher-level compositions such as confirm dialogs, multi-step forms, and dynamic lists.
