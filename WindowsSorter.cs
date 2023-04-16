using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PixelsSorted.Parser;

namespace PixelsSorted
{
    public class WindowsSorter : Sorter
    {
        public override void Sort(Arguments args)
        {
            if (!OperatingSystem.IsWindows())
            {
                Console.WriteLine("Internal Error: Incorrect OS chosen");
                return;
            }

            //Handle invalid paths and just restart the program loop if invalid
            Bitmap org_bitmap;
            try
            {
                org_bitmap = new(args.path);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }

            string filename = Path.GetFileNameWithoutExtension(args.path);

            //Make a copy of the bitmap then disposes the original in order to avoid the "generic error"
            //This happens when you save to a file that is already open
            Bitmap bitmap = new(org_bitmap);
            org_bitmap.Dispose();
            bitmap.Save("Original.png", ImageFormat.Png);

            Console.WriteLine("Sorting...");

            if (args.sortDirection == Parser.SortDirection.Horizontal)
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
                Program.QuickSort(colorArray[i], 0, colorArray[i].Length - 1, ref args);
            }

            //Write sorted array back into the original bitmap
            for (int i = 0; i < bitmap.Width; i++)
            {
                for (int j = 0; j < bitmap.Height; j++)
                {
                    bitmap.SetPixel(i, j, colorArray[i][j]);
                }
            }

            if (args.sortDirection == Parser.SortDirection.Horizontal)
            {
                bitmap.RotateFlip(RotateFlipType.Rotate270FlipNone);
            }

            //Save as png
            bitmap.Save(filename + " (sorted).png", ImageFormat.Png);
            Console.WriteLine("Sorted \n");
        }
    }
}
