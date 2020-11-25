using Microsoft.VisualStudio.TestTools.UnitTesting;
using ImageEdgeDetection;
using System.Drawing;

namespace ImageEdgeDetectionTest
{
    [TestClass]
    public class FilterTests
    {
        [TestMethod]
        public void TestSwapFilter()
        {
            //get images from Resources
            Bitmap testImage = Properties.Resources.original;
            Bitmap realResult = Properties.Resources.original_swap;

            //apply filter on test image
            Bitmap result = ExtBitmap.ApplySwapFilter(testImage);

            //get Hash from images
            string resultImageHash = TestFunctions.GetImageHash(result);
            string realResultImageHash = TestFunctions.GetImageHash(realResult);

            //comparison
            Assert.AreEqual(resultImageHash, realResultImageHash);

        }

        [TestMethod]
        public void TestRainbowFilter()
        {
            //get images from Resources
            Bitmap testImage = Properties.Resources.original_wide;
            Bitmap realResult = Properties.Resources.original_wide_rainbow;

            //apply filter on test image
            Bitmap result = ExtBitmap.ApplyRainbowFilter(testImage);

            //get Hash from images
            string resultImageHash = TestFunctions.GetImageHash(result);
            string realResultImageHash = TestFunctions.GetImageHash(realResult);

            //comparison
            Assert.AreEqual(resultImageHash, realResultImageHash);
        }
    }
}
