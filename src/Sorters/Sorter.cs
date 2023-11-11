using PixelsSorted.Parsing;

namespace PixelsSorted.Sorters
{
    public class Sorter
    {
        public virtual void Sort(Arguments args)
        {
            Console.WriteLine("Your OS is not supported yet :(");
        }

        public static Sorter CreateOSSpecificSorter()
        {
            if (OperatingSystem.IsWindows())
            {
                return new WindowsSorter();
            }
            else if (OperatingSystem.IsLinux())
            {
                return new();
            }
            else if (OperatingSystem.IsMacOS())
            {
                return new();
            }
            else
            {
                throw new NotSupportedException("Your system is not supported");
            }
        }
    }
}
