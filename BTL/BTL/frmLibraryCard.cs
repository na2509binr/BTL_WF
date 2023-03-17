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
    public partial class frmLibraryCard : Form
    {
        bool edit = true;
        public frmLibraryCard()
        {
            InitializeComponent();
        }

        private void frmLibraryCard_Load(object sender, EventArgs e)
        {
            ShowLibraryCard();
            ShowDetailInput();
        }

        private void dgvLibraryCard_Click(object sender, EventArgs e)
        {
            ShowDetailInput();
        }

        private void ShowDetailInput()
        {
            if (dgvLibraryCard.CurrentRow != null)
            {
                var row = dgvLibraryCard.CurrentRow;
                txtCardID.Text = row.Cells[0].Value.ToString();
                txtNote.Text = row.Cells[3].Value.ToString();
                txtCardID.ReadOnly = true;
                edit = true;
            }
        }

        private void ShowLibraryCard()
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from LibraryCard", SQLServerConnection.StringConnection);
            DataSet ds = new DataSet();
            da.Fill(ds, "LibraryCard");
            dgvLibraryCard.DataSource = ds.Tables["LibraryCard"];
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            edit = false;
            txtCardID.Text = txtNote.Text = "";
            txtCardID.ReadOnly = false;
            txtCardID.Focus();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!edit)
            {
                SqlCommand cmd = SQLServerConnection.Connection.CreateCommand();
                cmd.CommandText = "insert into LibraryCard values(@id,@datebegin,@dateend,@note)";
                cmd.Parameters.AddWithValue("id", txtCardID.Text);
                cmd.Parameters.AddWithValue("datebegin", dtpBegin.Value.Date);
                cmd.Parameters.AddWithValue("dateend", dtpEnd.Value.Date);
                cmd.Parameters.AddWithValue("note", txtNote.Text);
                int row = cmd.ExecuteNonQuery();
                MessageBox.Show("Đã thêm mới thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ShowDetailInput();
                ShowLibraryCard();
            }
            else
            {
                SqlCommand cmd = SQLServerConnection.Connection.CreateCommand();
                cmd.CommandText = "update LibraryCard set datebegin=@datebegin, dateend=@dateend, note=@note where cardid=@id";
                cmd.Parameters.AddWithValue("id", txtCardID.Text);
                cmd.Parameters.AddWithValue("datebegin", dtpBegin.Value.Date);
                cmd.Parameters.AddWithValue("dateend", dtpEnd.Value.Date);
                cmd.Parameters.AddWithValue("note", txtNote.Text);
                int row = cmd.ExecuteNonQuery();
                MessageBox.Show("Đã lưu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
                ShowDetailInput();
                ShowLibraryCard();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                SqlCommand cmd = SQLServerConnection.Connection.CreateCommand();
                cmd.CommandText = "delete from LibraryCard where cardid= @id";
                cmd.Parameters.AddWithValue("id", txtCardID.Text);
                int row = cmd.ExecuteNonQuery();
                MessageBox.Show("Đã xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ShowDetailInput();
                ShowLibraryCard();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
