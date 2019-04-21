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
            this.label = new System.Windows.Forms.Label();
            this.browseButton = new System.Windows.Forms.Button();
            this.textBoxSelectFolder = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // referenceButton
            // 
            this.referenceButton.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.referenceButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.referenceButton.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.referenceButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.referenceButton.Location = new System.Drawing.Point(216, 55);
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
            this.startPackagingButton.Location = new System.Drawing.Point(305, 55);
            this.startPackagingButton.Margin = new System.Windows.Forms.Padding(2);
            this.startPackagingButton.Name = "startPackagingButton";
            this.startPackagingButton.Size = new System.Drawing.Size(84, 23);
            this.startPackagingButton.TabIndex = 14;
            this.startPackagingButton.Text = "Упаковать";
            this.startPackagingButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.startPackagingButton.UseVisualStyleBackColor = false;
            this.startPackagingButton.Click += new System.EventHandler(this.startPackaging_Click);
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label.Location = new System.Drawing.Point(12, 10);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(238, 15);
            this.label.TabIndex = 13;
            this.label.Text = "Выберите папку с курсом для упаковки";
            // 
            // browseButton
            // 
            this.browseButton.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.browseButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.browseButton.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.browseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.browseButton.Location = new System.Drawing.Point(305, 27);
            this.browseButton.Margin = new System.Windows.Forms.Padding(2);
            this.browseButton.Name = "browseButton";
            this.browseButton.Size = new System.Drawing.Size(83, 23);
            this.browseButton.TabIndex = 12;
            this.browseButton.Text = "Обзор...";
            this.browseButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.browseButton.UseVisualStyleBackColor = false;
            this.browseButton.Click += new System.EventHandler(this.browseButton_Click);
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
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(400, 88);
            this.Controls.Add(this.referenceButton);
            this.Controls.Add(this.startPackagingButton);
            this.Controls.Add(this.label);
            this.Controls.Add(this.browseButton);
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
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.Button browseButton;
        public System.Windows.Forms.TextBox textBoxSelectFolder;
    }
}