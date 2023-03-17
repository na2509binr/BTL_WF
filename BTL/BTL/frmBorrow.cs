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
    public partial class frmBorrow : Form
    {
        bool edit = true;
        public frmBorrow()
        {
            InitializeComponent();
        }

        private void frmBorrowPay_Load(object sender, EventArgs e)
        {
            ShowDetailInput();
            ShowBorrow();
            ShowBook();
        
        }

        private void ShowBook()
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from Book",SQLServerConnection.StringConnection);
            DataSet ds = new DataSet();
            da.Fill(ds, "Book");
            cboBook.DataSource = ds.Tables["Book"];
            cboBook.DisplayMember = "BookName";
            cboBook.ValueMember = "BookID";
        }

        private void dgvBorrow_Click(object sender, EventArgs e)
        {
            ShowDetailInput();
        }

        private void ShowDetailInput()
        {
            if (dgvBorrow.CurrentRow != null)
            {
                var row = dgvBorrow.CurrentRow;
                txtBorrowID.Text = row.Cells[0].Value.ToString();
                txtCardID.Text = row.Cells[1].Value.ToString();
                cboBook.Text = row.Cells[3].Value.ToString();
                txtBorrowID.ReadOnly = true;
                edit = true;
            }
        }

        private void ShowBorrow()
        {
            SqlDataAdapter da = new SqlDataAdapter("select BorrowID, c.CardID, b.BookID, b.BookName, DateBorrow from Borrow br inner join LibraryCard c on br.CardID = c.CardID inner join Book b on br.BookID = b.BookID", SQLServerConnection.StringConnection);
            DataSet ds = new DataSet();
            da.Fill(ds, "Borrow");
            dgvBorrow.DataSource = ds.Tables["Borrow"];
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            edit = false;
            txtCardID.Text = txtBorrowID.Text = "";
            txtBorrowID.ReadOnly = false;
            txtBorrowID.Focus();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!edit)
            {
                SqlCommand cmd = SQLServerConnection.Connection.CreateCommand();
                cmd.CommandText = "insert into Borrow values (@brid,@cid,@bid,@date)";
                cmd.Parameters.AddWithValue("brid", txtBorrowID.Text);
                cmd.Parameters.AddWithValue("cid", txtCardID.Text);
                cmd.Parameters.AddWithValue("bid", cboBook.SelectedValue);
                cmd.Parameters.AddWithValue("date", dtpDateBorrow.Value.Date);
                int row = cmd.ExecuteNonQuery();
                MessageBox.Show("Bạn đã thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ShowBorrow();
                ShowDetailInput();
            }
            else
            {
                SqlCommand cmd = SQLServerConnection.Connection.CreateCommand();
                cmd.CommandText = "update Borrow set cardid=@cid, bookid=@bid, dateborrow=@date where borrowid=@brid";
                cmd.Parameters.AddWithValue("brid", txtBorrowID.Text);
                cmd.Parameters.AddWithValue("cid", txtCardID.Text);
                cmd.Parameters.AddWithValue("bid", cboBook.SelectedValue);
                cmd.Parameters.AddWithValue("date", dtpDateBorrow.Value.Date);
                int row = cmd.ExecuteNonQuery();
                MessageBox.Show("Bạn đã lưu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ShowBorrow();
                ShowDetailInput();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        //private int CheckPay()
        //{
        //    SqlCommand cmd = SQLServerConnection.Connection.CreateCommand();
        //    cmd.CommandText = "select * from Pay where borrowid=@id";
        //    cmd.Parameters.AddWithValue("id", txtBorrowID.Text);
        //    int row = cmd.ExecuteNonQuery();
        //    return row;
        //}

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa hay không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                SqlCommand cmd = SQLServerConnection.Connection.CreateCommand();
                cmd.CommandText = "delete from Borrow where borrowid=@id";
                cmd.Parameters.AddWithValue("id", txtBorrowID.Text);
                int row = cmd.ExecuteNonQuery();
                MessageBox.Show("Bạn đã xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ShowBorrow();
                ShowDetailInput();
            }
            //if (CheckPay() != null)
            //{

            //}
            //else
            //{
            //    MessageBox.Show("Sách chưa được trả!", "Thông báo", MessageBoxButtons.OK,MessageBoxIcon.Warning);
            //}
        }
    }
}
