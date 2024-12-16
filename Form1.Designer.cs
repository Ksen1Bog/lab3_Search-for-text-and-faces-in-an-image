namespace Redactor2
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.btnLoadImage = new System.Windows.Forms.Button();
            this.btnDetectTextRegions = new System.Windows.Forms.Button();
            this.btnExtractText = new System.Windows.Forms.Button();
            this.btnStartVideo = new System.Windows.Forms.Button();
            this.btnStopVideo = new System.Windows.Forms.Button();
            this.btnSaveImage = new System.Windows.Forms.Button();
            this.btnApplyMask = new System.Windows.Forms.Button();
            this.pictureBoxOriginal = new System.Windows.Forms.PictureBox();
            this.pictureBoxProcessed = new System.Windows.Forms.PictureBox();

            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxOriginal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProcessed)).BeginInit();
            this.SuspendLayout();
        
            this.btnLoadImage.Location = new System.Drawing.Point(12, 12);
            this.btnLoadImage.Name = "btnLoadImage";
            this.btnLoadImage.Size = new System.Drawing.Size(150, 30);
            this.btnLoadImage.Text = "Загрузить изображение";
            this.btnLoadImage.UseVisualStyleBackColor = true;
            this.btnLoadImage.Click += new System.EventHandler(this.btnLoadImage_Click);

            this.btnDetectTextRegions.Location = new System.Drawing.Point(12, 48);
            this.btnDetectTextRegions.Name = "btnDetectTextRegions";
            this.btnDetectTextRegions.Size = new System.Drawing.Size(150, 30);
            this.btnDetectTextRegions.Text = "Выделить текст";
            this.btnDetectTextRegions.UseVisualStyleBackColor = true;
            this.btnDetectTextRegions.Click += new System.EventHandler(this.btnDetectTextRegions_Click);

      
            this.btnExtractText.Location = new System.Drawing.Point(12, 84);
            this.btnExtractText.Name = "btnExtractText";
            this.btnExtractText.Size = new System.Drawing.Size(150, 30);
            this.btnExtractText.Text = "Распознать текст";
            this.btnExtractText.UseVisualStyleBackColor = true;
            this.btnExtractText.Click += new System.EventHandler(this.btnExtractText_Click);

            this.btnStartVideo.Location = new System.Drawing.Point(12, 120);
            this.btnStartVideo.Name = "btnStartVideo";
            this.btnStartVideo.Size = new System.Drawing.Size(150, 30);
            this.btnStartVideo.Text = "Запустить видео";
            this.btnStartVideo.UseVisualStyleBackColor = true;
            this.btnStartVideo.Click += new System.EventHandler(this.btnStartVideo_Click);

            this.btnStopVideo.Location = new System.Drawing.Point(12, 156);
            this.btnStopVideo.Name = "btnStopVideo";
            this.btnStopVideo.Size = new System.Drawing.Size(150, 30);
            this.btnStopVideo.Text = "Остановить видео";
            this.btnStopVideo.UseVisualStyleBackColor = true;
            this.btnStopVideo.Click += new System.EventHandler(this.btnStopVideo_Click);

            this.btnSaveImage.Location = new System.Drawing.Point(12, 192);
            this.btnSaveImage.Name = "btnSaveImage";
            this.btnSaveImage.Size = new System.Drawing.Size(150, 30);
            this.btnSaveImage.Text = "Сохранить";
            this.btnSaveImage.UseVisualStyleBackColor = true;
            this.btnSaveImage.Click += new System.EventHandler(this.btnSaveImage_Click);

            this.pictureBoxOriginal.Location = new System.Drawing.Point(200, 12);
            this.pictureBoxOriginal.Name = "pictureBoxOriginal";
            this.pictureBoxOriginal.Size = new System.Drawing.Size(400, 300);
            this.pictureBoxOriginal.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;

            this.pictureBoxProcessed.Location = new System.Drawing.Point(620, 12);
            this.pictureBoxProcessed.Name = "pictureBoxProcessed";
            this.pictureBoxProcessed.Size = new System.Drawing.Size(400, 300);
            this.pictureBoxProcessed.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;

            this.btnApplyMask = new System.Windows.Forms.Button();
            this.btnApplyMask.Location = new System.Drawing.Point(12, 228);
            this.btnApplyMask.Name = "btnApplyMask";
            this.btnApplyMask.Size = new System.Drawing.Size(150, 30);
            this.btnApplyMask.Text = "Наложить маску";
            this.btnApplyMask.UseVisualStyleBackColor = true;
            this.btnApplyMask.Click += new System.EventHandler(this.btnApplyMask_Click);

            this.ClientSize = new System.Drawing.Size(1040, 330);
            this.Controls.Add(this.btnLoadImage);
            this.Controls.Add(this.btnDetectTextRegions);
            this.Controls.Add(this.btnExtractText);
            this.Controls.Add(this.btnStartVideo);
            this.Controls.Add(this.btnStopVideo);
            this.Controls.Add(this.btnSaveImage);
            this.Controls.Add(this.pictureBoxOriginal);
            this.Controls.Add(this.pictureBoxProcessed);
            this.Controls.Add(this.btnApplyMask);
            this.Text = "Обработка изображений";
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Button btnLoadImage;
        private System.Windows.Forms.Button btnDetectTextRegions;
        private System.Windows.Forms.Button btnExtractText;
        private System.Windows.Forms.Button btnStartVideo;
        private System.Windows.Forms.Button btnStopVideo;
        private System.Windows.Forms.Button btnSaveImage;
        private System.Windows.Forms.Button btnApplyMask;
        private System.Windows.Forms.PictureBox pictureBoxOriginal;
        private System.Windows.Forms.PictureBox pictureBoxProcessed;
    }
}
