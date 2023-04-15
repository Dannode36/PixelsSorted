using ExtensionMethods;
using PixelsSorted.Parser;
using System.Drawing;

namespace PixelsSorted
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var settings = Parser.InputParser.ParseInput(args);
            Sorter sorter;

            if (OperatingSystem.IsWindows())
            {
                sorter = new WindowsSorter();
            }
            else if (OperatingSystem.IsLinux())
            {
                sorter = new();
            }
            else if (OperatingSystem.IsMacOS())
            {
                sorter = new();
            }
            else
            {
                sorter = new();
            }

            while (true)
            {
                settings.invalid = true;
                while (settings.invalid)
                {
                    Console.WriteLine("Input path and any other arguments:");
                    string input = Console.ReadLine() + "";
                    settings = Parser.InputParser.ParseInput(input.Split(" "));
                }
                sorter.Sort(settings);
            }
        }

        public static void QuickSort(Color[] array, int leftIndex, int rightIndex, ref Arguments args)
        {
            var i = leftIndex;
            var j = rightIndex;
            var pivot = array[leftIndex].GetSortingValue(args.sortValue);
            while (i <= j)
            {
                while (array[i].GetSortingValue(args.sortValue) < pivot)
                {
                    i++;
                }

                while (array[j].GetSortingValue(args.sortValue) > pivot)
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
