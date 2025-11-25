using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChochoNest.View
{
    public partial class AdminDashboard : Form
    {
        public AdminDashboard()
        {
            InitializeComponent();
        }

        private void btn_RiwayatTransaksi_Click(object sender, EventArgs e)
        {
            Transaksi tr = new Transaksi();
            tr.Show();
            this.Hide();
        }

        private void btn_Dashboard_Click(object sender, EventArgs e)
        {
            AdminDashboard AD = new AdminDashboard();
            AD.Show();
            this.Hide();
        }

        private void btn_KelolaKatalog_Click(object sender, EventArgs e)
        {
            KelolaKatalog FK = new KelolaKatalog();
            FK.Show(); 
            this.Hide();
        }

        private void AdminDashboard_Load(object sender, EventArgs e)
        {

        }
    }
}
