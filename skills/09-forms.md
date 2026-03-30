# 09 — Forms and Validation

```
Namespace: AppsByTAP.BlazorFluentUI.Components.Forms
```

BlazorFluentUI integrates with Blazor's built-in `EditForm` and validation infrastructure. The `Forms/` namespace provides a `ValidationInput` component that wraps `TextField` and connects it to the active `EditContext`, displaying validation messages automatically.

---

## ValidationInput

`ValidationInput` is a form-aware text field. Use it inside an `EditForm` the same way you would use `InputText`, but with the full styling and features of `TextField`.

### Parameters

`ValidationInput` exposes the same parameters as `TextField`:

| Parameter | Type | Default | Description |
|---|---|---|---|
| `Label` | `string` | — | Label text |
| `Value` | `string` | — | Bound value; two-way with `@bind-Value` |
| `PlaceHolder` | `string` | — | Placeholder text |
| `IsMultiLine` | `bool` | `false` | Renders a textarea |
| `CharacterLimit` | `int` | `0` | Max character count |
| `Type` | `TextFieldType` | `Text` | Input type |
| `Width` | `string` | — | CSS width |

Validation messages for the bound field are rendered automatically below the input when validation fails.

---

## Basic Form Example

```razor
@page "/register"
@using AppsByTAP.BlazorFluentUI.Components.Forms
@using AppsByTAP.BlazorFluentUI.Components.Button
@using System.ComponentModel.DataAnnotations

<EditForm Model="model" OnValidSubmit="Submit">
    <DataAnnotationsValidator />

    <ValidationInput Label="First Name"
                     @bind-Value="model.FirstName"
                     PlaceHolder="Enter your first name" />

    <ValidationInput Label="Last Name"
                     @bind-Value="model.LastName"
                     PlaceHolder="Enter your last name" />

    <ValidationInput Label="Email"
                     @bind-Value="model.Email"
                     Type="TextFieldType.Email"
                     PlaceHolder="user@example.com" />

    <ValidationInput Label="Password"
                     @bind-Value="model.Password"
                     Type="TextFieldType.Password" />

    <DefaultButton Text="Register" IsPrimary="true" />
</EditForm>

@code {
    RegistrationModel model = new();

    void Submit()
    {
        // model is valid — perform registration
    }

    class RegistrationModel
    {
        [Required(ErrorMessage = "First name is required")]
        [MaxLength(50)]
        public string FirstName { get; set; } = "";

        [Required(ErrorMessage = "Last name is required")]
        [MaxLength(50)]
        public string LastName { get; set; } = "";

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Enter a valid email address")]
        public string Email { get; set; } = "";

        [Required(ErrorMessage = "Password is required")]
        [MinLength(8, ErrorMessage = "Password must be at least 8 characters")]
        public string Password { get; set; } = "";
    }
}
```

---

## Combining ValidationInput with Other Components

Non-text inputs (checkboxes, dropdowns, toggles) do not have a `ValidationInput` counterpart — bind them normally and validate at the model level.

```razor
@using AppsByTAP.BlazorFluentUI.Components.Forms
@using AppsByTAP.BlazorFluentUI.Components.CheckBox
@using AppsByTAP.BlazorFluentUI.Components.DropDown
@using AppsByTAP.BlazorFluentUI.Components.Button
@using System.ComponentModel.DataAnnotations

<EditForm Model="model" OnValidSubmit="Submit">
    <DataAnnotationsValidator />
    <ValidationSummary />

    <ValidationInput Label="Name" @bind-Value="model.Name" />

    <DropDown TItem="string"
              Label="Role"
              ItemsSource="roles"
              @bind-SelectedItem="model.Role"
              Width="250px" />

    <CheckBox Label="I accept the terms" @bind-IsChecked="model.AcceptsTerms" />

    <DefaultButton Text="Submit" IsPrimary="true" />
</EditForm>

@code {
    FormModel model = new();
    List<string> roles = new() { "Admin", "Editor", "Viewer" };

    void Submit() { /* all valid */ }

    class FormModel
    {
        [Required]
        public string Name { get; set; } = "";

        [Required(ErrorMessage = "Please select a role")]
        public string? Role { get; set; }

        [Range(typeof(bool), "true", "true", ErrorMessage = "You must accept the terms")]
        public bool AcceptsTerms { get; set; }
    }
}
```

---

## Handling Submit Outcomes

```razor
<EditForm Model="model" OnValidSubmit="Submit" OnInvalidSubmit="ShowErrors">
    <DataAnnotationsValidator />

    <ValidationInput Label="Email" @bind-Value="model.Email" Type="TextFieldType.Email" />

    <DefaultButton Text="Save" IsPrimary="true" IsBusy="isSaving" />

    @if (!string.IsNullOrEmpty(errorMessage))
    {
        <p style="color: var(--semanticTextColors-ErrorText)">@errorMessage</p>
    }
</EditForm>

@code {
    FormModel model = new();
    bool isSaving;
    string errorMessage = "";

    async Task Submit()
    {
        isSaving = true;
        errorMessage = "";
        try
        {
            await SaveAsync(model);
        }
        catch (Exception ex)
        {
            errorMessage = ex.Message;
        }
        finally
        {
            isSaving = false;
        }
    }

    void ShowErrors()
    {
        // EditForm automatically shows field-level errors via ValidationInput
    }

    Task SaveAsync(FormModel m) => Task.CompletedTask; // replace with real save

    class FormModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } = "";
    }
}
```

---

## Tips

- Always include `<DataAnnotationsValidator />` inside `<EditForm>` when using data annotations.
- Use `OnValidSubmit` instead of `OnSubmit` to prevent the handler from firing when there are validation errors.
- Use `ValidationSummary` from the standard Blazor library if you want a consolidated list of all errors at the top of the form.
- For custom server-side validation errors, obtain the `EditContext` and call `editContext.AddDataAnnotationsValidation()` or use `ValidationMessageStore`.
