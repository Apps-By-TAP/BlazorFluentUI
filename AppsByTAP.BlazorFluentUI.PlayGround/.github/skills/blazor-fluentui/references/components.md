# Component Catalog — AppsByTAP.BlazorFluentUI

Detailed API reference for every component in the library.

---

## Button Components

**Namespace:** `AppsByTAP.BlazorFluentUI.Components.Button`

All button components inherit from `ButtonBaseParameters` which extends `BaseComponentViewModel`.

### Shared Button Parameters (ButtonBaseParameters)

| Parameter | Type | Default | Description |
|-----------|------|---------|-------------|
| `Text` | `string` | — | Button label text |
| `IsPrimary` | `bool` | `false` | Primary (filled) vs secondary (outlined) style |
| `OnClick` | `EventCallback<MouseEventArgs>` | — | Click handler |
| `OnClickStopPropagation` | `bool` | `false` | Prevent click from bubbling to parent |
| `Icon` | `IconTypes` | — | Icon displayed before text |
| `Disabled` | `bool` | `false` | Disable the button |
| `ShowIsBusy` | `bool` | `false` | Show a loading spinner in the button |
| `SecondaryText` | `string` | — | Subtitle text (CompoundButton only) |

### DefaultButton

Standard Fluent UI button.

```razor
<DefaultButton Text="Click Me" IsPrimary="true" OnClick="HandleClick" />
<DefaultButton Text="With Icon" Icon="IconTypes.CheckMark" OnClick="HandleClick" />
<DefaultButton Text="Disabled" Disabled="true" />
<DefaultButton Text="Busy" ShowIsBusy="true" OnClick="HandleClick" />
```

### CompoundButton

Button with primary and secondary (subtitle) text.

```razor
<CompoundButton Text="Primary Text" SecondaryText="Secondary description" IsPrimary="true" OnClick="HandleClick" />
```

### IconButton

Shows only an icon, no text.

```razor
<IconButton Icon="IconTypes.Delete" OnClick="HandleDelete" />
<IconButton Icon="IconTypes.Edit" Disabled="true" />
```

### SplitButton

Button with a dropdown for additional options.

```razor
<SplitButton TItem="string" Width="200px"
    ItemsSource="options" @bind-SelectedItem="selectedOption" OnClick="HandleClick" />

@code {
    private List<string> options = new() { "Option A", "Option B", "Option C" };
    private string selectedOption = "";
}
```

### HyperLinkButton

Button styled as a text hyperlink.

```razor
<HyperLinkButton Text="Learn more" OnClick="HandleClick" />
```

### NavButton

Navigation-oriented button.

```razor
<NavButton Text="Go To Settings" OnClick="Navigate" />
```

### PostButton

Button for POST-style actions.

```razor
<PostButton Text="Submit" OnClick="HandleSubmit" />
```

### TemplateButton

Fully templated button with custom child content.

```razor
<TemplateButton OnClick="HandleClick">
    <div style="display:flex;align-items:center;">
        <Icon IconType="IconTypes.Mail" />
        <span>Custom Content</span>
    </div>
</TemplateButton>
```

---

## TextField

**Namespace:** `AppsByTAP.BlazorFluentUI.Components.TextField`

| Parameter | Type | Default | Description |
|-----------|------|---------|-------------|
| `Value` | `string` | — | Current text value |
| `ValueChanged` | `EventCallback<string>` | — | Two-way binding callback |
| `Label` | `string` | — | Label above the field |
| `IsMultiLine` | `bool` | `false` | Render as textarea |
| `Width` | `string` | — | CSS width (e.g., `"300px"`, `"100%"`) |
| `MaxWidth` | `string` | — | CSS max-width |
| `Height` | `string` | — | CSS height (multiline) |
| `PlaceHolder` | `string` | — | Placeholder text |
| `DisplayBorder` | `bool` | `true` | Show border |
| `Mask` | `string` | — | Input mask pattern (uses IMask.js). `0` = digit, `a` = letter |
| `Type` | `TextFieldType` | `text` | Input type: `text`, `number`, `tel`, `email`, `password` |
| `CharacterLimit` | `int` | — | Max character count (shows counter) |
| `Step` | `string` | — | Step for number type |
| `OnBlur` | `EventCallback<FocusEventArgs>` | — | Fires when field loses focus |
| `Class` | `string` | — | CSS class |

```razor
<!-- Basic text field -->
<TextField Label="Name" @bind-Value="name" PlaceHolder="Enter name" />

<!-- Phone mask -->
<TextField ID="phone" Mask="(000)000-0000" />

<!-- Password -->
<TextField Type="TextFieldType.password" Label="Password" @bind-Value="password" />

<!-- Multi-line with character limit -->
<TextField Label="Notes" IsMultiLine="true" PlaceHolder="Write here" CharacterLimit="500" />

<!-- Controlled width -->
<TextField Label="Code" Width="100px" MaxWidth="200px" />
```

---

## DropDown

**Namespace:** `AppsByTAP.BlazorFluentUI.Components.DropDown`

### DropDown\<T\>

| Parameter | Type | Default | Description |
|-----------|------|---------|-------------|
| `ItemsSource` | `IList<T>` | — | Items to display |
| `SelectedItem` | `T` | — | Currently selected item |
| `SelectedItemChanged` | `EventCallback<T>` | — | Selection changed callback |
| `SelectedItems` | `IList<T>` | — | Multi-select selected items |
| `SelectedItemsChanged` | `EventCallback<IList<T>>` | — | Multi-select callback |
| `Label` | `string` | — | Label above dropdown |
| `Width` | `string` | `"300px"` | CSS width |
| `IsMultiSelect` | `bool` | `false` | Enable multi-select with checkboxes |
| `IsOpen` | `bool` | `false` | Programmatic open/close |
| `Disabled` | `bool` | `false` | Disable the dropdown |
| `ItemTemplate` | `RenderFragment<T>` | — | Custom item rendering |

```razor
<!-- Simple list of strings -->
<DropDown ItemsSource="fruits" @bind-SelectedItem="selectedFruit" Label="Pick a fruit" />

<!-- With DropDownItem for headers/groups -->
<DropDown ItemsSource="groupedItems" @bind-SelectedItem="selected" Label="Grouped" Width="200px" />

<!-- Multi-select -->
<DropDown ItemsSource="options" @bind-SelectedItem="selected"
    IsMultiSelect="true" @bind-SelectedItems="selectedList" />

<!-- Custom item template -->
<DropDown TItem="Person" ItemsSource="people" @bind-SelectedItem="selectedPerson">
    <ItemTemplate>
        <div>
            <strong>@context.Name</strong>
            <small>@context.Role</small>
        </div>
    </ItemTemplate>
</DropDown>
```

#### DropDownItem\<T\>

Wrapper for items with header support:

```csharp
List<DropDownItem<string>> items = new()
{
    new DropDownItem<string>("Fruits", DropDownItemType.Header),
    new DropDownItem<string>("Apple", DropDownItemType.Item),
    new DropDownItem<string>("Banana", DropDownItemType.Item),
    new DropDownItem<string>("Vegetables", DropDownItemType.Header),
    new DropDownItem<string>("Carrot", DropDownItemType.Item),
};
```

### BlankDropDown

Unstyled dropdown for fully custom rendering.

| Parameter | Type | Description |
|-----------|------|-------------|
| `DisplayInfo` | `RenderFragment` | What shows when closed |
| `Content` | `RenderFragment` | Dropdown content |
| `Disabled` | `bool` | Disable |
| `Width` | `string` | CSS width |

```razor
<BlankDropDown>
    <DisplayInfo>
        <span>Select something</span>
    </DisplayInfo>
    <Content>
        <ul>
            <li @onclick="() => Choose(1)">Option 1</li>
            <li @onclick="() => Choose(2)">Option 2</li>
        </ul>
    </Content>
</BlankDropDown>
```

---

## CheckBox

**Namespace:** `AppsByTAP.BlazorFluentUI.Components.CheckBox`

| Parameter | Type | Default | Description |
|-----------|------|---------|-------------|
| `Label` | `string` | — | Label text |
| `IsChecked` | `bool` | `false` | Checked state (supports `@bind-IsChecked`) |
| `BoxSide` | `BoxSide` | `Start` | `Start` = checkbox left, `End` = checkbox right |
| `OnChanged` | `EventCallback<CheckBoxChangedArgs>` | — | Change event with args |

```razor
<CheckBox Label="Accept terms" @bind-IsChecked="accepted" />
<CheckBox Label="Right-aligned" BoxSide="BoxSide.End" @bind-IsChecked="flag" />
```

---

## CheckboxGroup

**Namespace:** `AppsByTAP.BlazorFluentUI.Components.CheckboxGroup`

| Parameter | Type | Default | Description |
|-----------|------|---------|-------------|
| `ItemsSource` | `IList<T>` | — | Available items |
| `SelectedItems` | `IList<T>` | — | Selected items (supports `@bind-SelectedItems`) |
| `UseToggleSwitches` | `bool` | `false` | Render as toggle switches instead of checkboxes |
| `GroupDirection` | `GroupDirection` | `Vertical` | `Vertical` or `Horizontal` layout |
| `WrapItems` | `bool` | `false` | Wrap items when horizontal |
| `Label` | `string` | — | Group label |

```razor
<CheckboxGroup ItemsSource="options" @bind-SelectedItems="selected"
    Label="Choose toppings" GroupDirection="GroupDirection.Horizontal" />

<CheckboxGroup ItemsSource="prefs" @bind-SelectedItems="selectedPrefs"
    UseToggleSwitches="true" Label="Preferences" />
```

---

## ChoiceGroup

**Namespace:** `AppsByTAP.BlazorFluentUI.Components.ChoiceGroup`

Radio-button-style single-select group. Generic `ChoiceGroup<T>` with `Choice<T>` children.

| Parameter | Type | Default | Description |
|-----------|------|---------|-------------|
| `SelectedItem` | `T` | — | Currently selected value |
| `SelectedItemChanged` | `EventCallback<T>` | — | Selection callback |
| `Label` | `string` | — | Group label |
| `GroupDirection` | `GroupDirection` | `Vertical` | Layout direction |
| `Disabled` | `bool` | `false` | Disable all choices |

```razor
<ChoiceGroup T="string" @bind-SelectedItem="selectedSize" Label="Size">
    <Choice Value="@("S")">Small</Choice>
    <Choice Value="@("M")">Medium</Choice>
    <Choice Value="@("L")">Large</Choice>
</ChoiceGroup>
```

---

## Toggle

**Namespace:** `AppsByTAP.BlazorFluentUI.Components.Toggle`

| Parameter | Type | Default | Description |
|-----------|------|---------|-------------|
| `Label` | `string` | — | Label text |
| `IsChecked` | `bool` | `false` | Toggle state (supports `@bind-IsChecked`) |
| `LabelIsInline` | `bool` | `false` | Show label beside toggle instead of above |

```razor
<Toggle @bind-IsChecked="enabled" />
<Toggle Label="Notifications" @bind-IsChecked="notificationsOn" />
<Toggle Label="Dark Mode" LabelIsInline="true" @bind-IsChecked="isDark" />
```

NOTE: Use fully-qualified `<AppsByTAP.BlazorFluentUI.Components.Toggle.Toggle />` if there's a naming conflict.

---

## SpinButton

**Namespace:** `AppsByTAP.BlazorFluentUI.Components.SpinButton`

| Parameter | Type | Default | Description |
|-----------|------|---------|-------------|
| `Type` | `SpinButtonType` | `Whole` | `Whole` (int) or `Decimal` |
| `WholeValue` | `int` | — | Integer value (when Type=Whole) |
| `DecimalValue` | `decimal` | — | Decimal value (when Type=Decimal) |
| `MinValue` | `decimal` | — | Minimum allowed value |
| `MaxValue` | `decimal` | — | Maximum allowed value |
| `Suffix` | `string` | — | Unit suffix (e.g., "cm", "px") |
| `Label` | `string` | — | Label text |
| `LabelPosition` | `LabelPosition` | `Above` | `Above`, `Left`, `Right`, `Below` |
| `IncrementAmount` | `decimal` | — | Step size |
| `RoundingPlaces` | `int` | — | Decimal places (Decimal type) |
| `TextFieldWidth` | `string` | — | Width of the numeric input |

```razor
<!-- Integer spinner -->
<SpinButton Label="Quantity" Type="SpinButtonType.Whole" @bind-WholeValue="qty"
    MinValue="0" MaxValue="100" />

<!-- Decimal with suffix -->
<SpinButton Label="Width" Type="SpinButtonType.Decimal" @bind-DecimalValue="width"
    Suffix="cm" RoundingPlaces="2" LabelPosition="LabelPosition.Left" />
```

Supports mouse wheel for increment/decrement.

---

## Tabs

**Namespace:** `AppsByTAP.BlazorFluentUI.Components.Tabs`

### Tabs (Container)

| Parameter | Type | Default | Description |
|-----------|------|---------|-------------|
| `Width` | `string` | — | Container width |
| `Height` | `string` | `"100%"` | Container height |
| `TabContentCanScroll` | `bool` | `false` | Enable scrolling in tab content |
| `DefaultOpenTab` | `int` | — | Index of initially open tab |

### Tab (Child)

| Parameter | Type | Default | Description |
|-----------|------|---------|-------------|
| `Header` | `string` | — | Tab header text |
| `Color` | `string` | — | Tab indicator color |
| `ChildContent` | `RenderFragment` | — | Tab content |

```razor
<Tabs Width="600px" Height="400px" TabContentCanScroll="true">
    <Tab Header="Overview" Color="Blue">
        <p>Overview content here</p>
    </Tab>
    <Tab Header="Details" Color="Green">
        <p>Details content here</p>
    </Tab>
    <Tab Header="Settings" Color="Orange">
        <p>Settings content here</p>
    </Tab>
</Tabs>
```

Features an animated indicator bar that slides between tabs.

---

## Modal

**Namespace:** `AppsByTAP.BlazorFluentUI.Components.Modal`

| Parameter | Type | Default | Description |
|-----------|------|---------|-------------|
| `ShowWindow` | `bool` | `false` | Show/hide (supports `@bind-ShowWindow`) |
| `Header` | `RenderFragment` | — | Header content |
| `Content` | `RenderFragment` | — | Body content |
| `Width` | `string` | `"fit-content"` | Modal width |
| `ShowHeader` | `bool` | `true` | Show header section |
| `CanLightDismiss` | `bool` | `true` | Close on outside click |
| `OnClose` | `EventCallback` | — | Close event |

```razor
<DefaultButton Text="Open Modal" OnClick="() => showModal = true" />

<Modal @bind-ShowWindow="showModal" CanLightDismiss="true">
    <Header>
        <h3>Confirm Action</h3>
    </Header>
    <Content>
        <p>Are you sure?</p>
        <DefaultButton Text="Yes" IsPrimary="true" OnClick="Confirm" />
        <DefaultButton Text="No" OnClick="() => showModal = false" />
    </Content>
</Modal>
```

---

## Callout

**Namespace:** `AppsByTAP.BlazorFluentUI.Components.Callout`

| Parameter | Type | Default | Description |
|-----------|------|---------|-------------|
| `IsOpen` | `bool` | `false` | Show/hide (supports `@bind-IsOpen`) |
| `ChildContent` | `RenderFragment` | — | Callout content |
| `Width` | `string` | `"300px"` | Callout width |
| `ItemsPanelHeight` | `int` | `-1` | Max height (-1 = auto) |
| `Disabled` | `bool` | `false` | Disable |
| `CanLightDismiss` | `bool` | `true` | Close on outside click |
| `TargetID` | `string` | — | ID of element to position relative to |
| `OnOpen` | `EventCallback` | — | Open event |
| `OnClose` | `EventCallback` | — | Close event |

```razor
<DefaultButton ID="calloutTarget" Text="Show Info" OnClick="() => isOpen = !isOpen" />

<Callout @bind-IsOpen="isOpen" TargetID="calloutTarget" Width="250px">
    <p>This is positioned next to the button.</p>
</Callout>
```

---

## Expander

**Namespace:** `AppsByTAP.BlazorFluentUI.Components.Expander`

| Parameter | Type | Default | Description |
|-----------|------|---------|-------------|
| `Header` | `RenderFragment` | — | Header content (always visible) |
| `ChildContent` | `RenderFragment` | — | Expandable content |
| `IsOpen` | `bool` | `false` | Expanded state |

```razor
<Expander IsOpen="true">
    <Header>Click to expand</Header>
    <ChildContent>
        <p>Expanded details here</p>
    </ChildContent>
</Expander>
```

---

## Spinner

**Namespace:** `AppsByTAP.BlazorFluentUI.Components.Spinner`

| Parameter | Type | Default | Description |
|-----------|------|---------|-------------|
| `Label` | `string` | — | Label text |
| `Position` | `SpinnerLabelPosition` | `Bottom` | `Top`, `Left`, `Right`, `Bottom` |
| `IsLoading` | `bool` | — | Show/hide the spinner |
| `Size` | `SpinnerSize` | — | `Large`, `Medium`, `Small`, `xSmall` |

```razor
<Spinner Label="Loading data..." Size="SpinnerSize.Large" IsLoading="isLoading" />
<Spinner Label="Please wait" Position="SpinnerLabelPosition.Right" Size="SpinnerSize.Small" IsLoading="true" />
```

Also available: `TinySpinner` for embedding inline.

---

## Icon

**Namespace:** `AppsByTAP.BlazorFluentUI.Components.Icon`

| Parameter | Type | Description |
|-----------|------|-------------|
| `IconType` | `IconTypes` | The icon to display |

```razor
<Icon IconType="IconTypes.Settings" />
<Icon IconType="IconTypes.Mail" />
<Icon IconType="IconTypes.Delete" />
```

Uses the FabricMDL2Icons font. 60+ icons available including: `AlertSettings`, `Bank`, `Calculator`, `Calendar`, `Cancel`, `CheckMark`, `ChevronDown`, `ChevronUp`, `Delete`, `Edit`, `Filter`, `Mail`, `More`, `Pause`, `Play`, `PowerButton`, `Search`, `Settings`, `Stop`, and many more.

---

## Label

**Namespace:** `AppsByTAP.BlazorFluentUI.Components.Label`

| Parameter | Type | Default | Description |
|-----------|------|---------|-------------|
| `Text` | `string` | — | Label text |
| `Disabled` | `bool` | `false` | Disabled style |
| `Hidden` | `bool` | `false` | Visually hidden |
| `Class` | `string` | — | CSS class |
| `Style` | `string` | — | Inline style |
| `ID` | `string` | — | HTML ID |

```razor
<Label Text="Field Label" />
<Label Text="Disabled" Disabled="true" />
```

---

## Persona

**Namespace:** `AppsByTAP.BlazorFluentUI.Components.Persona`

Displays a user avatar with initials (auto-generated) and deterministic background color.

| Parameter | Type | Default | Description |
|-----------|------|---------|-------------|
| `FirstName` | `string` | — | First name |
| `LastName` | `string` | — | Last name |
| `Title` | `string` | — | Job title or secondary text |
| `UserImage` | `string` | — | Image URL (overrides initials) |
| `Size` | `int` | `50` | Avatar diameter in pixels |
| `BorderRadius` | `int` | `50` | Border radius (50 = circle) |

```razor
<Persona FirstName="John" LastName="Doe" Title="Software Engineer" Size="60" />
<Persona FirstName="Jane" LastName="Smith" UserImage="/images/jane.jpg" />
```

Colors are deterministically assigned from a 20-color palette based on initials.

---

## Chip / ChipSet

**Namespace:** `AppsByTAP.BlazorFluentUI.Components.Chip`

### ChipSet

| Parameter | Type | Description |
|-----------|------|-------------|
| `ItemsSource` | `IList<string>` | Items to display as chips |
| `ChipType` | `ChipType` | `Input` (removable) or `Filter` |
| `Label` | `string` | Label before chips |
| `CreateNewItem` | `Func<string, string>` | Factory for creating new items |

### Chip

| Parameter | Type | Description |
|-----------|------|-------------|
| `Text` | `string` | Chip text |
| `ChipType` | `ChipType` | `Input` or `Filter` |
| `OnRemove` | `EventCallback` | Remove handler |
| `OnEdit` | `EventCallback` | Edit handler |

```razor
<ChipSet ItemsSource="tags" ChipType="ChipType.Input" Label="Tags: " CreateNewItem="(s) => s" />
```

---

## FitText

**Namespace:** `AppsByTAP.BlazorFluentUI.Components.FitText`

Dynamically sizes text to fit its container.

| Parameter | Type | Default | Description |
|-----------|------|---------|-------------|
| `Text` | `string` | — | Text to display (alternative: use ChildContent) |
| `Compressor` | `double` | `1.0` | Size multiplier |
| `Width` | `string` | `"100%"` | Container width |
| `Height` | `string` | `"100%"` | Container height |
| `Alignment` | `Alignment` | `Center` | `Center`, `Left`, `Right` |

```razor
<FitText Text="Auto-sized heading" Width="300px" Height="100px" />

<FitText Width="100%" Compressor="0.8" Alignment="Alignment.Left">
    <h1>This text scales to fit</h1>
</FitText>
```

---

## Forms / ValidationInput

**Namespace:** `AppsByTAP.BlazorFluentUI.Components.Forms`

Use inside an `EditForm` for validation:

```razor
<EditForm Model="@myModel">
    <ValidationInput Value="@myModel.Email" />
</EditForm>
```
