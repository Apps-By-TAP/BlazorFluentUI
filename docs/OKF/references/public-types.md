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

## `AppsByTAP.BlazorFluentUI.Components.BaseComponent.BaseComponentViewModel`

Kind: **class**.

- `ClassName: string`
- `ID: string`
- `Style: string`

## `AppsByTAP.BlazorFluentUI.Components.BaseComponent.LayerCounter`

Kind: **class**.

No declared public properties, events, or enum members.

## `AppsByTAP.BlazorFluentUI.Components.BaseComponent.SelectionType`

Kind: **enum**.

- `Single`
- `Multi`

## `AppsByTAP.BlazorFluentUI.Components.Button.BaseButtonViewModel`

Kind: **class**.

- `SecondaryText: string`

## `AppsByTAP.BlazorFluentUI.Components.Button.ButtonBaseParameters`

Kind: **class**.

- `Disabled: bool`
- `Icon: IconTypes`
- `IsBusy: bool`
- `IsPrimary: bool`
- `OnClick: EventCallback<MouseEventArgs>`
- `OnClickStopPropagation: bool`
- `ShowIsBusy: bool`
- `Text: string`

## `AppsByTAP.BlazorFluentUI.Components.Button.CompoundButtonViewModel`

Kind: **class**.

- `SecondaryText: string`

## `AppsByTAP.BlazorFluentUI.Components.Button.HiddenValue`

Kind: **class**.

- `Name: string`
- `Value: string`

## `AppsByTAP.BlazorFluentUI.Components.Button.HyperLinkButtonViewModel`

Kind: **class**.

- `IsBusyColor1: string`
- `IsBusyColor2: string`
- `JSRuntime: IJSRuntime`
- `TargetType: TargetTypes`
- `Url: string`

## `AppsByTAP.BlazorFluentUI.Components.Button.PostButtonViewModel`

Kind: **class**.

- `Disabled: bool`
- `FormID: string`
- `FormIDChanged: EventCallback<string>`
- `HiddenValues: List<HiddenValue>`
- `IsPrimary: bool`
- `Text: string`
- `Url: string`

## `AppsByTAP.BlazorFluentUI.Components.Button.SplitButtonViewModel`1`

Kind: **class**.

- `CanLightDismiss: bool`
- `DropDownTemplate: RenderFragment<T>`
- `ItemsSource: List<T>`
- `SelectedItem: T`
- `SelectedItemChanged: EventCallback<T>`
- `SelectedItemTemplate: RenderFragment<T>`
- `Width: string`

## `AppsByTAP.BlazorFluentUI.Components.Button.TargetTypes`

Kind: **enum**.

- `Self`
- `Blank`
- `Parent`
- `Top`

## `AppsByTAP.BlazorFluentUI.Components.Button.TemplateButtonViewModel`

Kind: **class**.

- `Border: string`
- `BorderRadius: string`
- `ChildContent: RenderFragment`

## `AppsByTAP.BlazorFluentUI.Components.CheckBox.BoxSide`

Kind: **enum**.

- `Start`
- `End`

## `AppsByTAP.BlazorFluentUI.Components.CheckBox.CheckBoxChangedArgs`

Kind: **class**.

- `IsChecked: bool`
- `ViewModel: CheckBoxViewModel`

## `AppsByTAP.BlazorFluentUI.Components.CheckBox.CheckBoxViewModel`

Kind: **class**.

- `BoxSide: BoxSide`
- `IsChecked: bool`
- `IsCheckedChanged: EventCallback<bool>`
- `Label: string`
- `OnChanged: EventCallback<CheckBoxChangedArgs>`

## `AppsByTAP.BlazorFluentUI.Components.Chip.ChipSetViewModel`1`

Kind: **class**.

- `ChipType: ChipType`
- `CreateNewItem: Func<string, T>`
- `ItemsSource: List<T>`
- `ItemsSourceChanged: EventCallback<List<T>>`
- `Label: string`
- `SelectedItem: T`
- `SelectedItems: List<T>`
- `SelectionType: SelectionType`
- `Watermark: string`

## `AppsByTAP.BlazorFluentUI.Components.Chip.ChipType`

Kind: **enum**.

- `Input`
- `Choice`
- `Filter`
- `Action`

## `AppsByTAP.BlazorFluentUI.Components.Chip.ChipViewModel`

Kind: **class**.

- `ChipType: ChipType`
- `GroupIndex: int`
- `OnEdit: EventCallback<string>`
- `OnRemove: EventCallback<string>`
- `Text: string`

## `AppsByTAP.BlazorFluentUI.Components.Common.GroupDirection`

Kind: **enum**.

- `Vertical`
- `Horizontal`

## `AppsByTAP.BlazorFluentUI.Components.Common.LabelPosition`

Kind: **enum**.

- `Above`
- `Left`

## `AppsByTAP.BlazorFluentUI.Components.DropDown.DropDownItemType`

Kind: **enum**.

- `Item`
- `Header`

## `AppsByTAP.BlazorFluentUI.Components.DropDown.DropDownItem`1`

Kind: **class**.

- `IsSelected: bool`
- `Item: T`
- `Type: DropDownItemType`

## `AppsByTAP.BlazorFluentUI.Components.DropDown.DropDownViewModel`1`

Kind: **class**.

- `Disabled: bool`
- `IsMultiSelect: bool`
- `IsOpen: bool`
- `IsOpenChanged: EventCallback<bool>`
- `ItemTemplate: RenderFragment<T>`
- `ItemsSource: List<T>`
- `Label: string`
- `OnClickStopPropagation: bool`
- `SelectedItem: T`
- `SelectedItemChanged: EventCallback<T>`
- `SelectedItems: IEnumerable<T>`
- `SelectedItemsChanged: EventCallback<IEnumerable<T>>`
- `Width: string`

## `AppsByTAP.BlazorFluentUI.Components.Expander.ExpanderViewModel`

Kind: **class**.

- `ChildContent: RenderFragment`
- `Header: RenderFragment`
- `IsOpen: bool`
- `IsOpenChanged: EventCallback<bool>`

## `AppsByTAP.BlazorFluentUI.Components.FitText.Alignment`

Kind: **enum**.

- `Left`
- `Center`
- `Right`

## `AppsByTAP.BlazorFluentUI.Components.Forms.ValidationResult`1`

Kind: **class**.

- `Result: T`
- `Success: bool`
- `ValidationErrorMessage: string`

## `AppsByTAP.BlazorFluentUI.Components.Icon.IconTypes`

Kind: **enum**.

- `None`
- `AlertSettings`
- `AlertSolid`
- `AlignJustify`
- `Bank`
- `BankSolid`
- `BulletedListText`
- `Calculator`
- `Calendar`
- `Cancel`
- `CheckMark`
- `ChevronDown`
- `ChevronUp`
- `ChromeClose`
- `ChromeFullScreen`
- `CirclePause`
- `CirclePauseSolid`
- `CircleStop`
- `CircleStopSolid`
- `ClearFilter`
- `Delete`
- `DrillDown`
- `DrillDownSolid`
- `Edit`
- `EditMirrored`
- `EditSolid12`
- `EditSolidMirrored12`
- `FavoriteStar`
- `FavoriteStarFill`
- `Filter`
- `FilterSolid`
- `IncidentTriangle`
- `Mail`
- `MailSolid`
- `More`
- `MoreVertical`
- `Pause`
- `Play`
- `PlaySolid`
- `PowerButton`
- `ReceiptProcessing`
- `RemoveFilter`
- `Search`
- `Settings`
- `SettingsSync`
- `ShieldAlert`
- `StatusCircleErrorX`
- `Stop`
- `StopSolid`
- `SyncError`
- `SyncStatus`
- `SyncStatusSolid`
- `Uneditable2`
- `Uneditable2Mirrored`
- `UneditableSolid12`
- `UneditableSolidMirrored12`
- `UnsyncOccurence`
- `UserSync`

## `AppsByTAP.BlazorFluentUI.Components.Icon.IconViewModel`

Kind: **class**.

- `IconType: IconTypes`

## `AppsByTAP.BlazorFluentUI.Components.Modal.ModalViewModel`

Kind: **class**.

- `CanLightDismiss: bool`
- `Content: RenderFragment`
- `Header: RenderFragment`
- `OnClose: EventCallback`
- `ShowHeader: bool`
- `ShowWindow: bool`
- `ShowWindowChanged: EventCallback<bool>`
- `Width: string`

## `AppsByTAP.BlazorFluentUI.Components.Persona.PersonaViewModel`

Kind: **class**.

- `BackgroundColor: string`
- `BorderRadius: int`
- `FirstName: string`
- `Initials: string`
- `LastName: string`
- `Size: int`
- `Title: string`
- `UserImage: string`

## `AppsByTAP.BlazorFluentUI.Components.SpinButton.SpinButtonType`

Kind: **enum**.

- `Whole`
- `Decimal`

## `AppsByTAP.BlazorFluentUI.Components.Spinner.SpinnerLabelPosition`

Kind: **enum**.

- `Top`
- `Bottom`
- `Left`
- `Right`

## `AppsByTAP.BlazorFluentUI.Components.Spinner.SpinnerSize`

Kind: **enum**.

- `Large`
- `Medium`
- `Small`
- `xSmall`

## `AppsByTAP.BlazorFluentUI.Components.Spinner.SpinnerViewModel`

Kind: **class**.

- `IsLoading: bool`
- `IsLoadingChanged: EventCallback<bool>`
- `Label: string`
- `Position: SpinnerLabelPosition`
- `Size: SpinnerSize`

## `AppsByTAP.BlazorFluentUI.Components.TextField.TextFieldType`

Kind: **enum**.

- `text`
- `number`
- `tel`
- `email`
- `password`

## `AppsByTAP.BlazorFluentUI.Components.Theme.Models.IThemeProvider`

Kind: **interface**.

- `Theme: Theme`
- `ThemeChanged: Action<Theme>`

## `AppsByTAP.BlazorFluentUI.Components.Theme.Models.Theme`

Kind: **class**.

- `Palette: IPalette`
- `SemanticColors: ISemanticColors`
- `SemanticTextColors: ISemanticTextColors`

## `AppsByTAP.BlazorFluentUI.Components.Theme.Models.ThemeProvider`

Kind: **class**.

- `Theme: Theme`
- `ThemeChanged: Action<Theme>`

## `AppsByTAP.BlazorFluentUI.Components.Theme.Themes.Dark.DarkSemanticColors`

Kind: **class**.

No declared public properties, events, or enum members.

## `AppsByTAP.BlazorFluentUI.Components.Theme.Themes.Dark.DarkSemanticTextColors`

Kind: **class**.

No declared public properties, events, or enum members.

## `AppsByTAP.BlazorFluentUI.Components.Theme.Themes.Dark.DarkThemePalette`

Kind: **class**.

- `Accent: string`
- `Black: string`
- `BlackTranslucent40: string`
- `Blue: string`
- `BlueDark: string`
- `BlueLight: string`
- `BlueMid: string`
- `Green: string`
- `GreenDark: string`
- `GreenLight: string`
- `Magenta: string`
- `MagentaDark: string`
- `MagentaLight: string`
- `NeutralDark: string`
- `NeutralLight: string`
- `NeutralLighter: string`
- `NeutralLighterAlt: string`
- `NeutralPrimary: string`
- `NeutralPrimaryAlt: string`
- `NeutralQuaternary: string`
- `NeutralQuaternaryAlt: string`
- `NeutralSecondary: string`
- `NeutralSecondaryAlt: string`
- `NeutralTertiary: string`
- `NeutralTertiaryAlt: string`
- `Orange: string`
- `OrangeLight: string`
- `OrangeLighter: string`
- `Purple: string`
- `PurpleDark: string`
- `PurpleLight: string`
- `Red: string`
- `RedDark: string`
- `Teal: string`
- `TealDark: string`
- `TealLight: string`
- `ThemeDark: string`
- `ThemeDarkAlt: string`
- `ThemeDarker: string`
- `ThemeLight: string`
- `ThemeLighter: string`
- `ThemeLighterAlt: string`
- `ThemePrimary: string`
- `ThemeSecondary: string`
- `ThemeTertiary: string`
- `White: string`
- `WhiteTranslucent40: string`
- `Yellow: string`
- `YellowDark: string`
- `YellowLight: string`

## `AppsByTAP.BlazorFluentUI.Components.Theme.Themes.IPalette`

Kind: **interface**.

- `Accent: string`
- `Black: string`
- `BlackTranslucent40: string`
- `Blue: string`
- `BlueDark: string`
- `BlueLight: string`
- `BlueMid: string`
- `Green: string`
- `GreenDark: string`
- `GreenLight: string`
- `Magenta: string`
- `MagentaDark: string`
- `MagentaLight: string`
- `NeutralDark: string`
- `NeutralLight: string`
- `NeutralLighter: string`
- `NeutralLighterAlt: string`
- `NeutralPrimary: string`
- `NeutralPrimaryAlt: string`
- `NeutralQuaternary: string`
- `NeutralQuaternaryAlt: string`
- `NeutralSecondary: string`
- `NeutralSecondaryAlt: string`
- `NeutralTertiary: string`
- `NeutralTertiaryAlt: string`
- `Orange: string`
- `OrangeLight: string`
- `OrangeLighter: string`
- `Purple: string`
- `PurpleDark: string`
- `PurpleLight: string`
- `Red: string`
- `RedDark: string`
- `Teal: string`
- `TealDark: string`
- `TealLight: string`
- `ThemeDark: string`
- `ThemeDarkAlt: string`
- `ThemeDarker: string`
- `ThemeLight: string`
- `ThemeLighter: string`
- `ThemeLighterAlt: string`
- `ThemePrimary: string`
- `ThemeSecondary: string`
- `ThemeTertiary: string`
- `White: string`
- `WhiteTranslucent40: string`
- `Yellow: string`
- `YellowDark: string`
- `YellowLight: string`

## `AppsByTAP.BlazorFluentUI.Components.Theme.Themes.ISemanticColors`

Kind: **interface**.

- `AccentButtonBackground: string`
- `BlockingBackground: string`
- `BodyBackground: string`
- `BodyBackgroundChecked: string`
- `BodyBackgroundHovered: string`
- `BodyDivider: string`
- `BodyFrameBackground: string`
- `BodyFrameDivider: string`
- `BodyStandoutBackground: string`
- `ButtonBackground: string`
- `ButtonBackgroundChecked: string`
- `ButtonBackgroundCheckedHovered: string`
- `ButtonBackgroundDisabled: string`
- `ButtonBackgroundHovered: string`
- `ButtonBackgroundPressed: string`
- `ButtonBorder: string`
- `ButtonBorderDisabled: string`
- `DefaultStateBackground: string`
- `DisabledBackground: string`
- `DisabledBorder: string`
- `ErrorBackground: string`
- `FocusBorder: string`
- `InputBackground: string`
- `InputBackgroundChecked: string`
- `InputBackgroundCheckedHovered: string`
- `InputBorder: string`
- `InputBorderHovered: string`
- `InputFocusBorderAlt: string`
- `InputForegroundChecked: string`
- `InputIcon: string`
- `InputIconDisabled: string`
- `InputIconHovered: string`
- `InputPlaceholderBackgroundChecked: string`
- `ListBackground: string`
- `ListHeaderBackgroundHovered: string`
- `ListHeaderBackgroundPressed: string`
- `ListItemBackgroundChecked: string`
- `ListItemBackgroundCheckedHovered: string`
- `ListItemBackgroundHovered: string`
- `MenuBackground: string`
- `MenuDivider: string`
- `MenuHeader: string`
- `MenuIcon: string`
- `MenuItemBackgroundHovered: string`
- `MenuItemBackgroundPressed: string`
- `PrimaryButtonBackground: string`
- `PrimaryButtonBackgroundDisabled: string`
- `PrimaryButtonBackgroundHovered: string`
- `PrimaryButtonBackgroundPressed: string`
- `PrimaryButtonBorder: string`
- `SmallInputBorder: string`
- `SuccessBackground: string`
- `VariantBorder: string`
- `VariantBorderHovered: string`
- `WarningBackground: string`
- `WarningHighlight: string`

## `AppsByTAP.BlazorFluentUI.Components.Theme.Themes.ISemanticTextColors`

Kind: **interface**.

- `AccentButtonText: string`
- `ActionLink: string`
- `ActionLinkHovered: string`
- `BodySubtext: string`
- `BodyText: string`
- `BodyTextChecked: string`
- `ButtonText: string`
- `ButtonTextChecked: string`
- `ButtonTextCheckedHovered: string`
- `ButtonTextDisabled: string`
- `ButtonTextHovered: string`
- `ButtonTextPressed: string`
- `DisabledBodySubtext: string`
- `DisabledBodyText: string`
- `DisabledSubtext: string`
- `DisabledText: string`
- `ErrorText: string`
- `InputPlaceholderText: string`
- `InputText: string`
- `InputTextHovered: string`
- `Link: string`
- `LinkHovered: string`
- `ListText: string`
- `MenuItemText: string`
- `MenuItemTextHovered: string`
- `PrimaryButtonText: string`
- `PrimaryButtonTextDisabled: string`
- `PrimaryButtonTextHovered: string`
- `PrimaryButtonTextPressed: string`
- `SuccessText: string`
- `WarningText: string`

## `AppsByTAP.BlazorFluentUI.Components.Theme.Themes.Light.LightSemanticTextColors`

Kind: **class**.

- `AccentButtonText: string`
- `ActionLink: string`
- `ActionLinkHovered: string`
- `BodySubtext: string`
- `BodyText: string`
- `BodyTextChecked: string`
- `ButtonText: string`
- `ButtonTextChecked: string`
- `ButtonTextCheckedHovered: string`
- `ButtonTextDisabled: string`
- `ButtonTextHovered: string`
- `ButtonTextPressed: string`
- `DisabledBodySubtext: string`
- `DisabledBodyText: string`
- `DisabledSubtext: string`
- `DisabledText: string`
- `ErrorText: string`
- `InputPlaceholderText: string`
- `InputText: string`
- `InputTextHovered: string`
- `Link: string`
- `LinkHovered: string`
- `ListText: string`
- `MenuItemText: string`
- `MenuItemTextHovered: string`
- `PrimaryButtonText: string`
- `PrimaryButtonTextDisabled: string`
- `PrimaryButtonTextHovered: string`
- `PrimaryButtonTextPressed: string`
- `SuccessText: string`
- `WarningText: string`

## `AppsByTAP.BlazorFluentUI.Components.Theme.Themes.Light.LightThemePalette`

Kind: **class**.

- `Accent: string`
- `Black: string`
- `BlackTranslucent40: string`
- `Blue: string`
- `BlueDark: string`
- `BlueLight: string`
- `BlueMid: string`
- `Green: string`
- `GreenDark: string`
- `GreenLight: string`
- `Magenta: string`
- `MagentaDark: string`
- `MagentaLight: string`
- `NeutralDark: string`
- `NeutralLight: string`
- `NeutralLighter: string`
- `NeutralLighterAlt: string`
- `NeutralPrimary: string`
- `NeutralPrimaryAlt: string`
- `NeutralQuaternary: string`
- `NeutralQuaternaryAlt: string`
- `NeutralSecondary: string`
- `NeutralSecondaryAlt: string`
- `NeutralTertiary: string`
- `NeutralTertiaryAlt: string`
- `Orange: string`
- `OrangeLight: string`
- `OrangeLighter: string`
- `Purple: string`
- `PurpleDark: string`
- `PurpleLight: string`
- `Red: string`
- `RedDark: string`
- `Teal: string`
- `TealDark: string`
- `TealLight: string`
- `ThemeDark: string`
- `ThemeDarkAlt: string`
- `ThemeDarker: string`
- `ThemeLight: string`
- `ThemeLighter: string`
- `ThemeLighterAlt: string`
- `ThemePrimary: string`
- `ThemeSecondary: string`
- `ThemeTertiary: string`
- `White: string`
- `WhiteTranslucent40: string`
- `Yellow: string`
- `YellowDark: string`
- `YellowLight: string`

## `AppsByTAP.BlazorFluentUI.Components.Theme.Themes.LightSemanticColors`

Kind: **class**.

- `AccentButtonBackground: string`
- `BlockingBackground: string`
- `BodyBackground: string`
- `BodyBackgroundChecked: string`
- `BodyBackgroundHovered: string`
- `BodyDivider: string`
- `BodyFrameBackground: string`
- `BodyFrameDivider: string`
- `BodyStandoutBackground: string`
- `ButtonBackground: string`
- `ButtonBackgroundChecked: string`
- `ButtonBackgroundCheckedHovered: string`
- `ButtonBackgroundDisabled: string`
- `ButtonBackgroundHovered: string`
- `ButtonBackgroundPressed: string`
- `ButtonBorder: string`
- `ButtonBorderDisabled: string`
- `DefaultStateBackground: string`
- `DisabledBackground: string`
- `DisabledBorder: string`
- `ErrorBackground: string`
- `FocusBorder: string`
- `InputBackground: string`
- `InputBackgroundChecked: string`
- `InputBackgroundCheckedHovered: string`
- `InputBorder: string`
- `InputBorderHovered: string`
- `InputFocusBorderAlt: string`
- `InputForegroundChecked: string`
- `InputIcon: string`
- `InputIconDisabled: string`
- `InputIconHovered: string`
- `InputPlaceholderBackgroundChecked: string`
- `ListBackground: string`
- `ListHeaderBackgroundHovered: string`
- `ListHeaderBackgroundPressed: string`
- `ListItemBackgroundChecked: string`
- `ListItemBackgroundCheckedHovered: string`
- `ListItemBackgroundHovered: string`
- `MenuBackground: string`
- `MenuDivider: string`
- `MenuHeader: string`
- `MenuIcon: string`
- `MenuItemBackgroundHovered: string`
- `MenuItemBackgroundPressed: string`
- `PrimaryButtonBackground: string`
- `PrimaryButtonBackgroundDisabled: string`
- `PrimaryButtonBackgroundHovered: string`
- `PrimaryButtonBackgroundPressed: string`
- `PrimaryButtonBorder: string`
- `ScrollbarThumb: string`
- `ScrollbarTrack: string`
- `SmallInputBorder: string`
- `SuccessBackground: string`
- `VariantBorder: string`
- `VariantBorderHovered: string`
- `WarningBackground: string`
- `WarningHighlight: string`

## `AppsByTAP.BlazorFluentUI.Components.TreeMenu.BranchItem`1`

Kind: **class**.

- `IsExpandable: bool`
- `RootItem: T`

## `AppsByTAP.BlazorFluentUI.Components.TreeMenu.Branch`1`

Kind: **class**.

- `ID: string`
- `IsExpandable: bool`
- `Items: List<BranchItem<T>>`
- `Parent: Branch<T>`
- `RootItem: T`

## `AppsByTAP.BlazorFluentUI.Components._Imports`

Kind: **class**.

No declared public properties, events, or enum members.
