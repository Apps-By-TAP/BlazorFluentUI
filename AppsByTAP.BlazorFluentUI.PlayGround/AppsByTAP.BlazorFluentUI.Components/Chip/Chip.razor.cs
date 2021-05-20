using AppsByTAP.BlazorFluentUI.Components.BaseComponent;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppsByTAP.BlazorFluentUI.Components.Chip
{
    public class ChipViewModel : BaseComponentViewModel
    {
        [Parameter]
        public string Text { get; set; }
        [Parameter]
        public bool ShowRemoval { get; set; }

        [Parameter]
        public EventCallback<MouseEventArgs> OnRemove { get; set; }
        [Parameter]
        public EventCallback<MouseEventArgs> OnEdit { get; set; }

        protected string _textMargin = "0px 12px;";

        protected override void OnInitialized()
        {
            base.OnInitialized();

            if(ShowRemoval)
            {
                _textMargin = "0px 8px 0px 4px;";
            }
        }
    }
}
