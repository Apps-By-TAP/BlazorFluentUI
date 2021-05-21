using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppsByTAP.BlazorFluentUI.Components.BaseComponent
{
    /// <summary>
    /// This is a hack for layering. Will redo this in time.
    /// </summary>
    public static class LayerCounter
    {
        private static int _layer = 1000000;

        public static int GetLayer() => _layer++;
    }
}
