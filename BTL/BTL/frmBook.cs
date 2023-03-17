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
    public partial class frmBook : Form
    {
        bool edit = true;
        public frmBook()
        {
            InitializeComponent();
        }

        private void frmBook_Load(object sender, EventArgs e)
        {
            ShowBook();
            ShowDetailInput();
            ShowAuthor();
            ShowCategory();
            ShowPublishingCompany();
        }

        public void ShowBook()
        {
            //tạo ra 1 adapter để đọc dữ liệu
            SqlDataAdapter da = new SqlDataAdapter("select BookID, BookName, a.AuthorID, a.AuthorName, c.CategoryID, c.CategoryName, p.PubCompanyID, p.PubCompanyName, PublishingYear" +
    " from Book b inner join Author a on b.AuthorID = a.AuthorID inner join Category c on b.CategoryID = c.CategoryID inner join PublishingCompany p on b.PubCompanyID = p.PubCompanyID", SQLServerConnection.StringConnection);
            //tạo dataset để chứa dữ liệu
            DataSet ds = new DataSet();
            //truyền dữ liệu từ adapter sang dataset
            //"Book" là tham số truyền vào Tables dgvHome
            da.Fill(ds, "Book");
            //hiển thị
            dgvBook.DataSource = ds.Tables["Book"];
        }

        private void ShowAuthor()
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from Author", SQLServerConnection.StringConnection);
            DataSet ds = new DataSet();
            da.Fill(ds, "Author");
            //Display Combobox
            cboAuthor.DataSource = ds.Tables["Author"];
            cboAuthor.DisplayMember = "AuthorName";
            cboAuthor.ValueMember = "AuthorID";
        }

        private void ShowCategory()
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from Category", SQLServerConnection.StringConnection);
            DataSet ds = new DataSet();
            da.Fill(ds, "Category");
            //Display Combobox
            cboCategory.DataSource = ds.Tables["Category"];
            cboCategory.DisplayMember = "CategoryName";
            cboCategory.ValueMember = "CategoryID";
        }

        private void ShowPublishingCompany()
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from PublishingCompany", SQLServerConnection.StringConnection);
            DataSet ds = new DataSet();
            da.Fill(ds, "PublishingCompany");
            //Display Combobox
            cboNXB.DataSource = ds.Tables["PublishingCompany"];
            cboNXB.DisplayMember = "PubCompanyName";
            cboNXB.ValueMember = "PubCompanyID";
        }

        public void ShowDetailInput()
        {
            //CurrentRow là dòng hiện tại đang trỏ tới
            if (dgvBook.CurrentRow != null)
            {
                // đặt biến row là dòng hiện tại đang đk trỏ
                var row = dgvBook.CurrentRow;
                txtBookID.Text = row.Cells[0].Value.ToString();
                txtBookName.Text = row.Cells[1].Value.ToString();
                cboAuthor.SelectedValue = row.Cells[2].Value;
                cboCategory.SelectedValue = row.Cells[4].Value;
                cboNXB.SelectedValue = row.Cells[6].Value;
                txtBookID.ReadOnly = true;
                edit = true;
            }
        }

        private void dgvBook_Click(object sender, EventArgs e)
        {
            ShowDetailInput();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            edit = false;
            txtBookID.ReadOnly = false;
            txtBookID.Text = txtBookName.Text = "";
            txtBookID.Focus();//<?> Tác dụng của Focus?
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //Nếu edit = false thì sẽ insert dữ liệu
            if (!edit)
            {
                SqlCommand cmd = SQLServerConnection.Connection.CreateCommand();
                //tạo câu lệnh sql insert dữ liệu vào bảng Book
                cmd.CommandText = "insert into Book values(@bid,@name,@aid,@cid,@pid,@namxb)";
                //gán giá trị vào các tham số trong câu lệnh insert ở trên
                cmd.Parameters.AddWithValue("bid", txtBookID.Text);
                cmd.Parameters.AddWithValue("name", txtBookName.Text);
                cmd.Parameters.AddWithValue("aid", cboAuthor.SelectedValue);
                cmd.Parameters.AddWithValue("cid", cboCategory.SelectedValue);
                cmd.Parameters.AddWithValue("pid", cboNXB.SelectedValue);
                cmd.Parameters.AddWithValue("namxb", dtpNamXB.Value.Date);
                //Câu lệnh thực thi
                int row = cmd.ExecuteNonQuery();
                //hiển thị box thông báo thành công
                MessageBox.Show("Đã thêm mới thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //cập nhật lại và hiển thị dữ liệu bảng Book 
                ShowBook();
                //hiển thị thông tin chi tiết dữ liệu trường thêm vào form insert
                ShowDetailInput();
            }
            else
            {
                SqlCommand cmd = SQLServerConnection.Connection.CreateCommand();
                cmd.CommandText = "update Book set bookname=@name,authorid=@aid,categoryid=@cid,pubcompanyid=@pid,publishingyear=@namxb where bookid=@bid";
                cmd.Parameters.AddWithValue("bid", txtBookID.Text);
                cmd.Parameters.AddWithValue("name", txtBookName.Text);
                cmd.Parameters.AddWithValue("aid", cboAuthor.SelectedValue);
                cmd.Parameters.AddWithValue("cid", cboCategory.SelectedValue);
                cmd.Parameters.AddWithValue("pid", cboNXB.SelectedValue);
                cmd.Parameters.AddWithValue("namxb", dtpNamXB.Value.Date);
                int row = cmd.ExecuteNonQuery();
                MessageBox.Show("Đã lưu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ShowBook();
                ShowDetailInput();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ShowDetailInput();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //Hiển thị thông báo xóa
            //<?> DialogResult là gì?
            if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                SqlCommand cmd = SQLServerConnection.Connection.CreateCommand();
                cmd.CommandText = "delete from Book where bookid=@id";
                cmd.Parameters.AddWithValue("id", txtBookID.Text);
                int row = cmd.ExecuteNonQuery();
                MessageBox.Show("Đã xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ShowBook();
                ShowDetailInput();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dtpNamXB_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dgvBook_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
