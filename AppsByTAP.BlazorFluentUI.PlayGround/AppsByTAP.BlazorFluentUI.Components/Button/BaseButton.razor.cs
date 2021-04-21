using Microsoft.AspNetCore.Components;
using System;

namespace AppsByTAP.BlazorFluentUI.Components.Button
{
    public class BaseButtonViewModel : ButtonBaseParameters
    {
        [Parameter]
        public string SecondaryText { get; set; }

    }
}
