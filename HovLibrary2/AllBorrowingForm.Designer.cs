namespace HovLibrary2
{
    partial class AllBorrowingForm
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.bookStatusComboBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.maxBorrowDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.minBorrowDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.applyButton = new System.Windows.Forms.Button();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.IdColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MemberNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BookTitleColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BookCodeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BorrowDateColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReturnDateColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FineColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReturnColumn = new System.Windows.Forms.DataGridViewButtonColumn();
            this.flowLayoutPanel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.label1);
            this.flowLayoutPanel1.Controls.Add(this.groupBox2);
            this.flowLayoutPanel1.Controls.Add(this.dataGridView);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(16, 16);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(768, 343);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(734, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "All Borrowing";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.flowLayoutPanel3);
            this.groupBox2.Location = new System.Drawing.Point(3, 26);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(762, 137);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Filter";
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.Controls.Add(this.panel3);
            this.flowLayoutPanel3.Controls.Add(this.panel4);
            this.flowLayoutPanel3.Controls.Add(this.applyButton);
            this.flowLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel3.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel3.Location = new System.Drawing.Point(3, 18);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(756, 116);
            this.flowLayoutPanel3.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.bookStatusComboBox);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Location = new System.Drawing.Point(3, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(706, 32);
            this.panel3.TabIndex = 4;
            // 
            // bookStatusComboBox
            // 
            this.bookStatusComboBox.FormattingEnabled = true;
            this.bookStatusComboBox.Location = new System.Drawing.Point(161, 4);
            this.bookStatusComboBox.Name = "bookStatusComboBox";
            this.bookStatusComboBox.Size = new System.Drawing.Size(542, 24);
            this.bookStatusComboBox.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 7);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 16);
            this.label4.TabIndex = 0;
            this.label4.Text = "Book Status";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.label10);
            this.panel4.Controls.Add(this.maxBorrowDateTimePicker);
            this.panel4.Controls.Add(this.minBorrowDateTimePicker);
            this.panel4.Controls.Add(this.label5);
            this.panel4.Location = new System.Drawing.Point(3, 41);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(706, 32);
            this.panel4.TabIndex = 4;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(411, 7);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(30, 16);
            this.label10.TabIndex = 4;
            this.label10.Text = "and";
            // 
            // maxBorrowDateTimePicker
            // 
            this.maxBorrowDateTimePicker.Enabled = false;
            this.maxBorrowDateTimePicker.Location = new System.Drawing.Point(447, 4);
            this.maxBorrowDateTimePicker.Name = "maxBorrowDateTimePicker";
            this.maxBorrowDateTimePicker.Size = new System.Drawing.Size(256, 22);
            this.maxBorrowDateTimePicker.TabIndex = 2;
            // 
            // minBorrowDateTimePicker
            // 
            this.minBorrowDateTimePicker.Enabled = false;
            this.minBorrowDateTimePicker.Location = new System.Drawing.Point(161, 3);
            this.minBorrowDateTimePicker.Name = "minBorrowDateTimePicker";
            this.minBorrowDateTimePicker.Size = new System.Drawing.Size(244, 22);
            this.minBorrowDateTimePicker.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 7);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(144, 16);
            this.label5.TabIndex = 0;
            this.label5.Text = "Borrow Date (Between)";
            // 
            // applyButton
            // 
            this.applyButton.Enabled = false;
            this.applyButton.Location = new System.Drawing.Point(3, 79);
            this.applyButton.Name = "applyButton";
            this.applyButton.Size = new System.Drawing.Size(706, 23);
            this.applyButton.TabIndex = 5;
            this.applyButton.Text = "Apply";
            this.applyButton.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.applyButton.UseVisualStyleBackColor = true;
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdColumn,
            this.MemberNameColumn,
            this.BookTitleColumn,
            this.BookCodeColumn,
            this.BorrowDateColumn,
            this.ReturnDateColumn,
            this.FineColumn,
            this.ReturnColumn});
            this.dataGridView.Location = new System.Drawing.Point(3, 182);
            this.dataGridView.Margin = new System.Windows.Forms.Padding(3, 16, 3, 3);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.RowHeadersWidth = 51;
            this.dataGridView.RowTemplate.Height = 24;
            this.dataGridView.Size = new System.Drawing.Size(762, 150);
            this.dataGridView.TabIndex = 2;
            // 
            // IdColumn
            // 
            this.IdColumn.DataPropertyName = "Id";
            this.IdColumn.HeaderText = "Id";
            this.IdColumn.MinimumWidth = 6;
            this.IdColumn.Name = "IdColumn";
            this.IdColumn.ReadOnly = true;
            this.IdColumn.Width = 125;
            // 
            // MemberNameColumn
            // 
            this.MemberNameColumn.DataPropertyName = "MemberName";
            this.MemberNameColumn.HeaderText = "Member Name";
            this.MemberNameColumn.MinimumWidth = 6;
            this.MemberNameColumn.Name = "MemberNameColumn";
            this.MemberNameColumn.ReadOnly = true;
            this.MemberNameColumn.Width = 125;
            // 
            // BookTitleColumn
            // 
            this.BookTitleColumn.DataPropertyName = "BookTitle";
            this.BookTitleColumn.HeaderText = "Book Title";
            this.BookTitleColumn.MinimumWidth = 6;
            this.BookTitleColumn.Name = "BookTitleColumn";
            this.BookTitleColumn.ReadOnly = true;
            this.BookTitleColumn.Width = 125;
            // 
            // BookCodeColumn
            // 
            this.BookCodeColumn.DataPropertyName = "BookCode";
            this.BookCodeColumn.HeaderText = "Book Code";
            this.BookCodeColumn.MinimumWidth = 6;
            this.BookCodeColumn.Name = "BookCodeColumn";
            this.BookCodeColumn.ReadOnly = true;
            this.BookCodeColumn.Width = 125;
            // 
            // BorrowDateColumn
            // 
            this.BorrowDateColumn.DataPropertyName = "BorrowDate";
            this.BorrowDateColumn.HeaderText = "Borrow Date";
            this.BorrowDateColumn.MinimumWidth = 6;
            this.BorrowDateColumn.Name = "BorrowDateColumn";
            this.BorrowDateColumn.ReadOnly = true;
            this.BorrowDateColumn.Width = 125;
            // 
            // ReturnDateColumn
            // 
            this.ReturnDateColumn.DataPropertyName = "ReturnDate";
            this.ReturnDateColumn.HeaderText = "Return Date";
            this.ReturnDateColumn.MinimumWidth = 6;
            this.ReturnDateColumn.Name = "ReturnDateColumn";
            this.ReturnDateColumn.ReadOnly = true;
            this.ReturnDateColumn.Width = 125;
            // 
            // FineColumn
            // 
            this.FineColumn.DataPropertyName = "Fine";
            this.FineColumn.HeaderText = "Fine";
            this.FineColumn.MinimumWidth = 6;
            this.FineColumn.Name = "FineColumn";
            this.FineColumn.ReadOnly = true;
            this.FineColumn.Width = 125;
            // 
            // ReturnColumn
            // 
            this.ReturnColumn.HeaderText = "";
            this.ReturnColumn.MinimumWidth = 6;
            this.ReturnColumn.Name = "ReturnColumn";
            this.ReturnColumn.ReadOnly = true;
            this.ReturnColumn.Text = "Return";
            this.ReturnColumn.UseColumnTextForButtonValue = true;
            this.ReturnColumn.Width = 125;
            // 
            // AllBorrowingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 375);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "AllBorrowingForm";
            this.Padding = new System.Windows.Forms.Padding(16);
            this.Text = "Form - All Borrowing";
            this.flowLayoutPanel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.flowLayoutPanel3.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ComboBox bookStatusComboBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DateTimePicker maxBorrowDateTimePicker;
        private System.Windows.Forms.DateTimePicker minBorrowDateTimePicker;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button applyButton;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn MemberNameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn BookTitleColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn BookCodeColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn BorrowDateColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReturnDateColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn FineColumn;
        private System.Windows.Forms.DataGridViewButtonColumn ReturnColumn;
    }
}