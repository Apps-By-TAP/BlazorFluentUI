# 03 — Buttons

```
Namespace: AppsByTAP.BlazorFluentUI.Components.Button
```

---

## Base Parameters (all button variants)

| Parameter | Type | Default | Description |
|---|---|---|---|
| `Text` | `string` | — | Button label text |
| `Icon` | `IconTypes` | `None` | Icon displayed alongside the text |
| `IsPrimary` | `bool` | `false` | Renders with the primary theme color |
| `Disabled` | `bool` | `false` | Disables the button |
| `IsBusy` | `bool` | `false` | Replaces the label with a tiny inline spinner |
| `OnClick` | `EventCallback` | — | Click handler |
| `OnClickStopPropagation` | `bool` | `false` | Stops the click event from bubbling |
| `ClassName` | `string` | — | Additional CSS class |
| `Style` | `string` | — | Inline CSS style |
| `ID` | `string` | — | HTML element `id` |

---

## Button Variants

| Component | Description |
|---|---|
| `DefaultButton` | Standard button — the most common variant |
| `CompoundButton` | Button with primary text and a secondary description line |
| `IconButton` | Icon-only button (no visible text) |
| `SplitButton` | Button with a main action and a separate dropdown trigger |
| `NavButton` | Navigation-style button (left-aligned icon + text) |
| `HyperLinkButton` | Renders with hyperlink-style appearance |
| `PostButton` | Post-action button |
| `TemplateButton` | Accepts a `RenderFragment` for fully custom button content |

### `CompoundButton` additional parameters

| Parameter | Type | Description |
|---|---|---|
| `SecondaryText` | `string` | Descriptive text displayed below the primary label |

---

## Examples

### Basic buttons

```razor
@using AppsByTAP.BlazorFluentUI.Components.Button

<!-- Primary action button -->
<DefaultButton Text="Save" IsPrimary="true" OnClick="Save" />

<!-- Secondary cancel button -->
<DefaultButton Text="Cancel" OnClick="Cancel" />

<!-- Disabled button -->
<DefaultButton Text="Unavailable" Disabled="true" />

<!-- Busy / loading state -->
<DefaultButton Text="Saving…" IsBusy="true" IsPrimary="true" />
```

### Button with an icon

```razor
<DefaultButton Text="Save" IsPrimary="true" OnClick="Save" Icon="IconTypes.Save" />
<DefaultButton Text="Delete" OnClick="Delete" Icon="IconTypes.Delete" />
<DefaultButton Text="Add Item" OnClick="AddItem" Icon="IconTypes.Add" />
```

### Icon-only button

```razor
<IconButton Icon="IconTypes.Delete" OnClick="Delete" />
<IconButton Icon="IconTypes.Settings" OnClick="OpenSettings" />
```

### CompoundButton

```razor
<CompoundButton Text="Send Email"
               SecondaryText="A confirmation email will be sent to the user"
               OnClick="SendEmail"
               IsPrimary="true" />
```

### SplitButton

```razor
<SplitButton Text="Export" OnClick="ExportDefault" Icon="IconTypes.Download" />
```

### HyperLinkButton

```razor
<HyperLinkButton Text="Learn more" OnClick="OpenDocs" />
```

### TemplateButton (custom content)

```razor
<TemplateButton OnClick="DoAction">
    <span style="display:flex; align-items:center; gap:8px;">
        <Icon IconType="IconTypes.Star" />
        <strong>Custom Layout</strong>
    </span>
</TemplateButton>
```

### Inline lambda handlers

```razor
<DefaultButton Text="Open Dialog" OnClick="() => showDialog = true" />
<DefaultButton Text="Increment" OnClick="() => count++" IsPrimary="true" />
```

---

## Common Patterns

### Confirming before destructive actions

```razor
<DefaultButton Text="Delete Account" OnClick="() => showConfirm = true" Icon="IconTypes.Delete" />
```

### Toggling busy state around async work

```razor
<DefaultButton Text="Submit" IsBusy="isSubmitting" IsPrimary="true" OnClick="Submit" />

@code {
    bool isSubmitting = false;

    async Task Submit()
    {
        isSubmitting = true;
        await DoWorkAsync();
        isSubmitting = false;
    }
}
```

### Stop-propagation inside a clickable container

```razor
<div @onclick="SelectRow">
    <DefaultButton Text="Edit" OnClick="EditRow" OnClickStopPropagation="true" />
</div>
```
