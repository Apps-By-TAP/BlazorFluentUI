using AppsByTAP.BlazorFluentUI.Components.BaseComponent;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppsByTAP.BlazorFluentUI.Components.Tabs
{
    public partial class Tabs : ComponentBase
    {
        [Parameter]
        public RenderFragment ChildContent { get; set; }
        [Parameter]
        public string Width { get; set; }
        [Parameter]
        public string Height { get; set; } = "100%";

        public event Action SelectionChanged;

        private Tab _activePage;
        public Tab ActivePage 
        { 
            get => _activePage;
            set
            {
                if(_activePage == value) { return; }

                _activePage = value;
                SelectionChanged?.Invoke();
                StateHasChanged();
            }
        }

        public Tab LastTab;

        private List<Tab> Pages = new List<Tab>();

        private double _left;
        private int _indictorPosition;
        private double _percent;

        internal void AddPage(Tab tabPage)
        {
            Pages.Add(tabPage);
            if (Pages.Count == 1)
                ActivePage = tabPage;

            _percent = (1d / (double)Pages.Count) * 100;
            _left = _indictorPosition * _percent;

            StateHasChanged();
        }

        string GetButtonClass(Tab page)
        {
            return page == ActivePage ? "btn-primary" : "btn-secondary";
        }

        void ActivatePage(Tab page)
        {
            LastTab = ActivePage;
            ActivePage = page;

            _indictorPosition = Pages.IndexOf(page);
            _left = _indictorPosition * _percent;
        }
    }
}
