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

namespace Form_TourDL
{
    public partial class F_Nhanvien : Form
    {
        string strcon = @"Data Source=MSI\MSIGAMMING;Initial Catalog=""QL_tour Du Lịch"";Integrated Security=True";
        SqlConnection conn;
        SqlCommand cmd;
        public F_Nhanvien()
        {
            InitializeComponent();
        }
        public void Clear_form()
        {
            txtmanv.Clear();
            txttennv.Clear();
            txtemail.Clear();
            txtsdt.Clear();
        }
        public void Hienthi_data()
        {
            conn = new SqlConnection(strcon);
            try
            {
                conn = new SqlConnection(strcon);
                conn.Open();
                string sql_ht = "select * from T_nhanvien";
                SqlDataAdapter da = new SqlDataAdapter(sql_ht, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                TT.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kết nối thông tin lỗi! " + ex);
            }
            conn.Close();
        }
        private void F_Nhanvien_Load(object sender, EventArgs e)
        {
            Hienthi_data();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (txtmanv.Text == "")
            {
                MessageBox.Show("Chưa nhập mã!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                try
                {
                    conn = new SqlConnection(strcon);
                    conn.Open();
                    string sql_dup = "select count(idnhanvien) from T_nhanvien where idnhanvien='" + txtmanv.Text + "'";
                    cmd = new SqlCommand(sql_dup, conn);
                    var dup = Convert.ToInt32(cmd.ExecuteScalar());
                    if (dup > 0)
                    {
                        MessageBox.Show("Mã " + txtmanv.Text + " đã tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        string sql_insert = "insert into T_nhanvien values(N'" + txtmanv.Text + "',N'" + txttennv.Text + "',N'" + datens.Text + "',N'" + txtemail.Text + "',N'" + txtsdt.Text + "',N'" + cb_gt.Text + "')";
                        cmd = new SqlCommand(sql_insert, conn);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Hienthi_data();
                        Clear_form();
                        txtmanv.Focus();
                    }
                    MessageBox.Show("Kết nối thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi kết nối! " + ex);
                }
                conn.Close();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (txtmanv.Text == "")
            {
                MessageBox.Show("Chưa nhập mã cần sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                conn = new SqlConnection(strcon);
                try
                {
                    conn.Open();
                    string sql_update = "Update T_nhanvien set idnhanvien=N'" + txtmanv.Text + "', tennhanvien=N'" + txttennv.Text + "', ngaysinh=N'" + datens.Text + "', email=N'" + txtemail.Text + "', phone=N'" + txtsdt.Text + "', gioitinh=N'" + cb_gt.Text + "' where idnhanvien=N'" + txtan.Text + "'";
                    cmd = new SqlCommand(sql_update, conn);
                    DialogResult msg = MessageBox.Show("Có chắc chắn sửa?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (msg == DialogResult.Yes)
                    {
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Sửa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Hienthi_data();
                        Clear_form();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi thông tin!" + ex, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            conn.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (txtmanv.Text == "")
            {
                MessageBox.Show("Chưa nhập mã cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                try
                {
                    conn.Open();
                    string sql_del = "Delete from T_nhanvien where idnhanvien=N'" + txtmanv.Text + "'";
                    cmd = new SqlCommand(sql_del, conn);
                    DialogResult msg = MessageBox.Show("Có chắc chắn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (msg == DialogResult.Yes)
                    {
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Hienthi_data();
                        Clear_form();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi thông tin!" + ex, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                conn.Close();
            }
        }

        private void TT_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            txtan.Text = TT.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtmanv.Text = TT.Rows[e.RowIndex].Cells[0].Value.ToString();
            txttennv.Text = TT.Rows[e.RowIndex].Cells[1].Value.ToString();
            cb_gt.Text = TT.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtemail.Text = TT.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtsdt.Text = TT.Rows[e.RowIndex].Cells[4].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtkey.Text == "")
            {
                Hienthi_data();
            }
            else
            {
                conn.Open();
                string sql_ser = "select * from T_nhanvien where idnhanvien=N'" + txtkey.Text + "'";
                SqlDataAdapter da = new SqlDataAdapter(sql_ser, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                TT.DataSource = dt;
                txtkey.Clear();
            }
            conn.Close();
        }
    }
}
