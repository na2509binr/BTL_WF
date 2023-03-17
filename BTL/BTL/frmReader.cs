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
    public partial class frmReader : Form
    {
        bool edit = true;
        public frmReader()
        {
            InitializeComponent();
        }

        private void frmReader_Load(object sender, EventArgs e)
        {
            ShowDetailInput();
            ShowReader();
        }

        private void dgvReader_Click(object sender, EventArgs e)
        {
            ShowDetailInput();
        }

        private void ShowDetailInput()
        {
            if (dgvReader.CurrentRow != null)
            {
                var row = dgvReader.CurrentRow;
                txtReaderID.Text = row.Cells[0].Value.ToString();
                txtReaderName.Text = row.Cells[1].Value.ToString();
                txtAddress.Text = row.Cells[2].Value.ToString();
                txtCardID.Text = row.Cells[3].Value.ToString();
                txtReaderID.ReadOnly = true;
                edit = true;
            }
        }

        private void ShowReader()
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from Reader", SQLServerConnection.StringConnection);
            DataSet ds = new DataSet();
            da.Fill(ds, "Reader");
            dgvReader.DataSource = ds.Tables["Reader"];
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            edit = false;
            txtReaderID.Text = txtReaderName.Text = txtAddress.Text = txtCardID.Text = "";
            txtReaderID.ReadOnly = false;
            txtReaderID.Focus();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!edit)
            {
                SqlCommand cmd = SQLServerConnection.Connection.CreateCommand();
                cmd.CommandText = "insert into Reader values(@rid,@name,@address,@cid)";
                cmd.Parameters.AddWithValue("rid", txtReaderID.Text);
                cmd.Parameters.AddWithValue("name", txtReaderName.Text);
                cmd.Parameters.AddWithValue("address", txtAddress.Text);
                cmd.Parameters.AddWithValue("cid", txtCardID.Text);
                int row = cmd.ExecuteNonQuery();
                MessageBox.Show("Bạn đã thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ShowDetailInput();
                ShowReader();
            }
            else
            {
                SqlCommand cmd = SQLServerConnection.Connection.CreateCommand();
                cmd.CommandText = "update Reader set readername=@name, address=@address, cardid=@cid where readerid=@rid";
                cmd.Parameters.AddWithValue("rid", txtReaderID.Text);
                cmd.Parameters.AddWithValue("name", txtReaderName.Text);
                cmd.Parameters.AddWithValue("address", txtAddress.Text);
                cmd.Parameters.AddWithValue("cid", txtCardID.Text);
                int row = cmd.ExecuteNonQuery();
                MessageBox.Show("Bạn đã ghi thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ShowDetailInput();
                ShowReader();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                SqlCommand cmd = SQLServerConnection.Connection.CreateCommand();
                cmd.CommandText = "delete from Reader where readerid=@rid";
                cmd.Parameters.AddWithValue("rid", txtReaderID.Text);
                int row = cmd.ExecuteNonQuery();
                MessageBox.Show("Bạn đã xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ShowDetailInput();
                ShowReader();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
