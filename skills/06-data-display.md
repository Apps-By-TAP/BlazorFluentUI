# 06 — Data Display

Covers `DropDown<T>`, `TreeMenu`, `Chip`/`ChipSet`, `Persona`, `Icon`, `Label`, `Spinner`, and `FitText`.

---

## DropDown\<T\>

```
Namespace: AppsByTAP.BlazorFluentUI.Components.DropDown
```

A generic dropdown supporting single-select, multi-select, grouped items, and custom item templates.

### Parameters

| Parameter | Type | Default | Description |
|---|---|---|---|
| `Label` | `string` | — | Label text displayed above the dropdown |
| `ItemsSource` | `List<T>` | — | Collection of items to display |
| `SelectedItem` | `T` | — | Currently selected item; two-way with `@bind-SelectedItem` |
| `SelectedItems` | `IEnumerable<T>` | — | Selected items in multi-select mode; two-way with `@bind-SelectedItems` |
| `IsMultiSelect` | `bool` | `false` | Enables multi-select with checkboxes |
| `Disabled` | `bool` | `false` | Disables the dropdown |
| `Width` | `string` | `"300px"` | CSS width |
| `IsOpen` | `bool` | `false` | Controls open/closed state; two-way with `@bind-IsOpen` |
| `ItemTemplate` | `RenderFragment<T>` | `null` | Custom template for each item |
| `OnClickStopPropagation` | `bool` | `true` | Stops click propagation |
| `ClassName` | `string` | — | Additional CSS class |
| `Style` | `string` | — | Inline CSS style |

### DropDownItem\<T\>

Wrap items in `DropDownItem<T>` to support grouping:

| Property | Type | Description |
|---|---|---|
| `Item` | `T` | The data item |
| `Type` | `DropDownItemType` | `Item` (default) or `Header` — headers are non-selectable group titles |
| `IsSelected` | `bool` | Whether the item is selected (multi-select mode) |

### Examples

#### Single-select with strings

```razor
@using AppsByTAP.BlazorFluentUI.Components.DropDown

<DropDown TItem="string"
          Label="Favorite Color"
          ItemsSource="colors"
          @bind-SelectedItem="selectedColor"
          Width="250px" />

<p>Selected: @selectedColor</p>

@code {
    List<string> colors = new() { "Red", "Green", "Blue", "Yellow" };
    string selectedColor = "";
}
```

#### Multi-select

```razor
<DropDown TItem="string"
          Label="Toppings"
          ItemsSource="toppings"
          IsMultiSelect="true"
          @bind-SelectedItems="selectedToppings"
          Width="300px" />

@code {
    List<string> toppings = new() { "Cheese", "Pepperoni", "Mushrooms", "Onions" };
    IEnumerable<string> selectedToppings = new List<string>();
}
```

#### Custom object type

```razor
<DropDown TItem="Country"
          Label="Country"
          ItemsSource="countries"
          @bind-SelectedItem="selectedCountry"
          Width="300px">
    <ItemTemplate Context="country">
        <span>@country.Flag @country.Name</span>
    </ItemTemplate>
</DropDown>

@code {
    record Country(string Name, string Flag);

    List<Country> countries = new()
    {
        new("United States", "🇺🇸"),
        new("United Kingdom", "🇬🇧"),
        new("Germany", "🇩🇪")
    };
    Country? selectedCountry;
}
```

#### Grouped items with headers

```razor
@using AppsByTAP.BlazorFluentUI.Components.DropDown

<DropDown TItem="DropDownItem<string>"
          Label="Category"
          ItemsSource="groupedItems"
          @bind-SelectedItem="selected"
          Width="280px" />

@code {
    List<DropDownItem<string>> groupedItems = new()
    {
        new() { Item = "Fruits", Type = DropDownItemType.Header },
        new() { Item = "Apple" },
        new() { Item = "Banana" },
        new() { Item = "Vegetables", Type = DropDownItemType.Header },
        new() { Item = "Carrot" },
        new() { Item = "Broccoli" }
    };
    DropDownItem<string>? selected;
}
```

### BlankDropDown (lower-level)

Use `BlankDropDown` when you need full control over the dropdown content:

| Parameter | Type | Default | Description |
|---|---|---|---|
| `Label` | `string` | — | Label text |
| `DisplayInfo` | `RenderFragment` | — | Content shown when collapsed |
| `Content` | `RenderFragment` | — | Content shown when expanded |
| `Disabled` | `bool` | `false` | Disables opening |
| `IsOpen` | `bool` | `false` | Open state; two-way with `@bind-IsOpen` |
| `Width` | `string` | `"300px"` | CSS width |
| `ItemsPanelHeight` | `int` | `-1` | Max panel height in pixels |
| `OnOpen` | `EventCallback` | — | Fires when opened |
| `OnClose` | `EventCallback` | — | Fires when closed |

```razor
<BlankDropDown Label="Custom Panel" @bind-IsOpen="isOpen" Width="350px">
    <DisplayInfo>@selectedLabel</DisplayInfo>
    <Content>
        <!-- any custom content -->
    </Content>
</BlankDropDown>
```

---

## TreeMenu / BranchComponent

```
Namespace: AppsByTAP.BlazorFluentUI.Components.TreeMenu
```

A hierarchical tree menu built from nested `BranchComponent` elements.

### Example

```razor
@using AppsByTAP.BlazorFluentUI.Components.TreeMenu

<TreeMenu>
    <BranchComponent Label="Documents">
        <BranchComponent Label="Work">
            <BranchComponent Label="Reports" />
            <BranchComponent Label="Presentations" />
        </BranchComponent>
        <BranchComponent Label="Personal" />
    </BranchComponent>
    <BranchComponent Label="Pictures" />
    <BranchComponent Label="Downloads" />
</TreeMenu>
```

---

## Chip / ChipSet

```
Namespace: AppsByTAP.BlazorFluentUI.Components.Chip
```

A chip input for tag-like selections and displays.

### ChipSet Parameters

| Parameter | Type | Description |
|---|---|---|
| `ItemsSource` | `List<T>` | Collection of chip items |
| `ChipType` | `ChipType` | Visual style: `Input`, `Compact`, or default |
| `CreateNewItem` | `EventCallback` | Callback to handle creating a new chip item |

### Example

```razor
@using AppsByTAP.BlazorFluentUI.Components.Chip

<ChipSet ItemsSource="tags" ChipType="ChipType.Input" CreateNewItem="AddTag" />

@code {
    List<string> tags = new() { "Blazor", "Fluent UI", ".NET" };

    void AddTag()
    {
        tags.Add("New Tag");
    }
}
```

---

## Persona

```
Namespace: AppsByTAP.BlazorFluentUI.Components.Persona
```

Displays a user's avatar circle (initials-based), full name, and title.

### Parameters

| Parameter | Type | Default | Description |
|---|---|---|---|
| `FirstName` | `string` | — | User's first name |
| `LastName` | `string` | — | User's last name |
| `Title` | `string` | — | User's title or role |
| `Size` | `int` | — | Avatar size in pixels |
| `BorderRadius` | `string` | — | CSS border radius (e.g. `"50%"` for a circle) |
| `BackgroundColor` | `string` | — | Background color of the avatar circle |
| `Initials` | `string` | — | Custom initials (auto-generated from name if omitted) |

### Example

```razor
@using AppsByTAP.BlazorFluentUI.Components.Persona

<Persona FirstName="Jane" LastName="Doe" Title="Software Engineer" Size="48" />

<!-- Custom initials and color -->
<Persona FirstName="John"
         LastName="Smith"
         Title="Manager"
         Size="64"
         BackgroundColor="#0078d4"
         Initials="JS" />
```

---

## Icon

```
Namespace: AppsByTAP.BlazorFluentUI.Components.Icon
```

Renders an icon from the Office Fabric icon set. Requires the `fabric-icons-inline.css` stylesheet.

### Parameters

| Parameter | Type | Default | Description |
|---|---|---|---|
| `IconType` | `IconTypes` | `None` | The icon to render |

### Commonly used icon values

```
IconTypes.Add              IconTypes.Delete          IconTypes.Edit
IconTypes.Save             IconTypes.Search          IconTypes.Settings
IconTypes.CheckMark        IconTypes.Cancel          IconTypes.Clear
IconTypes.Mail             IconTypes.Calendar        IconTypes.People
IconTypes.Home             IconTypes.Download        IconTypes.Upload
IconTypes.ChevronDown      IconTypes.ChevronUp       IconTypes.ChevronLeft
IconTypes.ChevronRight     IconTypes.Info            IconTypes.Warning
IconTypes.Error            IconTypes.Star            IconTypes.Filter
IconTypes.Sort             IconTypes.Copy            IconTypes.Paste
IconTypes.Refresh          IconTypes.Forward         IconTypes.Back
```

### Example

```razor
@using AppsByTAP.BlazorFluentUI.Components.Icon

<Icon IconType="IconTypes.CheckMark" />
<Icon IconType="IconTypes.Settings" />
<Icon IconType="IconTypes.Mail" />
```

---

## Label

```
Namespace: AppsByTAP.BlazorFluentUI.Components.Label
```

A simple themed text label.

### Parameters

| Parameter | Type | Description |
|---|---|---|
| `Text` | `string` | Label text |

### Example

```razor
@using AppsByTAP.BlazorFluentUI.Components.Label

<Label Text="First Name" />
<Label Text="Email Address" />
```

---

## Spinner

```
Namespace: AppsByTAP.BlazorFluentUI.Components.Spinner
```

A loading indicator with configurable size and label position.

### Parameters

| Parameter | Type | Default | Description |
|---|---|---|---|
| `IsLoading` | `bool` | `false` | Shows or hides the spinner |
| `Size` | `SpinnerSize` | — | `xSmall`, `Small`, `Medium`, or `Large` |
| `Position` | `SpinnerLabelPosition` | — | Label position: `Top`, `Bottom`, `Left`, or `Right` |
| `Label` | `string` | — | Loading text displayed next to the spinner |

### Examples

```razor
@using AppsByTAP.BlazorFluentUI.Components.Spinner

<Spinner IsLoading="true" Size="SpinnerSize.Large" Label="Loading data…" Position="SpinnerLabelPosition.Bottom" />

<Spinner IsLoading="isLoading" Size="SpinnerSize.Small" Label="Saving…" Position="SpinnerLabelPosition.Right" />

@code {
    bool isLoading = false;
}
```

---

## FitText

```
Namespace: AppsByTAP.BlazorFluentUI.Components.FitText
```

Automatically scales its text content to fit inside the parent container.

### Example

```razor
@using AppsByTAP.BlazorFluentUI.Components.FitText

<div style="width: 200px; height: 40px;">
    <FitText>This text shrinks to fit the container width.</FitText>
</div>
```
