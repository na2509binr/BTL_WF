namespace BTL
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.mnuTitle = new System.Windows.Forms.MenuStrip();
            this.adsadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dgvHome = new System.Windows.Forms.DataGridView();
            this.Sách = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tlMain = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.btnBook = new System.Windows.Forms.ToolStripButton();
            this.btnCategory = new System.Windows.Forms.ToolStripButton();
            this.btnAuthor = new System.Windows.Forms.ToolStripButton();
            this.btnNXB = new System.Windows.Forms.ToolStripButton();
            this.btnLibraryCard = new System.Windows.Forms.ToolStripButton();
            this.btnReader = new System.Windows.Forms.ToolStripButton();
            this.btnBorrowPay = new System.Windows.Forms.ToolStripDropDownButton();
            this.mnuBorrow = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPay = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
            this.mnuTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHome)).BeginInit();
            this.tlMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // mnuTitle
            // 
            this.mnuTitle.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.mnuTitle.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.adsadToolStripMenuItem,
            this.toolStripTextBox1});
            this.mnuTitle.Location = new System.Drawing.Point(0, 0);
            this.mnuTitle.Name = "mnuTitle";
            this.mnuTitle.Padding = new System.Windows.Forms.Padding(6, 2, 10, 2);
            this.mnuTitle.Size = new System.Drawing.Size(599, 45);
            this.mnuTitle.TabIndex = 0;
            this.mnuTitle.Text = "menuStrip1";
            // 
            // adsadToolStripMenuItem
            // 
            this.adsadToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.adsadToolStripMenuItem.ForeColor = System.Drawing.Color.Olive;
            this.adsadToolStripMenuItem.Name = "adsadToolStripMenuItem";
            this.adsadToolStripMenuItem.Size = new System.Drawing.Size(252, 41);
            this.adsadToolStripMenuItem.Text = "Quản Lý Thư Viện";
            // 
            // dgvHome
            // 
            this.dgvHome.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHome.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Sách,
            this.Column1,
            this.Column2,
            this.Column3});
            this.dgvHome.Location = new System.Drawing.Point(152, 48);
            this.dgvHome.Name = "dgvHome";
            this.dgvHome.Size = new System.Drawing.Size(443, 346);
            this.dgvHome.TabIndex = 2;
            // 
            // Sách
            // 
            this.Sách.DataPropertyName = "BookName";
            this.Sách.HeaderText = "Sách";
            this.Sách.Name = "Sách";
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "AuthorName";
            this.Column1.HeaderText = "Tác giả";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "CategoryName";
            this.Column2.HeaderText = "Thể loại";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "PubCompanyName";
            this.Column3.HeaderText = "NXB";
            this.Column3.Name = "Column3";
            // 
            // tlMain
            // 
            this.tlMain.BackColor = System.Drawing.SystemColors.Control;
            this.tlMain.Dock = System.Windows.Forms.DockStyle.Left;
            this.tlMain.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tlMain.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.tlMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator2,
            this.toolStripButton4,
            this.btnBook,
            this.btnCategory,
            this.btnAuthor,
            this.btnNXB,
            this.btnLibraryCard,
            this.btnReader,
            this.btnBorrowPay});
            this.tlMain.Location = new System.Drawing.Point(0, 45);
            this.tlMain.Name = "tlMain";
            this.tlMain.Padding = new System.Windows.Forms.Padding(0);
            this.tlMain.Size = new System.Drawing.Size(149, 352);
            this.tlMain.TabIndex = 4;
            this.tlMain.Text = "toolStrip1";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.BackColor = System.Drawing.SystemColors.Control;
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(148, 6);
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.BackColor = System.Drawing.SystemColors.Control;
            this.toolStripButton4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripButton4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton4.Image")));
            this.toolStripButton4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(148, 36);
            this.toolStripButton4.Text = "Trang chủ";
            // 
            // btnBook
            // 
            this.btnBook.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnBook.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBook.ForeColor = System.Drawing.Color.Yellow;
            this.btnBook.Image = ((System.Drawing.Image)(resources.GetObject("btnBook.Image")));
            this.btnBook.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBook.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnBook.Name = "btnBook";
            this.btnBook.Size = new System.Drawing.Size(148, 36);
            this.btnBook.Text = "Sách";
            this.btnBook.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBook.Click += new System.EventHandler(this.btnBook_Click_1);
            // 
            // btnCategory
            // 
            this.btnCategory.BackColor = System.Drawing.SystemColors.Control;
            this.btnCategory.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCategory.Image = ((System.Drawing.Image)(resources.GetObject("btnCategory.Image")));
            this.btnCategory.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCategory.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCategory.Name = "btnCategory";
            this.btnCategory.Size = new System.Drawing.Size(148, 36);
            this.btnCategory.Text = "Thể loại";
            this.btnCategory.Click += new System.EventHandler(this.btnCategory_Click);
            // 
            // btnAuthor
            // 
            this.btnAuthor.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnAuthor.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAuthor.ForeColor = System.Drawing.Color.Yellow;
            this.btnAuthor.Image = ((System.Drawing.Image)(resources.GetObject("btnAuthor.Image")));
            this.btnAuthor.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAuthor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAuthor.Name = "btnAuthor";
            this.btnAuthor.Size = new System.Drawing.Size(148, 36);
            this.btnAuthor.Text = "Tác giả";
            this.btnAuthor.Click += new System.EventHandler(this.btnAuthor_Click);
            // 
            // btnNXB
            // 
            this.btnNXB.BackColor = System.Drawing.SystemColors.Control;
            this.btnNXB.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNXB.Image = ((System.Drawing.Image)(resources.GetObject("btnNXB.Image")));
            this.btnNXB.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNXB.Name = "btnNXB";
            this.btnNXB.Size = new System.Drawing.Size(148, 36);
            this.btnNXB.Text = "Nhà xuất bản";
            this.btnNXB.Click += new System.EventHandler(this.btnNXB_Click);
            // 
            // btnLibraryCard
            // 
            this.btnLibraryCard.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnLibraryCard.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLibraryCard.ForeColor = System.Drawing.Color.Yellow;
            this.btnLibraryCard.Image = ((System.Drawing.Image)(resources.GetObject("btnLibraryCard.Image")));
            this.btnLibraryCard.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnLibraryCard.Name = "btnLibraryCard";
            this.btnLibraryCard.Size = new System.Drawing.Size(148, 36);
            this.btnLibraryCard.Text = "Thẻ thư viện";
            this.btnLibraryCard.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // btnReader
            // 
            this.btnReader.BackColor = System.Drawing.SystemColors.Control;
            this.btnReader.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnReader.Image = ((System.Drawing.Image)(resources.GetObject("btnReader.Image")));
            this.btnReader.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReader.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnReader.Name = "btnReader";
            this.btnReader.Size = new System.Drawing.Size(148, 36);
            this.btnReader.Text = "Độc giả";
            this.btnReader.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReader.Click += new System.EventHandler(this.btnReader_Click);
            // 
            // btnBorrowPay
            // 
            this.btnBorrowPay.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnBorrowPay.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuBorrow,
            this.mnuPay});
            this.btnBorrowPay.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBorrowPay.ForeColor = System.Drawing.Color.Yellow;
            this.btnBorrowPay.Image = ((System.Drawing.Image)(resources.GetObject("btnBorrowPay.Image")));
            this.btnBorrowPay.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBorrowPay.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnBorrowPay.Name = "btnBorrowPay";
            this.btnBorrowPay.Size = new System.Drawing.Size(148, 36);
            this.btnBorrowPay.Text = "Mượn, Trả";
            // 
            // mnuBorrow
            // 
            this.mnuBorrow.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.mnuBorrow.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mnuBorrow.ForeColor = System.Drawing.Color.Gray;
            this.mnuBorrow.Name = "mnuBorrow";
            this.mnuBorrow.Size = new System.Drawing.Size(115, 22);
            this.mnuBorrow.Text = "Mượn";
            this.mnuBorrow.Click += new System.EventHandler(this.btnBorrow_Click);
            // 
            // mnuPay
            // 
            this.mnuPay.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.mnuPay.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mnuPay.ForeColor = System.Drawing.Color.Gray;
            this.mnuPay.Name = "mnuPay";
            this.mnuPay.Size = new System.Drawing.Size(115, 22);
            this.mnuPay.Text = "Trả";
            this.mnuPay.Click += new System.EventHandler(this.mnuPay_Click);
            // 
            // toolStripTextBox1
            // 
            this.toolStripTextBox1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripTextBox1.Name = "toolStripTextBox1";
            this.toolStripTextBox1.Size = new System.Drawing.Size(100, 41);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(599, 397);
            this.Controls.Add(this.tlMain);
            this.Controls.Add(this.dgvHome);
            this.Controls.Add(this.mnuTitle);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.mnuTitle;
            this.Name = "frmMain";
            this.Text = "Quản lý thư viện";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.mnuTitle.ResumeLayout(false);
            this.mnuTitle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHome)).EndInit();
            this.tlMain.ResumeLayout(false);
            this.tlMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mnuTitle;
        private System.Windows.Forms.ToolStripMenuItem adsadToolStripMenuItem;
        private System.Windows.Forms.DataGridView dgvHome;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sách;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.ToolStrip tlMain;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private System.Windows.Forms.ToolStripButton btnBook;
        private System.Windows.Forms.ToolStripButton btnCategory;
        private System.Windows.Forms.ToolStripButton btnAuthor;
        private System.Windows.Forms.ToolStripButton btnNXB;
        private System.Windows.Forms.ToolStripButton btnReader;
        private System.Windows.Forms.ToolStripButton btnLibraryCard;
        private System.Windows.Forms.ToolStripDropDownButton btnBorrowPay;
        private System.Windows.Forms.ToolStripMenuItem mnuBorrow;
        private System.Windows.Forms.ToolStripMenuItem mnuPay;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox1;
    }
}

