using AppsByTAP.BlazorFluentUI.Components.Theme.Themes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppsByTAP.BlazorFluentUI.Components.Theme.Models
{
    public interface IThemeProvider
    {
        Theme Theme { get; }
        event Action<Theme> ThemeChanged;
        void ChangeTheme(Theme theme);
        Theme CreateTheme(IPalette palette);
    }
}
