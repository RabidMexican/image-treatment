using Microsoft.VisualStudio.TestTools.UnitTesting;
using ImageEdgeDetection;
using System.Drawing;
using System.IO;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace ImageEdgeDetectionTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestSwapMethod()
        {
            //get images from Resources
            Bitmap testImage = Properties.Resources.original;
            Bitmap realResult = Properties.Resources.original_swap;

            //apply filter on test image
            Bitmap result = ExtBitmap.ApplyFilterSwap(testImage);

            //get Hash from images
            string resultImageHash = TestFunctions.GetImageHash(result);
            string realResultImageHash = TestFunctions.GetImageHash(realResult);

            //comparison
            Assert.AreEqual(resultImageHash, realResultImageHash);

        }

        public Bitmap getTestImage(string imageName)
        {
            StreamReader streamReader = new StreamReader(imageName);
            Bitmap image = (Bitmap)Image.FromStream(streamReader.BaseStream);
            streamReader.Close();

            return image;
        }
    }
}
