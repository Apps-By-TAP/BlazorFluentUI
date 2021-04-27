using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppsByTAP.BlazorFluentUI.Components.BaseComponent
{
    public class BaseComponentViewModel : ComponentBase
    {
        [Parameter]
        public string Style { get; set; }
        [Parameter]
        public string ClassName { get; set; }
    }
}
