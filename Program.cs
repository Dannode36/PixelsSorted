using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;

namespace PixelsSorted
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var settings = Parser.InputParser.ParseInput(args);

            while (true)
            {
                settings.invalid = true;
                while (settings.invalid)
                {
                    Console.WriteLine("Input path and any other arguments:");
                    string input = Console.ReadLine() + "";
                    settings = Parser.InputParser.ParseInput(input.Split(" "));
                }
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();

                //Handle invalid paths and just restart the loop if so
                Bitmap org_bitmap;
                try
                {
                    org_bitmap = new(settings.path);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    continue;
                }

                string filename = Path.GetFileNameWithoutExtension(settings.path);

                //Make a copy of the bitmap then disposes the original in order to avoid the "generic error"
                //This happens when you save to a file that is already open
                Bitmap bitmap = new(org_bitmap);
                org_bitmap.Dispose();
                bitmap.Save("Original.png", ImageFormat.Png);

                Console.WriteLine("Sorting...");

                if (settings.sortDirection == Parser.SortDirection.Horizontal)
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

                //Sort Vertically
                for (int i = 0; i < colorArray.Length; i++)
                {
                    QuickSort(colorArray[i], 0, colorArray[i].Length - 1);
                }

                //Write sorted array back into the bitmap
                for (int i = 0; i < bitmap.Width; i++)
                {
                    for (int j = 0; j < bitmap.Height; j++)
                    {
                        bitmap.SetPixel(i, j, colorArray[i][j]);
                    }
                }

                if (settings.sortDirection == Parser.SortDirection.Horizontal)
                {
                    bitmap.RotateFlip(RotateFlipType.Rotate270FlipNone);
                }

                //Save as png
                bitmap.Save(filename + " (sorted).png", ImageFormat.Png);
                Console.WriteLine("Sorted");

                stopwatch.Stop();
                Console.WriteLine("Sorting took {0} ms", stopwatch.ElapsedMilliseconds);
                Console.WriteLine("");
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
