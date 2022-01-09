namespace USBAudioSort
{
    partial class MainForm
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.TransferButton = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.DirectoryNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreationTimeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastWriteTimeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FullPathColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ToLowerButton = new System.Windows.Forms.Button();
            this.ToUpperButton = new System.Windows.Forms.Button();
            this.SelectDriveButton = new System.Windows.Forms.Button();
            this.ReverseDataGridViewItemsButton = new System.Windows.Forms.Button();
            this.TransferProgressBar = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // TransferButton
            // 
            this.TransferButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TransferButton.Font = new System.Drawing.Font("BIZ UDPゴシック", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TransferButton.Location = new System.Drawing.Point(938, 14);
            this.TransferButton.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.TransferButton.Name = "TransferButton";
            this.TransferButton.Size = new System.Drawing.Size(121, 62);
            this.TransferButton.TabIndex = 0;
            this.TransferButton.Text = "転送開始";
            this.TransferButton.UseVisualStyleBackColor = true;
            this.TransferButton.Click += new System.EventHandler(this.TransferButton_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowDrop = true;
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DirectoryNameColumn,
            this.CreationTimeColumn,
            this.LastWriteTimeColumn,
            this.FullPathColumn});
            this.dataGridView1.Location = new System.Drawing.Point(14, 87);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("BIZ UDPゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.RowTemplate.Height = 21;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1040, 710);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.DragDrop += new System.Windows.Forms.DragEventHandler(this.DataGridView1_DragDrop);
            this.dataGridView1.DragOver += new System.Windows.Forms.DragEventHandler(this.DataGridView1_DragOver);
            this.dataGridView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DataGridView1_KeyDown);
            this.dataGridView1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DataGridView1_MouseDown);
            this.dataGridView1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.DataGridView1_MouseMove);
            // 
            // DirectoryNameColumn
            // 
            this.DirectoryNameColumn.HeaderText = "フォルダ名";
            this.DirectoryNameColumn.Name = "DirectoryNameColumn";
            this.DirectoryNameColumn.ReadOnly = true;
            this.DirectoryNameColumn.Width = 108;
            // 
            // CreationTimeColumn
            // 
            this.CreationTimeColumn.HeaderText = "作成日時";
            this.CreationTimeColumn.Name = "CreationTimeColumn";
            this.CreationTimeColumn.ReadOnly = true;
            this.CreationTimeColumn.Width = 96;
            // 
            // LastWriteTimeColumn
            // 
            this.LastWriteTimeColumn.HeaderText = "更新日時";
            this.LastWriteTimeColumn.Name = "LastWriteTimeColumn";
            this.LastWriteTimeColumn.ReadOnly = true;
            this.LastWriteTimeColumn.Width = 96;
            // 
            // FullPathColumn
            // 
            this.FullPathColumn.HeaderText = "フルパス名";
            this.FullPathColumn.Name = "FullPathColumn";
            this.FullPathColumn.ReadOnly = true;
            this.FullPathColumn.Visible = false;
            // 
            // ToLowerButton
            // 
            this.ToLowerButton.Location = new System.Drawing.Point(379, 24);
            this.ToLowerButton.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.ToLowerButton.Name = "ToLowerButton";
            this.ToLowerButton.Size = new System.Drawing.Size(54, 46);
            this.ToLowerButton.TabIndex = 2;
            this.ToLowerButton.Text = "↓";
            this.ToLowerButton.UseVisualStyleBackColor = true;
            this.ToLowerButton.Click += new System.EventHandler(this.ToLowerButton_Click);
            // 
            // ToUpperButton
            // 
            this.ToUpperButton.Location = new System.Drawing.Point(313, 24);
            this.ToUpperButton.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.ToUpperButton.Name = "ToUpperButton";
            this.ToUpperButton.Size = new System.Drawing.Size(54, 46);
            this.ToUpperButton.TabIndex = 2;
            this.ToUpperButton.Text = "↑";
            this.ToUpperButton.UseVisualStyleBackColor = true;
            this.ToUpperButton.Click += new System.EventHandler(this.ToUpperButton_Click);
            // 
            // SelectDriveButton
            // 
            this.SelectDriveButton.Font = new System.Drawing.Font("BIZ UDPゴシック", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.SelectDriveButton.Location = new System.Drawing.Point(30, 12);
            this.SelectDriveButton.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.SelectDriveButton.Name = "SelectDriveButton";
            this.SelectDriveButton.Size = new System.Drawing.Size(106, 62);
            this.SelectDriveButton.TabIndex = 0;
            this.SelectDriveButton.Text = "ドライブ選択";
            this.SelectDriveButton.UseVisualStyleBackColor = true;
            this.SelectDriveButton.Click += new System.EventHandler(this.SelectDriveButton_Click);
            // 
            // ReverseDataGridViewItemsButton
            // 
            this.ReverseDataGridViewItemsButton.Location = new System.Drawing.Point(503, 30);
            this.ReverseDataGridViewItemsButton.Name = "ReverseDataGridViewItemsButton";
            this.ReverseDataGridViewItemsButton.Size = new System.Drawing.Size(59, 34);
            this.ReverseDataGridViewItemsButton.TabIndex = 3;
            this.ReverseDataGridViewItemsButton.Text = "反転";
            this.ReverseDataGridViewItemsButton.UseVisualStyleBackColor = true;
            this.ReverseDataGridViewItemsButton.Click += new System.EventHandler(this.ReverseDataGridViewItemsButton_Click);
            // 
            // TransferProgressBar
            // 
            this.TransferProgressBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TransferProgressBar.Location = new System.Drawing.Point(704, 41);
            this.TransferProgressBar.Name = "TransferProgressBar";
            this.TransferProgressBar.Size = new System.Drawing.Size(225, 23);
            this.TransferProgressBar.TabIndex = 4;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1069, 804);
            this.Controls.Add(this.TransferProgressBar);
            this.Controls.Add(this.ReverseDataGridViewItemsButton);
            this.Controls.Add(this.ToUpperButton);
            this.Controls.Add(this.ToLowerButton);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.SelectDriveButton);
            this.Controls.Add(this.TransferButton);
            this.Font = new System.Drawing.Font("BIZ UDPゴシック", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.MinimumSize = new System.Drawing.Size(1085, 39);
            this.Name = "MainForm";
            this.Text = "USBAudioSort";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResizeEnd += new System.EventHandler(this.MainForm_ResizeEnd);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button TransferButton;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button ToLowerButton;
        private System.Windows.Forms.Button ToUpperButton;
        private System.Windows.Forms.Button SelectDriveButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn DirectoryNameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreationTimeColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastWriteTimeColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn FullPathColumn;
        private System.Windows.Forms.Button ReverseDataGridViewItemsButton;
        private System.Windows.Forms.ProgressBar TransferProgressBar;
    }
}

