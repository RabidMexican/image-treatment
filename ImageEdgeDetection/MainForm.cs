/*
 * The Following Code was developed by Dewald Esterhuizen
 * View Documentation at: http://softwarebydefault.com
 * Licensed under Ms-PL 
*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Imaging;

namespace ImageEdgeDetection
{
    public partial class MainForm : Form
    {
        private Bitmap originalBitmap = null;
        private Bitmap previewBitmap = null;
        private Bitmap resultBitmap = null;

        private bool blackAndWhite = false;
        private bool colorSwap = false;

        public MainForm()
        {
            InitializeComponent();
            cmbEdgeDetection.SelectedIndex = 0;
        }

        private void TreatImage(bool isPreview)
        {
            Bitmap image;

            if (isPreview) image = previewBitmap;
            else image = originalBitmap;


            image = ApplyFilters(image);
            image = ApplyEdgeDetection(image);

            if (image == null) return;

            if (isPreview) picPreview.Image = image;
            else resultBitmap = image;
        }

        private Bitmap ApplyFilters(Bitmap image)
        {
            if (image != null)
            {
                if (colorSwap) image = image.ApplyRainbowFilter();
                if (blackAndWhite) image = image.ApplyFilterSwap();

                checkBox1.Enabled = true;
                checkBox2.Enabled = true;
            }

   

            return image;
        }

        private Bitmap ApplyEdgeDetection(Bitmap image)
        {
            if (image == null || cmbEdgeDetection.SelectedIndex == -1) return null;

            switch (cmbEdgeDetection.SelectedItem.ToString())
            {
                case "None": break;
                case "Laplacian 3x3": image = image.Laplacian3x3Filter(false); break;
                case "Laplacian 3x3 Grayscale": image = image.Laplacian3x3Filter(true); break;
                case "Laplacian 5x5": image = image.Laplacian5x5Filter(false); break;
                case "Laplacian 5x5 Grayscale": image = image.Laplacian5x5Filter(true); break;
                case "Laplacian of Gaussian": image = image.LaplacianOfGaussianFilter(); break;
                case "Laplacian 3x3 of Gaussian 3x3": image = image.Laplacian3x3OfGaussian3x3Filter(); break;
                case "Laplacian 3x3 of Gaussian 5x5 - 1": image = image.Laplacian3x3OfGaussian5x5Filter1(); break;
                case "Laplacian 3x3 of Gaussian 5x5 - 2": image = image.Laplacian3x3OfGaussian5x5Filter2(); break;
                case "Laplacian 5x5 of Gaussian 3x3": image = image.Laplacian5x5OfGaussian3x3Filter(); break;
                case "Laplacian 5x5 of Gaussian 5x5 - 1": image = image.Laplacian5x5OfGaussian5x5Filter1(); break;
                case "Laplacian 5x5 of Gaussian 5x5 - 2": image = image.Laplacian5x5OfGaussian5x5Filter2(); break;
                case "Sobel 3x3": image = image.Sobel3x3Filter(false); break;
                case "Sobel 3x3 Grayscale": image = image.Sobel3x3Filter(); break;
                case "Prewitt": image = image.PrewittFilter(false); break;
                case "Prewitt Grayscale": image = image.PrewittFilter(); break;
                case "Kirsch": image = image.KirschFilter(false); break;
                case "Kirsch Grayscale": image = image.KirschFilter(); break;
            }
            return image;
        }

        private void Check_BlackAndWhite(object sender, EventArgs e)
        {
            this.blackAndWhite = !this.blackAndWhite;
            checkBox1.Enabled = false;
            checkBox2.Enabled = false;
            TreatImage(true);
        }

        private void Check_ColorSwap(object sender, EventArgs e)
        {
            this.colorSwap = !this.colorSwap;
            checkBox1.Enabled = false;
            checkBox2.Enabled = false;
            TreatImage(true);
        }

        private void OnLoadButtonClick(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Select an image file.";
            ofd.Filter = "Png Images(*.png)|*.png|Jpeg Images(*.jpg)|*.jpg";
            ofd.Filter += "|Bitmap Images(*.bmp)|*.bmp";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                StreamReader streamReader = new StreamReader(ofd.FileName);
                originalBitmap = (Bitmap)Image.FromStream(streamReader.BaseStream);
                streamReader.Close();

                previewBitmap = originalBitmap.CopyToSquareCanvas(picPreview.Width);
                picPreview.Image = previewBitmap;

                cmbEdgeDetection.Enabled = true;
                checkBox1.Enabled = true;
                checkBox2.Enabled = true;
                btnSaveNewImage.Enabled = true;

                TreatImage(true);
            }
        }

        private void OnSaveButtonClick(object sender, EventArgs e)
        {
            TreatImage(false);

            if (resultBitmap != null)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Title = "Specify a file name and file path";
                sfd.Filter = "Png Images(*.png)|*.png|Jpeg Images(*.jpg)|*.jpg";
                sfd.Filter += "|Bitmap Images(*.bmp)|*.bmp";

                if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    string fileExtension = Path.GetExtension(sfd.FileName).ToUpper();
                    ImageFormat imgFormat = ImageFormat.Png;

                    if (fileExtension == "BMP")         imgFormat = ImageFormat.Bmp;
                    else if (fileExtension == "JPG")    imgFormat = ImageFormat.Jpeg;

                    StreamWriter streamWriter = new StreamWriter(sfd.FileName, false);
                    resultBitmap.Save(streamWriter.BaseStream, imgFormat);
                    streamWriter.Flush();
                    streamWriter.Close();

                    resultBitmap = null;
                }
            }
        }

        private void OnEdgeDetectionChange(object sender, EventArgs e)
        {
            TreatImage(true); 
        }

    }
}
