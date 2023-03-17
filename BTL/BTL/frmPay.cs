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
    public partial class frmPay : Form
    {
        public frmPay()
        {
            InitializeComponent();
        }

        private void frmPay_Load(object sender, EventArgs e)
        {
            ShowPay();
            ShowDetailInput();
        }

        private void ShowPay()
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from Pay", SQLServerConnection.StringConnection);
            DataSet ds = new DataSet();
            da.Fill(ds, "Pay");
            dgvPay.DataSource = ds.Tables["Pay"];
        }

        private void ShowDetailInput()
        {
            if (dgvPay.CurrentRow != null)
            {
                var row = dgvPay.CurrentRow;
                txtBorrowID.Text = row.Cells[0].Value.ToString();
                txtNote.Text = row.Cells[1].Value.ToString();
                chkPM.Checked = bool.Parse(row.Cells[2].Value.ToString());
                txtBorrowID.ReadOnly = true;
            }
        }

        private void dgvPay_Click(object sender, EventArgs e)
        {
            ShowDetailInput();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = SQLServerConnection.Connection.CreateCommand();
            cmd.CommandText = "update Pay set note=@note, payment=@payment where borrowid=@id";
            cmd.Parameters.AddWithValue("id", txtBorrowID.Text);
            cmd.Parameters.AddWithValue("note", txtNote.Text);
            cmd.Parameters.AddWithValue("payment", chkPM.Checked);
            int row = cmd.ExecuteNonQuery();
            MessageBox.Show("Bạn đã lưu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ShowPay();
            ShowDetailInput();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (chkPM.Checked == true)
            {
                if (MessageBox.Show("Bạn có muốn xóa hay không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    SqlCommand cmd = SQLServerConnection.Connection.CreateCommand();
                    cmd.CommandText = "delete from Pay where borrowid=@id";
                    cmd.Parameters.AddWithValue("id", txtBorrowID.Text);
                    int row = cmd.ExecuteNonQuery();
                    MessageBox.Show("Bạn đã xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ShowPay();
                    ShowDetailInput();
                }
            }
            else
            {
                MessageBox.Show("Sách vẫn chưa được trả", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }
    }
}
