using AppsByTAP.BlazorFluentUI.Components.BaseComponent;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;

namespace AppsByTAP.BlazorFluentUI.Components.Persona
{
    public class PersonaViewModel : BaseComponentViewModel
    {
        [Parameter]
        public int Size { get; set; } = 50;
        [Parameter]
        public string FirstName { get; set; } = null;
        [Parameter]
        public string LastName { get; set; } = null;
        public string Initials { get => (FirstName?.Substring(0, 1) ?? "") + (LastName?.Substring(0, 1) ?? ""); }
        [Parameter]
        public string Title { get; set; }
        public string BackgroundColor { get; set; }
        [Parameter]
        public string UserImage { get; set; }
        [Parameter]
        public int BorderRadius { get; set; } = 50;

        private List<string> _colors = new List<string>
        {
            "#498205",
            "#0b6a0b",
            "#038387",
            "#005b70",
            "#4f6bed",
            "#0078d4",
            "#004e8c",
            "#8764b8",
            "#5c2e91",
            "#881798",
            "#c239b3",
            "#e3008c",
            "#750b1c",
            "#d13438",
            "#a4262c",
            "#ca5010",
            "#8e562e",
            "#986f0b",
            "#7a7574",
            "#69797e",
        };

        protected override void OnInitialized()
        {
            base.OnInitialized();

            if (string.IsNullOrEmpty(BackgroundColor))
            {
                if(!string.IsNullOrEmpty(Initials))
                {
                    BackgroundColor = _colors[(Initials[0] + Initials[1]) % _colors.Count];
                }
                else
                {
                    BackgroundColor = _colors[new Random().Next(0, _colors.Count - 1)];
                }
            }
        }

        protected override void OnParametersSet()
        {
            base.OnParametersSet();

            if (!string.IsNullOrEmpty(Initials))
            {
                BackgroundColor = _colors[(Initials[0] + Initials[1]) % _colors.Count];
            }
        }
    }
}
