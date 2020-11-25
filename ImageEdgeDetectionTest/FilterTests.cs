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
            Bitmap result = ExtBitmap.ApplyFilterSwap(testImage);

            //get Hash from images
            string resultImageHash = TestFunctions.GetImageHash(result);
            string realResultImageHash = TestFunctions.GetImageHash(realResult);

            //comparison
            Assert.AreEqual(resultImageHash, realResultImageHash);

        }

        public void TestRainbowFilter()
        {

        }
    }
}
