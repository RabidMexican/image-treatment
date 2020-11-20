using Microsoft.VisualStudio.TestTools.UnitTesting;
using ImageEdgeDetection;
using System.Drawing;
using System.IO;

namespace ImageEdgeDetectionTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestSwapMethod()
        {
            Bitmap testImage = getTestImage("./images/bag.png");
            Bitmap realResult = getTestImage("./images/bag_swap.png");

            Bitmap result = ExtBitmap.ApplyFilterSwap(testImage);
            Assert.AreEqual(result, realResult);
           
        }

        public Bitmap getTestImage(string imageName)
        {
         /*   ImageEdgeDetectionTest.;
            StreamReader streamReader = new StreamReader();
            Bitmap image = (Bitmap)Image.FromStream(streamReader.BaseStream);
            streamReader.Close();*/

           // return image;
        }

        
    }
}
