# 07 — Navigation

Covers `BottomNavigationBar` / `NavigationItem` and `FloatingActionButton`.

---

## BottomNavigationBar

```
Namespace: AppsByTAP.BlazorFluentUI.Components.BottomNavigationBar
```

A mobile-style bottom navigation bar containing `NavigationItem` entries. Typically placed at the bottom of the page layout.

### NavigationItem Parameters

| Parameter | Type | Description |
|---|---|---|
| `Label` | `string` | Text label displayed under the icon |
| `Icon` | `IconTypes` | Icon displayed above the label |

### Example

```razor
@using AppsByTAP.BlazorFluentUI.Components.BottomNavigationBar
@using AppsByTAP.BlazorFluentUI.Components.Icon

<BottomNavigationBar>
    <NavigationItem Label="Home" Icon="IconTypes.Home" />
    <NavigationItem Label="Search" Icon="IconTypes.Search" />
    <NavigationItem Label="Messages" Icon="IconTypes.Mail" />
    <NavigationItem Label="Profile" Icon="IconTypes.People" />
</BottomNavigationBar>
```

### Typical placement in a layout

```razor
@* MainLayout.razor *@
<div class="layout">
    <main>
        @Body
    </main>

    <BottomNavigationBar>
        <NavigationItem Label="Home" Icon="IconTypes.Home" />
        <NavigationItem Label="Settings" Icon="IconTypes.Settings" />
    </BottomNavigationBar>
</div>
```

---

## FloatingActionButton

```
Namespace: AppsByTAP.BlazorFluentUI.Components.FloatingActionButton
```

A floating action button (FAB) — typically used for the primary action on a screen, rendered in a fixed position.

### Parameters

The `FloatingActionButton` shares the base button parameters:

| Parameter | Type | Default | Description |
|---|---|---|---|
| `Icon` | `IconTypes` | — | Icon displayed inside the FAB |
| `OnClick` | `EventCallback` | — | Click handler |
| `Disabled` | `bool` | `false` | Disables the FAB |
| `IsBusy` | `bool` | `false` | Shows a spinner instead of the icon |

### Example

```razor
@using AppsByTAP.BlazorFluentUI.Components.FloatingActionButton
@using AppsByTAP.BlazorFluentUI.Components.Icon

<!-- Add new item FAB -->
<FloatingActionButton Icon="IconTypes.Add" OnClick="CreateNew" />

<!-- Delete FAB (disabled state) -->
<FloatingActionButton Icon="IconTypes.Delete" OnClick="DeleteSelected" Disabled="@(selectedItems.Count == 0)" />

@code {
    List<string> selectedItems = new();

    void CreateNew()
    {
        // open create dialog
    }

    void DeleteSelected()
    {
        // delete selected items
    }
}
```

### Positioning the FAB

Wrap the FAB in a fixed-position container to pin it to a corner:

```razor
<div style="position: fixed; bottom: 24px; right: 24px; z-index: 100;">
    <FloatingActionButton Icon="IconTypes.Add" OnClick="CreateNew" />
</div>
```
