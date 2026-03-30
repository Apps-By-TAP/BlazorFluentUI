# 10 — Common Patterns and Recipes

Higher-level patterns that compose multiple BlazorFluentUI components to solve real-world UI problems.

---

## Pattern 1 — Confirm / Delete Dialog

Show a modal asking the user to confirm a destructive action.

```razor
@using AppsByTAP.BlazorFluentUI.Components.Modal
@using AppsByTAP.BlazorFluentUI.Components.Button

<!-- Trigger button (e.g. in a list row) -->
<DefaultButton Text="Delete" Icon="IconTypes.Delete" OnClick="() => OpenConfirm(item)" />

<!-- Confirm modal -->
<Modal @bind-ShowWindow="showConfirm" Width="400px" CanLightDismiss="false">
    <Header>Confirm Delete</Header>
    <Content>
        <p>Are you sure you want to delete <strong>@itemToDelete?.Name</strong>? This cannot be undone.</p>
        <div style="display:flex; gap:8px; margin-top:16px;">
            <DefaultButton Text="Delete" IsPrimary="true" IsBusy="isDeleting" OnClick="ConfirmDelete" />
            <DefaultButton Text="Cancel" OnClick="() => showConfirm = false" />
        </div>
    </Content>
</Modal>

@code {
    record Item(int Id, string Name);

    bool showConfirm;
    bool isDeleting;
    Item? itemToDelete;

    void OpenConfirm(Item item)
    {
        itemToDelete = item;
        showConfirm = true;
    }

    async Task ConfirmDelete()
    {
        isDeleting = true;
        await DeleteAsync(itemToDelete!.Id);
        isDeleting = false;
        showConfirm = false;
    }

    Task DeleteAsync(int id) => Task.CompletedTask; // replace with real delete
}
```

---

## Pattern 2 — Light/Dark Theme Toggle

Let users switch between light and dark mode at runtime using a `Toggle`.

```razor
@using AppsByTAP.BlazorFluentUI.Components.Toggle
@using AppsByTAP.BlazorFluentUI.Components.Theme.Models
@using AppsByTAP.BlazorFluentUI.Components.Theme.Themes.Light
@using AppsByTAP.BlazorFluentUI.Components.Theme.Themes.Dark

@inject IThemeProvider ThemeProvider

<Toggle Label="Dark Mode" @bind-IsChecked="isDark" LabelIsInline="true" />

@code {
    private bool _isDark;

    private bool isDark
    {
        get => _isDark;
        set
        {
            _isDark = value;
            IPalette palette = value ? new DarkThemePalette() : new LightThemePalette();
            ThemeProvider.ChangeTheme(ThemeProvider.CreateTheme(palette));
        }
    }
}
```

---

## Pattern 3 — Loading State Overlay

Show a full-screen spinner while data is being loaded.

```razor
@using AppsByTAP.BlazorFluentUI.Components.Modal
@using AppsByTAP.BlazorFluentUI.Components.Spinner

<Modal @bind-ShowWindow="isLoading" ShowHeader="false" CanLightDismiss="false">
    <Content>
        <div style="padding: 32px; display:flex; justify-content:center;">
            <Spinner IsLoading="true"
                     Size="SpinnerSize.Large"
                     Label="Loading, please wait…"
                     Position="SpinnerLabelPosition.Bottom" />
        </div>
    </Content>
</Modal>

@code {
    bool isLoading;

    protected override async Task OnInitializedAsync()
    {
        isLoading = true;
        await LoadDataAsync();
        isLoading = false;
    }

    Task LoadDataAsync() => Task.Delay(1000); // replace with real load
}
```

---

## Pattern 4 — Search and Filter with DropDown

Filter a list using a dropdown and a search text field.

```razor
@using AppsByTAP.BlazorFluentUI.Components.TextField
@using AppsByTAP.BlazorFluentUI.Components.DropDown

<div style="display:flex; gap:12px; align-items:flex-end;">
    <TextField Label="Search" @bind-Value="searchText" PlaceHolder="Search…" Width="200px" />
    <DropDown TItem="string"
              Label="Status"
              ItemsSource="statuses"
              @bind-SelectedItem="selectedStatus"
              Width="160px" />
</div>

@foreach (var item in FilteredItems)
{
    <p>@item.Name — @item.Status</p>
}

@code {
    record Item(string Name, string Status);

    string searchText = "";
    string selectedStatus = "";
    List<string> statuses = new() { "", "Active", "Inactive", "Pending" };

    List<Item> allItems = new()
    {
        new("Alice", "Active"),
        new("Bob", "Inactive"),
        new("Charlie", "Pending")
    };

    IEnumerable<Item> FilteredItems =>
        allItems
            .Where(i => string.IsNullOrEmpty(searchText) ||
                        i.Name.Contains(searchText, StringComparison.OrdinalIgnoreCase))
            .Where(i => string.IsNullOrEmpty(selectedStatus) || i.Status == selectedStatus);
}
```

---

## Pattern 5 — Multi-Step Wizard with Tabs

Use `Tabs` for a step-based workflow where each tab represents a form step.

```razor
@using AppsByTAP.BlazorFluentUI.Components.Tabs
@using AppsByTAP.BlazorFluentUI.Components.Forms
@using AppsByTAP.BlazorFluentUI.Components.Button

<Tabs Width="700px" ActivePage="@activeStep">
    <Tab Name="Personal">
        <ValidationInput Label="Full Name" @bind-Value="model.FullName" />
        <ValidationInput Label="Email" @bind-Value="model.Email" Type="TextFieldType.Email" />
        <DefaultButton Text="Next" IsPrimary="true" OnClick='() => activeStep = "Address"' />
    </Tab>
    <Tab Name="Address">
        <ValidationInput Label="Street" @bind-Value="model.Street" />
        <ValidationInput Label="City" @bind-Value="model.City" />
        <DefaultButton Text="Back" OnClick='() => activeStep = "Personal"' />
        <DefaultButton Text="Next" IsPrimary="true" OnClick='() => activeStep = "Review"' />
    </Tab>
    <Tab Name="Review">
        <p><strong>Name:</strong> @model.FullName</p>
        <p><strong>Email:</strong> @model.Email</p>
        <p><strong>Address:</strong> @model.Street, @model.City</p>
        <DefaultButton Text="Back" OnClick='() => activeStep = "Address"' />
        <DefaultButton Text="Submit" IsPrimary="true" OnClick="Submit" />
    </Tab>
</Tabs>

@code {
    string activeStep = "Personal";

    WizardModel model = new();

    void Submit() { /* handle final submit */ }

    class WizardModel
    {
        public string FullName { get; set; } = "";
        public string Email { get; set; } = "";
        public string Street { get; set; } = "";
        public string City { get; set; } = "";
    }
}
```

---

## Pattern 6 — Tag Input with ChipSet

Allow users to add and remove tags using `ChipSet`.

```razor
@using AppsByTAP.BlazorFluentUI.Components.Chip
@using AppsByTAP.BlazorFluentUI.Components.TextField
@using AppsByTAP.BlazorFluentUI.Components.Button

<div style="display:flex; gap:8px; align-items:flex-end;">
    <TextField Label="Add tag" @bind-Value="newTag" PlaceHolder="Type a tag…" Width="200px" />
    <DefaultButton Text="Add" IsPrimary="true" OnClick="AddTag" Disabled="@string.IsNullOrWhiteSpace(newTag)" />
</div>

<ChipSet ItemsSource="tags" ChipType="ChipType.Input" />

@code {
    string newTag = "";
    List<string> tags = new() { "Blazor", ".NET" };

    void AddTag()
    {
        var tag = newTag.Trim();
        if (!string.IsNullOrEmpty(tag) && !tags.Contains(tag))
            tags.Add(tag);
        newTag = "";
    }
}
```

---

## Pattern 7 — Expandable Settings Sections

Organize a long settings page with `Expander` sections.

```razor
@using AppsByTAP.BlazorFluentUI.Components.Expander
@using AppsByTAP.BlazorFluentUI.Components.Toggle
@using AppsByTAP.BlazorFluentUI.Components.TextField

<Expander @bind-IsOpen="generalOpen">
    <Header>General</Header>
    <ChildContent>
        <TextField Label="App Name" @bind-Value="appName" Width="300px" />
        <Toggle Label="Maintenance Mode" @bind-IsChecked="maintenanceMode" />
    </ChildContent>
</Expander>

<Expander @bind-IsOpen="notificationsOpen">
    <Header>Notifications</Header>
    <ChildContent>
        <Toggle Label="Email Alerts" @bind-IsChecked="emailAlerts" />
        <Toggle Label="Push Notifications" @bind-IsChecked="pushAlerts" />
    </ChildContent>
</Expander>

<Expander @bind-IsOpen="dangerOpen">
    <Header>Danger Zone</Header>
    <ChildContent>
        <DefaultButton Text="Reset to Defaults" OnClick="Reset" Icon="IconTypes.Refresh" />
    </ChildContent>
</Expander>

@code {
    bool generalOpen = true;
    bool notificationsOpen;
    bool dangerOpen;
    string appName = "My App";
    bool maintenanceMode;
    bool emailAlerts = true;
    bool pushAlerts;

    void Reset() { /* reset logic */ }
}
```

---

## Pattern 8 — User Profile Header with Persona

Display the current user's identity alongside navigation actions.

```razor
@using AppsByTAP.BlazorFluentUI.Components.Persona
@using AppsByTAP.BlazorFluentUI.Components.Button

<div style="display:flex; align-items:center; justify-content:space-between; padding: 8px 16px; background: var(--semanticColors-BodyBackground);">
    <span style="font-weight:600; font-size:18px;">My Application</span>
    <div style="display:flex; align-items:center; gap:12px;">
        <Persona FirstName="@user.FirstName"
                 LastName="@user.LastName"
                 Title="@user.Role"
                 Size="36" />
        <IconButton Icon="IconTypes.Settings" OnClick="OpenSettings" />
    </div>
</div>

@code {
    record UserProfile(string FirstName, string LastName, string Role);
    UserProfile user = new("Jane", "Doe", "Admin");

    void OpenSettings() { /* open settings modal */ }
}
```

---

## Pattern 9 — Dynamic Form from a Model List

Render a list of items with editable fields and action buttons.

```razor
@using AppsByTAP.BlazorFluentUI.Components.TextField
@using AppsByTAP.BlazorFluentUI.Components.Button

@foreach (var item in items)
{
    <div style="display:flex; gap:8px; align-items:flex-end; margin-bottom:8px;">
        <TextField @bind-Value="item.Name" PlaceHolder="Item name" Width="250px" />
        <TextField @bind-Value="item.Value" PlaceHolder="Value" Width="120px" />
        <IconButton Icon="IconTypes.Delete" OnClick="() => items.Remove(item)" />
    </div>
}

<DefaultButton Text="Add Row" Icon="IconTypes.Add" OnClick="AddRow" />

@code {
    class EditableItem { public string Name { get; set; } = ""; public string Value { get; set; } = ""; }

    List<EditableItem> items = new() { new() { Name = "Item 1", Value = "100" } };

    void AddRow() => items.Add(new());
}
```

---

## Pattern 10 — FAB + Modal for Quick Create

Place a `FloatingActionButton` to open a quick-create `Modal`.

```razor
@using AppsByTAP.BlazorFluentUI.Components.FloatingActionButton
@using AppsByTAP.BlazorFluentUI.Components.Modal
@using AppsByTAP.BlazorFluentUI.Components.Forms
@using AppsByTAP.BlazorFluentUI.Components.Button

<!-- Floating button -->
<div style="position:fixed; bottom:24px; right:24px; z-index:100;">
    <FloatingActionButton Icon="IconTypes.Add" OnClick="() => showCreate = true" />
</div>

<!-- Quick create modal -->
<Modal @bind-ShowWindow="showCreate" Width="420px">
    <Header>New Item</Header>
    <Content>
        <ValidationInput Label="Name" @bind-Value="newItemName" PlaceHolder="Enter a name" />
        <div style="display:flex; gap:8px; margin-top:16px;">
            <DefaultButton Text="Create" IsPrimary="true" OnClick="Create" />
            <DefaultButton Text="Cancel" OnClick="() => showCreate = false" />
        </div>
    </Content>
</Modal>

@code {
    bool showCreate;
    string newItemName = "";

    void Create()
    {
        if (!string.IsNullOrWhiteSpace(newItemName))
        {
            // save new item
            newItemName = "";
            showCreate = false;
        }
    }
}
```
