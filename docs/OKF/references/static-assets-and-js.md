---
type: API Reference
title: Static assets and JavaScript interop
description: Required Razor class library assets, importing components, and runtime failure modes.
tags: [blazor, static-assets, javascript, icons, masking]
status: stable
generated: { by: codex/gpt-5, at: 2026-08-14T00:00:00-04:00 }
verified: { by: "process:okf-docs-validator", at: 2026-08-14T00:00:00-04:00 }
verification_scope: source-paths-and-links
sources:
  - id: assets
    resource: "../../../AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components/wwwroot"
    title: Component static assets
---

# Static assets and JavaScript interop

## Host-loaded asset

The host must load [fabric-icons-inline.css](../../../AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components/wwwroot/css/fabric-icons-inline.css) from `_content/AppsByTAP.BlazorFluentUI.Components/css/fabric-icons-inline.css`. `Icon` maps `IconTypes.ToString()` directly to an `ms-Icon--{name}` class; a missing stylesheet produces blank icons without a C# error.

## Dynamically imported modules

| Module | Consumers | Purpose and requirements |
|---|---|---|
| `BlankDropDown.js` | BlankDropDown | Dropdown DOM positioning/measurement. |
| `Callout.js` | Callout | Anchors the overlay to `TargetID`; the target must exist. |
| `FitText.js` | FitText | Measures the element and calls back with bounds. |
| `HyperLinkButton.js` | HyperLinkButton | Registers busy-animation CSS; current code also invokes browser `eval`. |
| `Mask.js` | both TextField variants | Applies a mask by DOM `ID`; missing ID throws after first render. |
| `Modal.js` | Modal | Modal client behavior and sizing. |

The import URLs begin with `./_content/AppsByTAP.BlazorFluentUI.Components/js/`. Static web assets must therefore be enabled and served under the assembly name. JavaScript-dependent behavior does not run during prerendering until an interactive render is available.

## Mask dependency

[Mask.js](../../../AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components/wwwroot/js/Mask.js) imports or uses the bundled `IMask.min.js`. A mask is only applied on first render. Changing `Mask` or `ID` later does not reinitialize it in current source.

## Failure diagnosis

- Browser 404 under `_content/...`: confirm the component project/package reference and static web asset middleware.
- Blank Fabric icon: confirm the stylesheet link and exact `IconTypes` member.
- JS exception finding an element: supply a stable `ID`/`TargetID` and render the target before opening the component.
- Prerender interop exception: defer opening or masking until the interactive render.
