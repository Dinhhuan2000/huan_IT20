using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Form_TourDL
{
    public partial class F_main : Form
    {
        public F_main()
        {
            InitializeComponent();
        }

        private void F_main_Load(object sender, EventArgs e)
        {
            IsMdiContainer = true;
        }

        private void nhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            F_Nhanvien nhanvien = new F_Nhanvien();
            nhanvien.Show();
            nhanvien .IsMdiContainer = true;
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult msg = MessageBox.Show("Xác nhận đóng?", "Thông báo",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (msg == DialogResult.OK)
            {
                Application.Exit();
            }
        }

        private void tàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            F_Taikhoan ftaikhoan = new F_Taikhoan();
            ftaikhoan.Show();
            ftaikhoan.MdiParent = this;
        }
    }
}
