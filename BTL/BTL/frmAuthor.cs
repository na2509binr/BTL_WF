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
    public partial class frmAuthor : Form
    {
        bool edit = true;
        public frmAuthor()
        {
            InitializeComponent();
        }

        private void frmAuthor_Load(object sender, EventArgs e)
        {
            ShowAuthor();
            ShowDetailInput();
        }

        private void dgvAuthor_Click(object sender, EventArgs e)
        {
            ShowDetailInput();
        }

        private void ShowDetailInput()
        {
            if (dgvAuthor.CurrentRow != null)
            {
                var row = dgvAuthor.CurrentRow;
                txtAuthorID.Text = row.Cells[0].Value.ToString();
                txtAuthorName.Text = row.Cells[1].Value.ToString();
                txtNote.Text = row.Cells[2].Value.ToString();
                txtAuthorID.ReadOnly = true;
                edit = true;
            }
        }

        private void ShowAuthor()
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from Author", SQLServerConnection.StringConnection);
            DataSet ds = new DataSet();
            da.Fill(ds, "Author");
            dgvAuthor.DataSource = ds.Tables["Author"];
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            edit = false;
            txtAuthorID.Text = txtAuthorName.Text = txtNote.Text = "";
            txtAuthorID.ReadOnly = false;
            txtAuthorID.Focus();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!edit)
            {
                SqlCommand cmd = SQLServerConnection.Connection.CreateCommand();
                cmd.CommandText = "insert into Author values(@id,@name,@note)";
                cmd.Parameters.AddWithValue("id", txtAuthorID.Text);
                cmd.Parameters.AddWithValue("name", txtAuthorName.Text);
                cmd.Parameters.AddWithValue("note", txtNote.Text);
                int row = cmd.ExecuteNonQuery();
                MessageBox.Show("Bạn đã thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ShowAuthor();
                ShowDetailInput();
            }
            else
            {
                SqlCommand cmd = SQLServerConnection.Connection.CreateCommand();
                cmd.CommandText = "update Author set authorname=@name, note=@note where authorid=@id";
                cmd.Parameters.AddWithValue("id", txtAuthorID.Text);
                cmd.Parameters.AddWithValue("name", txtAuthorName.Text);
                cmd.Parameters.AddWithValue("note", txtNote.Text);
                int row = cmd.ExecuteNonQuery();
                MessageBox.Show("Bạn đã lưu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ShowAuthor();
                ShowDetailInput();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                SqlCommand cmd = SQLServerConnection.Connection.CreateCommand();
                cmd.CommandText = "delete from Author  where authorid=@id";
                cmd.Parameters.AddWithValue("id", txtAuthorID.Text);
                int row = cmd.ExecuteNonQuery();
                MessageBox.Show("Bạn đã xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ShowAuthor();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
