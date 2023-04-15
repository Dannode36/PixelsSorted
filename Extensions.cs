using PixelsSorted.Parser;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionMethods
{
    public static class Extensions
    {
        public static float GetSortingValue(this Color color, SortValue sortValue)
        {
            return sortValue switch
            {
                SortValue.Hue => color.GetHue(),
                SortValue.Saturation => color.GetSaturation(),
                SortValue.Brightness => color.GetBrightness(),
                _ => 0,
            };
        }
    }
}
