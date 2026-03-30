# 04 — Inputs

Covers `TextField`, `CheckBox`, `CheckboxGroup`, `ChoiceGroup`, `Toggle`, and `SpinButton`.

---

## TextField

```
Namespace: AppsByTAP.BlazorFluentUI.Components.TextField
```

Single-line or multi-line text input with optional character limit, input type, and regex mask.

### Parameters

| Parameter | Type | Default | Description |
|---|---|---|---|
| `ID` | `string` | — | HTML element id (required when using `Mask`) |
| `Label` | `string` | — | Label text displayed above the input |
| `Value` | `string` | `""` | Current value; two-way with `@bind-Value` |
| `PlaceHolder` | `string` | — | Placeholder text |
| `IsMultiLine` | `bool` | `false` | Renders a `<textarea>` |
| `MultiLineCanResize` | `bool` | `true` | Allows the textarea to be resized |
| `Width` | `string` | — | CSS width (e.g. `"300px"`, `"100%"`) |
| `MaxWidth` | `string` | — | CSS max-width |
| `Height` | `int` | `-1` | Height in pixels (`-1` = auto) |
| `CharacterLimit` | `int` | `0` | Max characters; shows remaining count when set |
| `Type` | `TextFieldType` | `Text` | `Text`, `Email`, `Password`, `Number`, etc. |
| `Mask` | `string` | — | Regex-based input mask (requires `ID`) |
| `DisplayBorder` | `bool` | `true` | Show or hide the input border |
| `Step` | `double?` | `null` | Step for number inputs |
| `Class` | `string` | — | Additional CSS class |
| `Style` | `string` | — | Inline CSS style |

### Examples

```razor
@using AppsByTAP.BlazorFluentUI.Components.TextField

<!-- Basic text field -->
<TextField Label="Full Name" @bind-Value="fullName" PlaceHolder="Enter your name" />

<!-- Email input -->
<TextField Label="Email" @bind-Value="email" Type="TextFieldType.Email" PlaceHolder="user@example.com" />

<!-- Password input -->
<TextField Label="Password" @bind-Value="password" Type="TextFieldType.Password" />

<!-- Multi-line with character limit -->
<TextField Label="Bio"
           @bind-Value="bio"
           IsMultiLine="true"
           CharacterLimit="500"
           Width="100%"
           Height="120" />

<!-- Phone number with input mask -->
<TextField Label="Phone"
           @bind-Value="phone"
           ID="phoneInput"
           Mask="(000) 000-0000" />

<!-- Number input with step -->
<TextField Label="Price" @bind-Value="price" Type="TextFieldType.Number" Step="0.01" />

<!-- No border (useful inside data tables) -->
<TextField @bind-Value="cellValue" DisplayBorder="false" />
```

---

## CheckBox

```
Namespace: AppsByTAP.BlazorFluentUI.Components.CheckBox
```

### Parameters

| Parameter | Type | Default | Description |
|---|---|---|---|
| `Label` | `string` | — | Label text |
| `IsChecked` | `bool` | `false` | Checked state; two-way with `@bind-IsChecked` |
| `OnChanged` | `EventCallback<CheckBoxChangedArgs>` | — | Fires when the state changes |
| `LabelSide` | `BoxSide` | `Start` | `BoxSide.Start` (left) or `BoxSide.End` (right) |

### Examples

```razor
@using AppsByTAP.BlazorFluentUI.Components.CheckBox

<CheckBox Label="I agree to the terms" @bind-IsChecked="agreed" />

<!-- Label on the right side -->
<CheckBox Label="Remember me" LabelSide="BoxSide.End" @bind-IsChecked="rememberMe" />

<!-- React to change event -->
<CheckBox Label="Subscribe to newsletter"
          IsChecked="subscribed"
          OnChanged="OnSubscribeChanged" />

@code {
    bool agreed;
    bool rememberMe;
    bool subscribed;

    void OnSubscribeChanged(CheckBoxChangedArgs args)
    {
        subscribed = args.IsChecked;
        // additional logic here
    }
}
```

---

## CheckboxGroup

```
Namespace: AppsByTAP.BlazorFluentUI.Components.CheckboxGroup
```

Groups multiple `CheckBox` (or `Toggle`) components with consistent layout.

### Parameters

| Parameter | Type | Default | Description |
|---|---|---|---|
| `Direction` | `GroupDirection` | `Vertical` | `GroupDirection.Horizontal` or `GroupDirection.Vertical` |
| `UseToggleSwitches` | `bool` | `false` | Renders toggle switches instead of checkboxes |
| `ChildContent` | `RenderFragment` | — | `CheckBox` or `Toggle` components |

### Examples

```razor
@using AppsByTAP.BlazorFluentUI.Components.CheckboxGroup
@using AppsByTAP.BlazorFluentUI.Components.CheckBox

<!-- Vertical group (default) -->
<CheckboxGroup>
    <CheckBox Label="Option A" @bind-IsChecked="optA" />
    <CheckBox Label="Option B" @bind-IsChecked="optB" />
    <CheckBox Label="Option C" @bind-IsChecked="optC" />
</CheckboxGroup>

<!-- Horizontal group -->
<CheckboxGroup Direction="GroupDirection.Horizontal">
    <CheckBox Label="Red" @bind-IsChecked="red" />
    <CheckBox Label="Green" @bind-IsChecked="green" />
    <CheckBox Label="Blue" @bind-IsChecked="blue" />
</CheckboxGroup>

<!-- Render as toggle switches -->
<CheckboxGroup UseToggleSwitches="true" Direction="GroupDirection.Vertical">
    <CheckBox Label="Enable feature A" @bind-IsChecked="featureA" />
    <CheckBox Label="Enable feature B" @bind-IsChecked="featureB" />
</CheckboxGroup>
```

---

## ChoiceGroup / Choice

```
Namespace: AppsByTAP.BlazorFluentUI.Components.ChoiceGroup
```

Radio button group for single-selection scenarios.

### ChoiceGroup Parameters

| Parameter | Type | Description |
|---|---|---|
| `ChildContent` | `RenderFragment` | Contains `Choice` child components |

### Choice Parameters

| Parameter | Type | Description |
|---|---|---|
| `Label` | `string` | Choice label text |
| `IsSelected` | `bool` | Whether this choice is currently selected |

### Example

```razor
@using AppsByTAP.BlazorFluentUI.Components.ChoiceGroup

<ChoiceGroup>
    <Choice Label="Option 1" IsSelected="selectedOption == 1" />
    <Choice Label="Option 2" IsSelected="selectedOption == 2" />
    <Choice Label="Option 3" IsSelected="selectedOption == 3" />
</ChoiceGroup>

@code {
    int selectedOption = 1;
}
```

---

## Toggle

```
Namespace: AppsByTAP.BlazorFluentUI.Components.Toggle
```

Binary on/off toggle switch.

### Parameters

| Parameter | Type | Default | Description |
|---|---|---|---|
| `Label` | `string` | — | Label text |
| `IsChecked` | `bool` | `false` | State; two-way with `@bind-IsChecked` |
| `LabelIsInline` | `bool` | `false` | Renders the label on the same line as the switch |

### Examples

```razor
@using AppsByTAP.BlazorFluentUI.Components.Toggle

<!-- Stacked label (default) -->
<Toggle Label="Enable notifications" @bind-IsChecked="notificationsEnabled" />

<!-- Inline label -->
<Toggle Label="Dark mode" @bind-IsChecked="isDarkMode" LabelIsInline="true" />
```

---

## SpinButton

```
Namespace: AppsByTAP.BlazorFluentUI.Components.SpinButton
```

Numeric spinner with increment/decrement controls.

### Parameters

| Parameter | Type | Default | Description |
|---|---|---|---|
| `Label` | `string` | — | Label text |
| `Type` | `SpinButtonType` | `Integer` | `SpinButtonType.Integer` or `SpinButtonType.Decimal` |
| `Suffix` | `string` | — | Unit suffix shown after the value (e.g. `"px"`, `"%"`) |
| `RoundingPlaces` | `int` | — | Decimal places for rounding (used with `Decimal` type) |

### Examples

```razor
@using AppsByTAP.BlazorFluentUI.Components.SpinButton

<!-- Integer quantity -->
<SpinButton Label="Quantity" Type="SpinButtonType.Integer" />

<!-- Decimal percentage with 2 decimal places -->
<SpinButton Label="Opacity" Type="SpinButtonType.Decimal" Suffix="%" RoundingPlaces="2" />

<!-- Pixel value -->
<SpinButton Label="Font Size" Type="SpinButtonType.Integer" Suffix="px" />
```
