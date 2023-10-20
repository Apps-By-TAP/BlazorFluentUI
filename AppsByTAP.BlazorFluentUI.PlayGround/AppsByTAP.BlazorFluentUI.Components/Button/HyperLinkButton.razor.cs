using Microsoft.AspNetCore.Components;

namespace AppsByTAP.BlazorFluentUI.Components.Button
{
    public class HyperLinkButtonViewModel : ButtonBaseParameters
    {
        [Parameter]
        public string Url { get; set; }
        protected string _target;
        private TargetTypes _targetType = TargetTypes.Self;
        [Parameter]
        public TargetTypes TargetType 
        {
            get => _targetType;
            set
            {
                if(_targetType == value) { return; }

                _targetType = value;
                _target = _targetType switch
                {
                    TargetTypes.Blank => "_blank",
                    TargetTypes.Parent => "_parent",
                    TargetTypes.Top => "_top",
                    _ => "_self"
                };
            }
        }
    }

    public enum TargetTypes
    {
        Self, 
        Blank,
        Parent,
        Top
    }
}
