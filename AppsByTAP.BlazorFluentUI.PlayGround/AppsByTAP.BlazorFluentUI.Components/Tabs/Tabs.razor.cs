﻿using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;

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
        [Parameter]
        public string Class { get; set; }
        [Parameter]
        public string Style { get; set; }
        [Parameter]
        public bool TabContentCanScroll { get; set; }
        [Parameter]
        public int DefaultOpenTab { get; set; }

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

            if(Pages.Count > DefaultOpenTab)
            {
                Tab tab = Pages[DefaultOpenTab];

                if(ActivePage != tab)
                {
                    ActivatePage(tab);
                }
            }
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
