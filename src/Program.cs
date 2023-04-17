using PixelsSorted.Sorters;
using PixelsSorted.Parsing;

namespace PixelsSorted
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //When args are present, program will only excecute once
            var settings = InputParser.ParseInput(args);
            Sorter sorter = Sorter.OSSpecificSorter();

            if (!settings.invalid)
            {
                sorter.Sort(settings);
                return;
            }

            //Main program loop
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
