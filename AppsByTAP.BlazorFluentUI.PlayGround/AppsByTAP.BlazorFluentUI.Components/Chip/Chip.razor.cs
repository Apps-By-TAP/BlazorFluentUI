using AppsByTAP.BlazorFluentUI.Components.BaseComponent;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System;
using System.Threading.Tasks;

namespace AppsByTAP.BlazorFluentUI.Components.Chip
{
    public class ChipViewModel : BaseComponentViewModel
    {
        [Parameter]
        public string ID { get; set; }
        [Parameter]
        public string Text { get; set; }
        [Parameter]
        public ChipType ChipType { get; set; }

        [Parameter]
        public EventCallback<string> OnRemove { get; set; }
        [Parameter]
        public EventCallback<string> OnEdit { get; set; }

        protected bool ShowRemoval;

        protected string _textMargin = "0px 12px;";
        private DateTime _whenRemovalWasClicked;

        protected override void OnInitialized()
        {
            base.OnInitialized();

            if(ChipType == ChipType.Input)
            {
                _textMargin = "0px 8px 0px 4px;";
                ShowRemoval = true;
            }

            if(string.IsNullOrEmpty(ID))
            {
                ID = Guid.NewGuid().ToString();
            }

            _whenRemovalWasClicked = DateTime.Now - new TimeSpan(0,0,10);
        }

        protected async Task Removal(MouseEventArgs args)
        {
            await OnRemove.InvokeAsync(ID);
            _whenRemovalWasClicked = DateTime.Now;
        }

        protected async Task Edit(MouseEventArgs args)
        {
            if((DateTime.Now - _whenRemovalWasClicked).TotalMilliseconds > 100)
            {
                await OnEdit.InvokeAsync(ID);
            }
        }
    }
}
