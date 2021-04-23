using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppsByTAP.BlazorFluentUI.Components.DropDown
{
    public class DropDownViewModel<T> : ComponentBase
    {
        protected T SelectedItem { get; set; }
        [Parameter]
        public List<T> ItemsSource { get; set; }

        protected bool _displayDropDown = false;

        protected void OpenDropDown()
        {
            _displayDropDown = !_displayDropDown;
        }
    }
}
