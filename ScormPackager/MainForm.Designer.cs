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
            this.sectionNameLabel = new System.Windows.Forms.Label();
            this.sectionNameTB = new System.Windows.Forms.TextBox();
            this.pageNameLabel = new System.Windows.Forms.Label();
            this.pageNameTB = new System.Windows.Forms.TextBox();
            this.sectionsGV = new System.Windows.Forms.DataGridView();
            this.pagesGV = new System.Windows.Forms.DataGridView();
            this.Folders = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Numbers = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.referenceButton.Location = new System.Drawing.Point(216, 464);
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
            this.startPackagingButton.Location = new System.Drawing.Point(306, 464);
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
            // courseNameTB
            // 
            this.courseNameTB.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.courseNameTB.CausesValidation = false;
            this.courseNameTB.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.courseNameTB.ForeColor = System.Drawing.Color.Black;
            this.courseNameTB.HideSelection = false;
            this.courseNameTB.Location = new System.Drawing.Point(12, 343);
            this.courseNameTB.Name = "courseNameTB";
            this.courseNameTB.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.courseNameTB.Size = new System.Drawing.Size(377, 23);
            this.courseNameTB.TabIndex = 19;
            // 
            // courseNameLabel
            // 
            this.courseNameLabel.AutoSize = true;
            this.courseNameLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.courseNameLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.courseNameLabel.Location = new System.Drawing.Point(12, 325);
            this.courseNameLabel.Name = "courseNameLabel";
            this.courseNameLabel.Size = new System.Drawing.Size(148, 15);
            this.courseNameLabel.TabIndex = 20;
            this.courseNameLabel.Text = "Введите название курса";
            // 
            // sectionNameLabel
            // 
            this.sectionNameLabel.AutoSize = true;
            this.sectionNameLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sectionNameLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.sectionNameLabel.Location = new System.Drawing.Point(12, 369);
            this.sectionNameLabel.Name = "sectionNameLabel";
            this.sectionNameLabel.Size = new System.Drawing.Size(151, 15);
            this.sectionNameLabel.TabIndex = 22;
            this.sectionNameLabel.Text = "Введите название главы";
            // 
            // sectionNameTB
            // 
            this.sectionNameTB.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.sectionNameTB.CausesValidation = false;
            this.sectionNameTB.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.sectionNameTB.ForeColor = System.Drawing.Color.Black;
            this.sectionNameTB.HideSelection = false;
            this.sectionNameTB.Location = new System.Drawing.Point(12, 387);
            this.sectionNameTB.Name = "sectionNameTB";
            this.sectionNameTB.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.sectionNameTB.Size = new System.Drawing.Size(377, 23);
            this.sectionNameTB.TabIndex = 21;
            // 
            // pageNameLabel
            // 
            this.pageNameLabel.AutoSize = true;
            this.pageNameLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.pageNameLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.pageNameLabel.Location = new System.Drawing.Point(12, 413);
            this.pageNameLabel.Name = "pageNameLabel";
            this.pageNameLabel.Size = new System.Drawing.Size(173, 15);
            this.pageNameLabel.TabIndex = 24;
            this.pageNameLabel.Text = "Введите название страницы";
            // 
            // pageNameTB
            // 
            this.pageNameTB.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.pageNameTB.CausesValidation = false;
            this.pageNameTB.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.pageNameTB.ForeColor = System.Drawing.Color.Black;
            this.pageNameTB.HideSelection = false;
            this.pageNameTB.Location = new System.Drawing.Point(12, 431);
            this.pageNameTB.Name = "pageNameTB";
            this.pageNameTB.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.pageNameTB.Size = new System.Drawing.Size(377, 23);
            this.pageNameTB.TabIndex = 23;
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
            this.sectionsGV.ColumnHeadersVisible = false;
            this.sectionsGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Folders,
            this.Numbers});
            this.sectionsGV.Location = new System.Drawing.Point(12, 56);
            this.sectionsGV.MultiSelect = false;
            this.sectionsGV.Name = "sectionsGV";
            this.sectionsGV.RowHeadersVisible = false;
            this.sectionsGV.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.sectionsGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.sectionsGV.ShowCellErrors = false;
            this.sectionsGV.Size = new System.Drawing.Size(186, 259);
            this.sectionsGV.TabIndex = 27;
            this.sectionsGV.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.sectionsGV_CellContentClick);
            this.sectionsGV.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.sectionsGV_EditingControlShowing);
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
            this.pagesGV.ColumnHeadersVisible = false;
            this.pagesGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2});
            this.pagesGV.Location = new System.Drawing.Point(204, 56);
            this.pagesGV.MultiSelect = false;
            this.pagesGV.Name = "pagesGV";
            this.pagesGV.RowHeadersVisible = false;
            this.pagesGV.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.pagesGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.pagesGV.ShowCellErrors = false;
            this.pagesGV.Size = new System.Drawing.Size(185, 259);
            this.pagesGV.TabIndex = 28;
            this.pagesGV.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.pagesGV_EditingControlShowing);
            // 
            // Folders
            // 
            this.Folders.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Folders.HeaderText = "ColumnFolders2";
            this.Folders.MinimumWidth = 150;
            this.Folders.Name = "Folders";
            this.Folders.ReadOnly = true;
            // 
            // Numbers
            // 
            this.Numbers.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Numbers.HeaderText = "ColumnNum1";
            this.Numbers.MaxInputLength = 3;
            this.Numbers.MinimumWidth = 28;
            this.Numbers.Name = "Numbers";
            this.Numbers.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Numbers.Width = 30;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn1.HeaderText = "ColumnFolders2";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 150;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewTextBoxColumn2.HeaderText = "ColumnNum1";
            this.dataGridViewTextBoxColumn2.MaxInputLength = 3;
            this.dataGridViewTextBoxColumn2.MinimumWidth = 28;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn2.Width = 28;
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(400, 498);
            this.Controls.Add(this.pagesGV);
            this.Controls.Add(this.sectionsGV);
            this.Controls.Add(this.pageNameLabel);
            this.Controls.Add(this.pageNameTB);
            this.Controls.Add(this.sectionNameLabel);
            this.Controls.Add(this.sectionNameTB);
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
        private System.Windows.Forms.Label sectionNameLabel;
        public System.Windows.Forms.TextBox sectionNameTB;
        private System.Windows.Forms.Label pageNameLabel;
        public System.Windows.Forms.TextBox pageNameTB;
        private System.Windows.Forms.DataGridView sectionsGV;
        private System.Windows.Forms.DataGridView pagesGV;
        private System.Windows.Forms.DataGridViewTextBoxColumn Folders;
        private System.Windows.Forms.DataGridViewTextBoxColumn Numbers;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
    }
}