---
okf_version: "0.2"
---

# BlazorFluentUI knowledge bundle

This is the canonical, source-verified reference for AppsByTAP.BlazorFluentUI 0.1.0. Coding agents should begin here, then load the relevant component concept before writing Razor. Exact parameter names, generic arguments, enum casing, defaults, binding pairs, and current limitations are deliberate contract data—not suggestions.

## Start here

* [Getting started](getting-started.md) - Project setup, services, static assets, namespaces, and first component usage.
* [Architecture and binding conventions](architecture-and-binding.md) - WPF-style names, data flow, component composition, and rules for generated code.
* [Components](components/) - One detailed source-linked page for each of the 41 compiled Razor components.
* [References](references/) - Supporting types, assets, migration, and documentation maintenance.
* [Update log](log.md) - Bundle and API changes in newest-first order.

## Agent consumption contract

1. Read the exact component page and every linked supporting type before emitting markup.
2. Copy parameter and enum spelling exactly. Do not infer conventional Blazor names such as `Value` when the page specifies `IsChecked`, `SelectedItem`, `WholeValue`, or `DecimalValue`.
3. Treat gotchas as implementation constraints. A public parameter may exist but be ignored by a wrapper; a callback may be declared but not invoked by current source.
4. Use only CSS variables listed on the [Theme page](components/theme.md).
5. Run the documented validator after changing components or this bundle.

## Authority and trust

Component source and the compiled assembly are authoritative. Existing demos and legacy Markdown are useful context but do not override the reflected contract. Documents marked as verified were checked mechanically for frontmatter, links, component coverage, parameters, binding pairs, examples, supporting types, and theme-token names; prose has not been human-certified.
