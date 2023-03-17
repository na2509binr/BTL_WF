using BTL.Data_Access;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTL
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            ShowBook();
        }

        public void ShowBook()
        {
            //tạo ra 1 adapter để đọc dữ liệu
            SqlDataAdapter da = new SqlDataAdapter("select BookName, a.AuthorName, c.CategoryName, p.PubCompanyName" +
                " from Book b inner join Author a on b.AuthorID = a.AuthorID inner join Category c on b.CategoryID = c.CategoryID inner join PublishingCompany p on b.PubCompanyID = p.PubCompanyID", SQLServerConnection.StringConnection);
            //tạo dataset để chứa dữ liệu
            DataSet ds = new DataSet();
            //truyền dữ liệu từ adapter sang dataset
            //"Author" là tham số truyền vào Tables dgvHome
            da.Fill(ds, "Book");
            //hiển thị
            dgvHome.DataSource = ds.Tables["Book"];
        }

        private bool CheckFormExist(string name)
        {
            bool flag = false;
            foreach (var f in this.MdiChildren)
            {
                if (f.Text == name)
                {
                    flag = true;
                    break;
                }
            }
            return flag;
        }

        private void btnCategory_Click(object sender, EventArgs e)
        {
            if (!CheckFormExist("frmCategory"))
            {
                frmCategory FrmCategory = new frmCategory();
                FrmCategory.Show();
            }
        }

        private void btnBook_Click_1(object sender, EventArgs e)
        {
            if (!CheckFormExist("frmBook"))
            {
                frmBook FrmBook = new frmBook();
                //dùng để giới hạn lại khu vực hiển thị form con trong form cha
                //FrmBook.MdiParent = this;
                FrmBook.Show();
            }
        }

        private void btnAuthor_Click(object sender, EventArgs e)
        {
            if (!CheckFormExist("frmAuthor"))
            {
                frmAuthor FrmAuthor = new frmAuthor();
                FrmAuthor.Show();
            }
        }

        private void btnReader_Click(object sender, EventArgs e)
        {
            if (!CheckFormExist("frmReader"))
            {
                frmReader frmReader = new frmReader();
                frmReader.Show();
            }
        }

        private void btnBorrowPay_Click(object sender, EventArgs e)
        {
        }

        private void btnNXB_Click(object sender, EventArgs e)
        {
            if (!CheckFormExist("frmPublishingCompany"))
            {
                frmPublishingCompany FrmPublishingCompany = new frmPublishingCompany();
                FrmPublishingCompany.Show();
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (!CheckFormExist("frmLibraryCard"))
            {
                frmLibraryCard FrmLibraryCard = new frmLibraryCard();
                FrmLibraryCard.Show();
            }
        }

        private void btnBorrow_Click(object sender, EventArgs e)
        {
            {
                frmBorrow FrmBorrow = new frmBorrow();
                FrmBorrow.Show();
            }
        }

        private void mnuPay_Click(object sender, EventArgs e)
        {
            {
                frmPay FrmPay = new frmPay();
                FrmPay.Show();
            }
        }
    }
}
