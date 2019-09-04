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
            this.courseNameTB = new System.Windows.Forms.TextBox();
            this.courseNameLabel = new System.Windows.Forms.Label();
            this.sectionsGV = new System.Windows.Forms.DataGridView();
            this.Folders = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Title = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Numbers = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pagesGV = new System.Windows.Forms.DataGridView();
            this.writeButton = new System.Windows.Forms.Button();
            this.notificationTB = new System.Windows.Forms.TextBox();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnTitle2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TestColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.sectionsGV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pagesGV)).BeginInit();
            this.SuspendLayout();
            // 
            // referenceButton
            // 
            this.referenceButton.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.referenceButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.referenceButton.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.referenceButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.referenceButton.Location = new System.Drawing.Point(306, 366);
            this.referenceButton.Margin = new System.Windows.Forms.Padding(2);
            this.referenceButton.Name = "referenceButton";
            this.referenceButton.Size = new System.Drawing.Size(90, 23);
            this.referenceButton.TabIndex = 15;
            this.referenceButton.Text = "Справка";
            this.referenceButton.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.referenceButton.UseVisualStyleBackColor = false;
            this.referenceButton.Click += new System.EventHandler(this.referenceButton_Click);
            // 
            // startPackagingButton
            // 
            this.startPackagingButton.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.startPackagingButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.startPackagingButton.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.startPackagingButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.startPackagingButton.Location = new System.Drawing.Point(499, 366);
            this.startPackagingButton.Margin = new System.Windows.Forms.Padding(2);
            this.startPackagingButton.Name = "startPackagingButton";
            this.startPackagingButton.Size = new System.Drawing.Size(90, 23);
            this.startPackagingButton.TabIndex = 14;
            this.startPackagingButton.Text = "Упаковать";
            this.startPackagingButton.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.startPackagingButton.UseVisualStyleBackColor = false;
            this.startPackagingButton.Click += new System.EventHandler(this.startPackagingButton_Click);
            // 
            // courseLabel
            // 
            this.courseLabel.AutoSize = true;
            this.courseLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.courseLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.courseLabel.Location = new System.Drawing.Point(12, 10);
            this.courseLabel.Name = "courseLabel";
            this.courseLabel.Size = new System.Drawing.Size(156, 15);
            this.courseLabel.TabIndex = 13;
            this.courseLabel.Text = "Выберите папку с курсом";
            // 
            // browseCourseButton
            // 
            this.browseCourseButton.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.browseCourseButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.browseCourseButton.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.browseCourseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.browseCourseButton.Location = new System.Drawing.Point(499, 27);
            this.browseCourseButton.Margin = new System.Windows.Forms.Padding(2);
            this.browseCourseButton.Name = "browseCourseButton";
            this.browseCourseButton.Size = new System.Drawing.Size(90, 23);
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
            this.textBoxSelectFolder.Size = new System.Drawing.Size(481, 23);
            this.textBoxSelectFolder.TabIndex = 11;
            // 
            // courseNameTB
            // 
            this.courseNameTB.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.courseNameTB.CausesValidation = false;
            this.courseNameTB.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.courseNameTB.ForeColor = System.Drawing.Color.Black;
            this.courseNameTB.HideSelection = false;
            this.courseNameTB.Location = new System.Drawing.Point(12, 71);
            this.courseNameTB.Name = "courseNameTB";
            this.courseNameTB.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.courseNameTB.Size = new System.Drawing.Size(577, 23);
            this.courseNameTB.TabIndex = 19;
            this.courseNameTB.TextChanged += new System.EventHandler(this.courseNameTB_TextChanged);
            // 
            // courseNameLabel
            // 
            this.courseNameLabel.AutoSize = true;
            this.courseNameLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.courseNameLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.courseNameLabel.Location = new System.Drawing.Point(12, 53);
            this.courseNameLabel.Name = "courseNameLabel";
            this.courseNameLabel.Size = new System.Drawing.Size(148, 15);
            this.courseNameLabel.TabIndex = 20;
            this.courseNameLabel.Text = "Введите название курса";
            // 
            // sectionsGV
            // 
            this.sectionsGV.AllowUserToAddRows = false;
            this.sectionsGV.AllowUserToDeleteRows = false;
            this.sectionsGV.AllowUserToResizeColumns = false;
            this.sectionsGV.AllowUserToResizeRows = false;
            this.sectionsGV.BackgroundColor = System.Drawing.SystemColors.Window;
            this.sectionsGV.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.sectionsGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.sectionsGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Folders,
            this.Title,
            this.Numbers});
            this.sectionsGV.Location = new System.Drawing.Point(12, 101);
            this.sectionsGV.MultiSelect = false;
            this.sectionsGV.Name = "sectionsGV";
            this.sectionsGV.RowHeadersVisible = false;
            this.sectionsGV.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.sectionsGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.sectionsGV.ShowCellErrors = false;
            this.sectionsGV.Size = new System.Drawing.Size(288, 258);
            this.sectionsGV.TabIndex = 27;
            this.sectionsGV.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.sectionsGV_CellContentClick);
            this.sectionsGV.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.Num_EditingControlShowing);
            // 
            // Folders
            // 
            this.Folders.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Folders.FillWeight = 1F;
            this.Folders.HeaderText = "Раздел";
            this.Folders.MinimumWidth = 2;
            this.Folders.Name = "Folders";
            this.Folders.ReadOnly = true;
            this.Folders.Width = 69;
            // 
            // Title
            // 
            this.Title.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Title.HeaderText = "Имя раздела";
            this.Title.MinimumWidth = 2;
            this.Title.Name = "Title";
            // 
            // Numbers
            // 
            this.Numbers.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Numbers.HeaderText = "№";
            this.Numbers.MaxInputLength = 3;
            this.Numbers.MinimumWidth = 28;
            this.Numbers.Name = "Numbers";
            this.Numbers.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Numbers.Width = 30;
            // 
            // pagesGV
            // 
            this.pagesGV.AllowUserToAddRows = false;
            this.pagesGV.AllowUserToDeleteRows = false;
            this.pagesGV.AllowUserToResizeColumns = false;
            this.pagesGV.AllowUserToResizeRows = false;
            this.pagesGV.BackgroundColor = System.Drawing.SystemColors.Window;
            this.pagesGV.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.pagesGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.pagesGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.ColumnTitle2,
            this.dataGridViewTextBoxColumn2,
            this.TestColumn});
            this.pagesGV.Location = new System.Drawing.Point(306, 101);
            this.pagesGV.MultiSelect = false;
            this.pagesGV.Name = "pagesGV";
            this.pagesGV.RowHeadersVisible = false;
            this.pagesGV.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.pagesGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.pagesGV.ShowCellErrors = false;
            this.pagesGV.Size = new System.Drawing.Size(283, 258);
            this.pagesGV.TabIndex = 28;
            this.pagesGV.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.Num_EditingControlShowing);
            // 
            // writeButton
            // 
            this.writeButton.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.writeButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.writeButton.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.writeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.writeButton.Location = new System.Drawing.Point(402, 366);
            this.writeButton.Margin = new System.Windows.Forms.Padding(2);
            this.writeButton.Name = "writeButton";
            this.writeButton.Size = new System.Drawing.Size(90, 23);
            this.writeButton.TabIndex = 29;
            this.writeButton.Text = "Записать";
            this.writeButton.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.writeButton.UseVisualStyleBackColor = false;
            this.writeButton.Click += new System.EventHandler(this.writeButton_Click);
            // 
            // notificationTB
            // 
            this.notificationTB.BackColor = System.Drawing.SystemColors.Window;
            this.notificationTB.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.notificationTB.Location = new System.Drawing.Point(12, 370);
            this.notificationTB.MinimumSize = new System.Drawing.Size(288, 23);
            this.notificationTB.Name = "notificationTB";
            this.notificationTB.ReadOnly = true;
            this.notificationTB.Size = new System.Drawing.Size(288, 16);
            this.notificationTB.TabIndex = 30;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn1.HeaderText = "Страница";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 30;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // ColumnTitle2
            // 
            this.ColumnTitle2.HeaderText = "Название страницы";
            this.ColumnTitle2.MinimumWidth = 150;
            this.ColumnTitle2.Name = "ColumnTitle2";
            this.ColumnTitle2.Width = 150;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewTextBoxColumn2.HeaderText = "№";
            this.dataGridViewTextBoxColumn2.MaxInputLength = 3;
            this.dataGridViewTextBoxColumn2.MinimumWidth = 28;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn2.Width = 28;
            // 
            // TestColumn
            // 
            this.TestColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.TestColumn.HeaderText = "?";
            this.TestColumn.Name = "TestColumn";
            this.TestColumn.Width = 28;
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(601, 398);
            this.Controls.Add(this.notificationTB);
            this.Controls.Add(this.writeButton);
            this.Controls.Add(this.pagesGV);
            this.Controls.Add(this.sectionsGV);
            this.Controls.Add(this.courseNameLabel);
            this.Controls.Add(this.courseNameTB);
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
            this.Text = "Scorm 1.2 упаковщик";
            ((System.ComponentModel.ISupportInitialize)(this.sectionsGV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pagesGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button referenceButton;
        private System.Windows.Forms.Button startPackagingButton;
        private System.Windows.Forms.Label courseLabel;
        private System.Windows.Forms.Button browseCourseButton;
        public System.Windows.Forms.TextBox textBoxSelectFolder;
        public System.Windows.Forms.TextBox courseNameTB;
        private System.Windows.Forms.Label courseNameLabel;
        private System.Windows.Forms.DataGridView sectionsGV;
        private System.Windows.Forms.DataGridView pagesGV;
        private System.Windows.Forms.DataGridViewTextBoxColumn Folders;
        private System.Windows.Forms.DataGridViewTextBoxColumn Title;
        private System.Windows.Forms.DataGridViewTextBoxColumn Numbers;
        private System.Windows.Forms.Button writeButton;
        private System.Windows.Forms.TextBox notificationTB;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTitle2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewCheckBoxColumn TestColumn;
    }
}