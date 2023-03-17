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
    public partial class frmCategory : Form
    {
        bool edit = true;
        public frmCategory()
        {
            InitializeComponent();
        }

        private void frmCategory_Load(object sender, EventArgs e)
        {
            ShowCateogry();
            ShowDetailInput(); 
        }

        private void ShowDetailInput()
        {
            if (dgvCategory.CurrentRow != null)
            {
                var row = dgvCategory.CurrentRow;
                txtCategoryID.Text = row.Cells[0].Value.ToString();
                txtCategoryName.Text = row.Cells[1].Value.ToString();
                txtCategoryID.ReadOnly = true;
                edit = true;
            }
        }

        private void ShowCateogry()
        {
            SqlDataAdapter da = new SqlDataAdapter("select CategoryID, CategoryName from Category", SQLServerConnection.StringConnection);
            DataSet ds = new DataSet();
            da.Fill(ds, "Category");
            dgvCategory.DataSource = ds.Tables["Category"];
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            edit = false;
            txtCategoryID.ReadOnly = false;
            txtCategoryID.Text = txtCategoryName.Text = "";
            txtCategoryID.Focus();

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!edit)
            {
                SqlCommand cmd = SQLServerConnection.Connection.CreateCommand();
                cmd.CommandText = "insert into Category values(@id,@name)";
                cmd.Parameters.AddWithValue("id", txtCategoryID.Text);
                cmd.Parameters.AddWithValue("name", txtCategoryName.Text);
                int row = cmd.ExecuteNonQuery();
                MessageBox.Show("Đã thêm mới thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ShowCateogry();
                ShowDetailInput();
            }
            else
            {
                SqlCommand cmd = SQLServerConnection.Connection.CreateCommand();
                cmd.CommandText = "update Category set categoryname=@name where categoryid=@id";
                cmd.Parameters.AddWithValue("id", txtCategoryID.Text);
                cmd.Parameters.AddWithValue("name", txtCategoryName.Text);
                int row = cmd.ExecuteNonQuery();
                MessageBox.Show("Đã lưu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ShowCateogry();
                ShowDetailInput();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                SqlCommand cmd = SQLServerConnection.Connection.CreateCommand();
                cmd.CommandText = "delete from Category where categoryid=@id";
                cmd.Parameters.AddWithValue("id", txtCategoryID.Text);
                int row = cmd.ExecuteNonQuery();
                MessageBox.Show("Đã xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ShowCateogry();
                ShowDetailInput();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dgvCategory_Click(object sender, EventArgs e)
        {
            ShowDetailInput();
        }
    }
}
