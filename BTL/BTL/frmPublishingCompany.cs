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
    public partial class frmPublishingCompany : Form
    {
        bool edit = true;
        public frmPublishingCompany()
        {
            InitializeComponent();
        }

        private void frmPublishingCompany_Load(object sender, EventArgs e)
        {
            ShowPublishingCompany();
            ShowDetailInput();
        }

        private void dgvPublishingCompany_Click(object sender, EventArgs e)
        {
            ShowDetailInput();
        }

        private void ShowPublishingCompany()
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from PublishingCompany", SQLServerConnection.StringConnection);
            DataSet ds = new DataSet();
            da.Fill(ds, "PublishingCompany");
            dgvPublishingCompany.DataSource = ds.Tables["PublishingCompany"];
        }

        private void ShowDetailInput()
        {
            if (dgvPublishingCompany.CurrentRow != null)
            {
                var row = dgvPublishingCompany.CurrentRow;
                txtPubCompanyID.Text = row.Cells[0].Value.ToString();
                txtPubCompanyName.Text = row.Cells[1].Value.ToString();
                txtEmail.Text = row.Cells[3].Value.ToString();
                txtAddress.Text = row.Cells[2].Value.ToString();
                txtPubCompanyID.ReadOnly = true;
                edit = true;
            }
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            edit = false;
            txtPubCompanyID.Text = txtPubCompanyName.Text = txtEmail.Text = txtAddress.Text = "";
            txtPubCompanyID.ReadOnly = false;
            txtPubCompanyID.Focus();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!edit)
            {
                SqlCommand cmd = SQLServerConnection.Connection.CreateCommand();
                cmd.CommandText = "insert into PublishingCompany values(@id,@name,@address,@email)";
                cmd.Parameters.AddWithValue("id", txtPubCompanyID.Text);
                cmd.Parameters.AddWithValue("name", txtPubCompanyName.Text);
                cmd.Parameters.AddWithValue("email", txtEmail.Text);
                cmd.Parameters.AddWithValue("address", txtAddress.Text);
                int row = cmd.ExecuteNonQuery();
                MessageBox.Show("Bạn đã thêm mới thành công!", "Thông báo", MessageBoxButtons.OK ,MessageBoxIcon.Information);
                ShowDetailInput();
                ShowPublishingCompany();
            }
            else
            {
                SqlCommand cmd = SQLServerConnection.Connection.CreateCommand();
                cmd.CommandText = "update PublishingCompany set pubcompanyname=@name, email=@email, address=@address where pubcompanyid=@id";
                cmd.Parameters.AddWithValue("id", txtPubCompanyID.Text);
                cmd.Parameters.AddWithValue("name", txtPubCompanyName.Text);
                cmd.Parameters.AddWithValue("email", txtEmail.Text);
                cmd.Parameters.AddWithValue("address", txtAddress.Text);
                int row = cmd.ExecuteNonQuery();
                MessageBox.Show("Bạn đã lưu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ShowDetailInput();
                ShowPublishingCompany();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = SQLServerConnection.Connection.CreateCommand();
            cmd.CommandText = "delete from PublishingCompany where pubcompanyid=@id";
            cmd.Parameters.AddWithValue("id", txtPubCompanyID.Text);
            int row = cmd.ExecuteNonQuery();
            MessageBox.Show("Bạn đã xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ShowDetailInput();
            ShowPublishingCompany();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
