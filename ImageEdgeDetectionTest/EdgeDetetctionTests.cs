using Microsoft.VisualStudio.TestTools.UnitTesting;
using ImageEdgeDetection;
using System.Drawing;

namespace ImageEdgeDetectionTest
{
    [TestClass]
    public class EdgeDetectionTests
    {
        [TestMethod]
        public void TestLaplacian3x3()
        {
            //get images from Resources
            Bitmap testImage = Properties.Resources.original;
            Bitmap realResult = Properties.Resources.original_laplacian3x3;

            //apply filter on test image
            Bitmap result = ExtBitmap.Laplacian3x3Filter(testImage, false);

            //get Hash from images
            string resultImageHash = TestFunctions.GetImageHash(result);
            string realResultImageHash = TestFunctions.GetImageHash(realResult);

            //comparison
            Assert.AreEqual(resultImageHash, realResultImageHash);

        }

        [TestMethod]
        public void TestSobel3x3()
        {
            //get images from Resources
            Bitmap testImage = Properties.Resources.original;
            Bitmap realResult = Properties.Resources.original_sobel3x3;

            //apply filter on test image
            Bitmap result = ExtBitmap.Sobel3x3Filter(testImage, false);

            //get Hash from images
            string resultImageHash = TestFunctions.GetImageHash(result);
            string realResultImageHash = TestFunctions.GetImageHash(realResult);

            //comparison
            Assert.AreEqual(resultImageHash, realResultImageHash);

        }

        [TestMethod]
        public void TestPrewitt()
        {
            //get images from Resources
            Bitmap testImage = Properties.Resources.original;
            Bitmap realResult = Properties.Resources.original_prewitt;

            //apply filter on test image
            Bitmap result = ExtBitmap.PrewittFilter(testImage, false);

            //get Hash from images
            string resultImageHash = TestFunctions.GetImageHash(result);
            string realResultImageHash = TestFunctions.GetImageHash(realResult);

            //comparison
            Assert.AreEqual(resultImageHash, realResultImageHash);

        }
    }
}
