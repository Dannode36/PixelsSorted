﻿namespace PixelsSorted.Parsing
{
    public static class InputParser
    {
        public static Arguments ParseInput(string[] args)
        {
            Arguments arguments = new("null");

            if(args.Length == 0)
            {
                arguments.invalid = true;
                return arguments;
            }

            try
            {
                foreach (var arg in args)
                {
                    if (arg == args[0])
                    {
                        arguments.path = arg;
                        continue;
                    }

                    switch (arg)
                    {
                        case "-hue":
                            arguments.sortValue = SortValue.Hue;
                            break;
                        case "-sat":
                            arguments.sortValue = SortValue.Saturation;
                            break;
                        case "-brt":
                            arguments.sortValue = SortValue.Brightness;
                            break;
                        case "-stl":
                            arguments.sortMode = SortMode.SmallestToLargest;
                            break;
                        case "-lts":
                            arguments.sortMode = SortMode.LargestToSmallest;
                            break;
                        case "-v":
                            arguments.sortDirection = SortDirection.Vertical;
                            break;
                        case "-h":
                            arguments.sortDirection = SortDirection.Horizontal;
                            break;
                        default:
                            throw new ArgumentException($"Unrecognised argument: \"{arg}\"");
                    }
                }
            }
            catch (Exception ex)
            {
                arguments.invalid = true;
                Console.WriteLine(ex.Message);
            }

            return arguments;
        }
    }
}