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

        public static void QuickSort(Color[] array, int leftIndex, int rightIndex)
        {
            var i = leftIndex;
            var j = rightIndex;
            var pivot = array[leftIndex].GetHue();
            while (i <= j)
            {
                while (array[i].GetHue() < pivot)
                {
                    i++;
                }

                while (array[j].GetHue() > pivot)
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
                QuickSort(array, leftIndex, j);
            if (i < rightIndex)
                QuickSort(array, i, rightIndex);
        }
    }
}
