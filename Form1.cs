using System;
using System.Drawing;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.OCR;
using Emgu.CV.Util;

namespace Redactor2
{
    public partial class Form1 : Form
    {
        private Image<Bgr, byte> originalImage;  
        private Image<Bgr, byte> processedImage; 
        private VideoCapture videoCapture;
        private Tesseract ocr;
        private CascadeClassifier faceDetector;

        public Form1()
        {
            InitializeComponent();
            string tessdataPath = System.IO.Path.Combine(Application.StartupPath, "Resources", "tessdata");
            string haarcascadePath = System.IO.Path.Combine(Application.StartupPath, "Resources", "frontalface", "haarcascade_frontalface_default.xml");
            // Инициализация Tesseract и каскада Хаара
            ocr = new Tesseract(tessdataPath, "eng", OcrEngineMode.Default);
            faceDetector = new CascadeClassifier(haarcascadePath);
        }

        private void btnLoadImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp",
                Title = "Выберите изображение"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                originalImage = new Image<Bgr, byte>(openFileDialog.FileName);
                processedImage = originalImage.Clone();
                pictureBoxOriginal.Image = originalImage.ToBitmap();
                pictureBoxProcessed.Image = processedImage.ToBitmap();
            }
        }

        private void btnDetectTextRegions_Click(object sender, EventArgs e)
        {
            if (originalImage != null)
            {
                var gray = originalImage.Convert<Gray, byte>();
                var binary = new Mat();
                CvInvoke.Threshold(gray, binary, 0, 255, ThresholdType.Otsu);

                var contours = new VectorOfVectorOfPoint();
                CvInvoke.FindContours(binary, contours, null, RetrType.External, ChainApproxMethod.ChainApproxSimple);

                var resultImage = originalImage.Clone();

                for (int i = 0; i < contours.Size; i++)
                {
                    var rect = CvInvoke.BoundingRectangle(contours[i]);
                    if (rect.Width > 20 && rect.Height > 20) 
                    {
                        CvInvoke.Rectangle(resultImage, rect, new MCvScalar(0, 255, 0), 2); 
                    }
                }

                processedImage = resultImage;
                pictureBoxProcessed.Image = processedImage.ToBitmap();
            }
            else
            {
                MessageBox.Show("Сначала загрузите изображение!");
            }
        }

        private void btnStartVideo_Click(object sender, EventArgs e)
        {
            if (videoCapture == null)
            {
                videoCapture = new VideoCapture();
                Application.Idle += ProcessVideoFrame;
            }
        }

        private void ProcessVideoFrame(object sender, EventArgs e)
        {
            var frame = new Mat();
            videoCapture.Read(frame);

            if (!frame.IsEmpty)
            {
                var grayFrame = new Mat();
                CvInvoke.CvtColor(frame, grayFrame, ColorConversion.Bgr2Gray);

                var faces = faceDetector.DetectMultiScale(grayFrame, 1.1, 4, Size.Empty, Size.Empty);

                foreach (var face in faces)
                {
                    CvInvoke.Rectangle(frame, face, new MCvScalar(255, 0, 0), 2);
                }

                pictureBoxOriginal.Image = frame.ToBitmap();
            }
        }

        private void btnStopVideo_Click(object sender, EventArgs e)
        {
            if (videoCapture != null)
            {
                var frame = new Mat();
                videoCapture.Read(frame);

                if (!frame.IsEmpty)
                {
                    processedImage = frame.ToImage<Bgr, byte>(); 
                    pictureBoxProcessed.Image = processedImage.ToBitmap();
                }

                Application.Idle -= ProcessVideoFrame;
                videoCapture.Dispose();
                videoCapture = null;
            }
        }
        private void btnExtractText_Click(object sender, EventArgs e)
        {
            if (processedImage != null)
            {
                var grayImage = processedImage.Convert<Gray, byte>();
                ocr.SetImage(grayImage);
                ocr.Recognize();
                string text = ocr.GetUTF8Text();
                MessageBox.Show($"Распознанный текст:\n{text}");
            }
            else
            {
                MessageBox.Show("Сначала обработайте изображение!");
            }
        }

        private void btnApplyMask_Click(object sender, EventArgs e)
        {
            if (processedImage != null)
            {
                var grayImage = processedImage.Convert<Gray, byte>();
                var faces = faceDetector.DetectMultiScale(grayImage, 1.1, 4, Size.Empty, Size.Empty);

                foreach (var face in faces)
                {
                    CvInvoke.Rectangle(processedImage, face, new MCvScalar(0, 0, 255), -1); 
                }

                pictureBoxProcessed.Image = processedImage.ToBitmap();
            }
            else
            {
                MessageBox.Show("Сначала обработайте изображение!");
            }
        }

        private void btnSaveImage_Click(object sender, EventArgs e)
        {
            if (processedImage != null)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    Filter = "PNG Image|*.png",
                    Title = "Сохранить обработанное изображение"
                };

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    processedImage.Save(saveFileDialog.FileName);
                    MessageBox.Show("Изображение успешно сохранено!");
                }
            }
            else
            {
                MessageBox.Show("Сначала обработайте изображение!");
            }
        }
    }
}
