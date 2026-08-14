param(
    [string]$RepositoryRoot = (Resolve-Path (Join-Path $PSScriptRoot '..\..')).Path
)

$ErrorActionPreference = 'Stop'
$validatorProject = Join-Path $RepositoryRoot 'tools\OkfDocsValidator\OkfDocsValidator.csproj'
$json = dotnet run --no-build -c Release --project $validatorProject -- inventory --repo-root $RepositoryRoot
if ($LASTEXITCODE -ne 0) { throw 'Could not read the compiled component inventory.' }
$inventory = $json | ConvertFrom-Json
$okfRoot = Join-Path $RepositoryRoot 'docs\OKF'
$componentsRoot = Join-Path $okfRoot 'components'
$referencesRoot = Join-Path $okfRoot 'references'
[IO.Directory]::CreateDirectory($componentsRoot) | Out-Null
[IO.Directory]::CreateDirectory($referencesRoot) | Out-Null
$utf8 = New-Object Text.UTF8Encoding($false)

function Write-Utf8([string]$Path, [string]$Content) {
    $normalized = $Content.Replace("`r`n", "`n").Replace("`r", "`n")
    $next = $normalized.TrimEnd() + "`n"
    if ((Test-Path $Path) -and [IO.File]::ReadAllText($Path) -ceq $next) { return }
    [IO.File]::WriteAllText($Path, $next, $utf8)
}

function Get-Slug($component) {
    if ($component.fullName -eq 'AppsByTAP.BlazorFluentUI.Components.Forms.TextField') { return 'forms-text-field' }
    $slug = [regex]::Replace($component.name, '(?<=[a-z0-9])(?=[A-Z])', '-')
    return $slug.ToLowerInvariant()
}

function Get-Description([string]$FullName) {
    switch -Wildcard ($FullName) {
        '*.BottomNavigationBar.BottomNavigationBar' { 'A visual container that fixes navigation items into a horizontal bottom bar.' }
        '*.BottomNavigationBar.NavigationItem' { 'A clickable bottom-navigation entry that renders an icon or image and navigates to a URL.' }
        '*.Button.BaseButton' { 'The shared WPF-style button implementation used by several public button variants.' }
        '*.Button.CompoundButton' { 'A button variant with primary text and a secondary descriptive line.' }
        '*.Button.DefaultButton' { 'The standard primary or secondary action button wrapper.' }
        '*.Button.HyperLinkButton' { 'An anchor-based button with target selection and optional busy animation.' }
        '*.Button.IconButton' { 'A compact icon-only clickable control.' }
        '*.Button.NavButton' { 'A BaseButton wrapped in an anchor when Href is provided.' }
        '*.Button.PostButton' { 'A native form-posting button that submits hidden name/value fields to a URL.' }
        '*.Button.SubmitButton' { 'A native HTML submit button for Blazor forms with shared button styling, icon, disabled, click, and busy-state parameters.' }
        '*.Button.SplitButton*' { 'A generic primary action plus callout menu for choosing an item.' }
        '*.Button.TemplateButton' { 'A button-like container whose visual content is supplied by a RenderFragment.' }
        '*.Callout.Callout' { 'A positioned overlay anchored to a target element ID with optional light dismiss.' }
        '*.CheckboxGroup.CheckboxGroup*' { 'A generic data-driven group that renders each item as a CheckBox or Toggle.' }
        '*.CheckBox.CheckBox' { 'A WPF-style binary check control with configurable box placement.' }
        '*.Chip.Chip' { 'A single chip with input, choice, filter, or action presentation.' }
        '*.Chip.ChipSet*' { 'A generic collection of editable/selectable chips with optional new-item creation.' }
        '*.ChoiceGroup.Choice`1' { 'A radio-style child option that must be hosted by a matching ChoiceGroup<T>.' }
        '*.ChoiceGroup.ChoiceGroup*' { 'A generic single-selection radio group using cascading coordination with Choice children.' }
        '*.DropDown.BlankDropDown' { 'A low-level dropdown shell with templated display and panel content.' }
        '*.DropDown.DropDown*' { 'A generic single- or multi-select dropdown with optional item templates and grouped DropDownItem data.' }
        '*.Expander.Expander' { 'A collapsible header/body container with bindable open state.' }
        '*.FitText.FitText' { 'A JavaScript-assisted text container that scales content to fit configured bounds.' }
        '*.FloatingActionButton.FloatingActionButton' { 'A floating action surface that can render an image, icon, text content, or a combination.' }
        '*.Forms.TextField' { 'An InputBase<string>-derived text field for EditForm validation and optional masking.' }
        '*.Icon.Icon' { 'A wrapper for the bundled Office Fabric icon font using IconTypes.' }
        '*.Label.Label' { 'A styled label element with hidden and disabled states.' }
        '*.LightDismiss.LightDismiss' { 'A fixed backdrop layer that closes its owning overlay when clicked.' }
        '*.Modal.Modal' { 'A JavaScript-assisted modal with header/content fragments and optional light dismissal.' }
        '*.Persona.Persona' { 'A user identity display with initials or image, name, title, and configurable sizing.' }
        '*.SpinButton.SpinButton' { 'A whole-number or decimal input with buttons and mouse-wheel increment/decrement behavior.' }
        '*.Spinner.TinySpinner' { 'A compact spinner variant that shares the Spinner parameter contract but omits label markup.' }
        '*.Spinner.Spinner' { 'A loading indicator with size and label-position options.' }
        '*.Tabs.Tab' { 'A child tab page registered with a parent Tabs component through a cascading parameter.' }
        '*.Tabs.Tabs' { 'A tab header and content host with an index-based initial selection.' }
        '*.TextField.TextField' { 'The standalone WPF-style text input with binding, masking, input types, and character limits.' }
        '*.TextField.ValidationInput' { 'A minimal InputBase<string> input that participates in EditForm validation.' }
        '*.Theme.Theme' { 'The application theme boundary that emits palette and semantic CSS custom properties.' }
        '*.Toggle.Toggle' { 'A WPF-style binary toggle switch with bindable IsChecked state.' }
        '*.TreeMenu.BranchComponent*' { 'The recursive branch renderer used internally by TreeMenu<T>.' }
        '*.TreeMenu.TreeMenu*' { 'A generic virtualized hierarchical menu with lazy child loading and selection.' }
        default { 'A BlazorFluentUI component.' }
    }
}

function Get-Gotchas([string]$FullName) {
    switch -Wildcard ($FullName) {
        '*.BottomNavigationBar.BottomNavigationBar' { @('This component only lays out ChildContent; it does not manage active selection.', 'Class is named `Class`, not `ClassName`.') }
        '*.BottomNavigationBar.NavigationItem' { @('Icon is the corrected 0.1.0 parameter name; the former `ICon` spelling was removed.', 'ImageUrl takes visual precedence over Icon; ActiveImageUrl is used only when IsActive is true.', 'Navigation is unconditional when clicked and uses NavigationManager.NavigateTo(Url).') }
        '*.Button.BaseButton' { @('The clickable root is a div, not a native button; keyboard activation and native disabled semantics are not provided.', 'ShowIsBusy controls temporary internal IsBusy state; IsBusy itself is not a parameter.', 'OnClickInternal is async void, so consumer callback failures cannot be awaited by the caller.') }
        '*.Button.CompoundButton' { @('Inherited Icon, ShowIsBusy, and OnClickStopPropagation are not forwarded by the current wrapper markup.', 'SecondaryText is the only additional parameter over ButtonBaseParameters.') }
        '*.Button.DefaultButton' { @('Although SecondaryText is inherited, DefaultButton does not forward it to its inner BaseButton.', 'The rendered clickable element comes from BaseButton and is not a native button.') }
        '*.Button.HyperLinkButton' { @('Busy CSS is registered only on first render when ShowIsBusy is already true.', 'The component imports a JS module and also calls eval to append a style element.', 'TargetType defaults to Self; the backing target string remains null until the setter runs, which behaves like the browser default.') }
        '*.Button.IconButton' { @('This is a div-based control without native button keyboard/disabled semantics.', 'It does not inherit the common button Text, IsPrimary, or ShowIsBusy parameters.') }
        '*.Button.NavButton' { @('Href null/empty changes whether an anchor wrapper is rendered.', 'SecondaryText is inherited but is not forwarded to the inner BaseButton.') }
        '*.Button.PostButton' { @('Submitting navigates away using a native form post; OnClick is not available.', 'HiddenValues is rendered directly as hidden inputs and should be treated as untrusted input when values come from users.') }
        '*.Button.SubmitButton' { @('The root is a native `<button type="submit">`; inside an EditForm or HTML form it initiates form submission in addition to invoking OnClick.', 'OnClickStopPropagation affects Blazor event bubbling but does not prevent the browser default submit action; the component exposes no prevent-default parameter.', 'ShowIsBusy tracks only the inherited OnClick callback. It does not track EditForm.OnValidSubmit or OnSubmit work unless that work is also awaited by OnClick.', 'OnClickInternal is inherited async void, so the renderer cannot await it and callback exceptions do not flow through a returned Task.', 'Disabled is applied as the native disabled attribute and also suppresses inherited click handling.', 'Unlike BaseButton, SubmitButton has no SecondaryText parameter and renders a native keyboard-operable button.') }
        '*.Button.SplitButton*' { @('TItem must be supplied and ItemsSource must be non-null before opening the menu.', 'SelectedItemTemplate and DropDownTemplate are required for meaningful generic rendering.', 'Selection closes the callout and invokes SelectedItemChanged.') }
        '*.Button.TemplateButton' { @('The root is button-like markup rather than a native button.', 'ChildContent controls presentation; Text and Icon inherited from the base contract are not rendered.') }
        '*.Callout.Callout' { @('TargetID must identify an existing DOM element for JS positioning.', 'IsOpen invokes OnOpen/OnClose from its setter; parameter setters with side effects produce Blazor analyzer warnings.', 'No focus trap or Escape-key behavior is implemented by the component.') }
        '*.CheckboxGroup.CheckboxGroup*' { @('This is data-driven through ItemsSource; it does not accept ChildContent.', 'Items are matched by Equals and duplicate/equal values cannot be selected independently.', 'UseToggleSwitches changes the child component but preserves SelectedItems binding.') }
        '*.CheckBox.CheckBox' { @('The placement parameter is named BoxSide, not LabelSide.', 'Both @bind-IsChecked and OnChanged can fire for one user action.', 'The visual control is div-based and does not provide native checkbox keyboard behavior.') }
        '*.Chip.Chip' { @('ChipType.Choice is the corrected 0.1.0 enum member; `Choise` was removed.', 'OnRemove and OnEdit carry the generated or supplied ID value rather than Text or a chip model.', 'Choice/filter state is managed by ChipSet; standalone use does not supply group coordination.') }
        '*.Chip.ChipSet*' { @('CreateNewItem must be supplied before the input-creation path is used.', 'The implementation writes child component parameters from outside the child and currently produces BL0005 warnings.', 'SelectionType.Single and Multi update different selection properties; no SelectedItemChanged/SelectedItemsChanged callbacks are exposed.') }
        '*.ChoiceGroup.Choice`1' { @('Choice<T> throws during initialization when it is not inside a ChoiceGroup<T> of the same T.', 'Parent is cascading state and must not be set as a normal attribute.', 'IsSelectedChanged can be used, but group selection should normally bind ChoiceGroup.SelectedItem.') }
        '*.ChoiceGroup.ChoiceGroup*' { @('ChildContent must contain Choice<T> children using the same T.', 'SelectedItem changes invoke both SelectedItemChanged and SelectionChanged.', 'The internal child notification path uses async void.') }
        '*.DropDown.BlankDropDown' { @('DisplayInfo and Content are separate named fragments.', 'The JS module is imported for positioning/measurement behavior.', 'IsOpen has callback side effects and OnClickStopPropagation defaults to true.') }
        '*.DropDown.DropDown*' { @('Use @bind-SelectedItem for single selection and @bind-SelectedItems for multi-selection.', 'ItemsSource is List<T>, not IEnumerable<T>.', 'Grouped headers require DropDownItem<T> values; ordinary T items are all selectable.', 'The component hard-codes the inner BlankDropDown panel height to 250px.') }
        '*.Expander.Expander' { @('The correct two-way binding is @bind-IsOpen.', 'The open-state setter invokes IsOpenChanged and produces a Blazor analyzer warning.', 'Header is clickable markup without built-in keyboard/ARIA expansion semantics.') }
        '*.FitText.FitText' { @('The FitText JS module must be available from the Razor class library static assets.', 'Compressor participates in the calculated font size; invalid or zero values can produce unusable output.', 'SetElementBounds is JS-invokable async void.') }
        '*.FloatingActionButton.FloatingActionButton' { @('BottomNavigationIsVisible changes bottom offset rather than observing a navigation component automatically.', 'The clickable root is not a native button.', 'ImageUrl, Icon, and ChildContent may all render; choose deliberately to avoid duplicate visuals.') }
        '*.Forms.TextField' { @('This is distinct from Components.TextField.TextField and inherits InputBase<string>.', 'CustomValidation and ValidationResult<T> are the corrected 0.1.0 names.', 'Mask requires a non-empty ID and throws ArgumentNullException after first render otherwise.', 'Default validation rejects null, empty, and whitespace-only values.') }
        '*.Icon.Icon' { @('The Fabric icon stylesheet must be linked by the host application.', 'IconTypes member names map directly to bundled ms-Icon CSS class names, including legacy spellings.', 'The icon is presentation-only and has no accessible label parameter.') }
        '*.Label.Label' { @('Hidden uses component styling rather than conditional removal.', 'This component does not associate itself with an input through a for parameter.') }
        '*.LightDismiss.LightDismiss' { @('Layer is allocated from a process-local counter when not supplied.', 'Clicking the backdrop invokes OnClose and updates IsOpenChanged.', 'It supplies no focus management or Escape-key handling.') }
        '*.Modal.Modal' { @('The Modal JS module is required for client behavior.', 'ShowWindow is the bindable visibility property.', 'CanLightDismiss controls backdrop clicks only; no focus trap is implemented.', 'Width is inserted as CSS and defaults to fit-content.') }
        '*.Persona.Persona' { @('BorderRadius is an integer pixel value, not a CSS string.', 'UserImage switches from generated initials to an image.', 'Initials are derived from FirstName/LastName; there is no Initials parameter.') }
        '*.SpinButton.SpinButton' { @('Bind WholeValue or DecimalValue according to SpinButtonType; there is no Value parameter.', 'SpinButtonType members are Whole and Decimal.', 'OnIncrement and OnDecrement are declared but their invocations are commented out in current source.', 'Parsing uses current-culture double parsing and a permissive regex.') }
        '*.Spinner.TinySpinner' { @('TinySpinner inherits Label and Position but does not render label markup.', 'SpinnerSize.xSmall intentionally begins with a lowercase x.', 'IsLoading is bindable even though consumers usually set it one-way.') }
        '*.Spinner.Spinner' { @('SpinnerSize.xSmall intentionally begins with a lowercase x.', 'IsLoading false hides the wrapper with display:none.', 'Parameter setters compute CSS class state and produce analyzer warnings.') }
        '*.Tabs.Tab' { @('Tab must be nested in Tabs or it throws ArgumentNullException during initialization.', 'The public label parameter is Header, not Name.', 'Parent is an internal cascading parameter and cannot be assigned by normal markup.') }
        '*.Tabs.Tabs' { @('DefaultOpenTab is a zero-based index and is applied as children register.', 'There is no public ActivePage parameter; active state is managed internally.', 'TabContentCanScroll only changes the content container overflow behavior.') }
        '*.TextField.TextField' { @('TextFieldType members are lowercase: text, number, tel, email, password.', 'Mask requires ID and throws ArgumentNullException on first render otherwise.', 'CharacterLimit truncates/blocks input according to component logic; it is not an HTML maxlength passthrough.', 'This component is not InputBase and does not integrate with EditForm field validation automatically.') }
        '*.TextField.ValidationInput' { @('ValidationInput inherits InputBase<string>; use it inside EditForm with a value expression produced by @bind-Value.', 'It always renders type=text and rejects blank values.', 'It is distinct from the richer Forms.TextField validation component.') }
        '*.Theme.Theme' { @('ThemeProvider() defaults to DarkThemePalette, not light.', 'Dark semantic branching is selected with `palette is DarkThemePalette`; a dark custom IPalette that does not derive from DarkThemePalette is treated as light.', 'The component subscribes to ThemeChanged but does not unsubscribe, so repeated disposal can retain handlers.', 'The component adds a wrapper div and global :root/body styles.') }
        '*.Toggle.Toggle' { @('Use @bind-IsChecked; there is no Value parameter.', 'The IsChecked setter invokes IsCheckedChanged and produces a Blazor analyzer warning.', 'The visual switch is div-based and has no native checkbox keyboard semantics.') }
        '*.TreeMenu.BranchComponent*' { @('BranchComponent<T> is recursive infrastructure and must receive a cascading TreeMenu<T>.', 'The current missing-parent exception message incorrectly refers to ChoiceGroup.', 'Child loading and selection notifications include async void paths.') }
        '*.TreeMenu.TreeMenu*' { @('Items, GetItems, and BranchDisplay are required for a useful tree.', 'GetItems receives an ItemsProviderRequest plus the parent item and must return BranchItem<T> values.', 'Branch<T>.Equals uses a generated ID while GetHashCode is not overridden.', 'There is no nested ChildContent API.') }
        default { @('Review the exact parameter table; this library intentionally uses WPF-style names rather than conventional Value parameters.') }
    }
}

function Get-Accessibility([string]$FullName) {
    if ($FullName -match '\.SubmitButton$') {
        return 'The root is a native button with built-in keyboard activation and disabled semantics. Supply meaningful Text; Icon has no separate accessible-label parameter, and the busy spinner does not add a live-region announcement.'
    }
    if ($FullName -match '\.(BaseButton|CompoundButton|DefaultButton|IconButton|NavButton|TemplateButton|CheckBox|Toggle|FloatingActionButton)$') {
        return 'The interactive surface is div-based. Add an accessible wrapper or extend the component before relying on keyboard activation, native disabled behavior, or button/checkbox semantics.'
    }
    if ($FullName -match '\.(Modal|Callout|LightDismiss)$') {
        return 'Overlay visibility is implemented, but focus trapping, focus restoration, Escape handling, and complete dialog semantics are not supplied automatically.'
    }
    if ($FullName -match '\.(TextField|ValidationInput|SpinButton)$') {
        return 'Use a visible label and stable ID where supported. Validation and masking do not replace accessible instructions or error association.'
    }
    return 'Inspect the rendered markup before assuming ARIA roles or keyboard behavior; the component does not add accessibility behavior beyond what is present in its source markup.'
}

function Get-ParameterNote($parameter) {
    $name = $parameter.name
    if ($name.EndsWith('Changed')) { return "Binding callback paired with $($name.Substring(0, $name.Length - 7)); normally supplied by @bind syntax." }
    $notes = @{
        'AdditionalAttributes'='Unmatched HTML attributes inherited from InputBase and applied to the input.'
        'ChildContent'='Child markup rendered by the component.'; 'Content'='Named body fragment.'; 'Header'='Header text or named header fragment, according to the declared type.'
        'Style'='Inline CSS appended to the component root.'; 'Class'='Additional CSS class string.'; 'ClassName'='Additional CSS class string inherited from the library base type.'; 'ID'='DOM id; required by masking features.'
        'Text'='Primary display text.'; 'Label'='Visible label text.'; 'Disabled'='Prevents the component action using component logic.'; 'OnClick'='Invoked for an accepted click.'; 'OnClickStopPropagation'='Controls Blazor click event propagation.'
        'Value'='Current value.'; 'ValueExpression'='Expression used by InputBase/EditContext validation.'; 'DisplayName'='Display name used in validation messages.'
        'IsChecked'='Current WPF-style checked state.'; 'IsOpen'='Current overlay/expansion state.'; 'ShowWindow'='Current modal visibility state.'; 'IsLoading'='Controls spinner visibility.'
        'SelectedItem'='Current single selected item.'; 'SelectedItems'='Current multi-selection.'; 'ItemsSource'='Items rendered by the component.'; 'ItemTemplate'='Template used to render an item.'
        'Width'='CSS width value.'; 'Height'='Height value; consult the exact type for pixels versus CSS text.'; 'MaxWidth'='CSS max-width value.'
        'Icon'='IconTypes value rendered by the component.'; 'IconType'='IconTypes value mapped to a Fabric icon class.'; 'PlaceHolder'='Input placeholder text; spelling is part of the public API.'
        'Type'='Selects the component input/behavior mode.'; 'Mask'='Mask passed to the bundled IMask integration.'; 'OnBlur'='Invoked when the input loses focus.'
        'TargetID'='DOM id of the element used for positioning.'; 'CanLightDismiss'='Allows backdrop/outside-click dismissal.'; 'Layer'='Explicit z-index/layer value.'
        'RenderFragment'='Template content.'; 'CreateNewItem'='Converts entered text into T.'; 'GetItems'='Loads child tree items for a parent and virtualization request.'
    }
    if ($notes.ContainsKey($name)) { return $notes[$name] }
    return 'Public component parameter; see behavior and gotchas below for component-specific effects.'
}

function Get-Examples($component) {
    $name = $component.name
    $generic = if ($component.genericParameters.Count -gt 0) { ' ' + (($component.genericParameters | ForEach-Object { "$_=`"string`"" }) -join ' ') } else { '' }
    $minimal = "<$name$generic />"
    $advanced = $minimal
    switch -Wildcard ($component.fullName) {
        '*.Button.BaseButton' { $minimal='<BaseButton Text="Save" OnClick="Save" />'; $advanced='<BaseButton Text="Save" Icon="IconTypes.CheckMark" IsPrimary="true" ShowIsBusy="true" OnClick="SaveAsync" />' }
        '*.Button.CompoundButton' { $minimal='<CompoundButton Text="Publish" SecondaryText="Make this visible" OnClick="Publish" />'; $advanced='<CompoundButton Text="Delete" SecondaryText="Cannot be undone" IsPrimary="true" Disabled="@isLocked" OnClick="Delete" />' }
        '*.Button.DefaultButton' { $minimal='<DefaultButton Text="Save" OnClick="Save" />'; $advanced='<DefaultButton Text="Save" IsPrimary="true" Icon="IconTypes.CheckMark" ShowIsBusy="true" OnClick="SaveAsync" />' }
        '*.Button.HyperLinkButton' { $minimal='<HyperLinkButton Text="Documentation" Url="/docs" />'; $advanced='<HyperLinkButton Text="Open report" Url="/report" TargetType="TargetTypes.Blank" Icon="IconTypes.ReceiptProcessing" />' }
        '*.Button.IconButton' { $minimal='<IconButton Icon="IconTypes.Settings" OnClick="OpenSettings" />'; $advanced='<IconButton Icon="IconTypes.Delete" Disabled="@isLocked" ID="delete-action" OnClick="Delete" />' }
        '*.Button.NavButton' { $minimal='<NavButton Text="Home" Href="/" />'; $advanced='<NavButton Text="Settings" Href="/settings" Icon="IconTypes.Settings" IsPrimary="true" />' }
        '*.Button.PostButton' { $minimal='<PostButton Text="Submit" Url="/orders" />'; $advanced='<PostButton Text="Submit" Url="/orders" FormID="order-form" HiddenValues="@fields" IsPrimary="true" />' }
        '*.Button.SubmitButton' { $minimal="<EditForm Model=`"@model`" OnValidSubmit=`"SaveAsync`">`n    <DataAnnotationsValidator />`n    <SubmitButton Text=`"Save`" IsPrimary=`"true`" />`n</EditForm>"; $advanced="<EditForm Model=`"@model`" OnValidSubmit=`"CreateAccountAsync`">`n    <DataAnnotationsValidator />`n    <SubmitButton Text=`"Create account`"`n                  Icon=`"IconTypes.CheckMark`"`n                  IsPrimary=`"true`"`n                  Disabled=`"@saving`"`n                  OnClick=`"RecordSubmitAttempt`"`n                  OnClickStopPropagation=`"true`" />`n</EditForm>" }
        '*.Button.SplitButton*' { $minimal='<SplitButton TItem="string" ItemsSource="@actions" SelectedItemTemplate="@RenderAction" DropDownTemplate="@RenderAction" />'; $advanced='<SplitButton TItem="string" Text="Run" ItemsSource="@actions" @bind-SelectedItem="selectedAction" CanLightDismiss="true" SelectedItemTemplate="@RenderAction" DropDownTemplate="@RenderAction" />' }
        '*.Button.TemplateButton' { $minimal='<TemplateButton><span>Custom action</span></TemplateButton>'; $advanced='<TemplateButton Border="none" BorderRadius="12px" OnClick="Run"><strong>Run</strong></TemplateButton>' }
        '*.BottomNavigationBar.BottomNavigationBar' { $minimal='<BottomNavigationBar><NavigationItem Text="Home" Url="/" Icon="IconTypes.Bank" /></BottomNavigationBar>'; $advanced='<BottomNavigationBar Class="app-nav" Style="height:64px"><NavigationItem Text="Home" Url="/" Icon="IconTypes.Bank" IsActive="true" /><NavigationItem Text="Search" Url="/search" Icon="IconTypes.Search" /></BottomNavigationBar>' }
        '*.BottomNavigationBar.NavigationItem' { $minimal='<NavigationItem Text="Home" Url="/" Icon="IconTypes.Bank" />'; $advanced='<NavigationItem Text="Profile" Url="/profile" ImageUrl="images/user.png" ActiveImageUrl="images/user-active.png" IsActive="@isProfile" />' }
        '*.Callout.Callout' { $minimal='<Callout TargetID="help-button" @bind-IsOpen="showHelp"><p>Help text</p></Callout>'; $advanced='<Callout TargetID="actions" Width="360px" ItemsPanelHeight="240" CanLightDismiss="true" @bind-IsOpen="open" OnClose="Closed"><p>Actions</p></Callout>' }
        '*.CheckboxGroup.CheckboxGroup*' { $minimal='<CheckboxGroup T="string" ItemsSource="@options" @bind-SelectedItems="selected" />'; $advanced='<CheckboxGroup T="string" Label="Features" ItemsSource="@options" @bind-SelectedItems="selected" GroupDirection="GroupDirection.Horizontal" WrapItems="true" UseToggleSwitches="true" />' }
        '*.CheckBox.CheckBox' { $minimal='<CheckBox Label="Remember me" @bind-IsChecked="remember" />'; $advanced='<CheckBox Label="Enable feature" BoxSide="BoxSide.End" @bind-IsChecked="enabled" OnChanged="Changed" />' }
        '*.Chip.Chip' { $minimal='<Chip Text="Blazor" ChipType="ChipType.Input" />'; $advanced='<Chip Text="Production" ChipType="ChipType.Filter" OnEdit="EditChip" OnRemove="RemoveChip" />' }
        '*.Chip.ChipSet*' { $minimal='<ChipSet TItem="string" ItemsSource="@tags" ChipType="ChipType.Input" CreateNewItem="@(text => text)" />'; $advanced='<ChipSet TItem="string" Label="Tags" @bind-ItemsSource="tags" ChipType="ChipType.Filter" SelectionType="SelectionType.Multi" SelectedItems="@selectedTags" CreateNewItem="@(text => text)" Watermark="Add tag" />' }
        '*.ChoiceGroup.Choice`1' { $minimal='<ChoiceGroup T="string" @bind-SelectedItem="choice"><Choice T="string" Value="A">Option A</Choice></ChoiceGroup>'; $advanced='<ChoiceGroup T="string" Label="Mode" @bind-SelectedItem="choice" GroupDirection="GroupDirection.Horizontal"><Choice T="string" Value="A">Automatic</Choice><Choice T="string" Value="M">Manual</Choice></ChoiceGroup>' }
        '*.ChoiceGroup.ChoiceGroup*' { $minimal='<ChoiceGroup T="string" @bind-SelectedItem="choice"><Choice T="string" Value="A">Option A</Choice></ChoiceGroup>'; $advanced='<ChoiceGroup T="string" Label="Mode" @bind-SelectedItem="choice" SelectionChanged="ModeChanged" Disabled="@locked"><Choice T="string" Value="A">Automatic</Choice><Choice T="string" Value="M">Manual</Choice></ChoiceGroup>' }
        '*.DropDown.BlankDropDown' { $minimal='<BlankDropDown @bind-IsOpen="open"><DisplayInfo>Choose</DisplayInfo><Content><p>Custom content</p></Content></BlankDropDown>'; $advanced='<BlankDropDown Label="Actions" Width="320px" ItemsPanelHeight="240" @bind-IsOpen="open" OnOpen="Opened" OnClose="Closed"><DisplayInfo>@summary</DisplayInfo><Content>@menu</Content></BlankDropDown>' }
        '*.DropDown.DropDown*' { $minimal='<DropDown TItem="string" Label="Color" ItemsSource="@colors" @bind-SelectedItem="color" />'; $advanced='<DropDown TItem="string" Label="Tags" ItemsSource="@tags" IsMultiSelect="true" @bind-SelectedItems="selectedTags" ItemTemplate="@RenderTag" Width="420px" />' }
        '*.Expander.Expander' { $minimal='<Expander @bind-IsOpen="open"><Header>Details</Header><ChildContent><p>More information</p></ChildContent></Expander>'; $advanced='<Expander ID="advanced" ClassName="settings" @bind-IsOpen="advancedOpen"><Header><strong>Advanced</strong></Header><ChildContent>@advancedSettings</ChildContent></Expander>' }
        '*.FitText.FitText' { $minimal='<FitText Text="Responsive heading" Width="320px" />'; $advanced='<FitText Compressor="1.2" Alignment="Alignment.Center" Width="100%" Height="80px"><strong>Dashboard</strong></FitText>' }
        '*.FloatingActionButton.FloatingActionButton' { $minimal='<FloatingActionButton Icon="IconTypes.Edit" OnClick="Edit" />'; $advanced='<FloatingActionButton ID="create" Icon="IconTypes.Edit" BottomNavigationIsVisible="true" IconCompressor="1.2" OnClickStopPropagation="true" OnClick="Create" />' }
        '*.Forms.TextField' { $minimal='<EditForm Model="@model"><TextField @bind-Value="model.Name" Label="Name" /></EditForm>'; $advanced='<EditForm Model="@model"><TextField ID="phone" @bind-Value="model.Phone" Label="Phone" Type="TextFieldType.tel" Mask="(000) 000-0000" CustomValidation="ValidatePhone" OnBlur="ValidateNow" /></EditForm>' }
        '*.Icon.Icon' { $minimal='<Icon IconType="IconTypes.Settings" />'; $advanced='<Icon ID="status-icon" IconType="IconTypes.CheckMark" ClassName="status" Style="font-size:24px" />' }
        '*.Label.Label' { $minimal='<Label Text="First name" />'; $advanced='<Label ID="account-label" Text="Account" Class="section-label" Disabled="@locked" Hidden="@hideLabel" />' }
        '*.LightDismiss.LightDismiss' { $minimal='<LightDismiss @bind-IsOpen="open" OnClose="Closed" />'; $advanced='<LightDismiss Layer="1000" @bind-IsOpen="overlayOpen" OnClose="CloseOverlay" />' }
        '*.Modal.Modal' { $minimal='<Modal @bind-ShowWindow="show"><Header>Confirm</Header><Content><p>Continue?</p></Content></Modal>'; $advanced='<Modal Width="640px" ShowHeader="true" CanLightDismiss="false" @bind-ShowWindow="show" OnClose="Closed"><Header><strong>Edit item</strong></Header><Content>@editor</Content></Modal>' }
        '*.Persona.Persona' { $minimal='<Persona FirstName="Ada" LastName="Lovelace" Title="Engineer" />'; $advanced='<Persona FirstName="Ada" LastName="Lovelace" Title="Engineer" UserImage="images/ada.jpg" Size="64" BorderRadius="32" BackgroundColor="var(--palette-ThemePrimary)" />' }
        '*.SpinButton.SpinButton' { $minimal='<SpinButton Label="Quantity" Type="SpinButtonType.Whole" @bind-WholeValue="quantity" />'; $advanced='<SpinButton Label="Opacity" Type="SpinButtonType.Decimal" MinValue="0" MaxValue="1" IncrementAmount="0.05" RoundingPlaces="2" Suffix="%" @bind-DecimalValue="opacity" />' }
        '*.Spinner.TinySpinner' { $minimal='<TinySpinner IsLoading="true" Size="SpinnerSize.xSmall" />'; $advanced='<TinySpinner ID="save-progress" IsLoading="@saving" Size="SpinnerSize.Small" ClassName="inline-progress" />' }
        '*.Spinner.Spinner' { $minimal='<Spinner IsLoading="true" Label="Loading" />'; $advanced='<Spinner @bind-IsLoading="loading" Label="Loading data" Position="SpinnerLabelPosition.Bottom" Size="SpinnerSize.Large" ClassName="page-spinner" />' }
        '*.Tabs.Tab' { $minimal='<Tabs><Tab Header="General"><p>General settings</p></Tab></Tabs>'; $advanced='<Tabs DefaultOpenTab="1"><Tab Header="General" Color="var(--palette-ThemePrimary)"><p>General</p></Tab><Tab Header="Security" Color="var(--palette-RedDark)"><p>Security</p></Tab></Tabs>' }
        '*.Tabs.Tabs' { $minimal='<Tabs><Tab Header="One"><p>First page</p></Tab><Tab Header="Two"><p>Second page</p></Tab></Tabs>'; $advanced='<Tabs Width="100%" Height="420px" DefaultOpenTab="1" TabContentCanScroll="true"><Tab Header="Summary">@summary</Tab><Tab Header="Details">@details</Tab></Tabs>' }
        '*.TextField.TextField' { $minimal='<TextField Label="Name" @bind-Value="name" />'; $advanced='<TextField ID="email" Label="Email" Type="TextFieldType.email" PlaceHolder="name@example.com" CharacterLimit="120" Width="100%" @bind-Value="email" OnBlur="ValidateEmail" />' }
        '*.TextField.ValidationInput' { $minimal='<EditForm Model="@model"><ValidationInput @bind-Value="model.Name" /></EditForm>'; $advanced='<EditForm Model="@model"><DataAnnotationsValidator /><ValidationInput DisplayName="Name" class="form-control" @bind-Value="model.Name" /><ValidationMessage For="@(() => model.Name)" /></EditForm>' }
        '*.Theme.Theme' { $minimal='<Theme>@Body</Theme>'; $advanced="@inject IThemeProvider ThemeProvider`n`n<Theme>@Body</Theme>`n`n@code {`n    void UseDark() => ThemeProvider.ChangeTheme(ThemeProvider.CreateTheme(new DarkThemePalette()));`n}" }
        '*.Toggle.Toggle' { $minimal='<Toggle Label="Notifications" @bind-IsChecked="notifications" />'; $advanced='<Toggle Label="Dark mode" LabelIsInline="true" @bind-IsChecked="darkMode" />' }
        '*.TreeMenu.BranchComponent*' { $minimal='<TreeMenu T="Node" Items="@roots" GetItems="LoadChildren" BranchDisplay="@RenderBranch" />'; $advanced='<TreeMenu T="Node" Items="@roots" GetItems="LoadChildren" @bind-SelectedItem="selected" BranchDisplay="@RenderBranch" />' }
        '*.TreeMenu.TreeMenu*' { $minimal='<TreeMenu T="Node" Items="@roots" GetItems="LoadChildren" BranchDisplay="@RenderBranch" />'; $advanced='<TreeMenu T="Node" Items="@roots" GetItems="LoadChildren" @bind-SelectedItem="selected" BranchDisplay="@RenderBranch" />' }
    }
    return @($minimal, $advanced)
}

function Format-ParameterTable($parameters, [string]$Marker) {
    $lines = New-Object Collections.Generic.List[string]
    $lines.Add("<!-- $Marker`:start -->")
    $lines.Add('| Name | Type | Default | Required | Binding | Declared by | Notes |')
    $lines.Add('|---|---|---|---|---|---|---|')
    foreach ($parameter in $parameters) {
        $default = [string]$parameter.default
        $default = $default.Replace('|', '\|')
        $note = (Get-ParameterNote $parameter).Replace('|', '\|')
        $lines.Add("| ``$($parameter.name)`` | ``$($parameter.type)`` | ``$default`` | $($parameter.required) | ``$($parameter.binding)`` | ``$($parameter.declaredBy)`` | $note |")
    }
    $lines.Add("<!-- $Marker`:end -->")
    return $lines -join "`n"
}

function Format-List($values, [string]$none='None.') {
    if ($null -eq $values -or $values.Count -eq 0) { return $none }
    return ($values | ForEach-Object { "- ``$_``" }) -join "`n"
}

function Get-ComponentSourceText($component) {
    $builder = New-Object Text.StringBuilder
    foreach ($source in $component.sourceFiles) {
        $path = Join-Path $RepositoryRoot $source
        if (Test-Path $path) { [void]$builder.AppendLine([IO.File]::ReadAllText($path)) }
    }
    return $builder.ToString()
}

function Get-RenderedStructure($component) {
    $razorPath = Join-Path $RepositoryRoot $component.source
    $razor = [IO.File]::ReadAllText($razorPath)
    $tags = [regex]::Matches($razor, '<(?<tag>[A-Za-z][A-Za-z0-9]*)\b') | ForEach-Object { $_.Groups['tag'].Value } | Where-Object { $_.Length -gt 1 } | Sort-Object -Unique
    $html = @($tags | Where-Object { [char]::IsLower($_[0]) })
    $components = @($tags | Where-Object { [char]::IsUpper($_[0]) })
    $lines = New-Object Collections.Generic.List[string]
    if ($html.Count -gt 0) { $lines.Add('- HTML elements observed in the Razor source: ' + (($html | ForEach-Object { "``$_``" }) -join ', ') + '.') }
    if ($components.Count -gt 0) { $lines.Add('- Composed component elements observed in the Razor source: ' + (($components | ForEach-Object { "``$_``" }) -join ', ') + '.') }
    if ($lines.Count -eq 0) { $lines.Add('- The component emits its content through C# render logic or fragments; inspect the linked source for conditional branches.') }
    $lines.Add('- Elements may be conditional on parameters and internal state. Attribute forwarding is limited to the parameters shown in the contract table; do not assume arbitrary attributes reach the root.')
    return $lines -join "`n"
}

function Get-LifecycleSummary($sourceText) {
    $pattern = '(?m)\b(?:Task|ValueTask|void|bool)\s+(?<name>OnInitializedAsync|OnInitialized|OnParametersSetAsync|OnParametersSet|OnAfterRenderAsync|OnAfterRender|DisposeAsync|Dispose|ShouldRender)\s*\('
    $methods = @([regex]::Matches($sourceText, $pattern) | ForEach-Object { $_.Groups['name'].Value } | Sort-Object -Unique)
    if ($methods.Count -eq 0) { return "No lifecycle method is overridden in this component's Razor/code-behind files; normal ComponentBase parameter assignment and rendering apply." }
    $lines = New-Object Collections.Generic.List[string]
    $lines.Add('Lifecycle methods implemented by this component: ' + (($methods | ForEach-Object { "``$_``" }) -join ', ') + '.')
    if ($methods -contains 'OnAfterRender' -or $methods -contains 'OnAfterRenderAsync') { $lines.Add('After-render work requires an interactive renderer; server prerendering alone cannot complete DOM or JavaScript work.') }
    if ($sourceText.Contains('firstRender')) { $lines.Add('The implementation contains a ``firstRender`` branch; initialization performed there is not repeated on ordinary re-renders.') }
    if ($methods -contains 'Dispose' -or $methods -contains 'DisposeAsync') { $lines.Add('The component owns disposable state; allow the renderer to dispose it instead of retaining detached instances.') }
    return ($lines | ForEach-Object { '- ' + $_ }) -join "`n"
}

function Get-CallbackSemantics($component, $sourceText) {
    if ($component.fullName -eq 'AppsByTAP.BlazorFluentUI.Components.Button.SubmitButton') {
        return '- `OnClick` (`EventCallback<MouseEventArgs>`) is invoked with the native click arguments by inherited `OnClickInternal` when `Disabled` is false. `ShowIsBusy` sets internal `IsBusy` around that callback only.'
    }
    $withoutLineComments = [regex]::Replace($sourceText, '(?m)^\s*//.*$', '')
    $callbacks = @($component.parameters | Where-Object { $_.type.StartsWith('EventCallback') })
    if ($callbacks.Count -eq 0) { return 'No EventCallback parameters are exposed.' }
    $lines = New-Object Collections.Generic.List[string]
    foreach ($callback in $callbacks) {
        $matches = @([regex]::Matches($withoutLineComments, ('\b' + [regex]::Escape($callback.name) + '\.InvokeAsync\((?<argument>[^)]*)\)')))
        if ($matches.Count -eq 0) {
            $lines.Add("- ``$($callback.name)`` is declared as ``$($callback.type)``; no direct InvokeAsync call is observable in this component's source files. A wrapper/base implementation may invoke it, or the current API may be inert.")
        } else {
            $arguments = @($matches | ForEach-Object { $_.Groups['argument'].Value.Trim() } | ForEach-Object { if ([string]::IsNullOrWhiteSpace($_)) { 'no payload' } else { $_ } } | Sort-Object -Unique)
            $lines.Add("- ``$($callback.name)`` (``$($callback.type)``) is invoked with " + (($arguments | ForEach-Object { "``$_``" }) -join ', ') + '.')
        }
    }
    return $lines -join "`n"
}

function Get-ExceptionSummary($sourceText) {
    $matches = @([regex]::Matches($sourceText, 'throw\s+new\s+(?<type>[A-Za-z_][A-Za-z0-9_]*)(?<arguments>\([^;]*?\))?\s*;'))
    if ($matches.Count -eq 0) { return 'No exception is thrown explicitly in the component source. Consumer callbacks, invalid templates/data, and JavaScript interop can still propagate their own failures.' }
    return ($matches | ForEach-Object {
        $expression = ($_.Groups['type'].Value + $_.Groups['arguments'].Value).Replace("`r", ' ').Replace("`n", ' ').Replace('|', '\|')
        "- Explicit source throw: ``$expression``."
    } | Sort-Object -Unique) -join "`n"
}

function Get-AssociatedTypes($component) {
    $common = @('bool','bool?','int','int?','double','double?','string','object','RenderFragment','EventCallback','EventCallback<MouseEventArgs>')
    $types = @($component.parameters.type + $component.cascadingParameters.type | Where-Object { $_ -and ($_ -notin $common) } | Sort-Object -Unique)
    if ($types.Count -eq 0) { return 'No non-scalar supporting types beyond framework primitives.' }
    return ($types | ForEach-Object { "- ``$_``" }) -join "`n"
}

function Get-StaticAssetSummary($component) {
    $css = @($component.sourceFiles | Where-Object { $_.EndsWith('.razor.css') })
    $lines = New-Object Collections.Generic.List[string]
    if ($css.Count -gt 0) { $lines.Add('- CSS isolation inputs: ' + (($css | ForEach-Object { "``$_``" }) -join ', ') + '. They are bundled by the Razor class library build.') }
    else { $lines.Add('- No component-scoped ``.razor.css`` file is associated with this component.') }
    if ($component.javaScriptModules.Count -gt 0) { $lines.Add('- Runtime JavaScript module imports: ' + (($component.javaScriptModules | ForEach-Object { "``$_``" }) -join ', ') + '.') }
    else { $lines.Add('- No direct JavaScript module import is observable in this component source.') }
    if ($component.fullName -eq 'AppsByTAP.BlazorFluentUI.Components.Icon.Icon') { $lines.Add('- The host must load ``_content/AppsByTAP.BlazorFluentUI.Components/css/fabric-icons-inline.css`` for glyphs to render.') }
    return $lines -join "`n"
}

foreach ($component in $inventory.components) {
    $slug = Get-Slug $component
    $description = Get-Description $component.fullName
    $genericYaml = if ($component.genericParameters.Count -eq 0) { '[]' } else { '[' + (($component.genericParameters | ForEach-Object { '"' + $_ + '"' }) -join ', ') + ']' }
    $sourceLink = '../../../' + $component.source
    $sources = ($component.sourceFiles | ForEach-Object { '- [' + ([IO.Path]::GetFileName($_)) + '](../../../' + $_ + ')' }) -join "`n"
    $parameters = Format-ParameterTable $component.parameters 'parameters'
    $cascading = Format-ParameterTable $component.cascadingParameters 'cascading-parameters'
    $genericDisplay = Format-List $component.genericParameters
    $services = Format-List $component.injectedServices
    $modules = Format-List $component.javaScriptModules
    $tokens = Format-List $component.themeTokens 'No CSS custom properties are referenced directly by this component source.'
    $gotchas = (Get-Gotchas $component.fullName | ForEach-Object { '- ' + $_ }) -join "`n"
    $examples = Get-Examples $component
    $accessibility = Get-Accessibility $component.fullName
    $sourceText = Get-ComponentSourceText $component
    $renderedStructure = Get-RenderedStructure $component
    $lifecycle = Get-LifecycleSummary $sourceText
    $callbacks = Get-CallbackSemantics $component $sourceText
    $exceptions = Get-ExceptionSummary $sourceText
    $associatedTypes = Get-AssociatedTypes $component
    $staticAssets = Get-StaticAssetSummary $component
    $content = @"
---
type: Blazor Component
title: "$($component.displayType)"
description: "$description"
resource: "$sourceLink"
tags: [blazor, fluent-ui, component, api-reference]
status: stable
dotnet_type: "$($component.fullName)"
component_source: "$($component.source)"
generic_parameters: $genericYaml
generated: { by: codex/gpt-5, at: 2026-08-14T00:00:00-04:00 }
verified: { by: "process:okf-docs-validator", at: 2026-08-14T00:00:00-04:00 }
verification_scope: api-contract-links-examples-and-theme-tokens
sources:
  - id: component-source
    resource: "$sourceLink"
    title: "$($component.name) Razor source"
---

# $($component.displayType)

$description

## Contract

- Namespace: ``$($component.namespace)``
- Compiled type: ``$($component.namespace).$($component.displayType)``
- Base type: ``$($component.baseType)``
- Intended level: $(if ($component.name -in @('BaseButton','BlankDropDown','BranchComponent','Choice','Tab','TinySpinner','ValidationInput')) { 'low-level or composition component; use directly only when its contract fits the scenario.' } else { 'consumer-facing component.' })

### Generic type parameters

$genericDisplay

## Parameters

The table lists the effective runtime contract, including inherited library and framework parameters.

$parameters

## Cascading parameters

Cascading values are supplied by an ancestor and must not be invented as normal component attributes.

$cascading

## Examples

Minimal:

``````razor
$($examples[0])
``````

Configured/composed:

``````razor
$($examples[1])
``````

## Rendered structure

$renderedStructure

## Associated types

$associatedTypes

Exact enum members and model properties are listed in the [public supporting types reference](../references/public-types.md).

## Lifecycle and callback behavior

$lifecycle

$callbacks

## Rendering, services, and assets

Injected services:

$services

JavaScript modules:

$modules

Static asset contract:

$staticAssets

Source files:

$sources

## Styling and theme tokens

$tokens

The listed tokens are case-sensitive. Use the [Theme reference](theme.md) for their emitted values and customization rules.

## Accessibility

$accessibility

## Exceptions

$exceptions

## Gotchas and current limitations

$gotchas

## Related knowledge

- [Component index](index.md)
- [Architecture and binding conventions](../architecture-and-binding.md)
- [Public supporting types](../references/public-types.md)
- [Static assets and JavaScript interop](../references/static-assets-and-js.md)
"@
    Write-Utf8 (Join-Path $componentsRoot ($slug + '.md')) $content
}

$componentEntries = $inventory.components | Sort-Object name, fullName | ForEach-Object {
    $slug = Get-Slug $_
    '* [' + $_.displayType + '](' + $slug + '.md) - ' + (Get-Description $_.fullName)
}
Write-Utf8 (Join-Path $componentsRoot 'index.md') ("# Components`n`n" + ($componentEntries -join "`n"))

$publicTypes = New-Object Text.StringBuilder
[void]$publicTypes.AppendLine(@"
---
type: API Reference
title: Public supporting types
description: Every public non-component type exposed by the component assembly, including exact enum members and properties.
tags: [blazor, fluent-ui, api-reference, types]
status: stable
reference_id: public-types
generated: { by: codex/gpt-5, at: 2026-08-14T00:00:00-04:00 }
verified: { by: "process:okf-docs-validator", at: 2026-08-14T00:00:00-04:00 }
verification_scope: public-type-and-enum-surface
sources:
  - id: component-assembly
    resource: "../../../AppsByTAP.BlazorFluentUI.PlayGround/AppsByTAP.BlazorFluentUI.Components"
    title: Component library source
---

# Public supporting types

These types appear in parameters, callbacks, templates, theming, or composition APIs. Names and enum casing are exact.
"@)
foreach ($type in $inventory.supportingTypes) {
    [void]$publicTypes.AppendLine("`n## ``$($type.fullName)```n")
    [void]$publicTypes.AppendLine("Kind: **$($type.kind)**.`n")
    if ($type.members.Count -eq 0) { [void]$publicTypes.AppendLine('No declared public properties, events, or enum members.') }
    else { foreach ($member in $type.members) { [void]$publicTypes.AppendLine("- ``$member``") } }
}
Write-Utf8 (Join-Path $referencesRoot 'public-types.md') $publicTypes.ToString()

$themePage = Join-Path $componentsRoot 'theme.md'
$themeText = [IO.File]::ReadAllText($themePage)
$themeGuide = @'

## Provider registration and lifetime

Register `IThemeProvider` before rendering `Theme`. Use a scoped provider in Blazor Server so each circuit/user owns its theme. A singleton shares one mutable theme across every server circuit. In WebAssembly, singleton is appropriate because the application runs in one browser process.

```csharp
// Blazor Server: one theme provider per circuit.
builder.Services.AddScoped<IThemeProvider>(_ =>
    new ThemeProvider(new LightThemePalette()));

// Blazor WebAssembly: one provider for the browser application.
builder.Services.AddSingleton<IThemeProvider>(
    new ThemeProvider(new LightThemePalette()));
```

The parameterless `ThemeProvider()` constructor starts with `DarkThemePalette`. Passing a palette to the constructor makes the initial selection explicit.

## Runtime theme switching

`IThemeProvider.Theme` exposes the current `Models.Theme`. `CreateTheme(IPalette)` derives semantic colors; `ChangeTheme(Models.Theme)` stores it and raises `ThemeChanged`. The `Theme` component listens to that event, re-renders its style block, and every descendant using the variables updates through CSS.

```csharp
@inject IThemeProvider ThemeProvider

void UseLight() => ThemeProvider.ChangeTheme(
    ThemeProvider.CreateTheme(new LightThemePalette()));

void UseDark() => ThemeProvider.ChangeTheme(
    ThemeProvider.CreateTheme(new DarkThemePalette()));
```

`Theme` emits the variables on `:root`, applies body font/background/text rules globally, and wraps `ChildContent` in an extra `div`. It subscribes to `ThemeChanged` during initialization; current source does not implement `IDisposable` or unsubscribe.

## Creating a custom palette

All 50 `IPalette` properties are required. The safest light-theme customization is to derive from `LightThemePalette` and override only the virtual values that change:

```csharp
public sealed class BrandLightPalette : LightThemePalette
{
    public override string ThemePrimary => "#5c2d91";
    public override string ThemeDarkAlt => "#4b2477";
    public override string ThemeDark => "#3b1c5f";
    public override string Accent => ThemePrimary;
}
```

For a dark theme, derive from `DarkThemePalette`:

```csharp
public sealed class BrandDarkPalette : DarkThemePalette
{
    public override string ThemePrimary => "#b4a0ff";
    public override string Accent => ThemePrimary;
}
```

This inheritance choice affects behavior: `ThemeProvider.CreateTheme` tests `palette is DarkThemePalette`. A custom class that merely implements `IPalette` is treated as light even if its colors are dark. Implementing `IPalette` directly is supported, but requires all 50 properties and produces light semantic branching unless the type also derives from `DarkThemePalette`.

## CSS variable naming and derivation

- Palette property `ThemePrimary` becomes `--palette-ThemePrimary`.
- Semantic color property `ButtonBackground` becomes `--semanticColors-ButtonBackground`.
- Semantic text property `ButtonText` becomes `--semanticTextColors-ButtonText`.
- Names and casing are exact; semantic text tokens must not use the `semanticColors` prefix.
- `ScrollbarTrack` and `ScrollbarThumb` are concrete `LightSemanticColors` properties and are emitted at runtime even though the current `ISemanticColors` interface omits them.
- `--label-font-weight` and `--label-padding-bottom` are appended directly by `Theme` rather than coming from a C# theme interface.

Use semantic tokens for contextual states and text, and palette tokens for raw color choices. Component CSS should not invent fallback token names.
'@
$tokenTables = New-Object Text.StringBuilder
[void]$tokenTables.AppendLine("`n## Complete emitted CSS-variable reference`n")
[void]$tokenTables.AppendLine('Theme emits exactly 141 variables: 50 palette colors, 58 semantic colors (including the concrete scrollbar properties), 31 semantic text colors, and two label layout variables. Values below are the runtime results for the built-in palettes.')
foreach ($prefix in @('--palette-', '--semanticColors-', '--semanticTextColors-', '--label-')) {
    $heading = switch ($prefix) { '--palette-' {'Palette variables (50)'} '--semanticColors-' {'Semantic color variables (58)'} '--semanticTextColors-' {'Semantic text variables (31)'} default {'Label variables (2)'} }
    [void]$tokenTables.AppendLine("`n### $heading`n")
    [void]$tokenTables.AppendLine('| CSS variable | Light | Dark |')
    [void]$tokenTables.AppendLine('|---|---|---|')
    foreach ($token in $inventory.themeTokenValues | Where-Object { $_.name.StartsWith($prefix) } | Sort-Object name) {
        [void]$tokenTables.AppendLine("| ``$($token.name)`` | ``$($token.lightValue)`` | ``$($token.darkValue)`` |")
    }
}
$themeText = $themeText.Replace('## Related knowledge', $themeGuide + $tokenTables.ToString() + "`n## Related knowledge")
Write-Utf8 $themePage $themeText
