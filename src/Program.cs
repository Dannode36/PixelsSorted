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
                Console.WriteLine();
            }
        }
    }
}
