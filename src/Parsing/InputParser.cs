namespace PixelsSorted.Parsing
{
    public static class InputParser
    {
        public static Arguments ParseInput(string[] args)
        {
            Arguments arguments;

            if(args.Length == 0)
            {
                arguments = new("")
                {
                    invalid = true
                };
                return arguments;
            }
            else
            {
                arguments = new(args[0]);
            }

            try
            {
                //Start at 1 because path argument is handled above
                for (int i = 1; i < args.Length; i++)
                {
                    switch (args[i])
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
                            throw new ArgumentException($"Unrecognised argument: \"{args[i]}\"");
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
