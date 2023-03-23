﻿using Microsoft.AspNetCore.Components;

namespace AppsByTAP.BlazorFluentUI.Components.Label
{
    public partial class Label : ComponentBase
    {
        [Parameter]
        public string ID { get; set; }
        [Parameter]
        public string Text { get; set; }
        [Parameter]
        public string Class { get; set; }
        [Parameter]
        public bool Hide { get; set; }
        [Parameter]
        public bool Disabled { get; set; }
    }
}
