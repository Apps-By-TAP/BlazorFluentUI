---
type: Playbook
title: Maintaining the OKF documentation
description: Regenerate component contracts and run the quality gates after source or documentation changes.
tags: [documentation, okf, validation, ci]
status: stable
generated: { by: codex/gpt-5, at: 2026-08-14T00:00:00-04:00 }
verified: { by: "process:okf-docs-validator", at: 2026-08-14T00:00:00-04:00 }
verification_scope: commands-and-links
sources:
  - id: validator
    resource: "../../../tools/OkfDocsValidator"
    title: OKF documentation validator
---

# Maintaining the OKF documentation

## Normal workflow

1. Build the validator, which also builds the component assembly.
2. Regenerate the reflected component tables after changing component parameters, inheritance, types, defaults, or theme classes.
3. Review and update the affected prose, examples, behavior, accessibility, and gotchas; generation cannot infer intent.
4. Run self-tests and the repository check.
5. Build the full solution.

```powershell
dotnet build tools/OkfDocsValidator/OkfDocsValidator.csproj
./tools/OkfDocsValidator/Generate-OkfDocs.ps1
dotnet run --no-build --project tools/OkfDocsValidator/OkfDocsValidator.csproj -- self-test
dotnet run --no-build --project tools/OkfDocsValidator/OkfDocsValidator.csproj -- check --repo-root .
dotnet build AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.PlayGround.sln --configuration Release
```

The generator intentionally rewrites component pages and the public-type reference from the compiled contract. Preserve or reapply reviewed prose changes by updating the generator's component metadata rather than hand-editing generated sections alone.

## Component page contract

- `type: Blazor Component`, exact `dotnet_type`, exact repository-relative `component_source`, and ordered `generic_parameters` in frontmatter.
- Parameter and cascading-parameter tables enclosed by validator markers.
- At least minimal and configured Razor examples using only reflected attributes and valid bind pairs.
- Source links, dependencies, theme tokens, accessibility notes, and current limitations.

## What CI rejects

- Invalid or missing YAML/type metadata and malformed reserved files.
- Missing/duplicate component concepts or stale type/source mappings.
- Missing, extra, or incorrectly typed parameters; invalid binding pairs.
- Unknown component attributes in fenced Razor examples.
- Missing public types/enum members, broken local links, unknown theme variables, or malformed palette hex values.

External HTTP links are not fetched in CI. Machine verification confirms structural claims, not the correctness of human interpretation; do not add a `human:` verifier without an actual review.
