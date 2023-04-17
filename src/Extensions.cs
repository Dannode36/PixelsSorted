using PixelsSorted.Parsing;
using System.Drawing;

namespace ExtensionMethods
{
    public static class Extensions
    {
        public static float GetSortValue(this Color color, SortValue sortValue)
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
