---
type: Migration Guide
title: Migration to 0.1.0
description: Breaking public-name corrections and theme-token repairs introduced by the source-verified API baseline.
tags: [migration, breaking-change, api, theme]
status: stable
generated: { by: codex/gpt-5, at: 2026-08-14T00:00:00-04:00 }
verified: { by: "process:okf-docs-validator", at: 2026-08-14T00:00:00-04:00 }
verification_scope: compiled-public-symbols-and-token-names
sources:
  - id: component-source
    resource: "../../../AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components"
    title: Component library source
---

# Migration to 0.1.0

Version 0.1.0 establishes a corrected pre-1.0 public baseline. The old names were removed rather than retained as obsolete aliases.

| Before 0.1.0 | 0.1.0 replacement | Required consumer change |
|---|---|---|
| `NavigationItem.ICon` | `NavigationItem.Icon` | Rename the Razor attribute or property access. |
| `ChipType.Choise` | `ChipType.Choice` | Rename the enum member. |
| `ValendationResult<T>` | `ValidationResult<T>` | Rename the type and update imports/usages. |
| `Forms.TextField.CustomValendation` | `CustomValidation` | Rename the Razor attribute/property. |

Theme fixes require no intended API migration, but custom CSS that copied an invalid spelling should change:

- `--pallette-Black` became `--palette-Black`.
- `ButtonText`, `ErrorText`, `InputText`, and `Link` use the `--semanticTextColors-` prefix.
- Built-in `GreenLight` is now the valid color `#bad80a`.

Preserved unconventional names are not migration targets: `TextFieldType.text/number/tel/email/password`, `SpinnerSize.xSmall`, `PlaceHolder`, `DropDown`, `CheckBox`, and the WPF-style binding properties remain exact public API.
