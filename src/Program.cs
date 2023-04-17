using ExtensionMethods;
using PixelsSorted.Parser;
using PixelsSorted.Sorters;
using System.Drawing;

namespace PixelsSorted
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var settings = InputParser.ParseInput(args);
            Sorter sorter = Sorter.OSSpecificSorter();

            while (true)
            {
                settings.invalid = true;
                while (settings.invalid)
                {
                    Console.WriteLine("Input path and any other arguments:");
                    string input = Console.ReadLine() + "";
                    settings = InputParser.ParseInput(input.Split(" "));
                }
                sorter.Sort(settings);
            }
        }

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
                    Color temp = array[i];
                    array[i] = array[j];
                    array[j] = temp;
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
