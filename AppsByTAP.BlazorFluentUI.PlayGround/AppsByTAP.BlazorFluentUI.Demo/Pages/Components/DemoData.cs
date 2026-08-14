using System;
using System.Collections.Generic;
using System.Linq;
using AppsByTAP.BlazorFluentUI.Components.Common;
using AppsByTAP.BlazorFluentUI.Components.DropDown;
using AppsByTAP.BlazorFluentUI.Components.Icon;
using Microsoft.AspNetCore.Components;

#nullable enable

namespace AppsByTAP.BlazorFluentUI.Demo.Pages.Components
{
    public static class DemoData
    {
        public static List<string> Fruits => new()
        {
            "Apple", "Banana", "Strawberry", "Blackberry", "Blueberry",
            "Raspberry", "Grapes", "Plum", "Pear"
        };

        public static List<string> Colors => new()
        {
            "Red", "Green", "Blue", "Yellow", "Purple", "Orange", "Pink", "Cyan"
        };

        public static List<string> Toppings => new()
        {
            "Cheese", "Pepperoni", "Mushrooms", "Onions", "Peppers", "Olives"
        };

        public static List<string> Tags => new()
        {
            "Blazor", "Fluent UI", ".NET", "Web", "C#"
        };

        public static List<DropDownItem<string>> DropdownGroups => new()
        {
            new DropDownItem<string>("Favorites", DropDownItemType.Header),
            new DropDownItem<string>("Apple", DropDownItemType.Item),
            new DropDownItem<string>("Banana", DropDownItemType.Item),
            new DropDownItem<string>("Cherry", DropDownItemType.Item),
            new DropDownItem<string>("Colors", DropDownItemType.Header),
            new DropDownItem<string>("Red", DropDownItemType.Item),
            new DropDownItem<string>("Green", DropDownItemType.Item),
            new DropDownItem<string>("Blue", DropDownItemType.Item),
            new DropDownItem<string>("Options", DropDownItemType.Header),
            new DropDownItem<string>("Option A", DropDownItemType.Item),
            new DropDownItem<string>("Option B", DropDownItemType.Item),
            new DropDownItem<string>("Option C", DropDownItemType.Item),
        };

        public static List<string> Countries => new()
        {
            "United States", "United Kingdom", "Canada", "Australia",
            "Germany", "France", "Japan", "Brazil"
        };

        public static List<string> Cities => new()
        {
            "New York", "London", "Tokyo", "Paris", "Sydney", "Berlin"
        };

        public static List<IconTypes> Icons => System.Enum.GetValues<IconTypes>().ToList();
    }

    public class WeatherForecast
    {
        public DateOnly Date { get; set; }
        public int TemperatureC { get; set; }
        public string? Summary { get; set; }
        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
    }
}
