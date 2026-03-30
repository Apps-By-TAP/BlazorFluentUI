# 05 — Overlays and Layout

Covers `Modal`, `Callout`, `Expander`, and `Tabs`.

---

## Modal

```
Namespace: AppsByTAP.BlazorFluentUI.Components.Modal
```

A dialog window with header, body, close button, and optional backdrop (light-dismiss).

### Parameters

| Parameter | Type | Default | Description |
|---|---|---|---|
| `ShowWindow` | `bool` | `false` | Controls visibility; two-way with `@bind-ShowWindow` |
| `Header` | `RenderFragment` | — | Content rendered in the modal header bar |
| `Content` | `RenderFragment` | — | Content rendered in the modal body |
| `Width` | `string` | `"fit-content"` | CSS width of the modal panel |
| `ShowHeader` | `bool` | `true` | Shows or hides the header and close button |
| `CanLightDismiss` | `bool` | `true` | Closes the modal when clicking outside it |
| `OnClose` | `EventCallback` | — | Fires when the modal closes |

### Examples

#### Basic modal

```razor
@using AppsByTAP.BlazorFluentUI.Components.Modal
@using AppsByTAP.BlazorFluentUI.Components.Button

<DefaultButton Text="Open Modal" OnClick="() => showModal = true" />

<Modal @bind-ShowWindow="showModal" Width="480px">
    <Header>Confirmation</Header>
    <Content>
        <p>Are you sure you want to continue?</p>
        <DefaultButton Text="Yes" IsPrimary="true" OnClick="Confirm" />
        <DefaultButton Text="No" OnClick="() => showModal = false" />
    </Content>
</Modal>

@code {
    bool showModal = false;

    void Confirm()
    {
        // perform action
        showModal = false;
    }
}
```

#### Modal without light-dismiss (requires explicit close)

```razor
<Modal @bind-ShowWindow="showModal" CanLightDismiss="false" Width="600px">
    <Header>Unsaved Changes</Header>
    <Content>
        <p>You have unsaved changes. Please save or discard before closing.</p>
        <DefaultButton Text="Save" IsPrimary="true" OnClick="Save" />
        <DefaultButton Text="Discard" OnClick="Discard" />
    </Content>
</Modal>
```

#### Modal without a header

```razor
<Modal @bind-ShowWindow="showModal" ShowHeader="false" Width="300px">
    <Content>
        <Spinner IsLoading="true" Label="Processing…" Size="SpinnerSize.Large" />
    </Content>
</Modal>
```

#### Handling the close event

```razor
<Modal @bind-ShowWindow="showModal" OnClose="OnModalClosed">
    <Header>Edit Profile</Header>
    <Content>
        <!-- form content -->
    </Content>
</Modal>

@code {
    bool showModal = false;

    void OnModalClosed()
    {
        // reset form state or log analytics
    }
}
```

---

## Callout

```
Namespace: AppsByTAP.BlazorFluentUI.Components.Callout
```

A contextual overlay panel, typically used for tooltips, menus, or supplementary information.

### Parameters

| Parameter | Type | Default | Description |
|---|---|---|---|
| `IsOpen` | `bool` | `false` | Controls visibility |
| `ChildContent` | `RenderFragment` | — | Callout body content |

### Example

```razor
@using AppsByTAP.BlazorFluentUI.Components.Callout
@using AppsByTAP.BlazorFluentUI.Components.Button

<DefaultButton Text="Show Info" OnClick="() => showCallout = true" />

<Callout IsOpen="showCallout">
    <p>Here is some contextual information.</p>
    <DefaultButton Text="Close" OnClick="() => showCallout = false" />
</Callout>

@code {
    bool showCallout = false;
}
```

---

## Expander

```
Namespace: AppsByTAP.BlazorFluentUI.Components.Expander
```

A collapsible section with a clickable header and chevron indicator.

### Parameters

| Parameter | Type | Default | Description |
|---|---|---|---|
| `IsOpen` | `bool` | `false` | Expanded or collapsed state; two-way with `@bind-IsOpen` |
| `Header` | `RenderFragment` | — | Header content (always visible) |
| `ChildContent` | `RenderFragment` | — | Collapsible body content |
| `ChevronIsDown` | `bool` | — | Overrides the chevron direction |

### Examples

```razor
@using AppsByTAP.BlazorFluentUI.Components.Expander

<!-- Basic expander -->
<Expander @bind-IsOpen="isExpanded">
    <Header>Advanced Settings</Header>
    <ChildContent>
        <p>These settings are for advanced users only.</p>
    </ChildContent>
</Expander>

<!-- Start expanded -->
<Expander @bind-IsOpen="isOpen">
    <Header>Details</Header>
    <ChildContent>
        <p>Additional detail content shown by default.</p>
    </ChildContent>
</Expander>

@code {
    bool isExpanded = false;
    bool isOpen = true;
}
```

---

## Tabs

```
Namespace: AppsByTAP.BlazorFluentUI.Components.Tabs
```

A tabbed content container. Each tab is a child `Tab` component.

### Tabs Parameters

| Parameter | Type | Default | Description |
|---|---|---|---|
| `Width` | `string` | — | CSS width of the tab container |
| `Height` | `string` | — | CSS height of the tab container |
| `TabContentCanScroll` | `bool` | — | Enables scrolling inside the tab content area |
| `ActivePage` | `string` | — | Name of the initially active tab |

### Tab Parameters

| Parameter | Type | Description |
|---|---|---|
| `Name` | `string` | Tab label shown in the tab strip |
| `ChildContent` | `RenderFragment` | Content rendered when this tab is active |

### Examples

```razor
@using AppsByTAP.BlazorFluentUI.Components.Tabs

<!-- Basic tabs -->
<Tabs Width="600px" Height="400px">
    <Tab Name="General">
        <p>General settings content.</p>
    </Tab>
    <Tab Name="Security">
        <p>Security settings content.</p>
    </Tab>
    <Tab Name="About">
        <p>Application version and license information.</p>
    </Tab>
</Tabs>

<!-- Scrollable content with a specific initial tab -->
<Tabs Width="800px" Height="500px" TabContentCanScroll="true" ActivePage="Security">
    <Tab Name="General">
        <!-- long content -->
    </Tab>
    <Tab Name="Security">
        <p>This tab is shown first.</p>
    </Tab>
</Tabs>
```
