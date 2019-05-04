namespace ScormPackager
{
    partial class mainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainForm));
            this.referenceButton = new System.Windows.Forms.Button();
            this.startPackagingButton = new System.Windows.Forms.Button();
            this.courseLabel = new System.Windows.Forms.Label();
            this.browseCourseButton = new System.Windows.Forms.Button();
            this.textBoxSelectFolder = new System.Windows.Forms.TextBox();
            this.startPageLabel = new System.Windows.Forms.Label();
            this.textBoxSelectStartPage = new System.Windows.Forms.TextBox();
            this.browseStartPageButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // referenceButton
            // 
            this.referenceButton.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.referenceButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.referenceButton.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.referenceButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.referenceButton.Location = new System.Drawing.Point(216, 98);
            this.referenceButton.Margin = new System.Windows.Forms.Padding(2);
            this.referenceButton.Name = "referenceButton";
            this.referenceButton.Size = new System.Drawing.Size(84, 23);
            this.referenceButton.TabIndex = 15;
            this.referenceButton.Text = "Справка";
            this.referenceButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.referenceButton.UseVisualStyleBackColor = false;
            this.referenceButton.Click += new System.EventHandler(this.programmReference_Click);
            // 
            // startPackagingButton
            // 
            this.startPackagingButton.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.startPackagingButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.startPackagingButton.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.startPackagingButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.startPackagingButton.Location = new System.Drawing.Point(304, 98);
            this.startPackagingButton.Margin = new System.Windows.Forms.Padding(2);
            this.startPackagingButton.Name = "startPackagingButton";
            this.startPackagingButton.Size = new System.Drawing.Size(84, 23);
            this.startPackagingButton.TabIndex = 14;
            this.startPackagingButton.Text = "Упаковать";
            this.startPackagingButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.startPackagingButton.UseVisualStyleBackColor = false;
            this.startPackagingButton.Click += new System.EventHandler(this.startPackaging_Click);
            // 
            // courseLabel
            // 
            this.courseLabel.AutoSize = true;
            this.courseLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.courseLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.courseLabel.Location = new System.Drawing.Point(12, 10);
            this.courseLabel.Name = "courseLabel";
            this.courseLabel.Size = new System.Drawing.Size(238, 15);
            this.courseLabel.TabIndex = 13;
            this.courseLabel.Text = "Выберите папку с курсом для упаковки";
            // 
            // browseCourseButton
            // 
            this.browseCourseButton.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.browseCourseButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.browseCourseButton.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.browseCourseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.browseCourseButton.Location = new System.Drawing.Point(306, 27);
            this.browseCourseButton.Margin = new System.Windows.Forms.Padding(2);
            this.browseCourseButton.Name = "browseCourseButton";
            this.browseCourseButton.Size = new System.Drawing.Size(83, 23);
            this.browseCourseButton.TabIndex = 12;
            this.browseCourseButton.Text = "Обзор...";
            this.browseCourseButton.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.browseCourseButton.UseVisualStyleBackColor = false;
            this.browseCourseButton.Click += new System.EventHandler(this.browseButton_Click);
            // 
            // textBoxSelectFolder
            // 
            this.textBoxSelectFolder.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.textBoxSelectFolder.CausesValidation = false;
            this.textBoxSelectFolder.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxSelectFolder.ForeColor = System.Drawing.Color.DimGray;
            this.textBoxSelectFolder.Location = new System.Drawing.Point(12, 27);
            this.textBoxSelectFolder.Name = "textBoxSelectFolder";
            this.textBoxSelectFolder.ReadOnly = true;
            this.textBoxSelectFolder.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.textBoxSelectFolder.Size = new System.Drawing.Size(288, 23);
            this.textBoxSelectFolder.TabIndex = 11;
            this.textBoxSelectFolder.Text = "...";
            // 
            // startPageLabel
            // 
            this.startPageLabel.AutoSize = true;
            this.startPageLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.startPageLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.startPageLabel.Location = new System.Drawing.Point(12, 53);
            this.startPageLabel.Name = "startPageLabel";
            this.startPageLabel.Size = new System.Drawing.Size(185, 15);
            this.startPageLabel.TabIndex = 18;
            this.startPageLabel.Text = "Выберите стартовую страницу";
            // 
            // textBoxSelectStartPage
            // 
            this.textBoxSelectStartPage.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.textBoxSelectStartPage.CausesValidation = false;
            this.textBoxSelectStartPage.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxSelectStartPage.ForeColor = System.Drawing.Color.DimGray;
            this.textBoxSelectStartPage.Location = new System.Drawing.Point(12, 71);
            this.textBoxSelectStartPage.Name = "textBoxSelectStartPage";
            this.textBoxSelectStartPage.ReadOnly = true;
            this.textBoxSelectStartPage.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.textBoxSelectStartPage.Size = new System.Drawing.Size(288, 23);
            this.textBoxSelectStartPage.TabIndex = 16;
            this.textBoxSelectStartPage.Text = "...";
            // 
            // browseStartPageButton
            // 
            this.browseStartPageButton.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.browseStartPageButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.browseStartPageButton.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.browseStartPageButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.browseStartPageButton.Location = new System.Drawing.Point(305, 71);
            this.browseStartPageButton.Margin = new System.Windows.Forms.Padding(2);
            this.browseStartPageButton.Name = "browseStartPageButton";
            this.browseStartPageButton.Size = new System.Drawing.Size(83, 23);
            this.browseStartPageButton.TabIndex = 19;
            this.browseStartPageButton.Text = "Обзор...";
            this.browseStartPageButton.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.browseStartPageButton.UseVisualStyleBackColor = false;
            this.browseStartPageButton.Click += new System.EventHandler(this.browseStartPageButton_Click);
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(400, 128);
            this.Controls.Add(this.browseStartPageButton);
            this.Controls.Add(this.startPageLabel);
            this.Controls.Add(this.textBoxSelectStartPage);
            this.Controls.Add(this.referenceButton);
            this.Controls.Add(this.startPackagingButton);
            this.Controls.Add(this.courseLabel);
            this.Controls.Add(this.browseCourseButton);
            this.Controls.Add(this.textBoxSelectFolder);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "mainForm";
            this.Text = "Scorm упаковщик";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button referenceButton;
        private System.Windows.Forms.Button startPackagingButton;
        private System.Windows.Forms.Label courseLabel;
        private System.Windows.Forms.Button browseCourseButton;
        public System.Windows.Forms.TextBox textBoxSelectFolder;
        private System.Windows.Forms.Label startPageLabel;
        public System.Windows.Forms.TextBox textBoxSelectStartPage;
        private System.Windows.Forms.Button browseStartPageButton;
    }
}