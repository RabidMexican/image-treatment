using System;
using System.Collections.Generic;
using System.Drawing;
using System.Security.Cryptography;

namespace ImageEdgeDetectionTest
{
    class Test
    {
        public static string GetImageHash(Bitmap bmpSource)
        {
            List<byte> colorList = new List<byte>();
            string hash;

            int i, j;
            Bitmap bmpMin = new Bitmap(bmpSource, new Size(16, 16)); //create new image with 16x16 pixel
            for (j = 0; j < bmpMin.Height; j++)
            {
                for (i = 0; i < bmpMin.Width; i++)
                {
                    colorList.Add(bmpMin.GetPixel(i, j).R);
                }
            }

            SHA1Managed sha = new SHA1Managed();
            byte[] checksum = sha.ComputeHash(colorList.ToArray());
            hash = BitConverter.ToString(checksum).Replace("-", String.Empty);

            sha.Dispose();
            bmpMin.Dispose();

            return hash;
        }
    }
}
