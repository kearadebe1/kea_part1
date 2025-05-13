using System;
using System.Drawing;
using System.IO;

namespace kea_part1
{
    internal class logo
    {
        public logo()
        {

            //get full location of the project

            string full_location = AppDomain.CurrentDomain.BaseDirectory;

            //replace the bin and debug
            string new_location = full_location.Replace("bin\\Debug\\", "");

            //combining the path
            string full_path = Path.Combine(new_location, "pic.png");

            //then time to use ascii

            //creating the BitMap class
            Bitmap image = new Bitmap(full_path);

            //then set the size
            image = new Bitmap(image, new Size(100, 100));

            //enter the inner loop
            for (int height = 0; height < image.Height; height++)
            {
                for (int width = 0; width < image.Width; width++)
                {
                    Color pixelColor = image.GetPixel(width, height);
                    int grey = (pixelColor.R + pixelColor.G + pixelColor.B) / 3;
                    char asciiChar = grey > 200 ? '.' : grey > 150 ? '*' : grey > 100 ? '0' : grey > 150 ? '#' : '@';
                    Console.Write(asciiChar);


                }

                // end of inner for loop
                Console.WriteLine();
            }
        }
    }
}