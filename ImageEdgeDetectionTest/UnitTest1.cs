using Microsoft.VisualStudio.TestTools.UnitTesting;
using ImageEdgeDetection;
using System.Drawing;
using System.IO;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Reflection;
using System.Resources;
using ImageEdgeDetectionTest.Properties;

namespace ImageEdgeDetectionTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestSwapMethod()
        {


            //get images from Resources
            Bitmap testImage = ImageEdgeDetectionTest.Properties.Resources.bag;
            Bitmap realResult = ImageEdgeDetectionTest.Properties.Resources.bag_swap;

            //apply filter on test image
            Bitmap result = ExtBitmap.ApplyFilterSwap(testImage);



            //get Hash from images
            String resultImageHash = GetImageHash(result);
            String realResultImageHash = GetImageHash(realResult);


            //comparison
            Assert.AreEqual(resultImageHash, realResultImageHash);
           
        }

        public Bitmap getTestImage(String imageName)
        {
         
            StreamReader streamReader = new StreamReader(imageName);
            Bitmap image = (Bitmap)Image.FromStream(streamReader.BaseStream);
            streamReader.Close();

         return image;
        }


        private string GetImageHash(Bitmap bmpSource)
        {
         List<byte> colorList = new List<byte>();
         string hash;
            
           colorList.Clear();
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
