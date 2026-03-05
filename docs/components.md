# Components Reference

Complete reference for every component in the BlazorFluentUI library. Each section lists the component's parameters and provides a usage example.

---

## Button

Multiple button variants share a common base. All buttons support the following base parameters:

| Parameter | Type | Default | Description |
|---|---|---|---|
| `Text` | `string` | — | Button label text |
| `Icon` | `IconTypes` | `None` | Icon displayed alongside the text |
| `IsPrimary` | `bool` | `false` | Renders the button with the primary theme color |
| `Disabled` | `bool` | `false` | Disables the button |
| `IsBusy` | `bool` | `false` | Replaces the text with a tiny spinner |
| `OnClick` | `EventCallback` | — | Click handler |
| `OnClickStopPropagation` | `bool` | `false` | Stops click event propagation |
| `ClassName` | `string` | — | Additional CSS class |
| `Style` | `string` | — | Inline CSS style |
| `ID` | `string` | — | HTML element id |

### Variants

| Component | Description |
|---|---|
| `DefaultButton` | Standard button |
| `CompoundButton` | Button with primary and secondary text lines |
| `IconButton` | Icon-only button without text |
| `SplitButton` | Button with a separate dropdown action |
| `NavButton` | Navigation-style button |
| `HyperLinkButton` | Renders as a hyperlink-style button |
| `PostButton` | Post-action button |
| `TemplateButton` | Button that accepts a `RenderFragment` for custom content |

`CompoundButton` (via `BaseButton`) adds:

| Parameter | Type | Description |
|---|---|---|
| `SecondaryText` | `string` | Secondary descriptive text displayed below the primary text |

### Example

```razor
@using AppsByTAP.BlazorFluentUI.Components.Button

<DefaultButton Text="Save" IsPrimary="true" OnClick="Save" Icon="IconTypes.Save" />
<DefaultButton Text="Cancel" OnClick="Cancel" />
<IconButton Icon="IconTypes.Delete" OnClick="Delete" />
<CompoundButton Text="Send Email" SecondaryText="Sends a confirmation email to the user" OnClick="Send" />
```

---

## TextField

Single-line and multi-line text input with optional character limit, input mask, and type control.

| Parameter | Type | Default | Description |
|---|---|---|---|
| `ID` | `string` | — | HTML element id (required when using `Mask`) |
| `Label` | `string` | — | Label text displayed above the input |
| `Value` | `string` | `""` | Current value (supports two-way binding with `@bind-Value`) |
| `PlaceHolder` | `string` | — | Placeholder text |
| `IsMultiLine` | `bool` | `false` | Renders a `<textarea>` instead of an `<input>` |
| `MultiLineCanResize` | `bool` | `true` | Allows resizing the textarea |
| `Width` | `string` | — | CSS width of the input |
| `MaxWidth` | `string` | — | CSS max-width of the input |
| `Height` | `int` | `-1` | Height in pixels (`-1` for default) |
| `CharacterLimit` | `int` | `0` | Maximum character count; displays remaining characters when set |
| `Type` | `TextFieldType` | `Text` | Input type — `Text`, `Email`, `Password`, `Number`, etc. |
| `Mask` | `string` | — | Regex-based input mask (requires `ID` to be set) |
| `DisplayBorder` | `bool` | `true` | Show or hide the input border |
| `Step` | `double?` | `null` | Step value for number inputs |
| `Class` | `string` | — | Additional CSS class |
| `Style` | `string` | — | Inline CSS style |

### Example

```razor
@using AppsByTAP.BlazorFluentUI.Components.TextField

<TextField Label="Email" @bind-Value="email" Type="TextFieldType.Email" PlaceHolder="user@example.com" />
<TextField Label="Bio" @bind-Value="bio" IsMultiLine="true" CharacterLimit="500" Width="100%" />
<TextField Label="Phone" @bind-Value="phone" ID="phoneInput" Mask="(000) 000-0000" />
```

---

## DropDown

Generic dropdown supporting single-select, multi-select, grouped items, and custom item templates.

| Parameter | Type | Default | Description |
|---|---|---|---|
| `Label` | `string` | — | Label text displayed above the dropdown |
| `ItemsSource` | `List<T>` | — | Collection of items to display |
| `SelectedItem` | `T` | — | Currently selected item (two-way with `@bind-SelectedItem`) |
| `SelectedItems` | `IEnumerable<T>` | — | Selected items in multi-select mode (two-way with `@bind-SelectedItems`) |
| `IsMultiSelect` | `bool` | `false` | Enables multi-select with checkboxes |
| `Disabled` | `bool` | `false` | Disables the dropdown |
| `Width` | `string` | `"300px"` | CSS width |
| `IsOpen` | `bool` | `false` | Controls the dropdown open state |
| `ItemTemplate` | `RenderFragment<T>` | `null` | Custom template for rendering each item |
| `OnClickStopPropagation` | `bool` | `true` | Stops click event propagation |
| `ClassName` | `string` | — | Additional CSS class |
| `Style` | `string` | — | Inline CSS style |

### BlankDropDown

A lower-level dropdown container used internally by `DropDown<T>`. Useful when you need full control over the dropdown content.

| Parameter | Type | Default | Description |
|---|---|---|---|
| `Label` | `string` | — | Label text |
| `DisplayInfo` | `RenderFragment` | — | Content shown in the collapsed display area |
| `Content` | `RenderFragment` | — | Content shown in the expanded panel |
| `Disabled` | `bool` | `false` | Disables opening |
| `IsOpen` | `bool` | `false` | Open state (two-way with `@bind-IsOpen`) |
| `Width` | `string` | `"300px"` | CSS width |
| `ItemsPanelHeight` | `int` | `-1` | Max height of the items panel in pixels |
| `OnOpen` | `EventCallback` | — | Fired when opened |
| `OnClose` | `EventCallback` | — | Fired when closed |

### DropDownItem&lt;T&gt;

Wrapper object for dropdown items. Supports grouping via `DropDownItemType`.

| Property | Type | Description |
|---|---|---|
| `Item` | `T` | The data item |
| `Type` | `DropDownItemType` | `Item` or `Header` — headers are rendered as non-selectable group titles |
| `IsSelected` | `bool` | Whether the item is selected (used in multi-select mode) |

### Example

```razor
@using AppsByTAP.BlazorFluentUI.Components.DropDown

<DropDown TItem="string"
          Label="Favorite Color"
          ItemsSource="colors"
          @bind-SelectedItem="selectedColor" />

<DropDown TItem="string"
          Label="Toppings"
          ItemsSource="toppings"
          IsMultiSelect="true"
          @bind-SelectedItems="selectedToppings" />

@code {
    List<string> colors = new() { "Red", "Green", "Blue" };
    string selectedColor;

    List<string> toppings = new() { "Cheese", "Pepperoni", "Mushrooms" };
    IEnumerable<string> selectedToppings = new List<string>();
}
```

---

## CheckBox

A checkbox with a configurable label position.

| Parameter | Type | Default | Description |
|---|---|---|---|
| `Label` | `string` | — | Checkbox label |
| `IsChecked` | `bool` | `false` | Checked state (two-way with `@bind-IsChecked`) |
| `OnChanged` | `EventCallback<CheckBoxChangedArgs>` | — | Fires when the checked state changes |
| `LabelSide` | `BoxSide` | `Start` | Label position — `BoxSide.Start` (left) or `BoxSide.End` (right) |

### Example

```razor
@using AppsByTAP.BlazorFluentUI.Components.CheckBox

<CheckBox Label="I agree to the terms" @bind-IsChecked="agreed" />
<CheckBox Label="Remember me" LabelSide="BoxSide.End" @bind-IsChecked="rememberMe" />
```

---

## CheckboxGroup

Groups multiple checkboxes in a horizontal or vertical layout. Can optionally render as toggle switches.

| Parameter | Type | Default | Description |
|---|---|---|---|
| `Direction` | `GroupDirection` | `Vertical` | `Horizontal` or `Vertical` layout |
| `UseToggleSwitches` | `bool` | `false` | Renders toggles instead of checkboxes |
| `ChildContent` | `RenderFragment` | — | Checkbox or toggle components |

### Example

```razor
@using AppsByTAP.BlazorFluentUI.Components.CheckboxGroup
@using AppsByTAP.BlazorFluentUI.Components.CheckBox

<CheckboxGroup Direction="GroupDirection.Horizontal">
    <CheckBox Label="Option A" @bind-IsChecked="optA" />
    <CheckBox Label="Option B" @bind-IsChecked="optB" />
    <CheckBox Label="Option C" @bind-IsChecked="optC" />
</CheckboxGroup>
```

---

## ChoiceGroup

Radio button group for single-selection among a set of choices.

| Parameter | Type | Description |
|---|---|---|
| `ChildContent` | `RenderFragment` | Contains `Choice` child components |

### Choice

| Parameter | Type | Description |
|---|---|---|
| `Label` | `string` | Choice label |
| `IsSelected` | `bool` | Whether this choice is selected |

### Example

```razor
@using AppsByTAP.BlazorFluentUI.Components.ChoiceGroup

<ChoiceGroup>
    <Choice Label="Option 1" />
    <Choice Label="Option 2" />
    <Choice Label="Option 3" />
</ChoiceGroup>
```

---

## Toggle

A binary toggle switch.

| Parameter | Type | Default | Description |
|---|---|---|---|
| `Label` | `string` | — | Toggle label text |
| `IsChecked` | `bool` | `false` | Checked state (two-way with `@bind-IsChecked`) |
| `LabelIsInline` | `bool` | `false` | Renders the label on the same line as the toggle |

### Example

```razor
@using AppsByTAP.BlazorFluentUI.Components.Toggle

<Toggle Label="Enable notifications" @bind-IsChecked="notificationsEnabled" />
<Toggle Label="Dark mode" @bind-IsChecked="isDarkMode" LabelIsInline="true" />
```

---

## SpinButton

Numeric input with increment and decrement buttons.

| Parameter | Type | Default | Description |
|---|---|---|---|
| `Label` | `string` | — | Label text |
| `Type` | `SpinButtonType` | `Integer` | `Integer` or `Decimal` |
| `Suffix` | `string` | — | Unit suffix displayed after the value (e.g. `"px"`, `"%"`) |
| `RoundingPlaces` | `int` | — | Number of decimal places for rounding |

### Example

```razor
@using AppsByTAP.BlazorFluentUI.Components.SpinButton

<SpinButton Label="Quantity" Type="SpinButtonType.Integer" />
<SpinButton Label="Opacity" Type="SpinButtonType.Decimal" Suffix="%" RoundingPlaces="2" />
```

---

## Modal

A dialog window with header, content, and light-dismiss support.

| Parameter | Type | Default | Description |
|---|---|---|---|
| `ShowWindow` | `bool` | `false` | Controls visibility (two-way with `@bind-ShowWindow`) |
| `Header` | `RenderFragment` | — | Content rendered in the modal header |
| `Content` | `RenderFragment` | — | Content rendered in the modal body |
| `Width` | `string` | `"fit-content"` | CSS width of the modal |
| `ShowHeader` | `bool` | `true` | Shows or hides the header bar and close button |
| `CanLightDismiss` | `bool` | `true` | Allows closing the modal by clicking the backdrop |
| `OnClose` | `EventCallback` | — | Fires when the modal is closed |

### Example

```razor
@using AppsByTAP.BlazorFluentUI.Components.Modal
@using AppsByTAP.BlazorFluentUI.Components.Button

<DefaultButton Text="Open Modal" OnClick="() => showModal = true" />

<Modal @bind-ShowWindow="showModal" Width="500px">
    <Header>Confirmation</Header>
    <Content>
        <p>Are you sure you want to continue?</p>
        <DefaultButton Text="Yes" IsPrimary="true" OnClick="() => showModal = false" />
        <DefaultButton Text="No" OnClick="() => showModal = false" />
    </Content>
</Modal>

@code {
    bool showModal = false;
}
```

---

## Callout

An overlay panel for contextual information or actions.

| Parameter | Type | Default | Description |
|---|---|---|---|
| `IsOpen` | `bool` | `false` | Controls visibility |
| `ChildContent` | `RenderFragment` | — | Callout content |

### Example

```razor
@using AppsByTAP.BlazorFluentUI.Components.Callout

<Callout IsOpen="showCallout">
    <p>Additional information here.</p>
</Callout>
```

---

## Expander

A collapsible section with a header and chevron indicator.

| Parameter | Type | Default | Description |
|---|---|---|---|
| `IsOpen` | `bool` | `false` | Expanded or collapsed state |
| `Header` | `RenderFragment` | — | Header content |
| `ChildContent` | `RenderFragment` | — | Collapsible body content |
| `ChevronIsDown` | `bool` | — | Controls chevron direction |

### Example

```razor
@using AppsByTAP.BlazorFluentUI.Components.Expander

<Expander @bind-IsOpen="isExpanded">
    <Header>Advanced Settings</Header>
    <ChildContent>
        <p>Advanced configuration options go here.</p>
    </ChildContent>
</Expander>

@code {
    bool isExpanded = false;
}
```

---

## Tabs

A tabbed content container. Each tab is defined with a `Tab` child component.

| Parameter | Type | Default | Description |
|---|---|---|---|
| `Width` | `string` | — | CSS width of the tab container |
| `Height` | `string` | — | CSS height of the tab container |
| `TabContentCanScroll` | `bool` | — | Enables scrolling in the tab content area |
| `ActivePage` | `string` | — | Name of the currently active tab |

### Tab

| Parameter | Type | Description |
|---|---|---|
| `Name` | `string` | Tab label |
| `ChildContent` | `RenderFragment` | Tab panel content |

### Example

```razor
@using AppsByTAP.BlazorFluentUI.Components.Tabs

<Tabs Width="600px" Height="400px">
    <Tab Name="General">
        <p>General settings content.</p>
    </Tab>
    <Tab Name="Security">
        <p>Security settings content.</p>
    </Tab>
    <Tab Name="About">
        <p>Application information.</p>
    </Tab>
</Tabs>
```

---

## TreeMenu

A hierarchical menu built from `BranchComponent` elements.

### Example

```razor
@using AppsByTAP.BlazorFluentUI.Components.TreeMenu

<TreeMenu>
    <BranchComponent Label="Documents">
        <BranchComponent Label="Work" />
        <BranchComponent Label="Personal" />
    </BranchComponent>
    <BranchComponent Label="Pictures" />
</TreeMenu>
```

---

## Icon

Renders an icon from the Office Fabric icon set.

| Parameter | Type | Default | Description |
|---|---|---|---|
| `IconType` | `IconTypes` | `None` | The icon to display |

Available icon types include `CheckMark`, `Delete`, `Add`, `Search`, `Settings`, `Mail`, `Calendar`, `People`, `Bank`, `ChevronDown`, `ChevronUp`, `ChevronLeft`, `ChevronRight`, and many more. See the `IconTypes` enum for the full list.

### Example

```razor
@using AppsByTAP.BlazorFluentUI.Components.Icon

<Icon IconType="IconTypes.CheckMark" />
<Icon IconType="IconTypes.Settings" />
<Icon IconType="IconTypes.Mail" />
```

---

## Label

A simple text label.

| Parameter | Type | Description |
|---|---|---|
| `Text` | `string` | Label text |

### Example

```razor
@using AppsByTAP.BlazorFluentUI.Components.Label

<Label Text="First Name" />
```

---

## Persona

Displays a user's avatar, name, and title. The avatar shows the user's initials by default.

| Parameter | Type | Default | Description |
|---|---|---|---|
| `FirstName` | `string` | — | User's first name |
| `LastName` | `string` | — | User's last name |
| `Title` | `string` | — | User's title or role |
| `Size` | `int` | — | Avatar size in pixels |
| `BorderRadius` | `string` | — | CSS border radius for the avatar |
| `BackgroundColor` | `string` | — | Background color of the avatar circle |
| `Initials` | `string` | — | Custom initials (auto-generated from name if not set) |

### Example

```razor
@using AppsByTAP.BlazorFluentUI.Components.Persona

<Persona FirstName="Jane" LastName="Doe" Title="Software Engineer" Size="48" />
```

---

## Spinner

A loading indicator with configurable size and label position.

| Parameter | Type | Default | Description |
|---|---|---|---|
| `IsLoading` | `bool` | `false` | Controls visibility |
| `Size` | `SpinnerSize` | — | `xSmall`, `Small`, `Medium`, or `Large` |
| `Position` | `SpinnerLabelPosition` | — | Label position: `Top`, `Bottom`, `Left`, or `Right` |
| `Label` | `string` | — | Loading text displayed near the spinner |

### Example

```razor
@using AppsByTAP.BlazorFluentUI.Components.Spinner

<Spinner IsLoading="true" Size="SpinnerSize.Large" Label="Loading data..." Position="SpinnerLabelPosition.Bottom" />
```

---

## Chip / ChipSet

A chip input for tag-like selections.

### ChipSet

| Parameter | Type | Description |
|---|---|---|
| `ItemsSource` | `List<T>` | Collection of chip items |
| `ChipType` | `ChipType` | Visual type: `Input`, `Compact`, or default |
| `CreateNewItem` | `EventCallback` | Callback to create new chip items |

### Example

```razor
@using AppsByTAP.BlazorFluentUI.Components.Chip

<ChipSet ItemsSource="tags" ChipType="ChipType.Input" />

@code {
    List<string> tags = new() { "Blazor", "Fluent UI", ".NET" };
}
```

---

## FloatingActionButton

A floating action button, typically used for a primary screen action.

### Example

```razor
@using AppsByTAP.BlazorFluentUI.Components.FloatingActionButton

<FloatingActionButton OnClick="CreateNew" Icon="IconTypes.Add" />
```

---

## BottomNavigationBar

A mobile-style bottom navigation bar containing `NavigationItem` entries.

### Example

```razor
@using AppsByTAP.BlazorFluentUI.Components.BottomNavigationBar

<BottomNavigationBar>
    <NavigationItem Label="Home" Icon="IconTypes.Home" />
    <NavigationItem Label="Search" Icon="IconTypes.Search" />
    <NavigationItem Label="Profile" Icon="IconTypes.People" />
</BottomNavigationBar>
```

---

## FitText

Automatically scales text to fit within its container.

### Example

```razor
@using AppsByTAP.BlazorFluentUI.Components.FitText

<div style="width: 200px;">
    <FitText>This text will shrink to fit.</FitText>
</div>
```

---

## LightDismiss

A backdrop overlay used internally by `Modal` and `BlankDropDown`. Can be used directly for custom overlay scenarios.

| Parameter | Type | Default | Description |
|---|---|---|---|
| `IsOpen` | `bool` | `false` | Visibility state (two-way with `@bind-IsOpen`) |
| `OnClose` | `EventCallback` | — | Fires when the backdrop is clicked |
| `Layer` | `int` | — | CSS z-index for layering |

---

## Form Validation

The `Forms/` directory includes a custom `TextField` with validation support and a `ValidationInput` component designed for use within Blazor's `EditForm`.

### ValidationInput

Wraps a `TextField` and connects it to the `EditContext` for validation. Displays validation messages automatically.

### Example

```razor
@using AppsByTAP.BlazorFluentUI.Components.Forms

<EditForm Model="formModel" OnValidSubmit="HandleSubmit">
    <DataAnnotationsValidator />

    <ValidationInput Label="Email" @bind-Value="formModel.Email" />

    <button type="submit">Submit</button>
</EditForm>

@code {
    FormModel formModel = new();

    void HandleSubmit() { /* ... */ }
}
```
