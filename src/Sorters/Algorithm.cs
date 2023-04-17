using ExtensionMethods;
using PixelsSorted.Parser;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PixelsSorted.Sorters
{
    public static class Algorithm
    {
        public static void QuickSort(Color[] array, int leftIndex, int rightIndex, ref Arguments args)
        {
            var i = leftIndex;
            var j = rightIndex;
            var pivot = array[leftIndex].GetSortValue(args.sortValue);
            while (i <= j)
            {
                while (array[i].GetSortValue(args.sortValue) < pivot)
                {
                    i++;
                }

                while (array[j].GetSortValue(args.sortValue) > pivot)
                {
                    j--;
                }
                if (i <= j)
                {
                    (array[j], array[i]) = (array[i], array[j]);
                    i++;
                    j--;
                }
            }

            if (leftIndex < j)
                QuickSort(array, leftIndex, j, ref args);
            if (i < rightIndex)
                QuickSort(array, i, rightIndex, ref args);
        }
    }
}
