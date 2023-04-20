using System.Drawing.Imaging;
using System.Drawing;
using PixelsSorted.Parsing;

namespace PixelsSorted.Sorters
{
    public class WindowsSorter : Sorter
    {
        public override void Sort(Arguments args)
        {
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

            if (args.sortDirection == SortDirection.Horizontal)
            {
                bitmap.RotateFlip(RotateFlipType.Rotate90FlipNone);
            }

            Color[][] colorArray = new Color[bitmap.Width][];

            //Convert bitmap to jagged array
            for (int i = 0; i < bitmap.Width; i++)
            {
                Color[] slice = new Color[bitmap.Height];
                for (int j = 0; j < bitmap.Height; j++)
                {
                    slice[j] = bitmap.GetPixel(i, j);
                }
                colorArray[i] = slice;
            }

            //Sort slices
            for (int i = 0; i < colorArray.Length; i++)
            {
                Algorithm.QuickSort(colorArray[i], 0, colorArray[i].Length - 1, ref args);
                if(args.sortMode == SortMode.LargestToSmallest)
                {
                    Array.Reverse(colorArray[i]);
                }
            }

            //Write sorted array back into the original bitmap
            for (int i = 0; i < bitmap.Width; i++)
            {
                for (int j = 0; j < bitmap.Height; j++)
                {
                    bitmap.SetPixel(i, j, colorArray[i][j]);
                }
            }

            if (args.sortDirection == SortDirection.Horizontal)
            {
                bitmap.RotateFlip(RotateFlipType.Rotate270FlipNone);
            }

            bitmap.Save(Path.GetFileNameWithoutExtension(args.path) + " (sorted).png", ImageFormat.Png);
            Console.WriteLine("Sorted!");
        }
    }
}
