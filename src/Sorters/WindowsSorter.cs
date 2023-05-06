using System.Drawing.Imaging;
using System.Drawing;
using PixelsSorted.Parsing;

namespace PixelsSorted.Sorters
{
    public class WindowsSorter : Sorter
    {
        public override void Sort(Arguments args)
        {
            //Mostly to remove some stupid warnings
            if (!OperatingSystem.IsWindows())
            {
                Console.WriteLine("Internal Error: Sorter does not support chosen OS");
                return;
            }

            //Handle invalid paths and just restart the program loop if invalid
            Bitmap bitmap;
            try
            {
                bitmap = new(args.path);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }

            //Yay sorting time!
            Console.WriteLine("Sorting...");

            //Rotating image = easy hack for sorting horizontally
            if (args.sortDirection == SortDirection.Horizontal)
            {
                bitmap.RotateFlip(RotateFlipType.Rotate90FlipNone);
            }

            Color[][] colorArray = new Color[bitmap.Width][];

            //Convert bitmap into a jagged array of "colour slices"
            for (int i = 0; i < bitmap.Width; i++)
            {
                Color[] slice = new Color[bitmap.Height];
                for (int j = 0; j < bitmap.Height; j++)
                {
                    slice[j] = bitmap.GetPixel(i, j);
                }
                colorArray[i] = slice;
            }

            //Sort the slices
            for (int i = 0; i < colorArray.Length; i++)
            {
                Algorithm.QuickSort(colorArray[i], 0, colorArray[i].Length - 1, ref args);
                if(args.sortMode == SortOrder.LargestToSmallest)
                {
                    Array.Reverse(colorArray[i]);
                }
            }

            //Write sorted array back into the bitmap
            for (int i = 0; i < bitmap.Width; i++)
            {
                for (int j = 0; j < bitmap.Height; j++)
                {
                    bitmap.SetPixel(i, j, colorArray[i][j]);
                }
            }

            //Rotate image back if it was rotated before
            if (args.sortDirection == SortDirection.Horizontal)
            {
                bitmap.RotateFlip(RotateFlipType.Rotate270FlipNone);
            }

            //Save to the root directory (should let user choose where it saves)
            bitmap.Save(Path.GetFileNameWithoutExtension(args.path) + " (sorted).png", ImageFormat.Png);
            Console.WriteLine("Sorted!");
        }
    }
}
