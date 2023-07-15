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
    public partial class F_Taikhoan : Form
    {
        public F_Taikhoan()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            F_Nhanvien fnhanvien = new F_Nhanvien();
            fnhanvien.ShowDialog();
        }
    }
}
