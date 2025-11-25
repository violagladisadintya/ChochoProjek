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
    public partial class Pelanggan_Dashboard : Form
    {
        public Pelanggan_Dashboard()
        {
            InitializeComponent();
        }

        private void Pelanggan_Katalog_Load(object sender, EventArgs e)
        {

        }

        private void InitializeComponent()
        {
            SuspendLayout();
            // 
            // Pelanggan_Dashboard
            // 
            ClientSize = new Size(282, 253);
            Name = "Pelanggan_Dashboard";
            Load += Pelanggan_Dashboard_Load;
            ResumeLayout(false);

        }

        private void Pelanggan_Dashboard_Load(object sender, EventArgs e)
        {

        }
    }
}
